namespace Monopoly.Models.FieldTypes
{
    internal class FieldClothes : FieldTypeBase
    {
        public override int Price => 100;

        public override int Rent => 100;

        public override bool IsPossibleToBuy => true;
    }
}
