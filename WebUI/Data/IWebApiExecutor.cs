
namespace WebUI.Data
{
    public interface IWebApiExecutor
    {
        Task<T?> InvokePost<T>(string relativeApi, T obj);
    }
}