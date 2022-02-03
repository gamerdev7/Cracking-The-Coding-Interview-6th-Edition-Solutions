class Program
{
    // time: O(trueLength)
    // space: O(trueLength)
    public static string URLify(string s, int trueLength)
    {
        string r = "%20";
        StringBuilder sb = new StringBuilder();
        int i = 0;

        while (trueLength > 0 && i < s.Length)
        {
            if (s[i] == ' ')
            {
                sb.Append(r);
            }
            else
            {
                sb.Append(s[i]);
            }

            trueLength--;
            i++;
        }

        return sb.ToString();
    }


    // time: O(trueLength)
    // space: O(1)
    public static void URLify(char[] s, int trueLength)
    {
        int spaceCount = 0;
        int newLength = 0;

        for (int i = 0; i < trueLength; i++)
        {
            if (s[i] == ' ')
                spaceCount++;
        }

        newLength = trueLength + spaceCount * 2 - 1;

        for (int i = trueLength - 1; i >= 0; i--)
        {
            if (s[i] != ' ')
            {
                s[newLength] = s[i];
                newLength--;
            }
            else
            {
                s[newLength] = '0';
                s[newLength - 1] = '2';
                s[newLength - 2] = '%';

                newLength -= 3;
            }
        }
    }

    static void Main(string[] args)
    {
        char[] c = "Mr John  Smith   r            ".ToCharArray();
        Console.WriteLine(URLify("Mr John  Smith   r            ", 18));

        URLify(c, 18);
        Console.WriteLine(new string(c));
    }
}