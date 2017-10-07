using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MetaEditor.Core.Contracts
{
    public interface IOperatingFiles
    {
        IDictionary<string, ISet<File>> Data { get; }
    }
}
