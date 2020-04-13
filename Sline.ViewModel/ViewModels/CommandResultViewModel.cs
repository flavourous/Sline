using Sline.Model;

namespace Sline.ViewModel.ViewModels
{
    public class CommandResultViewModel : ViewModelBase
    {
        public CommandResultViewModel(ISlineCommandResult result)
        {
            // need to use ninject somehow
            Value = (result as SlineStringCommandResult).Value;
        }

        public string Value { get; }
    }
}
