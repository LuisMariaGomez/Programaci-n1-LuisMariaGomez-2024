using CEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Contracts
{
    public interface ICreacionPersonaLogic  //No hereda de nada porque no hay interfaz de logica generica
    {
        void AltaPersona(Persona persona)
        {

        }

        bool IsValidStrinng_withLessThanXLetters(string word, int num_letters);

        bool ContieneCaracter(string text);
    }
}

