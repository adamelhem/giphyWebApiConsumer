namespace DTO.Response
{
    public class ReturnObject<T> : IReturnObject<T> where T : class
    {
        // success = 0 , any other value is fail
        public bool IsSuccess => returnCode == 0;
        public int returnCode { get; set; }
        public string? returnMessage { get; set; }
        public T? data { get; set; }

        public IReturnObject<T> setSuccess(T? returnDataValue = null)
        {
            data = returnDataValue;
            return this;
        }

        public IReturnObject<T> setError()
        {
            returnMessage = "error";
            returnCode = -1;
            return this;
        }

        public IReturnObject<T> setError(string errorReturnMessage = "error", int errorReturnCode = -1)
        {
            returnMessage = errorReturnMessage;
            returnCode = errorReturnCode;
            return this;
        }

        public IReturnObject<T> setError(int errorReturnCode = -1, string errorReturnMessage = "error")
        {
            returnMessage = errorReturnMessage;
            returnCode = errorReturnCode;
            return this;
        }

    }
}
