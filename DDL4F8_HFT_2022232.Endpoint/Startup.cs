using DDL4F8_HFT_2022232.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DDL4F8_HFT_2022232.Repository.ClassRepo;
using DDL4F8_HFT_2022232.Logic.ClassLogic;
using DDL4F8_HFT_2022232.Repository;
using DDL4F8_HFT_2022232.Logic.ClassLogicInterfaces;

namespace DDL4F8_HFT_2022232.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PetsDbContext>();

            services.AddTransient<IRepository<PetFood>, PetFoodRepository>();
            services.AddTransient<IRepository<Petowner>, PetownerRepository>();
            services.AddTransient<IRepository<Pet>, PetRepository>();

            services.AddTransient<IPetFoodLogic, PetFoodLogic>();
            services.AddTransient<IPetLogic, PetLogic>();
            services.AddTransient<IPetownerLogic, PetownerLogic>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
