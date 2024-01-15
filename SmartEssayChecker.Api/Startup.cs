using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartEssayChecker.Api.Brokers.Loggings;
using SmartEssayChecker.Api.Brokers.OpenAis;
using SmartEssayChecker.Api.Brokers.Storages;
using SmartEssayChecker.Api.Services.Foundations.Essays;
using SmartEssayChecker.Api.Services.Foundations.Feedbacks;
using SmartEssayChecker.Api.Services.Foundations.OpenAis;
using SmartEssayChecker.Api.Services.Foundations.TextInputFormatter;
using SmartEssayChecker.Api.Services.Foundations.Users;
using SmartEssayChecker.Api.Services.Orchestrations;

namespace SmartEssayChecker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.InputFormatters.Add(new TextInput());
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddDbContext<StorageBroker>();
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IOpenAiBroker, OpenAiBroker>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEssayService, EssayService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IEssayAnalysisOrchestrationService, EssayAnalysisOrchestrationService>();
            services.AddTransient<IOpenAiService, OpenAiService>();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestLineSize = 8192; // For request line length
            });

            services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", config =>
                {
                    config.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "SmartEssayChecker.Api",
                        Version = "v1"
                    });
            });

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartEssayChecker.Api v1"));
            }

            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
