using MetaEditor.Commands;
using MetaEditor.Commands.Adding;
using MetaEditor.Commands.Contracts;
using MetaEditor.Commands.Editing;
using MetaEditor.Core;
using MetaEditor.Core.Contracts;
using MetaEditor.Core.Factories;
using MetaEditor.Core.Providers;
using MetaEditor.Utils;
using MetaEditor.Utils.Contracts;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaEditor.Ninject
{
    public class MetaEditorModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();

            this.Bind<IEditor>().To<Editor>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IOperatingFiles>().To<OperatingFiles>().InSingletonScope();

            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            // adding commands
            this.Bind<ICommand>().To<AddFilesCommand>()
                .InSingletonScope()
                .Named(Constants.AddSongsCommand);

            // editing
            this.Bind<ICommand>().To<EditAlbumCommand>()
                .InSingletonScope()
                .Named(Constants.SetAlbumCommand);

            this.Bind<ICommand>().To<EditArtistCommand>()
               .InSingletonScope()
               .Named(Constants.SetArtistCommand);

        }
    }
}
