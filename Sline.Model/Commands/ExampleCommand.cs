using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sline.Model
{
    public class ExampleCommand : ISlineCommand
    {
        public string Name { get; } = "ExampleCommand";

        public IList<ISlineCommandArgument> Arguments { get; } = new[] { new SlineStringCommandArgument("Arg 1") };

        public Task<ISlineCommandResult> Execute(IList<ISlineCommandArgumentValue> arguments)
        {
            var arg = arguments.Cast<SlineStringCommandArgumentValue>().Single().Value;

            var response = arg + " was recieved";

            ISlineCommandResult result = new SlineStringCommandResult(response);

            return Task.FromResult(result);
        }
    }

}
