using PetDoor.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetDoor.Models
{
    public class Consulta
    {
        public int ConsultaId { get; set; }
        public string Descricao { get; set; } = null!;
        public char Presente { get; set; }
        public int Custo { get; set; }
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
        [ForeignKey("PetId")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        [ForeignKey("AgendaId")]
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }
    }
}
