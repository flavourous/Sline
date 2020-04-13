namespace Sline.Model
{
    public class SlineStringCommandArgument : ISlineCommandArgument
    {
        internal SlineStringCommandArgument(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}