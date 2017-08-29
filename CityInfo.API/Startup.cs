using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //Dependency Injection sisteminin kullanıldığı servislerle ilgili ayarların yapıldığı methodtur.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        //ASP.NET CORE MVC Pipeline ında kullanılacak loglama cacheleme authorization vb süreçlerin ayarlarının yapıldığı bölümdür.

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //Http requestlerin tamamında aşağıdaki sonucu döndürür.

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
