using AutoMapper;
using Core;
using Infrastructure.Repository;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IConfiguration Configuration { get; set; }

        public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            var dbProvider = Configuration.GetValue<DbProvider>("DbProvider");
            switch (dbProvider)
            {
                case DbProvider.SqlServer:
                    ConfigureForSqlServer(services);
                    break;
                case DbProvider.InMemory:
                    ConfigureForInMemory(services);
                    break;
                case DbProvider.MySQL:
                    ConfigureForMySQL(services);
                    break;
                case DbProvider.PostgreSQL:
                    ConfigureForPostgreSQL(services);
                    break;
                default:
                    ConfigureForInMemory(services);
                    break;
            }

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ClassesRepository));
            services.AddTransient(typeof(CoursesRepository));
            services.AddScoped(typeof(PhotosRepository));
            services.AddScoped(typeof(IFileBuilder<>), typeof(FileBuilder<>));
            services.AddScoped(typeof(CertificatesRepository));
            services.AddScoped(typeof(InteractionsRepository));
            services.AddScoped<IMailProviderHelper, MailProviderHelper>(serviceProvider => BuildMailProvider());

            services.AddAutoMapper(typeof(ServiceCollectionExtension));

            return services;
        }

        private static void ConfigureForSqlServer(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"), x => x.EnableRetryOnFailure()));
        }

        private static void ConfigureForInMemory(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("InMemoryConnection")));
        }

        private static void ConfigureForMySQL(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));
        }

        private static void ConfigureForPostgreSQL(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection")));
        }

        private static MailProviderHelper BuildMailProvider()
        {
            string senderName = Configuration.GetValue<string>("EmailConfiguration:SenderName");
            string senderEmail = Configuration.GetValue<string>("EmailConfiguration:SenderEmail");
            string smtpHost = Configuration.GetValue<string>("EmailConfiguration:SmtpHost");
            int smtpPort = Configuration.GetValue<int>("EmailConfiguration:SmtpPort");
            string smtpUserName = Configuration.GetValue<string>("EmailConfiguration:SmtpUserName");
            string smtpPassword = Configuration.GetValue<string>("EmailConfiguration:SmtpPassword");
            bool useSsl = Configuration.GetValue<bool>("EmailConfiguration:UseSsl");

            return new MailProviderHelper(new SmtpClient(), senderName, senderEmail, smtpHost, smtpPort, smtpUserName, smtpPassword, useSsl);
        }
    }
}
