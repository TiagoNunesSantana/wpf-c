using System.Windows.Controls;
using ClinicLab.App.ViewModels;

namespace ClinicLab.App.Views;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();

        DataContext = new DashboardViewModel();
    }
}