namespace Lexicon.Models.Menus
{
    using Lexicon.Models.Contracts;

    public class MenuSlide : IMenuSlide
    {
        private readonly string id;
        private readonly string[] options;
        private int selectedOption = 0;


        public MenuSlide(string id, string[] options)
        {
            this.id = id;
            this.options = options;
        }

        public string Id => id;
        public string[] Options => options;

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
