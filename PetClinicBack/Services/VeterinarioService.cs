using PetDoor.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetDoor.Services
{
    public class VeterinarioService
    {
        private static AppDbContext _context;

        public static void addContext(AppDbContext context)
        {
            _context = context;
        }

        public static string validarVeterinario(Veterinario veterinario)
        {
            if (veterinario == null) return "Objeto nulo";

            bool AtributoNulo =
                veterinario.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(veterinario))
                .Any(value => string.IsNullOrEmpty(value));

            if (AtributoNulo)
                return "Atributo(s) nulo(s)";

            if (DateTime.Now.Year - veterinario.Nascimento.Year < 18)
                return "Menor de 18 anos";

            var email = new EmailAddressAttribute();
            if (!email.IsValid(veterinario.Email))
                return "Email inválido";
            else
            {
                if (_context == null)
                    return "Contexto Nulo";

                var emailExist = _context.Tutor.Any(x => x.Email == veterinario.Email);
                if (emailExist)
                    return "Email já cadastrado";
            }

            if (!Funcoes.ValidarCpf(veterinario.CPF))
                return "CPF inválido";
            else
            {
                var cpfExist = _context.Tutor.Any(x => x.CPF == veterinario.CPF);
                if (cpfExist)
                    return "CPF já cadastrado";
            }

            //Criar função para validar Celular
            if (veterinario.Celular.Length > 11)
                return "Celular inválido";


            if (!Funcoes.ValidarCep(veterinario.CEP))
                return "Cep inválido";

            return "Ok";
        }
    }
}
