using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiConta.Models
{
    [Table("Conta")]
    public class Conta
    {
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(250)] 
        public string Descricao { get; set; }

    }
}