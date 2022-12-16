using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetDoor.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public int Ano { get; set; }
        [ForeignKey("VeterinarioId")]
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }
        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
