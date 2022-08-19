using JsonParser.Models;

namespace JsonParser.Specification
{
    public class CustomerSpec : ISpecification<Customer>
    {
        public async Task<bool> IsSatisfiedBy(Customer customer)
        {
            // Apply business rules here in the IsSatisfiedBy method
             var exist = await CustomerEmailExist(customer.Email);
             // Business rule around if a customer address exit you cannot create a customer with the same address 
             var addressExist = await CustomerAddressExist(customer.Address);
             if(exist == true){
                throw new Exception("Email already exist");
             }else(addressExist == true){
                throw new Exception("Address already exist");


            throw new NotImplementedException();
         }
        }

         // We can even use a AddressSpec here if you do alot of address validation
        private async Task<bool> CustomerAddressExist(Address address){

          // Just example of how to use the specification pattern to check if an address already exist would add mothod to call out of address repository
          var isAddressStreet = await Task.Run(() =>  { return address.Street != string.Empty ? address.Street : "Need Street";});
           if (isAddressStreet == "Need Street"){
               return false;


            }
            return true;
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