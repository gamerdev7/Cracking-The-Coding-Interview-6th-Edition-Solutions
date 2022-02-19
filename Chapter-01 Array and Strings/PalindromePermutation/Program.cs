class Program
{
    // time: O(n), n = length of s
    // space: O(m) m = no of unique characters in s
    public static bool PalindromePermutationUsingHashSet(string s)
    {
        HashSet<char> characters = new();

        foreach (var c in s)
        {
            if (char.IsWhiteSpace(c))
                continue;

            if (!characters.Add(char.ToLower(c)))
                characters.Remove(char.ToLower(c));
        }

        return characters.Count <= 1;
    }


    // Let's assume that the no of characters are limited to a-z and A-Z. Then
    // no of characters = 56 but from the example in the book we can see that the
    // characters are case insensitive. So the no of characters we need to count
    // is 26. So we can use an integer.
    // time: O(n), n = length of s,  
    // space: O(1) 
    public static bool PalindromePermutationUsingBitManipulation(string s)
    {
        int bitVector = 0;

        foreach (var c in s)
        {
            if (char.IsWhiteSpace(c))
                continue;

            int mapping = char.ToLower(c) - 'a';
            ToggleBit(ref bitVector, mapping);
        }

        return bitVector == 0 || CheckExactlyOneBitSet(bitVector);
    }

    private static void ToggleBit(ref int bitVector, int mapping)
    {
        int mask = 1 << mapping;

        if ((bitVector & mask) == 0)
        {
            bitVector |= mask;
        }
        else
        {
            mask = ~mask;
            bitVector &= mask;
        }
    }

    private static bool CheckExactlyOneBitSet(int bitVector)
    {
        return (bitVector & (bitVector - 1)) == 0;
    }


    static void Main(string[] args)
    {
        string s1 = "Tact Coa";
        string s2 = "TaCo";

        Console.WriteLine(PalindromePermutationUsingHashSet(s1));
        Console.WriteLine(PalindromePermutationUsingBitManipulation(s1));

        Console.WriteLine(PalindromePermutationUsingHashSet(s2));
        Console.WriteLine(PalindromePermutationUsingBitManipulation(s2));
    }
}