using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MAUICommunications.ViewModels;


[ObservableObject]
public partial  class NetworkingPageViewModel
{

    private ObservableCollection<string> activeConnectionProfiles = new ObservableCollection<string>();

    public NetworkingPageViewModel() =>
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

    ~NetworkingPageViewModel() =>
        Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;

    void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess == NetworkAccess.ConstrainedInternet)
            NetworkStatus="Internet access is available but is limited.";

        else if (e.NetworkAccess != NetworkAccess.Internet)
            NetworkStatus = "Internet access has been lost.";

        // Log each active connection
        activeConnectionProfiles.Clear();

        foreach (var item in e.ConnectionProfiles)
        {
            switch (item)
            {
                case ConnectionProfile.Bluetooth:
                    activeConnectionProfiles.Add("Bluetooth");
                    break;
                case ConnectionProfile.Cellular:
                    activeConnectionProfiles.Add("Cell");
                    break;
                case ConnectionProfile.Ethernet:
                    activeConnectionProfiles.Add("Ethernet");
                    break;
                case ConnectionProfile.WiFi:
                    activeConnectionProfiles.Add("WiFi");
                    break;
                default:
                    break;
            }
        }

    }

    public ObservableCollection<string> ActiveConnectionProfiles { get { return activeConnectionProfiles; } }

    [ObservableProperty]
    private string networkStatus;
}