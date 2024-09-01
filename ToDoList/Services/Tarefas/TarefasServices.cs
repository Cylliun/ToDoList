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

        public async Task<ResponseModel<List<TarefasModel>>>  CriarTarefa(TarefaCriacaoDto tarefaCriacaoDto)
        {
            ResponseModel<List<TarefasModel>> resposta = new ResponseModel<List<TarefasModel>> ();

            try
            {

                var Tarefas = new TarefasModel()
                {

                    Titulo = tarefaCriacaoDto.Titulo,
                    Descricao = tarefaCriacaoDto.Descricao

                };

                await _context.AddAsync(Tarefas);
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

        public async Task<ResponseModel<List<TarefasModel>>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto)
        {
            ResponseModel<List<TarefasModel>> resposta = new ResponseModel<List<TarefasModel>>();

            try
            {

                var Tarefa = await _context.Tarefas
                    .FirstOrDefaultAsync(tarefabanco => tarefabanco.Id == tarefaEdicaoDto.Id);

                if (Tarefa == null)
                {
                    resposta.Mensagem = "Tarefa não encontrada!";
                    return resposta;
                }

                Tarefa.Titulo = tarefaEdicaoDto.Titulo;
                Tarefa.Descricao = tarefaEdicaoDto.Descricao;
                Tarefa.Tempo = tarefaEdicaoDto.Tempo;

                _context.Update(Tarefa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Tarefas.ToListAsync();
                resposta.Mensagem = "Tarefa editada com sucesso!";
                return resposta;


            }catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<TarefasModel>>> ExcluirTarefa(int Id)
        {
            ResponseModel<List<TarefasModel>> resposta = new ResponseModel<List<TarefasModel>>();

            try
            {

                var Tarefa = await _context.Tarefas
                    .FirstOrDefaultAsync(tarefaBanco => tarefaBanco.Id == Id);

                if (Tarefa == null)
                {
                    resposta.Mensagem = "A tarefa não existe!";
                    return resposta;
                }

                _context.Remove(Tarefa);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Tarefas.ToListAsync();
                resposta.Mensagem = "Tarefa Excluida com sucesso!";

                return resposta;


            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

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
