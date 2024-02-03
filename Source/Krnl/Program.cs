
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace KRNLBootstrapper
{
    public static class Utils
    {
        // Function to download file from given URL and save it to specified path
        public static bool DownloadFile(string url, string path)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(url), path);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error downloading file: " + e.Message);
                return false;
            }
        }

        // Function to extract ZIP file to specified path
        public static bool ExtractZip(string zipPath, string extractPath)
        {
            try
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error extracting ZIP file: " + e.Message);
                return false;
            }
        }

        // Function to delete file at specified path
        public static bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting file: " + e.Message);
                return false;
            }
        }

        // Function to check if file exists at specified path
        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        // Function to check if directory exists at specified path
        public static bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        // Function to create new empty directory at specified path
        public static bool CreateDirectory(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating directory: " + e.Message);
                return false;
            }
        }

        // Function to delete directory at specified path
        public static bool DeleteDirectory(string path)
        {
            try
            {
                Directory.Delete(path, true);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error deleting directory: " + e.Message);
                return false;
            }
        }

        // Function to execute command line command
        public static string ExecuteCommand(string command)
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + command;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error executing command: " + e.Message);
                return "";
            }
        }

        // Function to write text to specified file
        public static bool WriteToFile(string path, string text)
        {
            try
            {
                File.WriteAllText(path, text);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing to file: " + e.Message);
                return false;
            }
        }

        // Function to initiate timer with specified interval and action
        public static void StartTimer(int interval, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += (sender, e) => action();
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        // Function to wait for specified time in milliseconds
        public static void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
