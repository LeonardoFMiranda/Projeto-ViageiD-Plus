using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ViajeiD_.Model;

namespace ViajeiD_.Data
{
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoBD;

        public UsuarioData(SQLiteAsyncConnection conexaoBD)
        {
            _conexaoBD = conexaoBD;
        }

        // Lista Users no BD, vai retornar a lista de todos os usuários.
        //Essa função usa o método Table() para acessar a tabela Usuario no banco de dados. 
        //O método ToListAsync() é usado para converter o resultado da consulta em uma lista de objetos Usuario.

        public Task<List<Usuario>> ListaUsuarios()
        {
            var lista = _conexaoBD
                .Table<Usuario>()
                .ToListAsync();
            return lista;

        }

        //Com os dois parâmetros, vai recuperar o usuário com email e senha no BD.
        //Essa função usa o método Where() para consultar a tabela Usuario por ID. 
        //O método FirstOrDefaultAsync() é usado para retornar o primeiro registro que corresponde à consulta, 
        //ou null se não houver registros correspondentes.

        public Task<Usuario> ObtemUsuario(string email, string senha)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(x => x.Email == email && x.Senha == senha)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public Task<Usuario> ObtemNomeUsuario(string nomeUsuario)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(x => x.NomeUsuario == nomeUsuario)
                .FirstOrDefaultAsync();
            return usuario;
        }

        // Recebendo o usuário para salva-lo no BD, se o user não existir,
        //será inserido um novo registro na tabela, caso exista, será atualizado.
        //Essa função usa o método InsertAsync() ou UpdateAsync() para salvar o objeto Usuario no banco de dados. 
        //Se o usuário não existir, o método InsertAsync() é usado para inserir um novo registro na tabela. 
        //Caso contrário, o método UpdateAsync() é usado para atualizar o registro existente.

        public async Task<int> SalvaUsuario(Usuario usuario)
        {
            var usuarioIsSalvo = await ObtemUsuarioId(usuario.Id);
            
            //Checagem de usuário
           
            if (usuarioIsSalvo == null)
            {
                return await _conexaoBD.InsertAsync(usuario);
            }
            else
            {
                return await _conexaoBD.UpdateAsync(usuario);
            }



        }
       
        //Essa função usa o método Where() para consultar a tabela Usuario por email e senha
        //O método FirstOrDefaultAsync() é usado para retornar o primeiro registro que corresponde à consulta.
        //ou null se não houver registro do usuário.
        
        public Task<Usuario> ObtemUsuarioId(Guid Id)
        {
            var usuario = _conexaoBD
                .Table<Usuario>()
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
            return usuario;

            
        }
        
        //Excluir Usuário
        //Essa função usa o método DeleteAsync() para excluir o registro do banco de dados correspondente ao ID fornecido.
        
        public async Task<int>ExcluirUsuario(Guid id)
        {
            return await _conexaoBD.DeleteAsync(id);
        }
     }
   }
