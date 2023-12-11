using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace App.Frameworks.Web.ExceptionHandler
{
    public class ExceptionHandlerMiddlware
    {
        private readonly RequestDelegate _Next;
        public ExceptionHandlerMiddlware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception ex)
            {
                string message = "[Message]:"+ex.Message+"\n"+ "[Source]:" + ex.Source+"\n"+ "[StackTrace]:" + "\n" + ex.StackTrace + "\n" ;
                Log.Error(message);
                context.Response.Redirect("/Home/Error");
                return;
            }
        }
    }


    public static class ExceptionHandler
    {
        public static IApplicationBuilder Use_ExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddlware>();
        }
    }


    public static class ExceptionHandlerLogConfiguration
    {
        public static void Add_SeriLogConfiguration(this IServiceCollection services, string LogPath = "Loging\\LogFile.txt")
        {
            string OutputTamplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}]{NewLine}{Message:lj} {NewLine}{Exception}";
            var logFile = Path.Combine(Environment.CurrentDirectory, "wwwroot", LogPath);
            Log.Logger = new LoggerConfiguration().WriteTo.File(logFile, outputTemplate: OutputTamplate).CreateLogger();
             
        }
    }


}
