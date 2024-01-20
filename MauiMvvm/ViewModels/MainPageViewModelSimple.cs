using System.Windows.Input;

namespace MauiMvvm.ViewModels;

public class MainPageViewModelSimple
{

    public string MyName { get; set; }

    public int Count { get; set; }

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

    public MainPageViewModelSimple(string myName)
    {
        IncrementCommand = new Command(() =>
        {
            Count++;
        });
        MyName = myName;

    }


    public ICommand IncrementCommand { get; set; }

}


