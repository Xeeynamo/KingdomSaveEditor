using System;

namespace KHSave.Extensions
{
    public static class DateTimeExtensions
    {
        private static DateTime _baseDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixEpoch(this int timestamp) =>
            FromUnixEpoch((uint)timestamp);

        public static DateTime FromUnixEpoch(this uint timestamp) =>
            _baseDateTime.AddSeconds(timestamp);

        public static uint ToUnixEpoch(this DateTime dateTime) =>
            (uint)((dateTime.Ticks - _baseDateTime.Ticks) / TimeSpan.TicksPerSecond);
    }
}
