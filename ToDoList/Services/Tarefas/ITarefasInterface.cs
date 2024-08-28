using ToDoList.Models;

namespace ToDoList.Services.Tarefas
{
    public interface ITarefasInterface
    {
        Task<ResponseModel<List<TarefasModel>>> ListarTarefas();
        Task<ResponseModel<TarefasModel>> CriarTarefas();
        Task<ResponseModel<List<TarefasModel>>> EditarTarefas();
        Task<ResponseModel<List<TarefasModel>>> ExcluirTarefas();
    }
}
