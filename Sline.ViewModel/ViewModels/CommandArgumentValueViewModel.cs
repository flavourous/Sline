using Sline.Model;

namespace Sline.ViewModel.ViewModels
{
    public class CommandArgumentValueViewModel : ViewModelBase
    {
        public CommandArgumentValueViewModel(CommandArgumentViewModel definition, string value)
        {
            Value = value;
        }

        public string Value { get; }

        public ISlineCommandArgumentValue CreateValue() => new SlineStringCommandArgumentValue(Value);
    }
}
