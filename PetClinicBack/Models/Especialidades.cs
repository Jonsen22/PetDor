using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetDoor.Models
{
    public class Especialidades
    {
        public int EspecialidadesId { get; set; }
        public string EspecialidadesNome { get; set; }
        [JsonIgnore]
        public virtual ICollection<VetEspecialidades> VetEspecialidades { get; set; }
    }
}
