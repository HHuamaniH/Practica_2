using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using WApiSigoSFC.Models;

namespace WApiSigoSFC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(
                options => options.UseInMemoryDatabase("paisDB")
                );
            services.AddMvc().AddJsonOptions(ConfigureJson);
        }
        private void ConfigureJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDBContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            if (!context.Paises.Any())
            {
                context.Paises.AddRange(
                    new List<Pais>()
                    {
                        new Pais(){Nombre="Republica Dominicana",
                        Provincias=new List<Provincia>()
                        {
                            new Provincia(){Nombre="Azua"}
                        }

                        },
                        new Pais(){Nombre="Mexico",
                            Provincias=new List<Provincia>(){
                                new Provincia(){Nombre="Puebla"},
                                new Provincia(){Nombre="Queretaro"}
                            }
                        },
                        new Pais(){Nombre="Argentina"}
                    }
                    );
                context.SaveChanges();
            }


        }
    }
}
