using ReactiveUI;
using Sline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;

namespace Sline.ViewModel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ObservableAsPropertyHelper<CommandResultViewModel> result;
        public CommandResultViewModel Result => result.Value;

        private string currentCommandText;
        public string CurrentCommandText
        {
            get => currentCommandText;
            set => this.RaiseAndSetIfChanged(ref currentCommandText, value);
        }

        private readonly ObservableAsPropertyHelper<IResolvedCommandViewModel> resolvedCommand;
        public IResolvedCommandViewModel ResolvedCommand => resolvedCommand.Value;

        private readonly ObservableAsPropertyHelper<IEnumerable<CommandArgumentValueViewModel>> argumentValues;
        public IEnumerable<CommandArgumentValueViewModel> ArgumentValues => argumentValues.Value;

        public ReactiveCommand<Unit, CommandResultViewModel> ExecuteCurrentCommand { get; }

        private ICollection<CommandViewModel> commands;

        private readonly ObservableAsPropertyHelper<string> error;
        public string Error => error.Value;

        public MainWindowViewModel(IEnumerable<ISlineCommand> commands)
        {
            this.commands = commands.Select(x => new CommandViewModel(x)).ToList();

            resolvedCommand = this
                .WhenAnyValue(x => x.CurrentCommandText)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Where(x => x.Contains(' '))
                .Select(x => x.Substring(0, x.IndexOf(' ')))
                .DistinctUntilChanged()
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => this.commands.SingleOrDefault(t => t.Name.Equals(x)) ?? (IResolvedCommandViewModel)new UnknownCommandViewModel(x))
                .ToProperty(this, x => x.ResolvedCommand);

            argumentValues = this
                .WhenAnyValue(x => x.CurrentCommandText)
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Where(x => x.Contains(' '))
                .Select(x => 
                    x.Substring(x.IndexOf(' '))
                     .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                     .Select((s, i) => new CommandArgumentValueViewModel(ResolvedCommand?.Arguments.ElementAtOrDefault(i), s)))
                .ToProperty(this, x => x.ArgumentValues);

            ExecuteCurrentCommand = ReactiveCommand.CreateFromTask<Unit, CommandResultViewModel>(async _ =>
            {
                var command = commands.Single(x => x.Name.Equals(ResolvedCommand.Name));
                // need some multi-resolution here also.
                var args = ArgumentValues.Select(x => x.CreateValue()).ToList();
                var result = await command.Execute(args);
                return new CommandResultViewModel(result);
            });
            
            // not sure if this is correct way to use async return value
            result = ExecuteCurrentCommand.ToProperty(this, x => x.Result);

            error = ExecuteCurrentCommand.ThrownExceptions
                .Select(x => x.ToString())
                .Merge(ExecuteCurrentCommand.Select(x=>""))
                .ToProperty(this, x => x.Error);
        }
    }
}
