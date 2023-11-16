using ViajeiD_.Model;

namespace ViajeiD_.View;

public partial class LoginUsuarioView : ContentPage
{
	public LoginUsuarioView()
	{
		InitializeComponent();
	}
         //Código que permite a navegação entre as páginas de cadastro e login
    private void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditaUsuarioView());
    }

    //esse código é responsável por verificar as credenciais de login inseridas pelo usuário em um formulário de login, consultar um banco de dados em busca de correspondências e,
    //se as credenciais forem válidas, armazenar o usuário para uso posterior no aplicativo.
    //Caso as credenciais sejam inválidas, ele exibe uma mensagem de erro.

    private async void btnEntrar_Clicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string senha = txtSenha.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlert("Atenção!", "Digite em todos os campos obrigatórios", "Fechar");
            return;
        }

        var usuario = await App.BancoDados.UsuarioDataTable.ObtemUsuario(email, senha);

        if (usuario == null)
        {
            await DisplayAlert("Atenção!", "E-mail ou senha incorretos", "Fechar");
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
            await DisplayAlert("Atenção!", "E-mail ou senha incorretos", "Fechar");
        }
    }

}