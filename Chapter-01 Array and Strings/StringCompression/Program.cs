class Program
{
    // time: O(Length(s))
    // space: O(Length(s))
    public static string StringCompression(string s)
    {
        var curChar = s[0];
        var count = 0;

        StringBuilder compressedString = new StringBuilder();

        foreach (var c in s)
        {
            if (curChar == c)
            {
                count++;
            }
            else
            {
                compressedString.Append($"{curChar}{count}");

                curChar = c;
                count = 1;
            }
        }

        compressedString.Append($"{curChar}{count}");

        if (compressedString.Length < s.Length)
            return compressedString.ToString();

        return s;
    }

    static void Main(string[] args)
    {
        string s = "aabcccccaaa";

        Console.WriteLine(StringCompression(s));
    }
}