namespace PM02API
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnVerPosts_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Views.verPosts());
        }
    }

}
