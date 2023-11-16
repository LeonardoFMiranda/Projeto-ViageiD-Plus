using ViajeiD_.Model;

namespace ViajeiD_.View;

public partial class LoginUsuarioView : ContentPage
{
	public LoginUsuarioView()
	{
		InitializeComponent();
	}
         //C�digo que permite a navega��o entre as p�ginas de cadastro e login
    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditaUsuarioView());
    }

    //esse c�digo � respons�vel por verificar as credenciais de login inseridas pelo usu�rio em um formul�rio de login, consultar um banco de dados em busca de correspond�ncias e,
    //se as credenciais forem v�lidas, armazenar o usu�rio para uso posterior no aplicativo.
    //Caso as credenciais sejam inv�lidas, ele exibe uma mensagem de erro.

    private async void btnEntrar_Clicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string senha = txtSenha.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlert("Aten��o!", "Digite em todos os campos obrigat�rios", "Fechar");
            return;
        }

        var usuario = await App.BancoDados.UsuarioDataTable.ObtemUsuario(email, senha);

        if (usuario == null)
        {
            await DisplayAlert("Aten��o!", "E-mail ou senha incorretos", "Fechar");
            return;
        }

        if (email == usuario.Email && senha == usuario.Senha)
        {
            App.Usuario = usuario;
            //await DisplayAlert("Sucesso", "Login bem-sucedido", "Fechar");
            Navigation.PushAsync(new HomePrincipalView());
        }
        else
        {
            await DisplayAlert("Aten��o!", "E-mail ou senha incorretos", "Fechar");
        }
    }

}