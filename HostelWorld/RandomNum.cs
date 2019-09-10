using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
namespace HostelWorld
{
    class RandomNum
    {

        [Test]

        public void RanNumCheck()
        {

            //Read the parameter values from the appSettings file
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            var inputfile = config["inputfile"];
            var outputfile = config["outputfile"];

            //Initialize the Output file
            StreamWriter cf = new StreamWriter(outputfile, true);
            cf.Close();

            //Search the testcase keyword in the output file to get the test run count
            string text = File.ReadAllText(outputfile).ToLower();
            int cnt = Regex.Matches(text, @"\btestcase\b").Count;
            Console.WriteLine(cnt);
            int TestCaseNum = cnt + 1;

            // Read the Input file each line by line and run validation
            StreamWriter sw = new StreamWriter(outputfile, true);
            string line;
            string TestResultPass = "";
            string TestResultFail = "";
            string ErrorLineValues = "";
            StreamReader file = new StreamReader(inputfile);
            while ((line = file.ReadLine()) != null)
            {
                string[] items = line.Split('\t');

                if (items[0].All(char.IsDigit) && items[1].All(char.IsDigit))
                {
                    int Num = Int32.Parse(items[1]);
                    if (Num >= 100 && Num <= 500)
                    {
                        TestResultPass = "TestCase" + " " + TestCaseNum.ToString() + ": Passed";

                    }
                    else
                    {

                        TestResultFail = "TestCase" + " " + TestCaseNum.ToString() + ": Failed";
                        TestResultPass = "";
                        ErrorLineValues = ErrorLineValues + "Line " + items[0] + ": " + items[1] + $" - Error:<{items[1]} does not fall between range [100 - 500]>" + "\r\n";
                    }


                }


                else
                {

                    TestResultFail = "TestCase" + " " + TestCaseNum.ToString() + ": Failed";
                    TestResultPass = "";
                    ErrorLineValues = ErrorLineValues + "Line " + items[0] + ": " + items[1] + " - Error:<Either or Both of them are Non-Numeric>" + "\r\n";

                }


            }
            if (!string.IsNullOrEmpty(TestResultFail))
            {
                sw.WriteLine(TestResultFail);
                sw.WriteLine(ErrorLineValues);
            }
            else
            {
                sw.WriteLine(TestResultPass);
            }

            sw.Close();
            file.Close();

        }
    }
}
