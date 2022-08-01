namespace dotNetEndpoint.Models
{// Person model with .net 6 standards
    public class PersonModel
    {
        public string FirstName { get; set; } = "Mike";

        public string LastName { get; set; } = "Tyson";

        public AddressModel HomeAddress { get; set; } = new AddressModel();
        public sealed override string ToString()
        {
            return $"My name is {FirstName} {LastName}";
        }
    }
}
