using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TreinamentoADONET.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cidade { get; set; }
        public string Departamento { get; set; }
    }
}
