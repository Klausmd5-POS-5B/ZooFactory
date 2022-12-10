using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using FactoryLib;
using FactoryLib.Animals;

namespace ZooFactory;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded();
    }

    private void buy_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        int amount = 1;
        try
        {
            amount = Convert.ToInt32(OrderAmount.Text);
        } catch (Exception exception)
        {
            Console.WriteLine(exception);
        }

        var selectedItem = ViechSelector.SelectedItem!.ToString();
        DrawGrid(Creator.Instance.CreateAnimal((Creator.Animals)Enum.Parse(typeof(Creator.Animals), selectedItem), amount));
        
        ListBox.Items = Creator.Instance.GetAnimals();
    }

    private void DrawGrid(List<Animal> items)
    {
        DataGrid.Items = items;
        DataGrid.Columns.Clear();
        
        foreach (var propertyInfo in items[0].GetType().GetProperties())
        {
            DataGrid.Columns.Add(new DataGridTextColumn() { Header = propertyInfo.Name, Binding = new Binding(propertyInfo.Name) });
        }
    }
    private void Loaded()
    {
        ViechSelector.Items = Enum.GetNames(typeof(Creator.Animals));
        ViechSelector.SelectedIndex = 0;
    }

    private void ListBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ListBox.SelectedItem is not null)
        {
            string item = ListBox.SelectedItem.ToString()!.Split(" - ")[0];
            DrawGrid(Creator.Instance.GetAnimals((Creator.Animals)Enum.Parse(typeof(Creator.Animals), item)));
        }
    }
}