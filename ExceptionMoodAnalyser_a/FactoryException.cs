using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExceptionMoodAnalyser_a
{
    public class FactoryException
    {
        /// <summary>
        ///  method to create object of MoodAnalyse class.
        /// </summary>
        /// <param name="className">MoodAnalyseFactory</param>
        /// <param name="constructorName">CreateMoodAnalyse</param>
        /// <returns></returns>
        public static object MoodAnalyseObject(string className, string constructorName)
        {
            string name = @"." + constructorName + "$";
            bool result = Regex.IsMatch(className, name);
            if (result)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyseType = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyseType);
                }
                catch (ArgumentNullException)
                {
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_CLASS, "No such class found");
                }
            }
            else
            {
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
        }

        public static object ParameterizedConstructor(string className, string constructorName, string message = "")
        {
            Type type = typeof(MoodAnalyserEx);
            if (type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo info = type.GetConstructor(new[] { typeof(string) });
                    object instance = info.Invoke(new object[] { (message) });
                    return instance;
                }
                else
                    throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_METHOD, "Constructor not found");
            }
            else
                throw new ExceptionMoodAnaly(ExceptionMoodAnaly.ExceptionType.NO_SUCH_CLASS, "No such class found");
        }

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
