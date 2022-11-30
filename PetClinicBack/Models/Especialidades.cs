using Newtonsoft.Json;
using PetShopBack.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinicBack.Models
{
    public class Especialidades
    {
        public int EspecialidadesId { get; set; }
        public string EspecialidadesNome { get; set; }
        [JsonIgnore]
        public virtual ICollection<VetEspecialidades> VetEspecialidades { get; set; }
    }
}
