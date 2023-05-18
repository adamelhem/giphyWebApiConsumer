namespace DTO.Response
{
    public interface IReturnObject<T> where T : class
    {
        T? data { get; set; }
        bool IsSuccess { get; }
        int returnCode { get; set; }
        string? returnMessage { get; set; }

        IReturnObject<T> setError();
        IReturnObject<T> setError(int errorReturnCode = -1, string errorReturnMessage = "error");
        IReturnObject<T> setError(string errorReturnMessage = "error", int errorReturnCode = -1);
        IReturnObject<T> setSuccess(T? returnDataValue = null);
    }
}