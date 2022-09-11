using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroFuncionario.Data.Model;

namespace CadastroFuncionario.Interface
{
    public interface IFuncionario
    {
        List<Funcionario> BuscaFuncionario(string nome);
        void CriarFuncionario(Funcionario funcionario);
        void AlterarFuncionario(Funcionario funcionario);
        void DeleteFuncionario(int codFuncionario);
    }
}
