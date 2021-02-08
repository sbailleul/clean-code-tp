namespace CleanCodeTp.Domain.Users
{
    public class Librarian : IUser
    {
        public Librarian(UserIdentifier identifier)
        {
            Identifier = identifier;
        }

        public UserType Type => new UserType(nameof(Librarian));
        public UserIdentifier Identifier { get; }
        
        
    }
}