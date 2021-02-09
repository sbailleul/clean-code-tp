namespace CleanCodeTp.Domain.Users
{
    public record UserIdentifier
    {
        public UserIdentifier(string? identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; }

        public virtual bool Equals(UserIdentifier? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Identifier == other.Identifier;
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }
    }
}