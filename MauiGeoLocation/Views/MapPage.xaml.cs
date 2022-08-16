namespace MauiApp1;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
	}

    /// <summary>
    /// The map functionality works by calling the IMap.OpenAsync method, and passing either an 
    /// instance of the Location or Placemark type. The following example opens the installed map app 
    /// at a specific GPS location
    /// </summary>
    /// <returns></returns>
    public async Task NavigateToBuilding25()
    {
        var location = new Location(47.645160, -122.1306032);
        var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

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
}