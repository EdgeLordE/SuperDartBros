using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SuperDartBrosApp;

public partial class WinnerUserControl : UserControl
{
    public WinnerUserControl()
    {
        InitializeComponent();
    }

    private void BtnNewGame_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        UserControl window = new InputNamesUserControl();
        Content = window;
    }
}