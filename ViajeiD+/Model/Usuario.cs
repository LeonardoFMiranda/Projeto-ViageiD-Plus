using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_.Model
{

    //O construtor da classe Usuario é responsável por inicializar os valores das propriedades 
    //Id, Email e Senha do objeto Usuario recém-criado.
    [Table("UsuarioData")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string NomeUsuario { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        //A propriedade Id é inicializada com um valor único usando o método Guid.NewGuid(). 
        //O método Guid.NewGuid() gera um identificador global exclusivo (GUID)
        //Que é um valor de 128 bits usado para identificar recursos de forma exclusiva.

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
