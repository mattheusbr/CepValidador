using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ValidadorCep.Models;

namespace ValidadorCep.Context
{
    public class HomeContext : DbContext
    {
        public HomeContext() : base("name=HomeContext")
        {
        }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}