namespace Lexicon.Models.Contracts
{
    public interface IMenuSlide
    {
        int Id { get; }
        string[] Options { get; }
        int SelectedOption { get; set; }
    }
}
