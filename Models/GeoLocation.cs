namespace FindMyPet.Models
{
    public class GeoLocation
    {
        public int GeoLocationId { get; set; }
        public int Accuracy { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeStamp { get; set; }
        public Pet Pet { get; set; }

        public GeoLocation()
        {
        }

        public GeoLocation(int accuracy, string latitude, string longitude, string timeStamp, Pet pet)
        {
            Accuracy = accuracy;
            Latitude = latitude;
            Longitude = longitude;
            TimeStamp = timeStamp;
            Pet = pet;
        }
    }
}