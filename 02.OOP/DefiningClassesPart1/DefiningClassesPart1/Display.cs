using DefiningClassesPart1.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPart1
{
    public class Display : IDisplay
    {
        private double size;
        private ulong numberOfColors;

        public Display(double size)
        {
            this.Size = size;
        }

        public Display(double size, ulong colors)
            : this(size)
        {
            this.numberOfColors = colors;
        }

        public ulong NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
        }

        public double Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Size cannot be negative");
                }
                this.size = value;
            }
        }
    }
}
