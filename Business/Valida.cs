using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ValidadorCep.Business
{
    public class Valida
    {
        public bool IsValidCep(string cep)
        {
            if (!Regex.IsMatch(cep, @"^[1-9][\d]{5}$"))
                return false;
            var cepVerdadeiro = true;
            foreach (var i in Enumerable.Range(0, 4))
            {
                if (cep.Substring(i, 1) == cep.Substring(i + 2, 1))
                    cepVerdadeiro = false;
            }                                
            return cepVerdadeiro;
        }
    }
}