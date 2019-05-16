namespace Lexicon.Models.Contracts
{
    public interface IMenuSlide
    {
        string Id { get; }
        string[] Options { get; }
        int SelectedOption { get; set; }
    }
}
