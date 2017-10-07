using MetaEditor.Core.Contracts;
using MetaEditor.Ninject;
using Ninject;
using TagLib;

namespace MetaEditor
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new MetaEditorModule());
            IEditor editor = kernel.Get<IEditor>();
            editor.Run();
            var s = File.Create("asdas");
        }
    }
}
