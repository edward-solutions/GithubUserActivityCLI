using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubUserActivityCLI
{
    public static class ValidationHelper
    {
        public static bool TryValidate(string input, out string error)
        {
            var baseKeyword = "github-activity";
            error = string.Empty;

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                error = "Invalid format: invalid parameters";
                return false;
            }

            if (!parts[0].Equals(baseKeyword, StringComparison.Ordinal))
            {
                error = "Invalid command";
                return false;
            }

            if (string.IsNullOrEmpty(parts[1]))
            {
                error = "Username was not provided";
                return false;
            }

            return true;
        }
    }
}
