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
    public async Task ListarAtividadeCriadaComSucesso()
    {
        //Arrange

        _tarefasApplicationMock.Setup(l => l.ListarTarefas())
            .ReturnsAsync(new ResponseModel<List<TarefasModel>>
            {
                Dados = new List<TarefasModel>
                {
                    new TarefasModel
                    {
                        Titulo = "TCC",
                        Descricao = "Aplicação de mecanismos de segurança do sistema TimeGamer",
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

    [Fact]

    public async Task CriarAtividadeInvalidaComErro()
    {
        //Arrange

        var tarefaInvalida = new TarefaCriacaoDto
        {
            Titulo = "",
            Descricao = "",
        };

        _tarefasApplicationMock.Setup(l => l.CriarTarefa(It.IsAny<TarefaCriacaoDto>()))
            .ReturnsAsync(new ResponseModel<List<TarefasModel>>
            {
                Dados = null,
                Mensagem = "Erro ao criar Atividade",
                Status = false
            });

        //Act

        var result = await _tarefasController.CriarTarefas(tarefaInvalida);

        //Assert

        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        var response = Assert.IsType<ResponseModel<List<TarefasModel>>>(badRequestResult.Value);
        Assert.False(response.Status);

    }

}
