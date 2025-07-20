using ToDoList.Dto;
using ToDoList.Models;

namespace ToDoList.Services.Tarefas
{
    public interface ITarefasInterface
    {
        Task<ResponseModel<List<TarefasModel>>> ListarTarefas();
        Task<ResponseModel<List<TarefasModel>>> CriarTarefa(TarefaCriacaoDto tarefaCriacaoDto);
        Task<ResponseModel<List<TarefasModel>>> EditarTarefa(TarefaEdicaoDto tarefaEdicaoDto);
        Task<ResponseModel<List<TarefasModel>>> ExcluirTarefa(int Id);
        Task<ResponseModel<List<TarefasModel>>> TarefaConcluida(int Id);
    }
}
