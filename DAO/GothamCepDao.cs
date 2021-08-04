using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ValidadorCep.Context;
using ValidadorCep.Models;

namespace ValidadorCep.DAO
{
    public class GothamCepDao
    {
        public void Adicionar(Endereco endereco)
        {
            using (var context = new HomeContext())
            {
                context.Enderecos.Add(endereco);
                context.SaveChanges();
            }
        }
    }
}