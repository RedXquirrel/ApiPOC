namespace MyApi.ResponseTypes
{
    public class RestServiceResponse
    {
        public bool Success { get; set; }
        public object Response { get; set; }
        public string Message { get; set; }
    }
}