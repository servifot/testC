using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection.Clases
{
    public class Computer
    {
        public string Id { get; set; }
        public string Cpu { get; set; }
        public string Hdd { get; set; }
        public string Ram { get; set; }

        public Computer(string id, string cpu, string hdd, string ram)
        {
            Id = id;
            Cpu = cpu;
            Hdd = hdd;
            Ram = ram;
        }
    }
}
