using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryForms.Classes
{
    public static class Factory
    {
        public static Dictionary<string, CustomerBase> dict = new Dictionary<string, CustomerBase>();

        public static CustomerBase CreateObj(string txt)
        {
            if (dict.Count == 0)
            {
                dict.Add("Lead", new CustomerLead());
                dict.Add("Customer", new Customer());
            }
            return dict[txt];
        }
    }
}
