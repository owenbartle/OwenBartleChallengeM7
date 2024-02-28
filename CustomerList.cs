using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwenBartleChallengeM7
{
    public class CustomerList
    {
        public delegate void ChangeHandler(CustomerList customers);
        public event ChangeHandler Changed;

        private List<Customer> customers;

        public CustomerList()
        {
            customers = new List<Customer>();
        }

        public int count => customers.Count;

        public Customer this[int index]
        {
            get { return customers[index]; }
            set { customers[index] = value; }
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
            onChanged();
        }

        public void Remove(Customer customer)
        {
            customers.Remove(customer);
            onChanged();
        }

        protected virtual void onChanged()
        {
           Changed?.Invoke(this);
        }
        
    }
}
