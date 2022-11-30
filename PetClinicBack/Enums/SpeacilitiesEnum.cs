using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace PetShopBack.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpeacilitiesEnum
    {
        [EnumMember(Value = "Anesthesia and analgesia")]
        AnesthesiaAnalgesia = 1,
        [EnumMember(Value = "Animal welfare")]
        AnimalWelfare = 2,
        [EnumMember(Value = "Behavioral medicine")]
        BehavioralMedicine = 3,
        [EnumMember(Value = "Clinical pharmacology")]
        ClinicalPharmacology = 4,
        [EnumMember(Value = "Dentistry")]
        Dentistry = 5,
        [EnumMember(Value = "Dermatology")]
        Dermatology = 6,
        [EnumMember(Value = "Emergency and critical care")]
        Emergency = 7,
        [EnumMember(Value = "Internal medicine")]
        InternalMedicine = 8,
        [EnumMember(Value = "Laboratory animal medicine")]
        LaboratoryAnimal = 9,
        [EnumMember(Value = "Microbiology")]
        Microbiology = 10,
        [EnumMember(Value = "Nutrition")]
        Nutrition = 11,
        [EnumMember(Value = "Ophthalmology")]
        Ophthalmology = 12,
        [EnumMember(Value = "Pathology")]
        Pathology = 13,
        [EnumMember(Value = "Poultry veterinary medicine")]
        PoultryVeterinary = 14,
        [EnumMember(Value = "Preventive medicine")]
        Preventive = 15,
        [EnumMember(Value = "Radiology")]
        Radiology = 16,
        [EnumMember(Value = "Species-specialized veterinary practice")]
        SpeciesSpecialized = 17,
        [EnumMember(Value = "Sports medicine and rehabilitation")]
        SportsMedicine = 18,
        [EnumMember(Value = "Surgery")]
        Surgery = 19,
        [EnumMember(Value = "Theriogenology")]
        Theriogenology = 20,
        [EnumMember(Value = "Toxicology")]
        Toxicology = 21,
        [EnumMember(Value = "Zoological medicine")]
        ZoologicalMedicine = 22,
    }

    public class ListSpeacilities
    {
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        IList<SpeacilitiesEnum> Speacilities { get; set; }
    }
}


