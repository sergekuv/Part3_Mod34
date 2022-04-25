using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Part3_Mod34.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Part3_Mod34
{
    public class Startup
    {
        //public Startup(IConfiguration configuration) - конструктор ломает процесс - значение Configuration считывается вне его..
        //{
        //   // Configuration = configuration;
        //}
        private IConfiguration Configuration{ get; } = new ConfigurationBuilder().AddJsonFile("HomeOptions.json").Build();

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HomeOptions>(Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c => {c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HomeApi", Version = "v1"
                });
            });

            // Подключаем автомаппинг
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            services.AddAutoMapper(assembly);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Проставляем специфичные для запуска при разработке свойства
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // Сопоставляем маршруты с контроллерами
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
