using Microsoft.Extensions.Hosting;
using HotChocolate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Example.DataAccess;
using HotChocolate.Types.Relay;
using System;
using System.Reflection;

namespace Example.Graphql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            String schemaPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) , @"gqlschema");
            String schemaFile = String.Format(@"{0}\schema.graphql", schemaPath);

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IBookingsRepository, BookingsRepository>();
            services.AddGraphQLServer()
                .AddDocumentFromFile(schemaFile)
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<UserTypeExtension>()
                .AddFiltering()
                .AddSorting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
