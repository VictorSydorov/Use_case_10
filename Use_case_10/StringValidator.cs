using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Use_case_10
{
    public  class StringValidator
    {
        private readonly int min;
        private readonly int max;
        private readonly string predefinedChars = @"!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~.";

        public StringValidator(int min, int max)
        {
            if (min > max) { throw new ArgumentException("Min value should be less or equal max value"); }
            this.min = min;
            this.max = max;
        }
        public  bool Validate(string str) {

            bool match = false;
            match &= Regex.IsMatch(str, $"[.]{{{min},{max}}}");
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
