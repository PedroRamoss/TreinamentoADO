using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoADONET.Models;

namespace TreinamentoADONET.DAL
{
    public interface IFuncionarioDAL
    {
        IEnumerable<Funcionario> GetAllFuncionarios();
        void AddFuncionario(Funcionario funcionario);
    }
}
