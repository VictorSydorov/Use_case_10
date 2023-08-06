using System.Text.RegularExpressions;

namespace Use_case_10
{
    public class StringValidator
    {
        private readonly int min;
        private readonly int max;

        public StringValidator(int min, int max)
        {
            if (min > max) { throw new ArgumentException("Min value should be less or equal max value"); }
            this.min = min;
            this.max = max;
        }
        public bool Validate(string str)
        {
            if (str == null) {  throw new ArgumentNullException("str"); }

            bool match = true;

            match &= Regex.IsMatch(str, $"^.{{{min},{max}}}$");
            if (!match) { return match; }

            match &= Regex.IsMatch(str, $"[a-z]+");
            if (!match) { return match; }

            match &= Regex.IsMatch(str, $"[A-Z]+");
            if (!match) { return match; }

            match &= Regex.IsMatch(str, $"\\d+");
            if (!match) { return match; }

            match &= Regex.IsMatch(str, $"[!\"#$%&'()*+,-./:;<=>?@[\\]^_`{{|}}~.]+");
            if (!match) { return match; }

            match &= Regex.IsMatch(str, $"^\\S*$");

            return match;
        }
    }
}
