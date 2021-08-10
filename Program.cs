using System;
using System.Collections.Generic;
/*
 * Project: Project 3/ Assi3
 * Purpose: Demonstrates visitor, CoR, Command.
 * Coder: Sonia Friesen
 * Date: Due April 13th 2021
 */
namespace Assi3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Server> Servers = new List<Server>();
            Queue<Request> PendingRequests = new Queue<Request>();
            ServerQuery visitor = new ServerQuery();
            Console.WriteLine("Please enter a command.");
            string command = "";

            while (command != "quit")
            {
                string[] commandArgs = command.Split(":");
                Console.WriteLine();

                switch (commandArgs[0])
                {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("createserver\t\tCreate a new server.");
                        Console.WriteLine("deleteserver:[id]\tDelete server #ID.");
                        Console.WriteLine("listservers\t\tList all servers.");
                        Console.WriteLine("new:[path]:[payload]\tCreate a new pending request.");
                        Console.WriteLine("dispatch\t\tSend a pending request to a server.");
                        Console.WriteLine("server:[id]\t\tHave server #ID execute its pending request and print the result.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    case "createserver":
                        Servers.Add(new Server());
                        Console.WriteLine("Created Server " + (Servers.Count - 1));
                        break;
                    case "deleteserver":
                        int index = int.Parse(commandArgs[1]);
                        Servers.RemoveAt(index);
                        Console.WriteLine("Deleted Server " + index);
                        break;
                    case "listservers":
                        if (Servers.Count == 0)
                        {
                            Console.WriteLine("No servers in collection.");
                            break;
                        }
                        for (int i = 0; i < Servers.Count; ++i)
                            Console.WriteLine(i +"\tServer" );
                        break;
                    case "new":
                        string path = commandArgs[1];
                        int payload = int.Parse(commandArgs[2]);
                        PendingRequests.Enqueue(new Request(path, payload));
                        Console.WriteLine("Request created with data " + payload + " going to " + path);
                        break;
                    case "dispatch":
                        if(Servers.Count == 0)
                        {
                            Console.WriteLine("No servers to dispatch quest to");
                        }
                        if(PendingRequests.Count == 0)
                        {
                            Console.WriteLine("No Pending Requests to dispatch");
                        }
                        int counter = 0;
                       foreach(var server in Servers)
                        {
                            //if there are no more requests to be assigned
                            if(PendingRequests.Count == 0)
                            {
                                break;
                            }
                            if(visitor.ServerStatus(server))
                            {        
                                
                                server.SetRequest(PendingRequests.Peek());
                                Console.WriteLine($"Sent request to Server {counter}");
                                PendingRequests.Dequeue(); 
                                counter++;
                            }
                        }
                       if(counter == 0)
                        {
                            Console.WriteLine("no available servers");
                        }
                        break;
                    case "server":                        
                        index = int.Parse(commandArgs[1]);
                        if (!visitor.ServerStatus(Servers[index]))
                        {
                            Servers[index].ProcessWork();
                        }
                        else
                            Console.WriteLine($"Server {index} has no work to do");
                        break;
                    default:
                        if (command != "")
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();
            }
        }
    }
}
