using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace CalculatorApp.Models
{
    public class Memory
    {
        private List<MemoryItem> _memoryItems = new List<MemoryItem>();

        public void Store(double value)
        {
            _memoryItems.Add(new MemoryItem(value));
        }

        public double Recall(int index)
        {
            return (index >= 0 && index < _memoryItems.Count) ? _memoryItems[index].Value : 0;
        }

        public void Clear()
        {
            _memoryItems.Clear();
        }
    }
}

