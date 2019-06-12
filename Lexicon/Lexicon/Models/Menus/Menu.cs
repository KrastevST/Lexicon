namespace Lexicon.Models.Menus
{
    using Lexicon.Models.Contracts;
    using Lexicon.Models.Database;
    using System.Collections.Generic;
    using System.Linq;

    public class Menu : IMenu
    {

        public Menu()
        {
            this.Slides = new List<MenuSlide>();

            // Id is the numeric pathway from main menu to the slide
            this.Slides.Add(new MenuSlide(1, new List<string> { "Exit", "Take the quiz", "List of people" }));
            this.Slides.Add(new MenuSlide(12, new List<string> { "Return", "Erase", "View" }));
        }
        public IList<MenuSlide> Slides { get; private set; }

        public IMenuSlide GetSlideById(int id)
        {
            MenuSlide result = Slides.Where(x => x.Id == id).First();
            return result;
        }
    }
}
