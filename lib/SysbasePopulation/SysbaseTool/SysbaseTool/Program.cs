using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysbaseTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var populate = PopulateFactory.GetInstance();
            IPopulator brokerVisits = populate.BuildBrokerVisits();
            try
            {
                brokerVisits.Populate();
                Console.WriteLine("Press a key to confirm..");
                Console.ReadLine();

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
