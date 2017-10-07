using MetaEditor.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MetaEditor.Core.Providers
{
    public class OperatingFiles : IOperatingFiles
    {
        private IDictionary<string,ISet<File>> files;

        public OperatingFiles()
        {
            this.files = new Dictionary<string, ISet<File>>();
        }

        public IDictionary<string,ISet<File>> Data
        {
            get
            {
                return this.files;
            }
}
    }
}
