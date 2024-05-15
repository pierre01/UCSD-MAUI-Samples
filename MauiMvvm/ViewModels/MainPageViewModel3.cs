using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiMvvm.ViewModels;

[ObservableObject]
public partial class MainPageViewModel3 : ParentClass
{
    [ObservableProperty]
    private string _myName;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ButtonText))]
    private int _count;

    public MainPageViewModel3(string myName)
    {
        MyName = myName;
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

    [RelayCommand]
    private void Increment()
    {
        Count++;
        ParentMethod();
    }
}

public class ParentClass
{
    protected void ParentMethod()
    {
        // Do Something
    }
}