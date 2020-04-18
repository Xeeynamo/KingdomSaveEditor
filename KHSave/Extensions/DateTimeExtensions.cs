using System;

namespace KHSave.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixEpoch(this int timestamp) =>
            FromUnixEpoch((uint)timestamp);

        public static DateTime FromUnixEpoch(this uint timestamp) =>
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(timestamp)
            .ToLocalTime();
    }
}
