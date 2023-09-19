// Written by Dr. Shane Wilson.
// The author licenses this file to you under the MIT license.
// See the LICENSE file in the solution root for more information.

using System.Text;

namespace MyMAUIApp;

public static class MyPhoneDialer
{
    public static string ToNumber(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return null;

        raw = raw.ToUpperInvariant();

        var newNumber = new StringBuilder();
        foreach (var c in raw)
        {
            if (" -0123456789".Contains(c))
                newNumber.Append(c);
            else
            {
                var result = TranslateToNumber(c);
                if (result != null)
                    newNumber.Append(result);
                // Bad character?
                else
                    return null;
            }
        }
        return newNumber.ToString();
    }

    static bool Contains(this string keyString, char c)
    {
        return keyString.IndexOf(c) >= 0;
    }

    static readonly string[] digits = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

    static int? TranslateToNumber(char c)
    {
        for (int i = 0; i < digits.Length; i++)
        {
            if (digits[i].Contains(c))
                return 2 + i;
        }
        return null;
    }


}
