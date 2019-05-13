﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nucleus.Application;
using Nucleus.Web.Core.ActionFilters;
using Nucleus.Web.Core.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;

namespace Nucleus.Web.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(_configuration);
            services.ConfigureAuthentication(_configuration);
            services.ConfigureJwtTokenAuth(_configuration);
            services.ConfigureCors(_configuration);
            services.ConfigureDependencyInjection();
            services.ConfigureNucleusApplication();

            services.AddMvc(setup =>
            {
                setup.Filters.AddService<UnitOfWorkActionFilter>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Nucleus API", Version = "v1" });
                c.AddSecurityDefinition("Bearer",
                 new ApiKeyScheme
                 {
                     In = "header",
                     Description = "Please enter into field the word 'Bearer' following by space and JWT",
                     Name = "Authorization",
                     Type = "apiKey"
                 });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nucleus API V1");
            });

            app.UseCors(_configuration["App:CorsOriginPolicyName"]);
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
