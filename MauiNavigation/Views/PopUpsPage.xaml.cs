using System.Diagnostics;

namespace MauiNavigation.Views;

public partial class PopUpsPage : ContentPage
{
	public PopUpsPage()
	{
		InitializeComponent();

	}

    public async void OnDisplayAlertSimple(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "You have been alerted", "OK");
    }

    public async void OnDisplayAlert2Buttons(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        Debug.WriteLine("Answer: " + answer);
    }

    public async void OnDisplayActionSheet(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
        Debug.WriteLine("Action: " + action);

    }

    public async void OnDisplayPrompt(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 1", "What's your name?");
    }

    public async void OnDisplayPrompt2(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);

    }

    async void OnDisplayActionSheet2(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("ActionSheet: SavePhoto?", "Cancel", "Delete", "Photo Roll", "Email");
        Debug.WriteLine("Action: " + action);
    }
}