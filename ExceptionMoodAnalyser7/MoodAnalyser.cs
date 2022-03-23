using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser7
{
    public class MoodAnalyser
    {

        public MoodAnalyser() { }
        private string message;
        
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        //exception handle using analyzeMood method
        public string AnalyzeMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.Empty_Message, "Mood should not be Empty");
                }

                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NULL_MESSAGE, "Mood should not be null");
            }

        }
    }
}
