using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace LaborExchange.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>

                {
                    // Использую кестрел - т.к мультиплатформа
                    webBuilder.UseKestrel(options =>
                    {
                        options.ListenAnyIP(5002, o=> o.UseHttps()); // Для blazor.
                                                                     // Добавил сюда TLS так как веб без защиты в 2022 это смех конечно
                                                                     // Но с сертификатам всеравно мотаться не хочу

                        options.ListenLocalhost(5000, o => o.Protocols =
                            HttpProtocols.Http2); // Setup a HTTP/2 endpoint without TLS.
                                                  // Используется для MagicOnion - он работает поверх gRPC
                                                  // Не защищенное соединение т.к не хочу мотаться с сертификатами
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}