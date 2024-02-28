using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwenBartleChallengeM7
{

    public class Customer
    {
            private string firstName;
            private string lastName;
            private string email;
            private string id;

            public Customer(string firstName, string lastName, string email, string id)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.email = email;
                this.id = id;
            }

            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }

            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }

            public string Email
            {
                get { return email; }
                set { lastName = value; }
            }

            public string Id
            {
                get { return id; }
                set { id = value; }
            }


        public string getDisplayText(int index)
        {
            return $"Number: {index + 1} Name: {firstName} {lastName} | Email: {email} | ID: {id}\n";

        }    
    }
}
