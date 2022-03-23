using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser_a
{
    public class MoodAnalyserEx
    {

        public MoodAnalyserEx() { }
        private string message;
        
        public MoodAnalyserEx(string message)
        {
            this.message = message;
        }
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
