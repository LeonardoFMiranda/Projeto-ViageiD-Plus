using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajeiD_.Model
{
    [Table("PostagemData")]
    public class Postagem
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string titulo { get; set; }

        public string destino { get; set; }

        public string descricao { get; set; }

        public string gasto { get; set; }

        public string foto { get; set; }

        public Postagem()
        {
            Id = Guid.NewGuid();
        }

        // Método para salvar uma foto
        public async Task SalvarFotoAsync(byte[] imagemBytes)
        {
            // Converta a matriz de bytes para uma string base64 (opcional, dependendo dos requisitos)
            foto = Convert.ToBase64String(imagemBytes);

            // Salve a imagem no banco de dados
            using (var db = new SQLiteConnection(Path.Combine(FileSystem.AppDataDirectory, "database.db3")))
            {
                db.InsertOrReplace(this);
            }
        }

        // Método para carregar uma foto
        public byte[] CarregarFoto()
        {
            // Converta a string base64 de volta para uma matriz de bytes (opcional, dependendo dos requisitos)
            if (!string.IsNullOrEmpty(foto))
            {
                return Convert.FromBase64String(foto);
            }

            return null;
        }
    }
}