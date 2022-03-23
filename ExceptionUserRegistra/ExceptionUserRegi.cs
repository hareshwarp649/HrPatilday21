using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionUserRegistra
{
    public class ExceptionUserRegi:Exception
    {
       
            public ExceptionType type;
            //Enumeration
            public enum ExceptionType
            {
                EXCEPTION
            }
            //Exception class Constructor.
            public ExceptionUserRegi(ExceptionType type, string message) : base(message)
            {
                this.type = type;
            }
        

    }
}
