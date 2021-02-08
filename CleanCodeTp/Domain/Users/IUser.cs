namespace CleanCodeTp.Domain.Users
{
    public interface IUser
    {
        public UserType Type { get; }
        public UserIdentifier Identifier { get; }
    }
}