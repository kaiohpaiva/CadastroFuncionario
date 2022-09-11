using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionario.Data.Model
{
    public class Funcionario
    {
        public int CodFuncionario { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
        public string Atividades { get; set; }
    }
}
