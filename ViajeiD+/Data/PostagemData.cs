using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViajeiD_.Model;

namespace ViajeiD_.Data
{
    public class PostagemData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public PostagemData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }

        public Task<List<Postagem>> ListaUsuarios()
        {
            var lista = _conexaoBD
                .Table<Postagem>()
                .ToListAsync();
            return lista;

        }
        //Com os dois parâmetros, vai recuperar o usuário com email e senha no BD.
        //Essa função usa o método Where() para consultar a tabela Usuario por ID. 
        //O método FirstOrDefaultAsync() é usado para retornar o primeiro registro que corresponde à consulta, 
        //ou null se não houver registros correspondentes.

        

        // Recebendo o usuário para salva-lo no BD, se o user não existir,
        //será inserido um novo registro na tabela, caso exista, será atualizado.
        //Essa função usa o método InsertAsync() ou UpdateAsync() para salvar o objeto Usuario no banco de dados. 
        //Se o usuário não existir, o método InsertAsync() é usado para inserir um novo registro na tabela. 
        //Caso contrário, o método UpdateAsync() é usado para atualizar o registro existente.

        public async Task<int> SalvaPostagem(Postagem postagem)
        {
            var postagemIsSalvo = await ObtemUsuarioId(App.Usuario.Id);

            //Checagem de usuário

            if (postagemIsSalvo == null)
            {
                return await _conexaoBD.InsertAsync(postagem);
            }
            else
            {
                return await _conexaoBD.UpdateAsync(postagem);
            }



        }

        //Essa função usa o método Where() para consultar a tabela Usuario por email e senha
        //O método FirstOrDefaultAsync() é usado para retornar o primeiro registro que corresponde à consulta.
        //ou null se não houver registro do usuário.

        public Task<Postagem> ObtemUsuarioId(Guid Id)
        {
            var usuario = _conexaoBD
                .Table<Postagem>()
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
            return usuario;


        }

        //Excluir Usuário
        //Essa função usa o método DeleteAsync() para excluir o registro do banco de dados correspondente ao ID fornecido.

        public async Task<int> ExcluirUsuario(Guid id)
        {
            return await _conexaoBD.DeleteAsync(id);
        }
    }
}
