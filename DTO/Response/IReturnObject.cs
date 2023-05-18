namespace DTO.Response
{
    public interface IReturnObject<T> where T : class
    {
        T? data { get; set; }
        bool IsSuccess { get; }
        int returnCode { get; set; }
        string? returnMessage { get; set; }

        void setError(int errorReturnCode = -1, string errorReturnMessage = "error");
        void setError(string errorReturnMessage = "error", int errorReturnCode = -1);
        void setSuccess(T? returnDataValue = null);
    }
}