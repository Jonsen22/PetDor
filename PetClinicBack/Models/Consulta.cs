using PetShopBack.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinicBack.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public string Descricao { get; set; }
        public char Presente { get; set; }
        public int Custo { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
        public Pet Pet { get; set; }
        [ForeignKey("AgendaId")]
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }
    }
}
