using GraphiQl;
using GraphQL.API.Data;
using GraphQL.API.GraphqlCore;
using GraphQL.API.Repository;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API
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

            services.AddControllers();
            services.AddDbContext<CountryRecordDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("LocalServer")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraphQL.API", Version = "v1" });
            });

            services.AddTransient<ICountryRecordRepository, CountryRecordRepository>();
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();

            services.AddTransient<CountryRecordInputType>();
            services.AddTransient<CountryRecordType>();
            services.AddTransient<CountryRecordQuery>();
            services.AddTransient<CountryRecordSchema>();
            services.AddTransient<CountryRecordMutation>();

            services.AddTransient<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddTransient<CountryRecordSchema>();
            services.AddGraphQL(o => o.ExposeExceptions = true)
                    .AddGraphTypes(ServiceLifetime.Transient);
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQL.API v1"));
            }

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<CountryRecordSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
