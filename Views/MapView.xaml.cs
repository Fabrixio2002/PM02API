namespace PM02API.Views;
using System.Net.NetworkInformation;
using static Microsoft.Maui.ApplicationModel.Permissions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Maps;

public partial class MapView : ContentPage
{
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public String Name { get; private set; }
    public String Cap { get; private set; }
    public MapView(double latitude, double longitude,String name,String reg)
    {
        InitializeComponent();
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        // Crear una ubicación y un span del mapa
        Location position = new Location(Latitude, Longitude);
        MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1));

        // Crear el mapa
        Map map = new Map(mapSpan);

        // Crear el pin
        Pin pin = new Pin
        {
            Location = position,
            Label = $"Pais:{name}-Región: {reg}",
            Address = $"Latitud: {Latitude}, Longitud: {Longitude}"
        };

        // Agregar el pin al mapa
        map.Pins.Add(pin);

        // Mover el mapa para que la región se ajuste al pin
        map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));

        // Agregar el mapa al contenido de la página
        Content = map;
    }
}
    
