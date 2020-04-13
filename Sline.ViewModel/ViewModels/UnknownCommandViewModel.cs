using System;
using System.Collections.Generic;

namespace Sline.ViewModel.ViewModels
{
    public class UnknownCommandViewModel : ViewModelBase, IResolvedCommandViewModel
    {
        public UnknownCommandViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public ICollection<CommandArgumentViewModel> Arguments => Array.Empty<CommandArgumentViewModel>();
    }
}
