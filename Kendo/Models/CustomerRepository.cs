namespace Kendo.Models
{
    public class CustomerRepository
    {
        public List<CustomerModel> GetAllCustomer()
        {
            var customerList = new List<CustomerModel>()
            {
                new CustomerModel() { CustomerID = "1", ContactName = "Ash1", CompanyName = "ABC 1 Company", Country = "BD"},
                 new CustomerModel() { CustomerID = "2", ContactName = "Ash2", CompanyName = "ABC 2 Company", Country = "UK"},
                  new CustomerModel() { CustomerID = "3", ContactName = "Ash3", CompanyName = "ABC 3 Company", Country = "USA"},
                   new CustomerModel() { CustomerID = "4", ContactName = "Ash4", CompanyName = "ABC 4 Company", Country = "IND"},
                    new CustomerModel() { CustomerID = "5", ContactName = "Ash5", CompanyName = "ABC 5 Company", Country = "Japan"},
                     new CustomerModel() { CustomerID = "6", ContactName = "Ash6", CompanyName = "ABC 6 Company", Country = "BD"},
                      new CustomerModel() { CustomerID = "7", ContactName = "Ash7", CompanyName = "ABC 7 Company", Country = "BD"},
                       new CustomerModel() { CustomerID = "8", ContactName = "Ash8", CompanyName = "ABC 8 Company", Country = "BD"},
                        new CustomerModel() { CustomerID = "9", ContactName = "Ash9", CompanyName = "ABC 9 Company", Country = "BD"},
                         new CustomerModel() { CustomerID = "10", ContactName = "Ash10", CompanyName = "ABC 10 Company", Country = "BD"}
            };
            return customerList;
        }
    }
}
