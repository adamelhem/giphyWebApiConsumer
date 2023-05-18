using DO.Request;

namespace DataAccessLayer
{
    public interface IWebAPIhandler
    {
        Task<T> GetAPIdataResponse<T>(IGiphyRequest urlRequest);
    }
}