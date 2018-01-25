using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EventLogCleaner {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("This program will remove the Cyberarms EventLog. This can not be undone.");
            Console.WriteLine("Are you sure that you want to continue? y/N");
            if (Console.ReadKey().Key == ConsoleKey.Y) {
                Console.WriteLine("Are you really sure? (y/N)");
                if (Console.ReadKey().Key == ConsoleKey.Y) {
                    try {
                        if (EventLog.Exists("Cyberarms Intrusion Detection")) {
                            EventLog.DeleteEventSource("Cyberarms Intrusion Detection");
                            Console.WriteLine("EventSource 'Cyberarms Intrusion Detection' was deleted");
                        } else {
                            Console.WriteLine("EventSource 'Cyberarms Intrusion Detection' was not found on this computer");
                        }
                        if (EventLog.Exists("Cyberarms")) {
                            EventLog.Delete("Cyberarms");
                            Console.WriteLine("Event Log 'Cyberarms' was deleted. You might have to restart your computer");
                            Console.WriteLine(@"and delete the event log file at %systemroot%\system32\winevt\Logs\Cyberarms.evtx");
                        } else {
                            Console.WriteLine("Event Log 'Cyberarms' was not found on this computer.");
                        }
                        Console.WriteLine("The command has executed successfully");
                    } catch (Exception ex) {
                        Console.WriteLine("Sorry, we have a problem. Details:\r\n{0}", ex.Message);
                    } finally { }
                    return;
                }
                

            }
            Console.WriteLine("Please be sure to use this utility ONLY when advised by Cyberarms support personel.");
        }
    }
}
