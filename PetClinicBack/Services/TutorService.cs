using PetDoor.Models;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace PetDoor.Services
{
    public class TutorService
    {
        private static AppDbContext _context;

        public static void addContext(AppDbContext context)
        {
            _context = context;
        }

        public static string validarTutor(Tutor tutor)
        {
            if (tutor == null) return "Objeto nulo";

            bool AtributoNulo =
                tutor.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string)pi.GetValue(tutor))
                .Any(value => string.IsNullOrEmpty(value));

            if (AtributoNulo)
                return "Atributo(s) nulo(s)";

            //if (!tutor.Genero.Equals("M") || !tutor.Genero.Equals("F"))
            //    return "Gênero inválido";

            if (DateTime.Now.Year - tutor.Aniversario.Year < 18)
                return "Menor de 18 anos";


            //Discutir se um veterionario pode ser Cliente
            var email = new EmailAddressAttribute();
            if (!email.IsValid(tutor.Email))
                return "Email inválido";
            else
            {
                if (_context == null)
                    return "Contexto Nulo";

                var emailExist = _context.Tutor.Any(x => x.Email == tutor.Email);
                if (emailExist)
                    return "Email já cadastrado";
            }

            if (!Funcoes.ValidarCpf(tutor.CPF))
                return "CPF inválido";
            else
            {
                var cpfExist = _context.Tutor.Any(x => x.CPF == tutor.CPF);
                if (cpfExist)
                    return "CPF já cadastrado";
            }

            //Criar função para validar Celular
            if (tutor.Celular.Length > 11)
                return "Celular inválido";

            
            if (!Funcoes.ValidarCep(tutor.CEP))
                return "Cep inválido";

            return "Ok";
        } 
        public static void notificicarTutor(Tutor tutor,Pet pet, Consulta consulta, string titulo, string dataAntiga = null, Vacina vacina = null)
        {
            string body = "";
            switch (titulo)
            {
                case "Consulta Agendada":
                    body = $"Olá, {tutor.Nome}! A consulta para o(a) {pet.Nome} " +
                        $"foi agendada para o dia {consulta.Data}";
                    break;
                case "Consulta Remarcada":
                    body = $"Olá, {tutor.Nome}! A consulta para o(a) {pet.Nome} " +
                        $"agendada para o dia {consulta.Data} foi remarcada " +
                        $"para o dia{dataAntiga}";
                    break;
                case "Consulta Desmarcada":
                    body = $"Olá, {tutor.Nome}! A consulta para o(a) {pet.Nome} " +
                       $"agendada para o dia {consulta.Data} foi desmarcada";
                    break;
                case "Vencimento Vacina":
                    body = $"Olá, {tutor.Nome}! A Vacina para o(a) {pet.Nome} " +
                        $"está para vencer no dia {vacina.DiaAplicacao.AddYears(1)}" +
                        $"contate-nos para a reaplicação da dose!";
                    break;
            }

                Funcoes.enviarEmail(tutor.Email, titulo, body);
        }
    }

}
