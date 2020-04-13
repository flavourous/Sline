using Sline.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace Sline.ViewModel.ViewModels
{
    public class CommandViewModel : ViewModelBase, IResolvedCommandViewModel
    {
        public CommandViewModel(ISlineCommand command)
        {
            Arguments = command.Arguments.Select(x => new CommandArgumentViewModel(x)).ToList();
            Name = command.Name;

        }

        public string Name { get; }

        public ICollection<CommandArgumentViewModel> Arguments { get; }
    }
}
