namespace MauiGeoLocation.Views;

public partial class GeolocationPage : ContentPage
{
	public GeolocationPage()
	{
		InitializeComponent();
	}

    public async Task<string> GetCachedLocation()
    {
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
                return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Handle not supported on device exception
        }
        catch (FeatureNotEnabledException fneEx)
        {
            // Handle not enabled on device exception
        }
        catch (PermissionException pEx)
        {
            // Handle permission exception
        }
        catch (Exception ex)
        {
            // Unable to get location
        }

        return "None";
    }

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public async Task GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                ActiveLocationLabel.Text =   $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
        }
        // Catch one of the following exceptions:
        //   FeatureNotSupportedException
        //   FeatureNotEnabledException
        //   PermissionException
        catch (Exception ex)
        {
            // Unable to get location
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

    /// <summary>
    /// The map functionality works by calling the IMap.OpenAsync method, and passing either an 
    /// instance of the Location or Placemark type. The following example opens the installed map app 
    /// at a specific GPS location
    /// </summary>
    /// <returns></returns>
    public async Task NavigateToUcsd()
    {
        Location location = new Location(32.879296, -117.235333);
        var options = new MapLaunchOptions { Name = "U.C.S.D" };

        //try
        //{
        //    await Map.Default.OpenAsync(location, options);
        //}
        //catch (Exception ex)
        //{
        //    // No map application available to open
        //}

        if (await Map.Default.TryOpenAsync(location, options) == false)
        {
            // Map failed to open
        }
    }

    /// <summary>
    /// When you use a Placemark to open the map, more information is required. 
    /// The information helps the map app search for the place you're looking for. The following information is required:
    ///   CountryName
    ///   AdminArea
    ///   Thoroughfare
    ///   Locality
    /// </summary>
    /// <returns></returns>
    public async Task NavigateToBuilding()
    {
        var placemark = new Placemark
        {
            CountryName = "United States",
            AdminArea = "WA",
            Thoroughfare = "Microsoft Building 25",
            Locality = "Redmond"
        };
        var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

        try
        {
            await Map.Default.OpenAsync(placemark, options);
        }
        catch (Exception ex)
        {
            // No map application available to open or placemark can not be located
        }
    }

    private async  void OnGetLastCachedLocation(object sender, EventArgs e)
    {
        CachedLocationLabel.Text = await GetCachedLocation();
    }

    private async void OnGetLastActiveLocation(object sender, EventArgs e)
    {
        await GetCurrentLocation();
    }

    private async void OnNavigateToUcsd(object sender, EventArgs e)
    {
        await NavigateToUcsd();
    }
}