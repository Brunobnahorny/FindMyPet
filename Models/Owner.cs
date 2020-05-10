using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FindMyPet.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();

        public Owner()
        {
        }

        public Owner(string ownerName, string phone, string email)
        {
            OwnerName = ownerName;
            Phone = phone;
            Email = email;
        }
    }
}