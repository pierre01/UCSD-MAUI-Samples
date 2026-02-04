namespace MauiDataBinding.Views;

public partial class BasicXamlBindingPage : ContentPage
{
	public BasicXamlBindingPage()
	{
		InitializeComponent();
        label2.BindingContext = slider2;
        label2.SetBinding(Label.RotationProperty, "Value");
    }
}