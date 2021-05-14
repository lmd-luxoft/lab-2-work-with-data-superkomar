namespace Monopoly.Models.FieldTypes
{
    internal class FieldTravel : FieldTypeBase
    {
        public override int Price => 700;

        public override int Rent => 300;

        public override bool IsPossibleToBuy => true;
    }
}
