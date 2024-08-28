using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Services.Tarefas
{
    public class TarefasServices : ITarefasInterface
    {

        private readonly AppDbContext _context;
        public TarefasServices(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<TarefasModel>> CriarTarefas()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TarefasModel>>> EditarTarefas()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TarefasModel>>> ExcluirTarefas()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<TarefasModel>>> ListarTarefas()
        {

            ResponseModel<List<TarefasModel>> resposta = new ResponseModel<List<TarefasModel>>();

            try
            {

                var Tarefas = await _context.Tarefas.ToListAsync();

                resposta.Dados = Tarefas;
                resposta.Mensagem = "Lista de tarefas encontrada";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

    }
}
