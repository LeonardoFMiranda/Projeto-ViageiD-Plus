using Microsoft.Maui.Controls.PlatformConfiguration;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajeiD_.Model;



namespace ViajeiD_.Data
{

    //A classe SQLiteData é responsável por gerenciar a conexão com o banco de dados SQLite
    //e fornecer métodos para realizar operações 
    //CRUD(Criar, Ler, Atualizar e Deletar) em tabelas do banco de dados.
    //O construtor da classe SQLiteData recebe o caminho para o arquivo de banco de dados SQLite como parâmetro.
    //O construtor cria um novo objeto SQLiteAsyncConnection 
    //usando o caminho especificado e estabelece a conexão com o banco de dados.

    public class SQLiteData2
    {

        //A propriedade _conexaoBD é um objeto do tipo SQLiteAsyncConnection que representa a conexão com o banco de dados SQLite. 
        //A conexão é estabelecida no construtor da classe SQLiteData.

        readonly SQLiteAsyncConnection _conexaoBD;

        public PostagemData PostagemDataTable { get; set; }


        //O método CreateTableAsync<Usuario>() cria a tabela Usuario no banco de dados se ela ainda não existir.
        //O método CreateTableAsync() é um método assíncrono que retorna uma tarefa Task. 
        //O método Wait() é usado para aguardar a conclusão da tarefa.
        //A instrução UsuarioDataTable = new UsuarioData(_conexaoBD) cria um novo objeto do tipo UsuarioData e atribui-o à propriedade UsuarioDataTable.
        //O objeto UsuarioData é inicializado com a conexão com o banco de dados armazenada na propriedade _conexaoBD.

        public SQLiteData2(string path)
        {
            _conexaoBD = new SQLiteAsyncConnection(path);


            _conexaoBD.CreateTableAsync<Usuario>()
                .Wait();


            PostagemDataTable = new PostagemData(_conexaoBD);

        }
    }
}
