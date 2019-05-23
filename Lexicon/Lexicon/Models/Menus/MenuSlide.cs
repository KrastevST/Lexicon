namespace Lexicon.Models.Menus
{
    using Lexicon.Models.Contracts;

    public class MenuSlide : IMenuSlide
    {
        private readonly int id;
        private readonly string[] options;
        private int selectedOption = 0;


        public MenuSlide(int id, string[] options)
        {
            this.id = id;
            this.options = options;
        }

        public int Id => this.id;
        
        public string[] Options => this.options;

        public int SelectedOption
        {
            get => selectedOption;
            set
            {
                if (0 <= value && value < this.options.Length)
                {
                    this.selectedOption = value;
                }
            }
        }
    }
}
