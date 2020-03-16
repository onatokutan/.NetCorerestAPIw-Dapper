using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Api.Data;
using System.IO;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*");
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var cfbuild = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var cfconfig = cfbuild.Build();

            services.AddTransient<IOgrenciProvider>(f => new OgrenciProvider(cfconfig["ConnectionString:Proje"]));
            services.AddTransient<IDersProvider>(f => new DersProvider(cfconfig["ConnectionString:Proje"]));
            services.AddTransient<ISinifProvider>(f => new SinifProvider(cfconfig["ConnectionString:Proje"]));

            services.AddTransient<IOgrenciProcessor>(f => new OgrenciProcessor(cfconfig["ConnectionString:Proje"]));
            services.AddTransient<IDersProcessor>(f => new DersProcessor(cfconfig["ConnectionString:Proje"]));
            services.AddTransient<ISinifProcessor>(f => new SinifProcessor(cfconfig["ConnectionString:Proje"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
