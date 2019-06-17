using System;

namespace BBCTests.Helpers
{    
    public static class RandomHelper
    {
        public static string GetGuidString(int maxLength = 32)
        {
            return Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Remove(maxLength-1);
        }
    }
}
