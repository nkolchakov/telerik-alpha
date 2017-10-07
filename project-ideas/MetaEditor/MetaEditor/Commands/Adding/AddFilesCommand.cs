using MetaEditor.Commands.Contracts;
using MetaEditor.Core.Contracts;
using MetaEditor.Utils;
using System.Collections.Generic;
using System.IO.Compression;
using TagLib;

namespace MetaEditor.Commands.Adding
{
    public class AddFilesCommand : ICommand
    {
        private readonly IOperatingFiles operatingFiles;

        public AddFilesCommand(IOperatingFiles operaingFiles)
        {
            this.operatingFiles = operaingFiles;
        }

        public string Execute(IList<string> parameters)
        {
            // open the given zip file
            // create temp folder for the files
            // extract each file to temp folder
            // add it to file cache for later usage
            // return message - how many files are added

            string zipPapth = parameters[0];
            var addedSongsCount = 0;

            ZipArchive zipFiles = ZipFile.Open(zipPapth, ZipArchiveMode.Read);
            System.IO.Directory.CreateDirectory(Constants.TemporaryFilesFolder);

            foreach (var entry in zipFiles.Entries)
            {
                string fileName = entry.FullName;
                if (!this.operatingFiles.Data.ContainsKey(fileName))
                {
                    var fileDir = Constants.TemporaryFilesFolder + '\\' + fileName;

                    this.operatingFiles.Data[fileName] = new HashSet<File>();
                    entry.ExtractToFile(fileDir, true);

                    var createdFile = File.Create(fileDir);
                    this.operatingFiles.Data[fileName].Add(createdFile);

                    addedSongsCount++;
                }
            }
            return $"===== {addedSongsCount} songs added.";
        }
    }
}
