using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFTCompFinder.Classes.Components
{
    class FullItem : Item
    {
        public FullItem(string name, int value1, int value2)
        {
            this.SetName(name);
            int fullItemValue;
            if (value1 < value2)
            {
                fullItemValue = value1*10 + value2;
            }
            else
            {
                fullItemValue = value2*10 + value1;
            }
            this.SetValue(fullItemValue);
            
            
        }
        
        public FullItem(string name)
        {
            this.SetName(name);
            this.SetValue(10);
        }
        //public override string ToString()
        //{
        //    return GetName();
        //}
    }
}
