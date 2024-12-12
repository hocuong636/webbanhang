using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_TH
{
    public class Person
    {
        private string id;
        private string name;
        private string address;
        private double asset;
        public Person(string id, string name, string address, double asset)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Asset = asset;
        }

        public global::System.String Id { get => id; set => id = value; }
        public global::System.String Name { get => name; set => name = value; }
        public global::System.String Address { get => address; set => address = value; }
        public global::System.Double Asset { get => asset; set => asset = value; }

    }
}
