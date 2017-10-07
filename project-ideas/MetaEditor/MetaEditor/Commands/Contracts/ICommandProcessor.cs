using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaEditor.Commands.Contracts
{
    public interface ICommandProcessor
    {
        string ProcessCommand(string commandAsString);
    }
}
