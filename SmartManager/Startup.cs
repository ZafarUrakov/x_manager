//===========================
// Copyright (c) Tarteeb LLC
// Managre quickly and easy
//===========================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartManager.Brokers.DateTimes;
using SmartManager.Brokers.Loggings;
using SmartManager.Brokers.Spreadsheets;
using SmartManager.Brokers.Storages;
using SmartManager.Services.Foundations.Attendances;
using SmartManager.Services.Foundations.Groups;
using SmartManager.Services.Foundations.GroupsStatistics;
using SmartManager.Services.Foundations.Payments;
using SmartManager.Services.Foundations.PaymentStatistics;
using SmartManager.Services.Foundations.Spreadsheets;
using SmartManager.Services.Foundations.Statistics;
using SmartManager.Services.Foundations.Students;
using SmartManager.Services.Foundations.StudentsStatistics;
using SmartManager.Services.Processings.Attendances;
using SmartManager.Services.Processings.Groups;
using SmartManager.Services.Processings.GroupsStatistics;
using SmartManager.Services.Processings.Payments;
using SmartManager.Services.Processings.PaymentStatistics;
using SmartManager.Services.Processings.Spreadsheets;
using SmartManager.Services.Processings.Statistics;
using SmartManager.Services.Processings.Students;
using SmartManager.Services.Processings.StudentsStatistics;

namespace SmartManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            ConfigureBrokers(services);
            ConfigureFoundationServices(services);
            ConfigureProcessingServices(services);
        }

        private static void ConfigureBrokers(IServiceCollection services)
        {
            services.AddDbContext<IStorageBroker, StorageBroker>();
            services.AddTransient<ISpreadsheetBroker, SpreadsheetBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
            services.AddTransient<IDateTimeBroker, DateTimeBroker>();
        }

        private static void ConfigureProcessingServices(IServiceCollection services)
        {
            services.AddTransient<IStudentProcessingService, StudentProcessingService>();
            services.AddTransient<IAttendanceProcessingService, AttendanceProcessingService>();
            services.AddTransient<IGroupProcessingService, GroupProcessingService>();
            services.AddTransient<IPaymentProcessingService, PaymentProcessingService>();
            services.AddTransient<IStatisticProcessingService, StatisticProcessingService>();
            services.AddScoped<ISpreadsheetsProcessingService, SpreadsheetsProcessingService>();
            services.AddTransient<IPaymentStatisticsProccessingService, PaymentStatisticsProccessingService>();
            services.AddTransient<IStudentsStatisticProccessingService, StudentsStatisticProccessingService>();
            services.AddTransient<IGroupsStatisticProccessingService, GroupsStatisticProccessingService>();
        }

        private static void ConfigureFoundationServices(IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IStatisticService, StatisticService>();
            services.AddTransient<ISpreadsheetService, SpreadsheetService>();
            services.AddTransient<IPaymentStatisticService, PaymentStatisticService>();
            services.AddTransient<IStudentsStatisticService, StudentsStatisticService>();
            services.AddTransient<IGroupsStatisticService, GroupsStatisticService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
