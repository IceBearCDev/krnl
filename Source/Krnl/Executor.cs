using System;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.ComponentModel;

namespace KRNL
{
    class Executor
    {
        private const string BaseUrl = "https://krnl.rocks/";
        private const string BootstrapperExe = "krnl_bootstrapper.exe";

        private const string TempFolder = "krnl-executor";

        // Path to the bootstrapper exe file
        private static string BootstrapperPath = Path.Combine(TempFolder, BootstrapperExe);

        private static bool CheckBootstrapper()
        {
            if (!Directory.Exists(TempFolder))
            {
                return false;
            }

            if (!File.Exists(BootstrapperPath))
            {
                return false;
            }

            return true;
        }

        private static void DownloadBootstrapper()
        {
            if (!Directory.Exists(TempFolder))
            {
                Directory.CreateDirectory(TempFolder);
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(BaseUrl + BootstrapperExe, BootstrapperPath);
            }
        }

        private static void RunBootstrapper()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = BootstrapperPath;
            startInfo.Verb = "runas";

            using (Process bootstrapper = Process.Start(startInfo))
            {
                bootstrapper.WaitForExit();
            }
        }

        private static void WaitForBootstrapper()
        {
            // Creates a process object for the bootstrapper
            Process bootstrapper = new Process();
            bootstrapper.StartInfo.FileName = BootstrapperPath;
            bootstrapper.EnableRaisingEvents = true; // Enables the Exited event
            bootstrapper.Exited += Bootstrapper_Exited; // Registers the Exited event handler

            bootstrapper.Start(); // Starts the bootstrapper process
        }

        private static void Bootstrapper_Exited(object sender, EventArgs e)
        {
            Directory.Delete(TempFolder, true);

            Console.WriteLine("KRNL executor has been successfully installed.");
            StartExecutor();
        }

        private static void StartExecutor()
        {
            string executorPath = Path.Combine(Environment.CurrentDirectory, "krnl.exe");

            using (Process executor = new Process())
            {
                executor.StartInfo.FileName = executorPath;
                executor.StartInfo.Verb = "runas"; // Runs the process as admin

                executor.Start();
            }
        }

        // Main method
        static void Main(string[] args)
        {
            if (!CheckBootstrapper())
            {
                // Downloads the bootstrapper
                Console.WriteLine("Downloading KRNL executor bootstrapper...");
                DownloadBootstrapper();
                Console.WriteLine("Bootstrapper downloaded.");

                RunBootstrapper();
                WaitForBootstrapper();
            }
            else
            {
                Console.WriteLine("KRNL executor is already installed. Starting...");
                StartExecutor();
            }
        }
    }
}
