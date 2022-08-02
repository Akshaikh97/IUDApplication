namespace IUDApplication.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}