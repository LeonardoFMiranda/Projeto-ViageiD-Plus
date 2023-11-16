using Microsoft.Maui.ApplicationModel.Communication;
using System.Text.RegularExpressions;
using ViajeiD_.Model;

namespace ViajeiD_.View;

public partial class EditaUsuarioView : ContentPage
{
	Usuario _usuario;

    //A classe EditaUsuarioPage é uma página responsável por editar as informações de um usuário.
    //O construtor da classe EditaUsuarioPage cria um novo objeto do tipo Usuario e o atribui à propriedade _usuario. 
	//O objeto _usuario é usado para armazenar as informações do usuário que está sendo editado.

    public EditaUsuarioView()
	{
		InitializeComponent();
		_usuario = new Usuario();
		
		this.BindingContext = _usuario;
	}

    //O método btnCadastrar_Clicked() é responsável por salvar as informações do usuário no banco de dados. 
    //O método verifica se o e-mail e a senha do usuário estão preenchidos. 
    //Se os campos não estiverem preenchidos, o método exibe um alerta e retorna.
    //Se os campos estiverem preenchidos, o método chama o método SalvaUsuario() da classe UsuarioData para salvar as informações do usuário no banco de dados.
    //O método SalvaUsuario() retorna o número de linhas afetadas pela operação.
    //Se o método SalvaUsuario() retornar um valor maior que zero, significa que a operação foi bem-sucedida.Nesse caso, o método retorna para a página anterior.

    private async void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_usuario.Email) || string.IsNullOrWhiteSpace(_usuario.Senha) || string.IsNullOrWhiteSpace(_usuario.Nome) || string.IsNullOrWhiteSpace(_usuario.NomeUsuario))
        {
            await DisplayAlert("Atenção!", "Preencha todas as informações", "Fechar");
            return;
        }

        if (!IsValidEmail(_usuario.Email))
        {
            await DisplayAlert("Atenção!", "Digite um email válido", "Fechar");
            return;
        }

        if (_usuario.Senha.Length < 6)
        {
            await DisplayAlert("Atenção!", "A senha deve ter pelo menos 6 caracteres", "Fechar");
            return;
        }

        var nomeUsuarioExistente = await App.BancoDados.UsuarioDataTable.ObtemNomeUsuario(_usuario.NomeUsuario);

        if (nomeUsuarioExistente != null)
        {
            await DisplayAlert("Atenção!", "Este nome de usuario já está cadastrado", "Fechar");
            return;
        }

        // Verificar se o e-mail já está cadastrado
        var usuarioExistente = await App.BancoDados.UsuarioDataTable.ObtemUsuario(_usuario.Email, _usuario.Senha);

        if (usuarioExistente != null)
        {
            await DisplayAlert("Atenção!", "Este e-mail já está cadastrado", "Fechar");
            return;
        }

        

        // Se o e-mail não existe, salvar o usuário
        var cadastro = await App.BancoDados.UsuarioDataTable.SalvaUsuario(_usuario);
        
        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Fechar");
            await Navigation.PopAsync();
        }
    }

    private bool IsValidEmail(string email)
    {
        // Expressão regular para validar um endereço de email simples.
        string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginUsuarioView());
    }
}