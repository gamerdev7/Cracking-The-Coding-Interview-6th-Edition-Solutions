class Program
{
    // time: O(n), n = length of s
    // space: O(u), u = no of unique characters in s, where u <= n
    public static bool IsUniqueUsingHashSet(string s)
    {
        HashSet<char> set = new();

        foreach (var c in s)
        {
            if (!set.Add(c))
                return false;
        }

        return true;
    }


    // Let's assume that the no of characters are limited to ascii. Then
    // no of characters = 128 in range [0...127], so we can use an array
    // to keep track if the character is in already S or not.
    // time: O(n), n = length of s, where n <= 128
    // space: O(1) 
    public static bool IsUniqueUsingArray(string s)
    {
        if (s.Length > 128)
            return false;

        bool[] isInS = new bool[128];

        for (int i = 0; i < s.Length; i++)
        {
            int index = s[i];

            if (isInS[index])
                return false;

            isInS[index] = true;
        }

        return true;
    }


    // Let's assume that the no of characters are limited to [a..z]. Then
    // we can reduce space complexity even more by using bit manipulation.
    // We can use an int to keep track if the character is already in S or not.
    // time: O(n), n = length of s, where n <= 26
    // space: O(1) , will be even better than using an array
    public static bool IsUniqueUsingBitManipulation(string s)
    {
        if (s.Length > 26)
            return false;

        int isInS = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int mapping = s[i] - 'a';
            int mask = 1 << mapping;
            if ((isInS & mask) > 0)
                return false;

            isInS |= mask;
        }

        return true;
    }


    static void Main(string[] args)
    {
        string s1 = "abcdAG#";
        string s2 = "abca";
        string s3 = "abcde";

        Console.WriteLine($"{s1} contains unique characters: {IsUniqueUsingHashSet(s1)}");
        Console.WriteLine($"{s2} contains unique characters: {IsUniqueUsingHashSet(s2)}");

        Console.WriteLine($"{s1} contains unique characters: {IsUniqueUsingArray(s1)}");
        Console.WriteLine($"{s2} contains unique characters: {IsUniqueUsingArray(s2)}");

        Console.WriteLine($"{s3} contains unique characters: {IsUniqueUsingBitManipulation(s3)}");
        Console.WriteLine($"{s2} contains unique characters: {IsUniqueUsingBitManipulation(s2)}");
    }
}