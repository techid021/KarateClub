using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KarateClub.Mvc.Models.ExtentionMethods
{
    public static class DateConverting
    {
        public static String ToPersianDate(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return string.Format("{0}/{1:00}/{2:00}",
                                 persianCalendar.GetYear(dateTime),
                                persianCalendar.GetMonth(dateTime),
                                persianCalendar.GetDayOfMonth(dateTime));
        }

        public static String ToPersianDateTime(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return string.Format("{0}/{1:00}/{2:00} ساعت {3:00}:{4:00}",
                                persianCalendar.GetYear(dateTime),
                                persianCalendar.GetMonth(dateTime),
                                persianCalendar.GetDayOfMonth(dateTime),
                                persianCalendar.GetHour(dateTime),
                                persianCalendar.GetMinute(dateTime));
        }

        public static String ToPersianTime(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            return string.Format("ساعت {0:00}:{1:00}",
                                persianCalendar.GetHour(dateTime),
                                persianCalendar.GetMinute(dateTime));
        }

        public static DateTime ToDateTime(this string objDate)
        {
            int year = 0;
            int month = 0;
            int day = 0;
            PersianCalendar persianCalendar = new PersianCalendar();

            string date = objDate as string;
            Match match;

            if (Regex.IsMatch(date, @"^((0?[1-9]|[12][0-9]|3[01])[- /.](0?[1-9]|1[012])[- /.](13|14)?\d{2})|((13|14)\d{2}[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01]))$"))
            {
                match = Regex.Match(date, @"^((0?[1-9]|[12][0-9]|3[01])[- /.](0?[1-9]|1[012])[- /.]((13|14)?\d{2}))|(((13|14)\d{2})[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01]))$");

                if (match.Groups[1].Success)
                {
                    day = Convert.ToInt32(match.Groups[2].Value);
                    month = Convert.ToInt32(match.Groups[3].Value);

                    if (match.Groups[5].Success)
                    {
                        year = Convert.ToInt32(match.Groups[4].Value);
                    }
                    else
                    {
                        year = Convert.ToInt32(string.Format("{0:00}{1:00}", persianCalendar.GetYear(DateTime.Now) / 100, match.Groups[4].Value));
                    }
                }
                else
                {
                    day = Convert.ToInt32(match.Groups[10].Value);
                    month = Convert.ToInt32(match.Groups[9].Value);
                    year = Convert.ToInt32(match.Groups[7].Value);
                }
            }
            else
            {
                throw new Exception("Invalid Date Expression");
            }

            return persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);

        }
    }
}