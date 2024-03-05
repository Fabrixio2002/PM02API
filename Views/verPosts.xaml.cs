using Microsoft.Maui;
using Microsoft.Maui.Controls;
using PM02API.Controllers;
using PM02API.Models;
using System.Collections.ObjectModel;
namespace PM02API.Views;

public partial class verPosts : ContentPage
{
    private ControllerPlace ControllerPlace = new ControllerPlace();
    public ObservableCollection<Posts> Posts { get; set; }

    public verPosts()
    {
        InitializeComponent();
        Posts = new ObservableCollection<Posts>();
        LoadAsyncs();

    }

    public async void LoadAsyncs()
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var posts = await ControllerPlace.GetPosts();

        foreach (var post in posts)
        {
            Posts.Add(post);
        }

        collectionViewPosts.ItemsSource = Posts;
    }

    //xd
    public async void LoadAsyncs2()
    {
        await LoadDataAsync2();
    }

    //xd
    private async Task LoadDataAsync2()
    {
        string valorSeleccionado = (string)Pais.SelectedItem;

        var posts = await ControllerPlace.BuscarNombreApi(valorSeleccionado);

        foreach (var post in posts)
        {
            Posts.Add(post);
        }

        collectionViewPosts.ItemsSource = Posts;
    }


    private async void Pais_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    private async void collectionViewPosts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Verificar si hay una selección actual
        if (e.CurrentSelection.FirstOrDefault() is Posts selectedPost)
        {
            // Verificar si capitalInfo es null o no
            if (selectedPost.capitalInfo != null)
            {
                // Acceder al valor de latlng
                List<double>? latlng = selectedPost.capitalInfo.latlng;
                String nombre = selectedPost.Name.Common;
                String reg = selectedPost.Region;

                if (latlng != null && latlng.Count >= 2)
                {
                    // Obtener latitud y longitud
                    double latitude = latlng[0];
                    double longitude = latlng[1];

                    // Mostrar las coordenadas en un cuadro de diálogo
                    await DisplayAlert("Coordenadas", $"Latitud: {latitude}, Longitud: {reg}", "OK");


                    await Navigation.PushAsync(new Views.MapView(latitude, longitude,nombre, reg));


                }
                else
                {
                    await DisplayAlert("Error", "No se encontraron valores de latitud y longitud.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "El objeto capitalInfo es nulo.", "OK");
            }



         }

       
     }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string valorSeleccionado = (string)Pais.SelectedItem;

        await DisplayAlert("", ""+ valorSeleccionado, "OK");
        Posts.Clear();
        LoadAsyncs2();

    }

}
