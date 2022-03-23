using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser_a
{
    public class Program
    {
        static void Main(string[] args)
        {
            ////Refactror a To intialize parameter
            Console.WriteLine("--------------Welcome To Mood Analyzer Problem------------");
            MoodAnalyserEx moodAnalyze = new MoodAnalyserEx("I am in Happy Mood");
            string mood = moodAnalyze.AnalyzeMood();

            Type type = typeof(MoodAnalyserEx);
            Console.WriteLine(type.FullName);
        }
    }
}
