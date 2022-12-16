using System;
using System.Collections.Generic;

namespace PetDoor.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }
        public string Nome { get; set; }
        public char Genero { get; set; }
        public DateTime Aniversario { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; } //CPF
        public string Celular { get; set; }
        public string CEP { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
     }
}
