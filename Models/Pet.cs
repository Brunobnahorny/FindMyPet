using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FindMyPet.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public string PhotoExt { get; set; }
        public Owner Owner { get; set; }
        [JsonIgnore]
        public ICollection<GeoLocation> LastGeoLocations { get; set; } = new List<GeoLocation>();
        public Pet()
        {
        }

        public Pet(string petName, string photoExt, Owner owner)
        {
            PetName = petName;
            PhotoExt = photoExt;
            Owner = owner;
        }
    }
}