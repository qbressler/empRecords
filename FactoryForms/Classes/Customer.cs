using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryForms.Classes
{
    public class CustomerBase
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public virtual void Validate()
        {
            throw new NotImplementedException("Not implemented");
        }
    }

    public class CustomerLead : CustomerBase
    {
        public override void Validate()
        {
            if(CustomerName.Length == 0 )
            {
                throw new Exception("Customer Name is required!");
            }
        }
    }

    public class Customer : CustomerBase
    {
        public override void Validate()
        {
            if (CustomerName.Length == 0)
                throw new Exception("Customer Name is required!");

            if (CustomerAddress.Length == 0)
                throw new Exception("Customer Address is required");
        }

    }
}
