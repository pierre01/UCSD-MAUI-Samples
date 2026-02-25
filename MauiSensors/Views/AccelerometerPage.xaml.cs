using System.Numerics;

namespace MauiSensors.Views;

public partial class AccelerometerPage : ContentPage
{
    private readonly double Sensitivity = 350.0;     // tweak to your liking (pixels per second²)
    private readonly double Friction = 0.99;         // 1.0 = no friction
    private readonly double MaxVelocity = 800.0;

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

    private void GameLoop(object? sender, EventArgs e)
    {
        double dt = 0.016; // ~60 FPS

        // Apply tilt as acceleration (screen coordinates)
        double accelX = -lastReading.X * Sensitivity;
        double accelY = +lastReading.Y * Sensitivity;   // Y is "forward/back" on most phones

        // Update velocity with friction
        velX = velX * Friction + accelX * dt;
        velY = velY * Friction + accelY * dt;

        // Clamp max speed so it doesn't fly off
        double speed = Math.Sqrt(velX * velX + velY * velY);
        if (speed > MaxVelocity)
        {
            double factor = MaxVelocity / speed;
            velX *= factor;
            velY *= factor;
        }

        // Update position (0..1 range for AbsoluteLayout)
        posX += (velX * dt) / Width;
        posY += (velY * dt) / Height;

        // Bounce softly on edges
        if (posX < 0.03) { posX = 0.03; velX = -velX * 0.6; }
        if (posX > 0.97) { posX = 0.97; velX = -velX * 0.6; }
        if (posY < 0.03) { posY = 0.03; velY = -velY * 0.6; }
        if (posY > 0.97) { posY = 0.97; velY = -velY * 0.6; }

        // Move the ball
        AbsoluteLayout.SetLayoutBounds(Ball, new Rect(posX, posY, 40, 40));
    }

    protected override void OnDisappearing()
    {
        Accelerometer.Default.Stop();
        gameTimer?.Stop();
        base.OnDisappearing();
    }
}