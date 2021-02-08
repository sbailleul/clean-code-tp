namespace CleanCodeTp.Domain.Users
{
    public record UserType
    {
        public UserType(string typeName)
        {
            TypeName = typeName;
        }

        public string TypeName { get; }

        public virtual bool Equals(UserType? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TypeName == other.TypeName;
        }

        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }
    }
}