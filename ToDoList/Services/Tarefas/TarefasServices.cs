using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoList.Data;
using ToDoList.Dto;
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

        public async Task<ResponseModel<List<TarefasModel>>>  CriarTarefas(TarefaCriacaoDto tarefaCriacaoDto)
        {
            ResponseModel<List<TarefasModel>> resposta = new ResponseModel<List<TarefasModel>> ();

            try
            {

                var tarefas = new TarefasModel()
                {

                    Titulo = tarefaCriacaoDto.Titulo,
                    Descricao = tarefaCriacaoDto.Descricao

                };

                await _context.AddAsync(tarefas);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Tarefas.ToListAsync();
                resposta.Mensagem = "Tarefa criada com sucesso!";
                return resposta;


            }catch(Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

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
