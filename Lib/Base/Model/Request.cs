namespace Base.Model
{
    public class Request
    {
        public Request(string requestId) {
            RequestId = requestId;
        }
        public string RequestId { get; }
    }
}
