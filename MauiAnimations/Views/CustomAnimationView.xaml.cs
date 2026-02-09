namespace MauiAnimations.Views;

public partial class CustomAnimationView : ContentPage
{
	public CustomAnimationView()
	{
		InitializeComponent();
	}

    private void OnAnimationClicked(object sender, EventArgs e)
    {
		var animation = new Animation(v => DotNetBotImage.Scale = v, 1, 4);


		// The first argument (owner) identifies the owner of the animation.
		//		This can be the visual element on which the animation is applied,
		//		or another visual element, such as the page.
		// The second argument (name) is the name of the animation.
		//		This is used to identify the animation when it is applied to the visual element.
		// The third argument (length) is the length of the animation in milliseconds.
		// The fourth argument (easing) is the easing function that is applied to the animation.
		// The fifth argument (callback) is the callback that is invoked when the animation is updated.
		//		The callback is passed the current value of the animation and the visual element on which the animation is applied.
		// The sixth argument (finished) is the callback that is invoked when the animation has finished.
		//		The callback is passed the visual element on which the animation is applied.
		// The seventh argument (repeat) is a callback that allows the animation to be repeated.
		//		It's called at the end of the animation, and returning true indicates that the animation should be repeated.
		animation.Commit(this, "SimpleAnimation", 16, 2000 ,Easing.CubicOut, (v, c) => DotNetBotImage.Scale = 1, () => false);
    }
}