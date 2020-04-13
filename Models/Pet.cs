namespace findmypet.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhotoExt { get; set; }

        public Owner Owner { get; set; }

        public Pet()
        {            
        }

        public Pet(string name, string location, string photoExt)
        {
            Name = name;
            Location = location;
            PhotoExt = photoExt;            
        }
        
    }
}