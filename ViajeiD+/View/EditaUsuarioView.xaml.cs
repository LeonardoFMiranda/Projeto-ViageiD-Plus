using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;
using ViajeiD_.Model;

namespace ViajeiD_.View;

public partial class EditaUsuarioView : ContentPage
{
	Usuario _usuario;

    //A classe EditaUsuarioPage � uma p�gina respons�vel por editar as informa��es de um usu�rio.
    //O construtor da classe EditaUsuarioPage cria um novo objeto do tipo Usuario e o atribui � propriedade _usuario. 
	//O objeto _usuario � usado para armazenar as informa��es do usu�rio que est� sendo editado.

    public EditaUsuarioView()
	{
		InitializeComponent();
		_usuario = new Usuario();
		
		this.BindingContext = _usuario;
	}

    //O m�todo btnCadastrar_Clicked() � respons�vel por salvar as informa��es do usu�rio no banco de dados. 
    //O m�todo verifica se o e-mail e a senha do usu�rio est�o preenchidos. 
    //Se os campos n�o estiverem preenchidos, o m�todo exibe um alerta e retorna.
    //Se os campos estiverem preenchidos, o m�todo chama o m�todo SalvaUsuario() da classe UsuarioData para salvar as informa��es do usu�rio no banco de dados.
    //O m�todo SalvaUsuario() retorna o n�mero de linhas afetadas pela opera��o.
    //Se o m�todo SalvaUsuario() retornar um valor maior que zero, significa que a opera��o foi bem-sucedida.Nesse caso, o m�todo retorna para a p�gina anterior.

    private async void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_usuario.Email) || string.IsNullOrWhiteSpace(_usuario.Senha) || string.IsNullOrWhiteSpace(_usuario.Nome) || string.IsNullOrWhiteSpace(_usuario.NomeUsuario))
        {
            await DisplayAlert("Aten��o!", "Preencha todas as informa��es", "Fechar");
            return;
        }

        if (!IsValidEmail(_usuario.Email))
        {
            await DisplayAlert("Aten��o!", "Digite um email v�lido", "Fechar");
            return;
        }

        if (_usuario.Senha.Length < 6)
        {
            await DisplayAlert("Aten��o!", "A senha deve ter pelo menos 6 caracteres", "Fechar");
            return;
        }

        var nomeUsuarioExistente = await App.BancoDados.UsuarioDataTable.ObtemNomeUsuario(_usuario.NomeUsuario);

        if (nomeUsuarioExistente != null)
        {
            await DisplayAlert("Aten��o!", "Este nome de usuario j� est� cadastrado", "Fechar");
            return;
        }

        // Verificar se o e-mail j� est� cadastrado
        var usuarioExistente = await App.BancoDados.UsuarioDataTable.ObtemUsuario(_usuario.Email, _usuario.Senha);

        if (usuarioExistente != null)
        {
            await DisplayAlert("Aten��o!", "Este e-mail j� est� cadastrado", "Fechar");
            return;
        }

        

        // Se o e-mail n�o existe, salvar o usu�rio
        var cadastro = await App.BancoDados.UsuarioDataTable.SalvaUsuario(_usuario);
        
        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");
            await Navigation.PopAsync();
        }
    }

    private bool IsValidEmail(string email)
    {
        // Express�o regular para validar um endere�o de email simples.
        string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginUsuarioView());
    }
}