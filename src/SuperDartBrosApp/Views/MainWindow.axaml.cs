using Avalonia.Controls;
using Avalonia.Input;
using ReactiveUI;

namespace SuperDartBrosApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //Cursor = new Cursor(StandardCursorType.None); Für Raspberry Pi später ändern
    }

    private void BtnStart_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool failed = false;
        if (string.IsNullOrWhiteSpace(TBPlayer1.Text) || string.IsNullOrWhiteSpace(TBPlayer2.Text))
        {
            failed = true;
        }
        if (failed == false)
        {
            UserControl userControl = new MainView();
            Content = userControl;
            // TODO: Spielernamen übergeben
        }
    }
}
