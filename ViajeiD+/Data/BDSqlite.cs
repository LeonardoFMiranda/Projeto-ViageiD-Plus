using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_.Data
{
    //Essa função recebe um parâmetro de string bancoDados e retorna uma string que representa o caminho local para o arquivo de banco de dados SQLite com o nome bancoDados.
    public interface BDSqlite
    {
        string SQLiteLocalPath(string bancoDados);
    }
}
