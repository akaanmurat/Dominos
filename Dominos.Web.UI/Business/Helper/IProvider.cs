namespace Dominos.Web.UI.Business.Helper
{
    public interface IProvider<T> where T : class, new()
    {
        void Execute(T model);
    }
}