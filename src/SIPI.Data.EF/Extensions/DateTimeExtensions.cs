namespace System
{
    public static class DateTimeExtensions
    {
        public static TimeSpan Offset { get; set; }

        public static DateTime ConvertFromClientToUTC(this DateTime datetime)
        {
            return new DateTimeOffset(datetime, Offset).ToUniversalTime().DateTime;
        }

        public static DateTime? ConvertFromClientToUTC(this DateTime? datetime)
        {
            return datetime?.ConvertFromClientToUTC();
        }
    }
}