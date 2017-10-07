using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaEditor.Core.Contracts
{
    public interface IWriter
    {
        void Write(string message);
    }
}
