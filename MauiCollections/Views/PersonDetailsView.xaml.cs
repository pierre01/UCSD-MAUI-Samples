using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiCollections.ViewModels;

namespace MauiCollections.Views;

public partial class PersonDetailsView : ContentPage
{
    public PersonDetailsView(PersonDetailsViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
}