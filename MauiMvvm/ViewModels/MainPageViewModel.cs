﻿using System.ComponentModel;
using System.Windows.Input;

namespace MauiMvvm.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private int _count;

    public event PropertyChangedEventHandler PropertyChanged;

    public string MyName { get; set; }

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(ButtonText));
        }
    }

    public string ButtonText
    {
        get
        {
            if (Count == 0)
            {
                return "Click me";
            }
            else if (Count == 1)
            {
                return $"Clicked {Count} time";
            }
            else
            {
                return $"Clicked {Count} times";
            }
        }
    }

    public MainPageViewModel(string myName)
    {
        IncrementCommand = new Command(() =>
        {
            Count++;
        });
        MyName = myName;

    }

    private void OnPropertyChanged(string v)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
    }

    public ICommand IncrementCommand { get; set; }

}

