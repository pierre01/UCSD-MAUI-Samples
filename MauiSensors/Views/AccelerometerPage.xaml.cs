using System.Numerics;

namespace MauiSensors.Views;

public partial class AccelerometerPage : ContentPage
{

    private double CurrentSensitivity = 700;     // ACCELERATION (pixels per second²)
    private double CurrentFriction = 0.998;      // start with slick metal _ 1.0 = no friction
    private double CurrentBounce = 0.82;         // start with slick metal BOUNCY

    // Add a quick switch method you can call from a button or picker
    private void SetBallType(bool isMetal)
    {
        if (isMetal)
        {
            CurrentSensitivity = 700;
            CurrentFriction = 0.998;   // ultra slick — feels glassy
            CurrentBounce = 0.82;
            Ball.Fill = Color.FromArgb("#afafaf"); // visual cue
        }
        else // wooden
        {
            CurrentSensitivity = 400;
            CurrentFriction = 0.975;   // nice rough stop
            CurrentBounce = 0.38;
            Ball.Fill =Color.FromArgb("#99685a"); 
        }
    }

    private double posX, posY;      // center of ball in pixels
    private double velX, velY;

    private IDispatcherTimer? gameTimer;
    private Vector3 lastReading;
    public AccelerometerPage()
    {
        InitializeComponent();
        ToggleAccelerometer();
    }
    public void ToggleAccelerometer()
    {
        // Start accelerometer (fastest rate for smooth feel)
        if (Accelerometer.Default.IsSupported)
        {
            Accelerometer.Default.ReadingChanged += OnAccelerometerReadingChanged;
            Accelerometer.Default.Start(SensorSpeed.Game);   // 60 Hz+
        }

        // Initial position = center
        posX = 0.5;
        posY = 0.5;

        // Game loop @ ~60 FPS
        gameTimer = Dispatcher.CreateTimer();
        gameTimer.Interval = TimeSpan.FromMilliseconds(16);
        gameTimer.Tick += GameLoop;
        gameTimer.Start();
    }

    private void OnAccelerometerReadingChanged(object? sender, AccelerometerChangedEventArgs e)
    {
        lastReading = e.Reading.Acceleration;
    }

    private void Material_Toggled(object sender, ToggledEventArgs e)
    {
       SetBallType(e.Value);
    }

    private void GameLoop(object? sender, EventArgs e)
    {
        double dt = 0.016;

        double accelX = -lastReading.X * CurrentSensitivity;
        double accelY = +lastReading.Y * CurrentSensitivity;

        // ←←← Use the current friction
        velX = velX * CurrentFriction + accelX * dt;
        velY = velY * CurrentFriction + accelY * dt;

        // ... velocity clamp stays exactly the same ...

        // Update position
        posX += (velX * dt) / Width;
        posY += (velY * dt) / Height;

        // ←←← Bounce now uses CurrentBounce
        if (posX < 0.03) { posX = 0.03; velX = -velX * CurrentBounce; }
        if (posX > 0.97) { posX = 0.97; velX = -velX * CurrentBounce; }
        if (posY < 0.03) { posY = 0.03; velY = -velY * CurrentBounce; }
        if (posY > 0.97) { posY = 0.97; velY = -velY * CurrentBounce; }

        // Move ball
        AbsoluteLayout.SetLayoutBounds(Ball, new Rect(posX, posY, 40, 40));
    }
    protected override void OnDisappearing()
    {
        Accelerometer.Default.Stop();
        gameTimer?.Stop();
        base.OnDisappearing();
    }
}