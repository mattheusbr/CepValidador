using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Endereco> BuscarTodosEnderecos()
        {
            using (var context = new HomeContext())
            {
                return context.Enderecos.ToList();
            }
        }

        public Endereco BuscarEnderecoPorId(int? id)
        {
            using (var context = new HomeContext())
            {
                return context.Enderecos.Find(id);
            }
        }

        public void Atualizar(Endereco endereco)
        {
            using (var contexto = new HomeContext())
            {
                contexto.Entry(endereco).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            var endereco = BuscarEnderecoPorId(id);
            using (var contexto = new HomeContext())
            {
                contexto.Entry(endereco).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}