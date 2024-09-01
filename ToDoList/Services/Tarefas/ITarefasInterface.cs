using ToDoList.Dto;
using ToDoList.Models;

namespace ToDoList.Services.Tarefas
{
    public interface ITarefasInterface
    {
        Task<ResponseModel<List<TarefasModel>>> ListarTarefas();
        Task<ResponseModel<List<TarefasModel>>> CriarTarefas(TarefaCriacaoDto tarefaCriacaoDto);
        Task<ResponseModel<List<TarefasModel>>> EditarTarefas();
        Task<ResponseModel<List<TarefasModel>>> ExcluirTarefas();
    }
}
