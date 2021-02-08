namespace CleanCodeTp.Domain.Users
{
    public class Guest: IUser   
    {
        public Guest(UserIdentifier identifier)
        {
            Identifier = identifier;
        }

        public UserType Type => new UserType(nameof(Guest));
        public UserIdentifier Identifier { get; }
        
        protected bool Equals(Guest other)
        {
            return Identifier.Equals(other.Identifier);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Guest) obj);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }
    }
}