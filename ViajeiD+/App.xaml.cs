using ViajeiD_.Data;
using ViajeiD_.Model;
using ViajeiD_.View;

namespace ViajeiD_
{

    // A classe App é responsável por inicializar o aplicativo e gerenciar o estado do aplicativo. 
    //As funções BandoDados, Usuario, InitializeComponent()
    //MainPage são usadas para inicializar o aplicativo e definir a página inicial do aplicativo.

    public partial class App : Application
    {

        static SQLiteData1 _bancoDados;


        //O objeto SQLiteData que representa o banco de dados do aplicativo.
        //Se a propriedade ainda não foi inicializada, obtém uma instância da implementação da interface BDSqlite,
        //usando o método DependencyService.Get<BDSqlite>().
        //Obtém o caminho local para o arquivo de banco de dados Dados.db3 usando o método SQLiteLocalPath().
        //Inicializa a propriedade com um novo objeto SQLiteData usando o caminho local para o arquivo de banco de dados.
        public static SQLiteData1 BancoDados
        {
            get
            {
                if(_bancoDados == null)
                {
                    _bancoDados =
                        new SQLiteData1(Path.Combine
                        (Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),
                        ("Dados.db")));

                }
                return _bancoDados;
            }
        }

        public static Usuario Usuario { get; set; }
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new LoginUsuarioView());

        }
    }
}