
namespace MetaEditor.Core.Contracts
{
    public interface ITag
    {
        //IPicture[] Pictures { get; set; }
        string Copyright { get; set; }
        string Title { get; set; }
        string Album { get; set; }
        string[] Genres { get; set; }
        uint Year { get; set; }
    }
}
