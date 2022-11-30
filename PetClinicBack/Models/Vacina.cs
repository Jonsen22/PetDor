using PetClinicBack.Models;
using PetShopBack.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopBack.Models
{
    public class Vacina
    {
        public int VacinaId { get; set; }
        public DateTime DiaAplicacao { get; set; }
        [ForeignKey("TipoVacinaId")]
        public int TipoVacinaId { get; set; }
        public TipoVacina TipoVacina { get; set; }
        [ForeignKey("PetId")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
