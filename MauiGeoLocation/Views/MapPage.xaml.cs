using Microsoft.Maui.Maps;

namespace MauiGeoLocation.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
	}
    // AIzaSyDyXgQimRh4Z6QtXJ8WB3y0tIpeVMF-LVI

 

    private void HomeClicked(object sender, EventArgs e)
    {
        //32.879296, -117.235333

        Location location = new Location(32.879296, -117.235333);
        MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
        MyMap.MoveToRegion(mapSpan);
    }

    private void MauiClicked(object sender, EventArgs e)
    {
        //22.116487, -159.553929
        Location location = new Location(22.116487, -159.553929);
        MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
        MyMap.MoveToRegion(mapSpan);

    }

    private void MicrosoftClicked(object sender, EventArgs e)
    {
        //NavigateToBuilding();
        Location location = new Location(36.9628066, -122.0194722);
        MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
        MyMap.MoveToRegion(mapSpan);
    }
}