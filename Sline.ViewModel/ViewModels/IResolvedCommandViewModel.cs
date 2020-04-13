using System.Collections.Generic;

namespace Sline.ViewModel.ViewModels
{
    public interface IResolvedCommandViewModel
    {
        string Name { get; }

        ICollection<CommandArgumentViewModel> Arguments { get; }
    }
}
