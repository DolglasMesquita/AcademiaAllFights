using System;

namespace AcademiaAllFights.API.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(age)) age--;

            return age;
        }

        public static string convertDate(this DateTime date)
        {
            var dataConvertida = date.ToString("yyyy-MM-dd");

            return dataConvertida;

        }
    }
}
