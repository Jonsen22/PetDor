using Newtonsoft.Json;
using PetDoor.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetDoor.Models
{
    public class VetEspecialidades
    {
        [ForeignKey("VeterinarioId")]
        public int VeterinarioId { get; set; }
        [JsonIgnore]
        public Veterinario Veterinario { get; set; }
        [ForeignKey("EspecialidadesId")]
        public int EspecialidadesId { get; set; }
        [JsonIgnore]
        public Especialidades Especialidade { get; set; }
    }
}
