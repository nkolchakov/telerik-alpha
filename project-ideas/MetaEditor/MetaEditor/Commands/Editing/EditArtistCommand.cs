using MetaEditor.Commands.Contracts;
using MetaEditor.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MetaEditor.Commands.Editing
{
    public class EditArtistCommand : ICommand
    {
        private readonly IOperatingFiles operatingFiles;

        public EditArtistCommand(IOperatingFiles operatingFiles)
        {
            this.operatingFiles = operatingFiles;
        }

        public string Execute(IList<string> parameters)
        {
            string newName = string.Join(" ", parameters);
            var allFiles = this.operatingFiles.Data.Values.SelectMany(f => f);
            foreach (File file in allFiles)
            {
                file.Tag.Artists = new string[] { newName };
                file.Save();
            }
            return $"==== Artist names set to {newName}";
        }
    }
}
