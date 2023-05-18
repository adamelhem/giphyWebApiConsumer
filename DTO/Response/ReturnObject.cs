namespace DTO.Response
{
    public class ReturnObject<T> : IReturnObject<T> where T : class
    {
        // success = 0 , any other value is fail
        public bool IsSuccess => returnCode == 0;
        public int returnCode { get; set; }
        public string? returnMessage { get; set; }
        public T? data { get; set; }

        public void setSuccess(T? returnDataValue = null)
        {
            data = returnDataValue;
        }

        public void setError(string errorReturnMessage = "error", int errorReturnCode = -1)
        {
            returnMessage = errorReturnMessage;
            returnCode = errorReturnCode;
        }

        public void setError(int errorReturnCode = -1, string errorReturnMessage = "error")
        {
            returnMessage = errorReturnMessage;
            returnCode = errorReturnCode;
        }

    }
}
