using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace FileChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("No Path Entered to Monitor will now exit....");
                Thread.Sleep(3000);
                System.Environment.Exit(1);
            }
            Console.WriteLine($"Monitoring {args[0]} .....");
            MonitorFiles monitor = new MonitorFiles(args[0]);
            do
            {
               if Console.ReadLine();
                
            }
            

           
            
            
        }
    }
}
