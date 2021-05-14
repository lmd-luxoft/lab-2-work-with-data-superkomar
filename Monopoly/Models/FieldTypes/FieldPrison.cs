namespace Monopoly.Models.FieldTypes
{
    internal class FieldPrison : FieldTypeBase
    {
        public override int Price => 0;

        public override int Rent => 1000;

        public override bool IsPossibleToBuy => false;
    }
}
