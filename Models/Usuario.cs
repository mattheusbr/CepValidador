using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValidadorCep.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }

        [Required(ErrorMessage = "Min 5 - Max 30 Caracteres"), StringLength(maximumLength: 30, MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }

}