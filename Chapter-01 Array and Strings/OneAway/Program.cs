class Program
{
    // time: O(Min(Length(a), Length(b)))
    // space: O(Min(Length(a), Length(b)))
    public static bool OneAway(string a, string b)
    {
        if (Math.Abs(a.Length - b.Length) > 1)
            return false;

        string small = a.Length < b.Length ? a : b;
        string large = a.Length < b.Length ? b : a;

        int i1 = 0;
        int i2 = 0;

        bool foundDifference = false;

        while (i2 < large.Length && i1 < small.Length)
        {
            if (small[i1] == large[i2])
            {
                i1++;
            }
            else
            {
                if (foundDifference)
                    return false;
                foundDifference = true;

                if (small.Length == large.Length)
                    i1++;
            }

            i2++;
        }

        return true;
    }

    static void Main(string[] args)
    {
        string s1 = "pala";
        string s2 = "paala";

        Console.WriteLine(OneAway(s1, s2));
    }
}