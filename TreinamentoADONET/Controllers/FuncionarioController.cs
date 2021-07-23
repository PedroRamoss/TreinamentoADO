using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoADONET.DAL;
using TreinamentoADONET.Models;

namespace TreinamentoADONET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioDAL _funcionarioDAL;
        public FuncionarioController(IFuncionarioDAL funcionarioDAL)
        {
            _funcionarioDAL = funcionarioDAL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> Get()
        {
            var retorno = _funcionarioDAL.GetAllFuncionarios();
            return Ok(retorno);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Funcionario funcionario)
        {
            _funcionarioDAL.AddFuncionario(funcionario);

            return Ok(new
            {
                funcionario.Nome,
                funcionario.Cidade,
                funcionario.Departamento
            });
        }

    }
}
