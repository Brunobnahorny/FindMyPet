namespace FindMyPet.Models
{
    public class GeoLocation
    {
        public int GeoLocationId { get; set; }
        public int accuracy { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string timeStamp { get; set; }
        public Pet Pet { get; set; }
    }
}