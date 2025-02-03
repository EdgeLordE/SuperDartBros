using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SuperDartBrosApp;

public partial class MessageBox : Window
{
    public MessageBox(string message)
    {
        InitializeComponent();
        MessageText.Text = message;
    }

    private void CloseWindow(object? sender, RoutedEventArgs e) => Close();
}
