namespace Lexicon.Models.Contracts
{
    using System.Collections.Generic;

    public interface IMenuSlide
    {
        int Id { get; }
        List<string> Options { get; }
        int SelectedOption { get; set; }
    }
}
