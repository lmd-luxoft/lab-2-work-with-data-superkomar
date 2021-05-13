using Monopoly.Models.FieldTypes;

namespace Monopoly.Models
{
    internal class FieldInfo
    {
        public static FieldInfo EmptyField = new FieldInfo(string.Empty, FieldType.EMPTY);

        private readonly FieldTypeBase _fieldTypeBase;

        public FieldInfo(string name, FieldType type)
        {
            Name = name;
            Type = type;

            Owner = PlayerInfo.EmptyPlayer;
            _fieldTypeBase = FieldTypeBase.Construct(Type);
        }

        public string Name { get; }

        public FieldType Type { get; }

        public PlayerInfo Owner { get; set; }
        
        public int Price => _fieldTypeBase.Price;
        
        public int Rent => _fieldTypeBase.Rent;

        public bool IsPossibleToBuy => _fieldTypeBase.IsPossibleToBuy;
        
        public bool IsFree => Owner == PlayerInfo.EmptyPlayer;
        
        public override bool Equals(object obj)
        {
            return obj is FieldInfo other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + _fieldTypeBase.GetHashCode() + Owner.GetHashCode();
        }

        private bool Equals(FieldInfo other)
        {
            return Name.Equals(other.Name)
                && Owner.Equals(other.Owner)
                && _fieldTypeBase.Equals(other._fieldTypeBase);
        }
    }
}
