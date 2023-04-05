namespace MMOnlineShop.Common.RegularExpression
{
    public class RegExpPattern
    {
        public const string OnlyEnglishTextSpace = @"[A-Za-z 0-9-]+";
        public const string OnlyPersianTextWithSpace = @"[\u0600-\u06FF 0-9-]+";
        public const string CellPhone = @"^(09[0-9][0-9]{8})?$";
        public const string NationalCode = @"^([0-9]{10})?$";
        public const string Email = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,5}(\.[a-zA-Z]{2,5}){0,1}";
        public const string OnlyNumber = @"^\d+$";
    }
}
