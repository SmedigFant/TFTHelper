using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFTCompFinder.Classes.Components;

namespace TFTCompFinder.Classes
{
    abstract class Item
    {
        
        private string Name;
        private int Value;
        
        public string GetName() { return Name; }
        public int GetValue() { return Value; }
        protected void SetName(string name) { Name = name;  }
        protected void SetValue(int value) { Value = value; }
        public virtual Item Combine(Item item) { return new FullItem("This Item combination does not exist yet"); }
        public override string ToString() { return Name; }
    }
}
