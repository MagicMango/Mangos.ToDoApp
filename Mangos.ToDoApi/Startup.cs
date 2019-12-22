using Mangos.ToDo.Core.Context;
using Mangos.ToDo.Core.Mockups;
using Mangos.ToDo.Core.RabbitMQ;
using Mangos.ToDo.Core.Repository;
using Mangos.ToDo.Entities;
using Mangos.ToDo.Interfaces;
using Mangos.ToDoApi.Queue;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mangos.ToDoApi
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
            services.AddRouting();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ToDoContext>();
            services.Configure<RabbitMQConfig>(Configuration.GetSection("RabbitMQ"));
            services.AddTransient(x => x.GetService<IConfiguration>().GetValue<RabbitMQConfig>("RabbitMQ"));
            services.AddSingleton<IEntitiePublisher<IEntity<Guid>>, EntitiePublisher<IEntity<Guid>>>();
            services.AddTransient<ICrud<ToDoItem, Guid>, GenericDatabaseRepository<ToDoItem, Guid, ToDoContext>>();
            services.AddTransient<ICrud<ToDoList, Guid>, ToDoMockup>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
