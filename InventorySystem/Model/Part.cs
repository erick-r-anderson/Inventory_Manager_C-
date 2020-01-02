using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventorySystem
{
    [Serializable]
    public abstract class Part

    {
        [DataMember]
        protected int id;
        [DataMember]
        protected string name;
        [DataMember]
        protected double price;
        [DataMember]
        protected int stock;
        [DataMember]
        protected int min;
        [DataMember]
        protected int max;

        //accessors and mutators for all data members
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public int Stock
        {
            get { return this.stock; }
            set { this.stock = value; }
        }
        public int Min
        {
            get { return this.min; }
            set { this.min = value; }
        }
        public int Max
        {
            get { return this.max; }
            set { this.max = value; }
        }

        public Part(int id, string name, double price, int stock, int min, int max)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Min = min;
            this.Max = max;
        }

        //data members implemented in the child class
        public abstract bool IsInHouse { get; set; }
        public abstract bool IsOutsourced { get; set; }

        public abstract int MachineId { get; set; }
        public abstract string CompanyName { get; set; }

    }
}
