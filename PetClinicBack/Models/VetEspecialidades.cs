using Newtonsoft.Json;
using PetShopBack.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicBack.Models
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
