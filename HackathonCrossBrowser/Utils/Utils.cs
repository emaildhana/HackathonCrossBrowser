using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace HackathonCrossBrowser
{
    public class Utils
    {
        public static string currentPath = Directory.GetCurrentDirectory();
        public static string projectFolder = Directory.GetParent(currentPath).Parent.FullName;
        public static string reportFileName = "TraditionalTestResults.txt";

        /// <summary>
        /// Method to write the report to a file
        /// </summary>
        /// <param name="taskNumber"></param>
        /// <param name="testName"></param>
        /// <param name="locatorID"></param>
        /// <param name="browserType"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="deviceType"></param>
        /// <param name="testStatus"></param>
        public static void HackathonReport(int taskNumber, string testName, string locatorID, 
            string browserType, int width, int height, string deviceType, string testStatus, string fileName)
        {
            //Create a file in the project folder and append the details 
            string filePath = Path.Combine(projectFolder, fileName);
            string reportText = $"{DateTime.UtcNow} Task: {taskNumber}, Test Name: {testName}, DOM Id: {locatorID}, Browser Type: {browserType}, Viewport: {width} x {height}, Device: {deviceType}, Status: {testStatus}";

            File.AppendAllText(filePath, reportText);
            File.AppendAllText(filePath, Environment.NewLine); 
        }


        public static void HackathonReport(string inputStr, string fileName)
        {
            string filePath = Path.Combine(projectFolder, fileName);
            File.AppendAllText(filePath, inputStr);
            File.AppendAllText(filePath, Environment.NewLine);

            File.AppendAllText(filePath, "----------------------------------------------------------------------------------------------------");
            File.AppendAllText(filePath, Environment.NewLine);
        }

        public static void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath); 
            }
            catch (DirectoryNotFoundException)
            {

                Console.WriteLine($"File is not present - {filePath}");
            }
        }

    }
}
