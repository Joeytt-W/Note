namespace CodeMan.Redis.Service.Repository
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
    }
}