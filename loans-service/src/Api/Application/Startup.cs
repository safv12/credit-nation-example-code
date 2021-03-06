﻿namespace LoanService.Api.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Gbm.Api.Scopes.Services.DomainEventSubscribers;
    using LoanService.Api.Domain.LoanAggregate;
    using LoanService.Api.Domain.UserAggregate;
    using LoanService.Api.Infrastructure.IntegrationEventSubscribers;
    using LoanService.Api.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Startup class to configure all services
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Startup"/> class
        /// </summary>
        /// <param name="configuration">Config values</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services">Services configured</param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(op => {
                op.Filters.Add(new CustomExceptionFilterAttribute());
            });
            services.AddTransient<IIntegrationEventSubscriber, UserCreatedSubscriber>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IDomainEventSubscriber, SomeSubscriber>();
            services.AddDbContext<LoanServiceContext>(options => options.UseSqlite("Data Source=loanServiceDB.db", b => b.MigrationsAssembly("LoanService.Api.Application")));

        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <param name="env">Environment details</param>
        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Integration event subscriber
            var subscribers = app.ApplicationServices.GetServices(typeof(IIntegrationEventSubscriber));
            foreach(IIntegrationEventSubscriber subscriber in subscribers) {
                subscriber.Subscribe();
            }

            // Domain event subscribers
            var domainEventSubscribers = app.ApplicationServices.GetServices(typeof(IDomainEventSubscriber));
            foreach(IDomainEventSubscriber subscriber in domainEventSubscribers) {
                subscriber.Subscribe();
            }

            app.UseMvc();
        }
    }
}
