using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionMoodAnalyser7;
namespace ExceptionMoodAnalyse
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           
                //Arrange 
                string expected = "SAD";
                string message = " I am in Sad Mood";
               MoodAnalyser  moodAnalyze = new MoodAnalyser(message);

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
                MoodAnalyser moodAnalyze = new MoodAnalyser(message);

                //Act
                string mood = moodAnalyze.AnalyzeMood();

                //Assert
                Assert.AreEqual(expected, mood);
            }
            /// <summary>
            ///  TC 3.1: Given NULL Mood Should Throw MoodAnalysisException.
            /// </summary>
            [TestMethod]
            public void NULL_MOOD_Throw_MoodAnalysisException()
            {
                try
                {
                    string? message = null;
                    MoodAnalyser moodAnalyze = new MoodAnalyser(message);
                    string mood = moodAnalyze.AnalyzeMood();
                }
                catch (ExceptionMoodAnaly e)
                {
                    Assert.AreEqual("Mood should not be null", e.Message);
                }
            }
            /// <summary>
            /// TC 3.2: Given Empty Mood Should Throw MoodAnalysisException Indicating Empty Mood.
            /// exception using reflecction
            /// </summary>
            [TestMethod]
            public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
            {
                try
                {
                    string message = "";
                    MoodAnalyser moodAnalyze = new MoodAnalyser(message);
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
                object expected = new MoodAnalyser();
                object obj = FactoryException.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse", "MoodAnalyse");
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
                    object moodAnalyseObject = FactoryException.CreateMoodAnalyse("MoodAnalyzerApp.DemoClass", "DemoClass");

                }
                catch (ExceptionMoodAnaly exception)
                {
                    Assert.AreEqual(expected, exception.Message);
                }
            }


            /// <summary>
            /// Test Case 4.3 Given Improper Constructor should throw MoodAnalysisException.
            /// </summary>
            [TestMethod]
            public void GivenImproperConstructorShouldThrowMoodAnalysisException()
            {

                string expected = "Constructor is Not Found";
                try
                {
                    object moodAnalyseObject = FactoryException.CreateMoodAnalyse("DemoClass", "MoodAnalyse");
                }
                catch (ExceptionMoodAnaly exception)
                {
                    Assert.AreEqual(expected, exception.Message);
                }
            }
            /// <summary>
            /// Test Case 5.1 Given MoodAnalyse Class Name Should Return MoodAnalyser Object.
            /// </summary>
            [TestMethod]
            public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
            {
                object expected = new MoodAnalyser("HAPPY");
                object obj = FactoryException.ParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyze",
                    "MoodAnalyse", "HAPPY");
                expected.Equals(obj);
            }

            /// <summary>
            /// Test Case 5.2 Given Improper Class Name Should throw MoodAnalyssiException.
            /// </summary>
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

            /// <summary>
            /// Test Case 5.3 Given Improper Constructor Name Should throw MoodAnalyssiException.
            /// </summary>
            [TestMethod]
            public void GivenImproperConstructorNameShouldThrowMoodAnalysisException_UsingParameterizedConstructor()
            {
                string expected = "Constructor is Not Found";
                try
                {
                    object moodAnalyseObject = FactoryException.ParameterizedConstructor("MoodAnalyzerProblem.MoodAnalyze",
                        "DemoConstructor", "HAPPY");

                }
                catch (ExceptionMoodAnaly exception)
                {
                    Assert.AreEqual(expected, exception.Message);
                }
            }


            /// <summary>
            /// Test Case 6.1 Given Happy Should Return Happy.
            /// </summary>
            [TestMethod]
            public void GivenHappyMoodShouldReturnHappy()
            {
                string expected = "HAPPY";
                string mood = FactoryException.InvokeAnalyseMood("Happy", "AnalyseMood");
                Assert.AreEqual(expected, mood);
            }

        /// <summary>
        /// Test Case 6.2 Given Happy Should Return Happy.
        /// </summary>
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