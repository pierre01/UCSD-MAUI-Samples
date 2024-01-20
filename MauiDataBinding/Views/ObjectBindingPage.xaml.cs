using MauiDataBinding.ViewModels;

namespace MauiDataBinding.Views;

public partial class ObjectBindingPage : ContentPage
{
    public ObjectBindingPage()
    {
        // DateTime.Parse("03/14/2000") Will not work if the locale is French
        //var p = new Person(new DateTime(1879, 3, 14), "Albert", "Einstein", "Male");
        var p = new Person(new DateTime(2000, 3, 14), "Albert", "Einstein", "Male");
        BindingContext = new PersonViewModel(p);
        InitializeComponent();
        //BindingContext =  new Person(DateTime.Parse("03/14/1879"), "Albert", "Einstein", "Male");
    }



}
