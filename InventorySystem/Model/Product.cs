using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace InventorySystem
{
    public class Product
    {
        private ObservableCollection<Part> AssociatedParts { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public void AddPart(Part part)
        {
            this.AssociatedParts.Add(part);
        }

        public void RemovePart(Part part)
        {
            this.AssociatedParts.Remove(part);
        }

    }
}
