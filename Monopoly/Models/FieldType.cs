namespace Monopoly.Models
{
    internal enum FieldType
    {
        EMPTY,
        AUTO,
        FOOD,
        CLOTHER,
        TRAVEL,
        PRISON,
        BANK
    }

    internal static class FieldTypeExt
    {
        public static int GetPrice(this FieldType type)
        {
            switch (type)
            {
                case FieldType.AUTO:    return 500;
                case FieldType.FOOD:    return 250;
                case FieldType.CLOTHER: return 100;
                case FieldType.TRAVEL:  return 700;
                
                case FieldType.EMPTY:
                default: return 0;
            }
        }

        public static int GetRent(this FieldType type)
        {
            switch (type)
            {
                case FieldType.AUTO:    return 250;
                case FieldType.FOOD:    return 250;
                case FieldType.CLOTHER: return 100;
                case FieldType.TRAVEL:  return 300;
                case FieldType.PRISON:  return 1000;
                case FieldType.BANK:    return 700;
                
                case FieldType.EMPTY:
                default: return 0;
            }
        }

        public static bool IsPossibleToBuy(this FieldType type)
        {
            switch (type)
            {
                case FieldType.AUTO:
                case FieldType.FOOD:
                case FieldType.CLOTHER:
                case FieldType.TRAVEL:
                {
                    return true;
                }

                case FieldType.PRISON:
                case FieldType.BANK:
                case FieldType.EMPTY:
                default:
                {
                    return false;
                }
            }
        }
    }
}
