using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using SuperDartBrosApp.Views;

namespace SuperDartBrosApp;

public partial class WinnerUserControl : UserControl
{
    public WinnerUserControl()
    {
        InitializeComponent();
    }

    private void BtnNewGame_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // Holt das übergeordnete Fenster (MainWindow)
        Window mainWindow = this.GetVisualRoot() as Window;

        // Schließt das Hauptfenster, falls es existiert
        mainWindow.Close();

        // Öffnet ein neues Hauptfenster
        MainWindow newMainWindow = new MainWindow();
        newMainWindow.Show();
    }
}