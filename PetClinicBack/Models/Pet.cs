using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopBack.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Nome { get; set; }
        public char Genero { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Castrado { get; set; } //castrado
        public string Animal { get; set; } //gato, cachorro,etc
        public string Raca { get; set; } //raça
        public string Descricao { get; set; }
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Vacina> Vacinas { get; set; }
    }
}
