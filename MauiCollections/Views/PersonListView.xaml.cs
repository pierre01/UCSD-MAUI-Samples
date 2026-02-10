using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MauiCollections.ViewModels;

namespace MauiCollections.Views;

public partial class PersonListView : ContentPage
{
    public PersonListView(PersonListViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }


}