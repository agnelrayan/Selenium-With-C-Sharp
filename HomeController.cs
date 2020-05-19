using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTraining
{
    class HomeController
    {
        public string GetEmployeeName(int empId)
        {
            string name;
            if (empId == 1)
            {
                name = "Arul";
            }
            else if (empId == 2)
            {
                name = "Rakesh";
            }
            else
            {
                name = "Not Found";
            }
            return name;
        }

        public string GetName(string first, string last)
        {
            return string.Concat(first," ",last);
        }
    }
}
