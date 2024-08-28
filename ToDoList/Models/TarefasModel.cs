namespace ToDoList.Models
{
    public class TarefasModel
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluido { get; set; } = false;
        public DateTime Tempo { get; set; }

    }
}
