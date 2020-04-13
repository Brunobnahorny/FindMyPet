using System.Collections.Generic;

namespace findmypet.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Pet> Pets { get; set; }

        public Owner()
        {            
        }

        public Owner(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;            
        }
    }
}