namespace ToDoList.Dto
{
    public class TarefaCriacaoDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Tempo { get; set; } = DateTime.Now;
    }
}
