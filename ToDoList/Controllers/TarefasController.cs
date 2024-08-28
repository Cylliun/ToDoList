﻿using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services.Tarefas;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : Controller
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

    }
}