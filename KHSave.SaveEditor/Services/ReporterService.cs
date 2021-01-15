using KHSave.SaveEditor.Interfaces;
using KHSave.SaveEditor.VersionCheck;
using System;
using System.Threading.Tasks;

namespace KHSave.SaveEditor.Services
{
    public class ReporterService : IReporter
    {
        internal static class GlobalReporterService
        {
            private const string AnonymousCookie = "YW5vbnltb3Vz";
            public static string Os => Environment.OSVersion.VersionString;
            public static string Ver => new DesktopCheckCurrentVersion().GetCurrentVersion();

            public static void SendGameName(string name)
            {
                Send("open", new
                {
                    gameId = name
                });
            }

            public static void SendCrashReport(Exception ex)
            {
                Send("crash", new
                {
                    exception = ex
                });
            }

            public static void DeleteCookies()
            {
                Send("delete", new
                {
                    cookie = GetCookie()
                });

                Common.Global.Cookie = string.Empty;
            }

            private static string GetCookie()
            {
                if (Common.Global.AnonymousReporting)
                    return AnonymousCookie;

                var cookie = Common.Global.Cookie;
                if (string.IsNullOrEmpty(cookie))
                    cookie = GenerateCookie();

                return cookie;
            }

            private static string GenerateCookie() =>
                Common.Global.Cookie = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            private static Task Send(string endpoint, object obj)
            {
#if !DEBUG
                if (Debugger.IsAttached)
                    return Task.CompletedTask;

                return Task.Run(async () =>
                {
                    try
                    {
                        using (var client = new HttpClient())
                        {
                            var content = new StringContent(
                                    JsonConvert.SerializeObject(obj),
                                    Encoding.UTF8,
                                    "application/json");
                            content.Headers.Add("kse-os", Os);
                            content.Headers.Add("kse-ver", Ver);
                            content.Headers.Add("kse-cookie", GetCookie());

                            var result = await client.PostAsync($"https://api.xee.dev/v1/khsaveeditor/{endpoint}", content);
                        }
                    }
                    catch { }
                });
#else
                return Task.CompletedTask;
#endif
            }
        }

        public static ReporterService Instance { get; } = new ReporterService();

        public void SendGameName(string name) => GlobalReporterService.SendGameName(name);
        public void SendCrashReport(Exception ex) => GlobalReporterService.SendCrashReport(ex);
        public void DeleteCookies() => GlobalReporterService.DeleteCookies();
    }
}
