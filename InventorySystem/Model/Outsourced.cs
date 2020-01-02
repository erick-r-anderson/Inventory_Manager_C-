using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventorySystem
{   [Serializable]
    public class Outsourced : Part
    {
        [DataMember]
        override public bool IsInHouse { get; set; }
        [DataMember]
        public override bool IsOutsourced { get; set; }
        [DataMember]
        override public int MachineId { get; set; }
        [DataMember]
        public override string CompanyName { get; set; }

        public Outsourced(int id, string name, double price, int stock, int min, int max, string companyName) : base(id, name, price, stock, min, max)
        {
            this.CompanyName = companyName;
            this.IsInHouse = false;
            this.IsOutsourced = true;
            this.MachineId = 0;
        }
    }
}
