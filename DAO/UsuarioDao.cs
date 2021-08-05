using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ValidadorCep.Context;
using ValidadorCep.Models;

namespace ValidadorCep.DAO
{
    public class UsuarioDao
    {
        public Usuario Buscar(Usuario usuario)
        {
            using (var contexto = new HomeContext())
            {
                return contexto.Usuarios.FirstOrDefault(u => u.Login == usuario.Login && u.Senha == usuario.Senha);
            }
        }

        public void Adiciona(Usuario usuario)
        {
            using (var context = new HomeContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        public bool BuscarLoginExistente(Usuario usuario)
        {
            using (var context = new HomeContext())
            {
                if (context.Usuarios.Where(x => x.Login == usuario.Login && usuario.Id != x.Id).Count() > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}