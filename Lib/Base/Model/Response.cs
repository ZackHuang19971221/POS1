namespace Base.Model
{
    public class Response<T>
    {
        public Response(ResultType resultCode, string message, T data)
        {
            ResultCode = resultCode;
            Message = message;
            Data = data;
        }
        public enum ResultType
        {
            Error = 1000,
            Fail = 9999,
            Success = 0000,
        }
        public ResultType ResultCode { get;}
        public string Message { get;}
        public T Data { get;}
    }
}
