using MauiLocalization.Resources.Languages;

namespace MauiLocalization
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CounterBtn.Text = AppResources.ClickMe;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"{AppResources.Clicked} {count} {AppResources.TimeSingular}";
            else
                CounterBtn.Text = $"{AppResources.Clicked} {count} {AppResources.Times}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}