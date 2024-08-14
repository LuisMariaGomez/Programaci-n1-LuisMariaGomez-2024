using CDatos.Repositories.Contracts;
using CEntidades.Entidades;
using CLogica.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Implementations
{
    public class CreacionPersonaLogic : ICreacionPersonaLogic
    {
        private readonly ICreacionPersonaRepository _personaRepository;

        public CreacionPersonaLogic(ICreacionPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public void AltaPersona(Persona personaNueva)
        {
            if (DocumentoExistente(personaNueva.Documento))
                throw new ArgumentException("Ya existe una Persona ligada a este documento");

            ValidarDatosPersona(personaNueva);

            Persona persona = new Persona
            {
                Nombre = personaNueva.Nombre,
                Apellido = personaNueva.Apellido,
                Nacionalidad = personaNueva.Nacionalidad,
                Documento = personaNueva.Documento,
                TipoDocumento = personaNueva.TipoDocumento,
                Telefono = personaNueva.Telefono,
                Email = personaNueva.Email,
            };
            _personaRepository.Update(persona);
            _personaRepository.Save();
        }




        // Precheck de validar los datos 
        private void ValidarDatosPersona(Persona persona)
        {
            if (string.IsNullOrEmpty(persona.Nombre) || !IsValidStrinng_withLessThanXLetters(persona.Nombre, 15))
                throw new ArgumentException("Nombre inválido");

            if (string.IsNullOrEmpty(persona.Apellido) || !IsValidStrinng_withLessThanXLetters(persona.Apellido, 15))
                throw new ArgumentException("Apellido inválido");

            if (string.IsNullOrEmpty(persona.Documento) || !IsValidDocumento(persona.Documento))
                throw new ArgumentException("Documento inválido");

            if (string.IsNullOrEmpty(persona.Telefono) || !IsValidTelefono(persona.Telefono))
                throw new ArgumentException("Teléfono inválido");

            if (string.IsNullOrEmpty(persona.Email) || !IsValidEmail(persona.Email))
                throw new ArgumentException("Email inválido");
        }
        public bool IsValidStrinng_withLessThanXLetters(string word, int num_letters)
        {
            return ContieneCaracter(word) && word.Length < num_letters;
        }

        private bool IsValidDocumento(string documento)
        {
            return documento.Length != 8 && ContieneCaracter(documento);
        }

        private bool IsValidTelefono(string telefono)
        {
            return telefono.Length != 10 && ContieneCaracter(telefono);
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains('@') && ContieneCaracter(email);
        }
        public bool ContieneCaracter(string text)
        {
            char[] caracteres = { '!', '"', '#', '$', '%', '&', '/', '(', ')', '=', '.', ',', };
            return caracteres.Any(p => text.Contains(p));
        }
        private bool DocumentoExistente(string documento)
        {
            var personas = _personaRepository.FindByCondition(p => p.Documento == documento);
            return personas.Count() > 0; // Verifica si hay alguna persona con el documento especificado
        }

    }
}
