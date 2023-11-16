namespace ViajeiD_.View;

public partial class HomePrincipalView : TabbedPage
{
	public HomePrincipalView()
	{
		InitializeComponent();

		var pagina1 = new FeedView()
		{
			Title = "",
			IconImageSource = "home.png",

	};
		var pagina2 = new ViagensView()
		{
			Title = "",
			IconImageSource = "destino.png",
		};

		var pagina3 = new ExibirUsuarioView()
		{
			Title = "",
			IconImageSource = "profile.png",
		};
		//Navegação entre paginas
		this.Children.Add( pagina1 );
		this.Children.Add( pagina2 );
		this.Children.Add( pagina3 );	

	}


}