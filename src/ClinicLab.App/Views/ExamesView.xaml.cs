using System.Windows.Controls;
using ClinicLab.App.ViewModels;

namespace ClinicLab.App.Views;

public partial class ExamesView : UserControl
{
    public ExamesView()
    {
        InitializeComponent();

        DataContext = new ExameViewModel();
    }
}