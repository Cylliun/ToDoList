﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.Dto;
using ToDoList.Models;
using ToDoList.Services.Tarefas;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private readonly ITarefasInterface _tarefasInterface;
        public TarefasController(ITarefasInterface tarefasInterface)
        {
            _tarefasInterface = tarefasInterface;
        }

        [HttpGet("ListarTarefas")]
        public async Task<ActionResult<ResponseModel<List<TarefasModel>>>> ListarTarefas()
        {
            var Tarefas = await _tarefasInterface.ListarTarefas();
            return Ok(Tarefas);
        }

        [HttpPost("CriarTarefa")]
        public async Task<ActionResult<ResponseModel<List<TarefasModel>>>> CriarTarefas(TarefaCriacaoDto tarefaCriacaoDto)
        {
            var Tarefas = await _tarefasInterface.CriarTarefa(tarefaCriacaoDto);
            return Ok(Tarefas);
        }

        [HttpPut("EditarTarefa/{id}")]

        public async Task<ActionResult<ResponseModel<List<TarefasModel>>>> EditarTarefas(int id,TarefaEdicaoDto tarefaEdicaoDto)
        {

            tarefaEdicaoDto.Id = id;                                

            var Tarefas = await _tarefasInterface.EditarTarefa(tarefaEdicaoDto);
            return Ok(Tarefas);
        }

        [HttpDelete("ExcluirTarefa/{id}")]
        public async Task<ActionResult<ResponseModel<List<TarefasModel>>>> ExcluirTarefa(int id)
        {
            var Tarefas = await _tarefasInterface.ExcluirTarefa(id);
            return Ok(Tarefas);
        }
    }
}
