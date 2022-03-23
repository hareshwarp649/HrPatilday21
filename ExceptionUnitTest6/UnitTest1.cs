using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionMoodAnalyser_a;
namespace ExceptionUnitTest6
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "SAD";
            string message = " I am in Sad Mood";
            MoodAnalyserEx moodAnalyze = new MoodAnalyserEx(message);

            //Act
            string mood = moodAnalyze.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, mood);

        }
        
        [TestMethod]
        [DataRow("I am in HAPPY Mood")]
        [DataRow(null)]
        public void ReturnHappy(string message)
        {
            //Arrange

            string expected = "HAPPY";
            MoodAnalyserEx moodAnalyze = new MoodAnalyserEx(message);

            //Act
            string mood = moodAnalyze.AnalyzeMood();

            //Assert
            Assert.AreEqual(expected, mood);
        }
        
        ///  TC 3.1: Given NULL Mood Should Throw MoodAnalysisException.
        
        [TestMethod]
        public void NULL_MOOD_Throw_MoodAnalysisException()
        {
            try
            {
                string? message = null;
                MoodAnalyserEx moodAnalyze = new MoodAnalyserEx(message);
                string mood = moodAnalyze.AnalyzeMood();
            }
            catch (ExceptionMoodAnaly e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }
       
        /// TC 3.2: Given Empty Mood Should Throw MoodAnalysisException Indicating Empty Mood.
       
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyserEx moodAnalyze = new MoodAnalyserEx(message);
                string mood = moodAnalyze.AnalyzeMood();
            }
            catch (ExceptionMoodAnaly e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }
        
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyserEx ();
            object obj = FactoryException.MoodAnalyseObject("MoodAnalyzerApp.MoodAnalyse", "MoodAnalyse");
            expected.Equals(obj);
        }

        /// <summary>
        ///  Test Case 4.2 Given Improper Class Name Should throw MoodAnalyssiException.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassNameShouldThrowMoodAnalysisException()
        {
            string expected = "Class Not Found";
            try
            {
                object moodAnalyseObject = FactoryException.MoodAnalyseObject("MoodAnalyzerApp.DemoClass", "DemoClass");

            }
            catch (ExceptionMoodAnaly exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }


        [TestMethod]
        public void GivenImproperConstructorShouldThrowMoodAnalysisException()
        {

            string expected = "Constructor is Not Found";
            try
            {
                object moodAnalyseObject = FactoryException.MoodAnalyseObject("DemoClass", "MoodAnalyse");
            }
            catch (ExceptionMoodAnaly exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
       
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyserEx("HAPPY");
            object obj =FactoryException.ParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyze",
                "MoodAnalyse", "HAPPY");
            expected.Equals(obj);
        }

        [TestMethod]
        public void GivenImproperClassNameShouldThrowMoodAnalysisException_UsingParameterizedConstructor()
        {
            string expected = "Class Not Found";
            try
            {
                object moodAnalyseObject = FactoryException.ParameterizedConstructor("MoodAnalyzerProblem.DemoClass",
                    "MoodAnalyze", "HAPPY");

            }
            catch (ExceptionMoodAnaly exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

       
        [TestMethod]
        public void GivenImproperConstructorNameShouldThrowMoodAnalysisException_UsingParameterizedConstructor()
        {
            string expected = "Constructor is Not Found";
            try
            {
                object moodAnalyseObject =FactoryException.ParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyze",
                    "DemoConstructor", "HAPPY");

            }
            catch (ExceptionMoodAnaly exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }


        
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = FactoryException.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

      
        [TestMethod]
        public void Given_ImproperMethodName_Should_Throw_MoodAnalysisException()
        {
            string expected = "Method is Not Found";
            try
            {
                string mood = FactoryException.InvokeAnalyseMood("Happy", "DemoMethod");
            }
            catch (ExceptionMoodAnaly e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

    }
}
