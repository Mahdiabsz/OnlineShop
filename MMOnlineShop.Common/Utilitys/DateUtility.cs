using System.Globalization;

namespace MMOnlineShop.Common.Utilitys
{
    public class NumberToPersianText
    {

        // Convert Num To String
        // http://aspcode.ir/Article.aspx?id=20

        private static string[] yekan = new string[10] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
        private static string[] dahgan = new string[10] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
        private static string[] dahyek = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
        //array[10..19]
        private static string[] sadgan = new string[10] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
        private static string[] basex = new string[5] { "", "هزار", "میلیون", "میلیارد", "تریلیون" };


        private static string getnum3(int num3)
        {
            string s = "";
            int d3, d12;
            d12 = num3 % 100;
            d3 = num3 / 100;
            if (d3 != 0)
                s = sadgan[d3] + " و ";
            if ((d12 >= 10) && (d12 <= 19))
            {
                s = s + dahyek[d12 - 10];
            }
            else
            {
                int d2 = d12 / 10;
                if (d2 != 0)
                    s = s + dahgan[d2] + " و ";
                int d1 = d12 % 10;
                if (d1 != 0)
                    s = s + yekan[d1] + " و ";
                s = s.Substring(0, s.Length - 3);
            };
            return s;
        }

        public static string num2str(string snum)
        {
            string stotal = "";
            if (snum == "0")
            {
                return yekan[0];
            }
            else
            {
                snum = snum.PadLeft(((snum.Length - 1) / 3 + 1) * 3, '0');
                int L = snum.Length / 3 - 1;
                for (int i = 0; i <= L; i++)
                {
                    int b = int.Parse(snum.Substring(i * 3, 3));
                    if (b != 0)
                        stotal = stotal + getnum3(b) + " " + basex[L - i] + " و ";
                }
                stotal = stotal.Substring(0, stotal.Length - 3);
            }
            return stotal;
        }

        public static string markstr(string snum)
        {
            string stotal = "";
            if (snum == "0" || snum == "0.0")
            {
                return yekan[0];
            }
            else
            {
                var d = double.Parse(snum);
                var de = float.Parse(snum) - Math.Truncate(d);
                snum = Math.Truncate(d).ToString();

                stotal = num2str(snum);
                var sde = de.ToString();
                if (snum == "0")
                {
                    switch (sde)
                    {
                        case "0.25":
                            stotal += "بیست و پنج صدم";
                            break;
                        case "0.5":
                            stotal += " نیم (پنجاه صدم)";
                            break;
                        case "0.75":
                            stotal += "هفتاد و پنج صدم";
                            break;
                    }
                }
                else
                    switch (sde)
                    {
                        case "0.25":
                            stotal += "و بیست و پنج صدم";
                            break;
                        case "0.5":
                            stotal += "و نیم";
                            break;
                        case "0.75":
                            stotal += "و هفتاد و پنج صدم";
                            break;
                    }
            }
            return stotal;
        }
    }

    public static class DateUtility
    {


        /// <summary>
        /// یک رشته تاریخ فارسی بدون جداکننده را گرفته و سعی در فرمت دهی آن می کند
        /// مثلا رشته زیر را گرفته و به شکل صحیح آن تبدیل می کند
        /// inputs  : 440213   , 13880701   , 139111     , 9121     , 91111    , 91611
        /// returns : 44/02/13 , 1388/07/01 , 1391/01/01 , 91/02/01 , 91/11/01 , 91/06/11
        /// </summary>
        /// <param name="persianDate"></param>
        /// <returns></returns>
        public static string ToDateFormat(this string persianDate)
        {
            int yy = 0, mm = 0, dd = 0;
            if (!string.IsNullOrEmpty(persianDate) && persianDate.Length > 3)
            {
                string md = string.Empty;
                if (persianDate.StartsWith("1"))
                {
                    yy = int.Parse(persianDate.Substring(0, 4));
                    md = persianDate.Substring(4);
                }
                else
                {
                    yy = int.Parse(persianDate.Substring(0, 2));
                    md = persianDate.Substring(2);
                }
                switch (md.Length)
                {
                    case 4:
                        mm = int.Parse(md.Substring(0, 2));
                        dd = int.Parse(md.Substring(2));
                        break;
                    case 2:
                        mm = int.Parse(md.Substring(0, 1));
                        dd = int.Parse(md.Substring(1));
                        break;
                    case 3:
                        if (md[0] < (char)50)
                        {
                            mm = int.Parse(md.Substring(0, 2));
                            dd = int.Parse(md.Substring(2));
                        }
                        else
                        {
                            mm = int.Parse(md.Substring(0, 1));
                            dd = int.Parse(md.Substring(1));
                        }
                        break;
                }
                return string.Format("{0}/{1:00}/{2:00}", yy, mm, dd);
            }
            return persianDate;
        }

        public static DateTime ConvertToDateTime(this String persianDate)
        {
            string temp = persianDate.ToString();
            char[] delimiterChars = { ' ', '\r', '\t', '\n', '"', '/' };
            string[] details = temp.Split(delimiterChars);
            var pCal = new System.Globalization.PersianCalendar();
            if (details.Length != 3)
                return DateTime.Now.AddYears(-10).AddMinutes(-10).AddDays(-10);
            else
            {
                try
                {
                    return pCal.ToDateTime(Convert.ToInt32(details[2]), Convert.ToInt32(details[1]), Convert.ToInt32(details[0]), 0, 0, 0, 0);
                }
                catch
                {
                    try
                    {
                        return pCal.ToDateTime(Convert.ToInt32(details[0]), Convert.ToInt32(details[1]), Convert.ToInt32(details[2]), 0, 0, 0, 0);
                    }
                    catch
                    {
                        return DateTime.MinValue;
                    }
                }
            }
        }
        /// <summary>
        /// تاریخ را به رشته تاریخ شمسی تبدیل می کند.
        /// </summary>
        /// <param name="dt">تاریخی که می خواهد فارسی شود</param>
        /// <param name="seperator">جدا کننده ای که برای نمایش تاریخ فارسی استفاده شود را مشخص می کنیم </param>
        /// <returns></returns>
        public static string ToPersianDate(this DateTime dt, string seperator = "/")
        {
            PersianCalendar pc = new PersianCalendar();
            string sy = pc.GetYear(dt).ToString();
            string sm = pc.GetMonth(dt).ToString("00");
            string sd = pc.GetDayOfMonth(dt).ToString("00");

            return sy + seperator + sm + seperator + sd;
        }



