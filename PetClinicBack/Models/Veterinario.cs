using Newtonsoft.Json;
using PetClinicBack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShopBack.Models
{
    public class Veterinario
    {
        public int VeterinarioId { get; set; }
        public string Nome { get; set; }
        public char Genero { get; set; }
        public bool Ferias { get; set; }
        public DateTime Nascimento { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; } //CPF
        public string Celular { get; set; }
        public string CEP { get; set; }
        [JsonIgnore]
        public virtual ICollection<VetEspecialidades> VetEspecialidade { get; set; }
        [NotMapped]
        public virtual IEnumerable<Especialidades> Especialidades => VetEspecialidade?.Select(x => x.Especialidade);
    }
}
