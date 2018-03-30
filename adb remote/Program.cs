using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adb_remote
{
    class Program
    {
        private static string IPAddress;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome.");

            while (string.IsNullOrEmpty(IPAddress))
            {
                Console.Write("Please enter the IP Address of the ADB Device: ");
                IPAddress = Console.ReadLine();
            }

            adbCommand("kill-server");
            adbCommand("start-server");
            adbCommand("connect " + IPAddress);

            while (true)
            {
                Console.Clear();
                PrintMainMenu();

                ConsoleKeyInfo cki;
                cki = Console.ReadKey();

                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        RemoteControlMode();
                        break;

                    case ConsoleKey.D2:
                        ADBMode();
                        break;

                    case ConsoleKey.D3:
                        ExitApplication();
                        break;

                    default:
                        PrintMainMenu();
                        break;
                }
            }
        }

        private static void adbCommand(string adbCommand)
        {
            ADB_Lib.ADBCommand.ExecuteAdbCommand(adbCommand);
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("Connected to: " + IPAddress);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1) Remote Control");
            Console.WriteLine("2) ADB Mode");
            Console.WriteLine("3) Exit");
        }

        private static void ADBMode()
        {
            Console.Clear();
            Console.WriteLine("ADB Mode (Press F5 for Menu)");

            bool getOut = false;
            while (!getOut)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key != ConsoleKey.F5)
                {
                    string command = Console.ReadLine();
                    adbCommand(command);
                }
                else
                {
                    getOut = true;
                }

            }
        }

        private static void RemoteControlMode()
        {
            Console.Clear();
            Console.WriteLine("Remote Control Mode (Press F5 for Menu)");

            bool getOut = false;
            while (!getOut)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                ADB_Lib.ADBCommand.ADBActionKey(cki.Key);
            }
        }

        private static void ExitApplication()
        {
            adbCommand("disconnect");
            adbCommand("kill-server");
            Environment.Exit(0);
        }
    }
}
