using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser7
{
    public class FactoryException
    {
        public static object CreateMoodAnalyse(string className, string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnaylseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnaylseType);
                }
                catch (ArgumentNullException)
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
                }
            }
            else
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
            }
        }

        //uc-5 added
        public static object ParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { "HAPPY" });
                    return instance;
                }
                else
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_METHOD, "Constructor is Not Found");
                }

            }
            else
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_CLASS, "Class Not Found");
            }

        }
        //uc-6 added the excetion handling is created 
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerProblem.MoodAnalyze");
                object moodAnalyseObject = FactoryException.ParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyze", "MoodAnalyze", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_METHOD, "Method is Not Found");
            }
        }
    }
}
