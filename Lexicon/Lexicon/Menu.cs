namespace Lexicon
{
    using Lexicon.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Menu : IMenu
    {
        private readonly string id;
        private readonly string[] options;
        private int selectedOption = 0;


        public Menu(string id, string[] options)
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
