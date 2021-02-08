namespace CleanCodeTp.Application
{
    public interface IAuthorizedAction
    {
        public bool IsAuthorized(string username);
    }
}