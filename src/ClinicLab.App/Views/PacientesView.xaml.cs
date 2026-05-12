using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using ClinicLab.App.ViewModels;

namespace ClinicLab.App.Views;

public partial class PacientesView : UserControl
{
    private bool _isFormatting;

    public PacientesView()
    {
        InitializeComponent();

        var vm = new PacienteViewModel();
        DataContext = vm;
        vm.CarregarCommand.Execute(null);
    }

    private void Cpf_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
    }

    private void Telefone_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
    }

    private void Cpf_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isFormatting)
            return;

        _isFormatting = true;

        var textBox = (TextBox)sender;
        var digits = new string(textBox.Text.Where(char.IsDigit).ToArray());

        if (digits.Length > 11)
            digits = digits[..11];

        string formatted = digits;

        if (digits.Length > 9)
            formatted = $"{digits[..3]}.{digits.Substring(3, 3)}.{digits.Substring(6, 3)}-{digits[9..]}";
        else if (digits.Length > 6)
            formatted = $"{digits[..3]}.{digits.Substring(3, 3)}.{digits[6..]}";
        else if (digits.Length > 3)
            formatted = $"{digits[..3]}.{digits[3..]}";

        textBox.Text = formatted;
        textBox.CaretIndex = textBox.Text.Length;

        _isFormatting = false;
    }

    private void Telefone_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isFormatting)
            return;

        _isFormatting = true;

        var textBox = (TextBox)sender;
        var digits = new string(textBox.Text.Where(char.IsDigit).ToArray());

        if (digits.Length > 11)
            digits = digits[..11];

        string formatted = digits;

        if (digits.Length > 7)
            formatted = $"({digits[..2]}) {digits.Substring(2, 5)}-{digits[7..]}";
        else if (digits.Length > 2)
            formatted = $"({digits[..2]}) {digits[2..]}";
        else if (digits.Length > 0)
            formatted = $"({digits}";

        textBox.Text = formatted;
        textBox.CaretIndex = textBox.Text.Length;

        _isFormatting = false;
    }
}