namespace Web_API_1.Models
{
    public class AddContactModel
    {
        // ID is given by us not while adding
        public string FullName { get; set; }

        public string Email { get; set; }

        public long PhoneNumber { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string College { get; set; }
    }
}
