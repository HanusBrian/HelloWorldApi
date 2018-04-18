using System;
using System.Collections.Generic;
using HelloWorldClient;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayDemo();
            Console.Clear();

            PlayInteractiveDemo();
        }

        public static void PlayDemo()
        {
            // Cannot call await from Main method so workaround with GetAwaiter

            // Get Hello World string
            Console.WriteLine(Api.GetMessage("Messages", 1).GetAwaiter().GetResult());
            Console.WriteLine();

            Console.WriteLine("Press any key to search for key = 5...");
            Console.ReadKey();
            Console.WriteLine();

            // Get key not found
            Console.WriteLine(Api.GetMessage("Messages", 5).GetAwaiter().GetResult());
            Console.WriteLine("Press any key to print all messages...");
            Console.ReadKey();

            PrintAllMessages();
            Console.WriteLine("Press any key to post a new message...");
            Console.ReadKey();

            Console.WriteLine(Api.PostMessage("Messages", "New Message").GetAwaiter().GetResult() + " has been added...");
            Console.WriteLine("Printing all messages...");

            PrintAllMessages();
            Console.WriteLine("Press any key to update a message...");
            Console.ReadKey();

            Console.WriteLine(Api.PutMessage("Messages", 2, "Put Message").GetAwaiter().GetResult() + " has been updated on key 2...");
            PrintAllMessages();
            Console.WriteLine("Press any key to delete a message...");
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Delete Message");
            Console.WriteLine(Api.DeleteMessage("Messages", 1).GetAwaiter().GetResult() + " has been deleted");
            PrintAllMessages();

            Console.WriteLine("Demo completed, press any key for the main menu...");
            Console.ReadKey();
        }

        public static void PlayInteractiveDemo()
        {
            System.ConsoleKeyInfo choice;
            do
            {
                Console.WriteLine("(G)et all messages\nG(e)t one message\n(P)ost message\nP(u)t message\n(D)elete message\n(Q)uit\n\n");
                choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.Key)
                {
                    case System.ConsoleKey.G:
                        {
                            PrintAllMessages();
                            break;
                        }
                    case System.ConsoleKey.E:
                        {
                            Console.WriteLine("Select (integer) Key value, then hit enter...");
                            string input = Console.ReadLine();
                            if (CheckIfNum(input))
                            {
                                Int32.TryParse(input, out int num);
                                Console.WriteLine(Api.GetMessage("Messages", num).GetAwaiter().GetResult());
                                Console.WriteLine();
                            }
                            break;
                        }
                    case System.ConsoleKey.P:
                        {
                            Console.WriteLine("Enter new message:");
                            string line = Console.ReadLine();
                            Console.WriteLine(Api.PostMessage("Messages", line).GetAwaiter().GetResult());
                            Console.WriteLine();

                            break;
                        }
                    case System.ConsoleKey.U:
                        {
                            Console.WriteLine("Select (integer) Key value, then hit enter...");
                            string input = Console.ReadLine();
                            if (CheckIfNum(input))
                            {
                                Int32.TryParse(input, out int num);
                                Console.WriteLine();
                                Console.WriteLine("Enter new message:");
                                string line = Console.ReadLine();
                                Console.WriteLine(Api.PutMessage("Messages", num, line).GetAwaiter().GetResult());
                                Console.WriteLine();
                            }
                            break;
                        }
                    case System.ConsoleKey.D:
                        {
                            Console.WriteLine("Select (integer) Key value, then hit enter...");
                            string input = Console.ReadLine();
                            if (CheckIfNum(input))
                            {
                                Int32.TryParse(input, out int num);
                                Console.WriteLine(Api.DeleteMessage("Messages", num).GetAwaiter().GetResult());
                                Console.WriteLine();
                            }
                            break;
                        }
                    case System.ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            } while (true);
        }

        public static bool CheckIfNum(string s)
        {
            if (!Int32.TryParse(s, out int num))
            {
                Console.WriteLine("Input must be an integer...");
                return false;
            }
            return true;
        }

        public static void PrintAllMessages()
        {
            List<string> all = Api.GetAllMessages("Messages").GetAwaiter().GetResult();
            Console.WriteLine();
            Console.WriteLine("All Messages");
            Console.WriteLine("------------");
            foreach (var m in all)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine();
        }
    }
}

