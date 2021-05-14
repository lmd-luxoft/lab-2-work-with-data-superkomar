using System;

namespace Monopoly.Models.FieldTypes
{
    internal abstract class FieldTypeBase
    {
        public abstract int Price { get; }

        public abstract int Rent { get; }

        public abstract bool IsPossibleToBuy { get; }

        public static FieldTypeBase Construct(FieldType type)
        {
            switch (type)
            {
                case FieldType.EMPTY:   return new FieldEmpty();
                case FieldType.AUTO:    return new FieldAuto();
                case FieldType.FOOD:    return new FieldFood();
                case FieldType.CLOTHES: return new FieldClothes();
                case FieldType.TRAVEL:  return new FieldTravel();
                case FieldType.PRISON:  return new FieldPrison();
                case FieldType.BANK:    return new FieldBank();
                default: throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            return obj is FieldTypeBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Price.GetHashCode() + Rent.GetHashCode() + IsPossibleToBuy.GetHashCode();
        }

        private bool Equals(FieldTypeBase other)
        {
            return Price.Equals(other.Price)
                && Rent.Equals(other.Rent)
                && IsPossibleToBuy.Equals(other.IsPossibleToBuy);
        }
    }
}
