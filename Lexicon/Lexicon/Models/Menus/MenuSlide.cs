namespace Lexicon.Models.Menus
{
    using Lexicon.Models.Contracts;
    using System.Collections.Generic;

    public class MenuSlide : IMenuSlide
    {
        private readonly int id;
        private readonly List<string> options;
        private int selectedOption = 0;


        public MenuSlide(int id, List<string> options)
        {
            this.id = id;
            this.options = options;
        }

        public int Id => this.id;
        
        public List<string> Options => this.options;

        public int SelectedOption
        {
            get => selectedOption;
            set
            {
                if (value >= 0 && value < this.options.Count)
                {
                    this.selectedOption = value;
                }
            }
        }
    }
}
