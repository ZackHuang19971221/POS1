using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace API.Controllers
{
    [ApiExplorerSettings(GroupName = "Common")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WebSocketController : ControllerBase
    {
        private static readonly ConcurrentBag<WebSocket> WebSockets = new ConcurrentBag<WebSocket>();

        [HttpGet]
        public async Task Subscribe()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                WebSockets.Add(webSocket);
                await ReceiveMessages(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private static async Task ReceiveMessages(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            WebSockets.TryTake(out _);
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public static async Task NotifyClients(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);

            foreach (var webSocket in WebSockets)
            {
                if (webSocket.State == WebSocketState.Open)
                {
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
