using Newtonsoft.Json;


namespace JsonParser.Parser
{

    public class JsonFileParser : IJsonFileParser<Customer>
    {

        public async Task<Customer> ParseFile(string path)
        {

            var json = await File.ReadAllTextAsync(path);
            var data = JsonConvert.DeserializeObject<Customer>(json);
            // TODO make this a customer factory and use dependency injection
            var customer = new Customer();
            if (data == null)
            {
                throw new Exception("File is empty");
            }

            //  Use factory method pattern here for complex objects and to enforce business rules
            var customerFromFile = await customer.CreateCustomer(data);
            return customerFromFile;

        }
    }
}