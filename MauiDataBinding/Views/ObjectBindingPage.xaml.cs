using MauiDataBinding.Models;
using MauiDataBinding.ViewModels;

namespace MauiDataBinding.Views;

public partial class ObjectBindingPage : ContentPage
{
    public ObjectBindingPage()
    {
        // DateTime.Parse("14/03/2000") Will not work if the locale is French
        //var p = new Person(new DateTime(1879, 3, 14), "Albert", "Einstein", "Male");
        var p = new Person(new DateTime(1879, 3, 14), "Albert", "Einstein", "Male");
        BindingContext = new PersonViewModel(p);
        InitializeComponent();
    }



}
