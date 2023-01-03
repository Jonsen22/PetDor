using PetDoor.Models;
using System;
using System.Linq;

namespace PetDoor.Services
{
    public class ConsultaService
    {
        private static AppDbContext _context;
        public static void addContext(AppDbContext context)
        {
            _context = context;
        }

        //RN-02 : Os usuários não poderão cancelar
        //ou alterar consultas com menos de 12 horas de antecedência.
        public static bool consultaMenosdeDozeHoras(Consulta consulta)
        {
            if (DateTime.Now.Hour - consulta.Data.Hour < 12)
                return false;

            return true;
        }
    }
}
