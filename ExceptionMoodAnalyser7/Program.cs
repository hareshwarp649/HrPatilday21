using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser7
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exception Handling In  MoodAnalyser Problem");
            Console.WriteLine("--------------Welcome To Mood Analyzer Problem------------");
            MoodAnalyser moodAnalyze = new MoodAnalyser("I am in Happy Mood");
            string mood = moodAnalyze.AnalyzeMood();

            Type type = typeof(MoodAnalyser);
            Console.WriteLine(type.FullName);

        }
    }
}
