namespace Monopoly.Models
{
    internal class FieldInfo
    {
        public static FieldInfo EmptyField = new FieldInfo(string.Empty, FieldType.EMPTY);

        public FieldInfo(string name, FieldType type)
        {
            Name = name;
            Type = type;

            Owner = PlayerInfo.EmptyPlayer;
        }

        public string Name { get; }

        public FieldType Type { get; }

        public int Price => Type.GetPrice();

        public int Rent => Type.GetRent();

        public PlayerInfo Owner { get; set; }

        public bool IsFree => Owner == PlayerInfo.EmptyPlayer;

        public override bool Equals(object obj)
        {
            return obj is FieldInfo other && Equals(other);
        }

        private bool Equals(FieldInfo other)
        {
            return Name.Equals(other.Name)
                && Type.Equals(other.Type)
                && Owner.Equals(other.Owner);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Type.GetHashCode() + Owner.GetHashCode();
        }
    }
}