        public static string ToPersianDayMonth(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int sm = pc.GetMonth(dt);
            string sd = pc.GetDayOfMonth(dt).ToString("00");
            return string.Format("{0} {1}", sd, PersianMonth[(sm - 1)]);
        }
        public static string ToPersinDateTimeSmartView(this DateTime dt)
        {
            var dn = DateTime.Now;
            if (dn.Year == dt.Year)
            {
                if (dn.Month == dt.Month)
                {
                    if (dn.Day == dt.Day)
                    {
                        if (dn.Hour == dt.Hour)
                            return string.Format("{0} دقیقه پیش", (dn.Minute - dt.Minute));
                        else
                        {
                            if (dn.Hour - dt.Hour < 2)
                                return string.Format("{0}:{1}", dt.Hour, dt.Minute);
                            else
                                return string.Format("{0} ساعت قبل", (dn.Hour - dt.Hour));
                        }
                    }
                    else
                    {
                        switch (dn.DayOfYear - dt.DayOfYear)
                        {
                            case 1:
                                return "دیروز";

                            case 2:
                                return "دو روز قبل";

                            case 3:
                                return "سه روز قبل";

                            case 4:
                                return "چهار روز";

                            case 5:
                                return "پنج روز";

                            case 6:
                                return "شش روز";

                            case 7:
                                return "یک هفته پیش";

                            case 14:
                                return "دو هفته پیش";

                            case 30:
                                return "یک ماه پیش";

                            default:
                                return dt.ToPersianDayMonth();

                        }
                    }
                }
                else
                    return dt.ToPersianDayMonth();
            }
            return dt.ToPersianDateTime();
        }
        public static string ToLittlePersianDate(this DateTime dt, string seperator = "/")
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{1}{0}{2}{0}{3}", seperator, pc.GetYear(dt) % 1300, pc.GetMonth(dt), pc.GetDayOfMonth(dt));
        }

        public static string[] PersianDays = { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" };

        public static DayOfWeek GetDayOfWeek(int year, int month, int day, bool showBreif = false)
        {
            PersianCalendar pcal = new PersianCalendar();
            return pcal.GetDayOfWeek(pcal.ToDateTime(year, month, day, 0, 0, 0, 0));
        }

        public static string GetPersianDayOfWeek(int year, int month, int day, bool showBreif = false)
        {
            var dw = GetDayOfWeek(year, month, day, showBreif);
            return GetPersianDayOfWeek(dw, showBreif);
        }

        public static int GetPersianDayOfWeekIndex(this DayOfWeek dw)
        {
            switch (dw)
            {
                case DayOfWeek.Saturday: return 0;
                case DayOfWeek.Sunday: return 1;
                case DayOfWeek.Monday: return 2;
                case DayOfWeek.Tuesday: return 3;
                case DayOfWeek.Wednesday: return 4;
                case DayOfWeek.Thursday: return 5;
                case DayOfWeek.Friday: return 6;
            }
            return -1;
        }

        public static string GetPersianDayOfWeek(this DayOfWeek dw, bool showBreif = false)
        {
            if (!showBreif)
                return PersianDays[dw.GetPersianDayOfWeekIndex()];
            else
                switch (dw)
                {
                    case DayOfWeek.Saturday: return "شنبه";
                    case DayOfWeek.Sunday: return "یک ";
                    case DayOfWeek.Monday: return "دو ";
                    case DayOfWeek.Tuesday: return "سه ";
                    case DayOfWeek.Wednesday: return "چهار";
                    case DayOfWeek.Thursday: return "پنج ";
                    case DayOfWeek.Friday: return "جمعه";
                }
            return "";
        }

        public static string GetTime(this DateTime dt)
        {
            return string.Format("{0:00}:{1:00}:{2:00}", dt.Hour, dt.Minute, dt.Second);
        }

        public static string[] PersianMonth = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
                                                  "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
                                              };

        public static string ToPersianDateString(this DateTime dt, string seperator = " ")
        {
            PersianCalendar pc = new PersianCalendar();
            int m = pc.GetMonth(dt);
            return GetPersianDayOfWeek(dt.DayOfWeek) + " " + NumberToPersianText.num2str(pc.GetDayOfMonth(dt).ToString()) + seperator + PersianMonth[m - 1] + seperator + pc.GetYear(dt);
        }

        /// <summary>
        /// تاریخ شمسی را به همراه ساعت نمایش می دهد
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public static string ToPersianDateTime(this DateTime dt, string seperator = "/")
        {
            return dt.ToPersianDate(seperator) + " " + string.Format("{0:00}:{1:00}", dt.Hour, dt.Minute);
        }

        /// <summary>
        /// محاسبه تفاوت دو تاریخ به دقیقه
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static int GetDifferenceFrom(this DateTime dt, DateTime delta)
        {
            int rs = 0;

            TimeSpan ts = delta.Subtract(dt);
            rs = ts.Days * 24 * 60 + ts.Hours * 60 + ts.Minutes;
            return rs;
        }
    }
}
