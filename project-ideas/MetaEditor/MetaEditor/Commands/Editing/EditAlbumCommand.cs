using MetaEditor.Commands.Contracts;
using MetaEditor.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaEditor.Commands.Editing
{
    public class EditAlbumCommand : ICommand
    {
        private readonly IOperatingFiles operatingFiles;

        public EditAlbumCommand(IOperatingFiles operatingFiles)
        {
            this.operatingFiles = operatingFiles;
        }

        public string Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
