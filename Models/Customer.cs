using JsonParser.Models;
using JsonParser.Specification;
using Newtonsoft.Json;

namespace JsonParser.Models
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



        //Use a factory method to create a new Customer object from a JSON string
        public async Task<Customer> CreateCustomer(Customer data)
        {

            // Check if the customer already exists
            // this can also include any business rules for the customer creation
            var customerSpec = new CustomerSpec();
            var isSatisfied = await customerSpec.IsSatisfiedBy(data);
            if (isSatisfied == true)
            {

                // Create the customer
                var customer = new Customer
                {
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    PhoneNumber = data.PhoneNumber,
                    Address = new Address
                    {
                        Street = data.Address.Street 
                        City = data.Address.City,
                        State = data.Address.State,
                        ZipCode = data.Address.ZipCode
                    },

                    CustomerId = Guid.NewGuid().ToString()
                };

                return customer;
            }
            else
            {

                throw new Exception("Customer is not creation not valid");
            }


        }


    }
}