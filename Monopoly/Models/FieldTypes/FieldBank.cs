namespace Monopoly.Models.FieldTypes
{
    internal class FieldBank : FieldTypeBase
    {
        public override int Price => 0;

        public override int Rent => 700;

        public override bool IsPossibleToBuy => false;
    }
}
