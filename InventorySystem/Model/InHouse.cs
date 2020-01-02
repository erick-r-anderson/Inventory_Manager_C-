using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InventorySystem
{
    [Serializable]
    class InHouse : Part
    {[DataMember]
        override public bool IsInHouse { get; set; }
        [DataMember]
        override public bool IsOutsourced { get; set; }
        [DataMember]
        override public int MachineId { get; set; }
        [DataMember]
        public override string CompanyName { get; set; }
        
        public InHouse(int id, string name, double price, int stock, int min, int max, int machineId) : base(id, name, price, stock, min, max)
        {
            this.MachineId = machineId;
            this.IsInHouse = true;
            this.IsOutsourced = false;
            this.CompanyName = "Internal";
        }

    }
}
