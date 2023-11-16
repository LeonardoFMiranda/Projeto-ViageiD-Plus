using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_
{

    //A Classe Constants é usada para centralizar informações relevantes ao banco de dados SQLite, como o nome do arquivo e as opções de abertura.
    //Isso facilita o acesso consistente ao banco de dados em diferentes partes do aplicativo, garantindo que todas as partes do código usem o mesmo nome de arquivo e as mesmas opções de abertura.
    //Essa abordagem ajuda a evitar erros e facilita a manutenção do código.
    public static class Constants
    {
        private const string DBFileName = "Dados.db";

        //Aqui, uma constante pública chamada Flags é declarada. Essa constante é do tipo SQLiteOpenFlags e combina várias opções de abertura do banco de dados SQLite.
        //Essas opções definem as permissões para ler e gravar no banco de dados e criar o arquivo do banco de dados, se ele não existir.

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        // Essa propriedade pública e estática, chamada DatabasePath, fornece o caminho completo para o arquivo do banco de dados SQLite no sistema de arquivos do aplicativo.
        // O caminho é obtido combinando o diretório de dados do aplicativo 

        public static string DatabasePath
        {
            get
            {
                return Path
                    .Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }


    }

}
