namespace Sline.Model
{
    public class SlineStringCommandArgumentValue : ISlineCommandArgumentValue
    {
        public SlineStringCommandArgumentValue(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}