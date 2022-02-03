class Program
{

    // time: O(n*log(n)), n = length of a and b
    // space: O(n)
    public static bool CheckPermutationUsingSorting(string a, string b)
    {
        if (a.Length != b.Length)
            return false;

        string sortedA = GetSortedString(a);
        string sortedB = GetSortedString(a);

        return sortedA.Equals(sortedB);
    }

    private static string GetSortedString(string s)
    {
        char[] array = s.ToCharArray();
        Array.Sort(array);
        return new String(array);
    }


    // time: O(n), n = length of a and b
    // space: O(n)
    public static bool CheckPermutation(string a, string b)
    {
        if (a.Length != b.Length)
            return false;

        Dictionary<char, int> charCount = new();

        foreach (var c in a)
        {
            charCount.Add(c, charCount.GetValueOrDefault(c, 1));
        }

        foreach (var c in b)
        {
            charCount[c]--;

            if (charCount[c] < 0)
                return false;
        }

        return true;
    }


    static void Main(string[] args)
    {
        string a = "abc";
        string b = "abc";

        Console.WriteLine(CheckPermutationUsingSorting(a, b));
        Console.WriteLine(CheckPermutation(a, b));
    }
}