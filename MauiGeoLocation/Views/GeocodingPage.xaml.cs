namespace MauiGeoLocation.Views;

public partial class GeocodingPage : ContentPage
{
	public GeocodingPage()
	{
		InitializeComponent();
	}

	public async Task<string>  GetGeolocationForAddress(string address)
	{
        IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);

        Location location = locations?.FirstOrDefault();

        if (location != null)
            return $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
        return "No Location for this address";
    }

    private async Task<string> GetGeocodeReverseData(double latitude = 47.673988, double longitude = -122.121513)
    {
        IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);

        Placemark placemark = placemarks?.FirstOrDefault();

        if (placemark != null)
        {
            return
                $"AdminArea:       {placemark.AdminArea}\n" +
                $"CountryCode:     {placemark.CountryCode}\n" +
                $"CountryName:     {placemark.CountryName}\n" +
                $"FeatureName:     {placemark.FeatureName}\n" +
                $"Locality:        {placemark.Locality}\n" +
                $"PostalCode:      {placemark.PostalCode}\n" +
                $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                $"SubLocality:     {placemark.SubLocality}\n" +
                $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                $"Thoroughfare:    {placemark.Thoroughfare}\n";

        }

        return "";
    }



    private async void OnGetGeolocation(object sender, EventArgs e)
    {
        GeoLocationLabel.Text = await GetGeolocationForAddress(AddressEntry.Text);

    }

    private async void OnGetReverseGeolocation(object sender, EventArgs e)
    {
        if (double.TryParse(LatitudeEntry.Text, out var latitude) && double.TryParse(LongitudeEntry.Text, out var longitude))
        {
            ReverseGeoLocationLabel.Text = await GetGeocodeReverseData(latitude, longitude);
        }
    }
}