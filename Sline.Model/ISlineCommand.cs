using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sline.Model
{
    public interface ISlineCommand
    {
        string Name { get; }
        IList<ISlineCommandArgument> Arguments { get; }
        Task<ISlineCommandResult> Execute(IList<ISlineCommandArgumentValue> arguments);
    }
}
