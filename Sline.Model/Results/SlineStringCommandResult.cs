namespace Sline.Model
{
    public class SlineStringCommandResult : ISlineCommandResult
    {
        public SlineStringCommandResult(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

}
