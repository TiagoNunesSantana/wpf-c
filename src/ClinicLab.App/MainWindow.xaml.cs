using System.Windows;
using ClinicLab.App.ViewModels;

namespace ClinicLab.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var vm = new PacienteViewModel();
        DataContext = vm;
        vm.CarregarCommand.Execute(null);
    }
}