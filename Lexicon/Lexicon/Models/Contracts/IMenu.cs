namespace Lexicon.Models.Contracts
{
    using Lexicon.Models.Menus;
    using System.Collections.Generic;

    public interface IMenu
    {
        IList<MenuSlide> Slides { get; }

        IMenuSlide GetSlideById(int id);
    }
}
