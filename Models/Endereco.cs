using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidadorCep.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CEP { get; set; }

        [Required]
        public string Cidade { get; set; }
    }
}