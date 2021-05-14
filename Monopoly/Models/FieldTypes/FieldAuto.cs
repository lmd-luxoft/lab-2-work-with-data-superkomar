namespace Monopoly.Models.FieldTypes
{
    internal class FieldAuto : FieldTypeBase
    {
        public override int Price => 500;

        public override int Rent => 250;

        public override bool IsPossibleToBuy => true;
    }
}
