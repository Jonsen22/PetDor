using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PetShopBack.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VacinesEnum
    {
        [EnumMember(Value = "Canine distemper virus (CDV)")]
        CDV =1,
        [EnumMember(Value = "Canine adenovirus (CAV)")]
        CAV = 2,
        [EnumMember(Value = "Canine Parvovirus (CPV-2)")]
        CPV2 = 3,
        [EnumMember(Value = "Feline parvovirus (FPV)")]
        FPV = 4,
        [EnumMember(Value = "Feline calicivirus (FCV)")]
        FCV = 5,
        [EnumMember(Value = "Feline herpesvirus (FHV-1)")]
        FHV1 = 6,
    }
}
