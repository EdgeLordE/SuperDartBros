using Avalonia.Controls;
using ReactiveUI;

namespace SuperDartBrosApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void  BtnStart_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (TBPlayer1.Text == "" || TBPlayer2.Text == "" || TBPlayer1.Text == " " || TBPlayer2.Text == " ")
        {
            MessageBox msgBox = new MessageBox("Hallo, das ist eine eigene MessageBox!");
            await msgBox.ShowDialog(this);
        }
        else
        {
            UserControl userControl = new MainView();
            Content = userControl;
        }
    }
}
