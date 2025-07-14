using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoList.Controllers;
using ToDoList.Dto;
using ToDoList.Models;
using ToDoList.Services.Tarefas;

namespace ToDoList.Tests;

public class TasksServicesTests
{

    private readonly Mock<ITarefasInterface> _tarefasApplicationMock;
    private readonly TarefasController _tarefasController;

    public TasksServicesTests()
    {
        _tarefasApplicationMock = new Mock<ITarefasInterface>();
        _tarefasController = new TarefasController( _tarefasApplicationMock.Object );
    }


    [Fact]
    public async Task ListarAtividadeCriada()
    {
        //Arrange

        _tarefasApplicationMock.Setup(service => service.ListarTarefas())
            .ReturnsAsync(new ResponseModel<List<TarefasModel>>
            {
                Dados = new List<TarefasModel>
                {
                    new TarefasModel
                    {
                        Titulo = "TCC",
                        Descricao = "Aplicação de mecanismos de segurança do sistema TimeGame",
                        Tempo = DateTime.Today
                    }
                },
                Mensagem = "Listagem realizada com sucesso",
                Status = true
            });
        //Act

        var result = await _tarefasController.ListarTarefas();

        //Assert

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var responseValue = Assert.IsType<ResponseModel<List<TarefasModel>>>(okResult.Value);
        Assert.True(responseValue.Status);
        Assert.Single(responseValue.Dados);

    }
}
