using MetaEditor.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaEditor.Utils.Contracts
{
    public interface IParser
    {
        ICommand CreateCommand(string fullCommand);
        IList<string> ParseParamters(string fullCommand);
    }
}
