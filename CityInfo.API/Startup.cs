﻿using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {

        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

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

            var connectionString = Startup.Configuration["ConnectionStrings:cityInfoDbConnectionString"];
            services.AddDbContext<CityInfoContext>(o=>o.UseSqlServer(connectionString));

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
        }

        //ASP.NET CORE MVC Pipeline ında kullanılacak loglama cacheleme authorization vb süreçlerin ayarlarının yapıldığı bölümdür.

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            CityInfoContext cityInfoContext)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            cityInfoContext.EnsureSeedDataForContext();
            //Browserda status code görüntülenmesini istiyorsak bu methodu kullanıyoruz.
            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<PointOfInterest, PointOfInterestDTO>();
            });


            app.UseMvc();

            //Http requestlerin tamamında aşağıdaki sonucu döndürür.

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
