namespace Storing_and_retriving_Web_Api.Model
{
    public class AddContactDTOs
    {

        public required string Name { get; set; }

        public string? Email { get; set; }

        public required string Phone { get; set; }

        public bool Favorite { get; set; }
    }
}
