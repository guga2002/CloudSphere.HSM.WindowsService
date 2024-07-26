using HSM.WinService.Applications.Interfaces;
using HSM.WinService.Applications.Services;
using HSM.WinService.Core.Data;
using HSM.WinService.Core.Interfaces;
using HSM.WinService.Infrastructure.Repository;
using HSM.WinService.UI.SystemService.SystemInterface;
using HSM.WinService.UI.SystemService.SystemServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace HSM.WinService.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HsmDbContext>(options =>
            options.UseSqlite("Data Source=C:\\Databases\\HSMDatabase.db"));
            services.AddTransient<MainForm>();
            services.AddTransient<ISoundService, SoundService>();
            services.AddTransient<IUdpComunicationService, UdpComunicationService>();
            services.AddSingleton<SmtpService>();
            services.AddTransient<IContactInfoRepository, ContactRepository>();
            services.AddScoped<IActionRepository,ActionRepository>();
            services.AddScoped<IActionService, ActionService>();
            services.AddScoped<IContactServices, ContactServices>();
            services.AddLogging();

        }
    }
}