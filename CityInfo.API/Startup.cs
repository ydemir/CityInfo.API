using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //Dependency Injection sisteminin kullanıldığı servislerle ilgili ayarların yapıldığı methodtur.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            //Json Formatın ayarlarını değiştirdik. property lerin ilk harflerinin büyük olmasını sağladık. (Camel case)
            //Artık genellikle küçük harf ile başlıyor o yüzden açıklamaya aldık.
            //.AddJsonOptions(o=>
            //{
            //    if (o.SerializerSettings.ContractResolver!=null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver
            //        as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null;
            //    }
            //});

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService,CloudMailService>();
#endif

        }

        //ASP.NET CORE MVC Pipeline ında kullanılacak loglama cacheleme authorization vb süreçlerin ayarlarının yapıldığı bölümdür.

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Browserda status code görüntülenmesini istiyorsak bu methodu kullanıyoruz.
            app.UseStatusCodePages();


            //Http requestlerin tamamında aşağıdaki sonucu döndürür.

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
