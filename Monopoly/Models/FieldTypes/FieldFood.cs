namespace Monopoly.Models.FieldTypes
{
    internal class FieldFood : FieldTypeBase
    {
        public override int Price => 250;

        public override int Rent => 250;

        public override bool IsPossibleToBuy => true;
    }
}
