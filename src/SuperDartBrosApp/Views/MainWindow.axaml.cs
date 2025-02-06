using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ReactiveUI;
using SuperDartBrosApp.Models;
using System.Collections.Generic;

namespace SuperDartBrosApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //Cursor = new Cursor(StandardCursorType.None); Für Raspberry Pi später ändern
    }
}
