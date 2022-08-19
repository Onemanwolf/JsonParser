using JsonParser.Models;
using Newtonsoft.Json;

namespace JsonParser.Parser
{
    public class Customer
    {

        public string CustomerId { get; set; }

        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phone")]
        public string? PhoneNumber { get; set; }
        [JsonProperty("address")]
        public Address? Address { get; set; }



        public async Task<Customer> CreateCustomer(Customer data)
        {

            // Check if the customer already exists
            var exist = await CustomerEmailExist(data.Email);
             if(exist == true){
                throw new Exception("Email already exist");
             }
            // Create the customer
            var customer = new Customer
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                Address = new Address
                {
                    Street = data.Address.Street,
                    City = data.Address.City,
                    State = data.Address.State,
                    ZipCode = data.Address.ZipCode
                },

                CustomerId = Guid.NewGuid().ToString()
            };

            return customer;
        }

        private async Task<bool> CustomerEmailExist(string email)
        {
            if(email == "timothy.oleson@gmail.com"){
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}