using Microsoft.Maui.Controls;
using ViajeiD_.ViewModel;

namespace ViajeiD_.View
{
    public partial class FeedView : ContentPage
    {
        public FeedView()
        {
            InitializeComponent();

            // Define o contexto de dados (ViewModel)
            this.BindingContext = new FeedViewModel();
        }

        private void OnNovaPostagemClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovaPostagemView());
        }
    }

    
    
}
