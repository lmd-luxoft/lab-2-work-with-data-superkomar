namespace Monopoly.Models.FieldTypes
{
    internal class FieldEmpty : FieldTypeBase
    {
        public override int Price => 0;

        public override int Rent => 0;

        public override bool IsPossibleToBuy => false;
    }
}
