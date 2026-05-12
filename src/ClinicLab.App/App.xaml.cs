using System.Windows;
using ClinicLab.App.Services;
using ClinicLab.App.Views;

namespace ClinicLab.App;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ShutdownMode = ShutdownMode.OnExplicitShutdown;

        if (!ConfigService.Exists())
        {
            var setupWindow = new SetupWizardWindow();
            var result = setupWindow.ShowDialog();

            if (result != true)
            {
                Shutdown();
                return;
            }
        }

        var mainWindow = new MainWindow();

        MainWindow = mainWindow;

        ShutdownMode = ShutdownMode.OnMainWindowClose;

        mainWindow.Show();
    }
}