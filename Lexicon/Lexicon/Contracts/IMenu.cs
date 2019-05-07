namespace Lexicon.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMenu
    {
        string Id { get; }
        string[] Options { get; }
        int SelectedOption { get; set; }
    }
}
