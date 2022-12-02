using Newtonsoft.Json;
using PetShopBack.Models;
using System.Collections.Generic;

namespace PetClinicBack.Models
{
    public class TipoVacina
    {
        public int TipoVacinaId { get; set; }
        public string Nome { get; set; }
        public string Iniciais { get; set; }
        public int Estoque { get; set; }
        public int Validade { get; set; }
        [JsonIgnore]
        public ICollection<Vacina> Vacinas { get; set; }
    }
}
