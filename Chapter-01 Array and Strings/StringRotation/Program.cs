class Program
{
    // time: O(Length(a))
    // space: O(1)
    public static bool StringRotation(string a, string b)
    {
        if (a.Length != b.Length && a.Length < 1) return false;

        return IsSubstring(a + a, b);
    }


    // Suppose this method is already given
    private static bool IsSubstring(string a, string b)
    {
        return true;
    }

    static void Main(string[] args)
    {
        string a = "waterbottle";
        string b = "erbottlewat";
        Console.WriteLine(StringRotation(a, b));
    }
}