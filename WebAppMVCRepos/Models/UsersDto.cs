namespace WebAppMVCRepos.Models
{
    public class UsersDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }  // dropdown 
    }
}
