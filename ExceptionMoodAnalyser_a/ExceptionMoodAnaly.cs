using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser_a
{
    public class ExceptionMoodAnaly:Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE, Empty_Message, NO_SUCH_CLASS, NO_SUCH_METHOD
        }

        ////Creating 'type' variable of type ExceptionType
        private readonly ExceptionType type;

        public ExceptionMoodAnaly(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }
    }
}
