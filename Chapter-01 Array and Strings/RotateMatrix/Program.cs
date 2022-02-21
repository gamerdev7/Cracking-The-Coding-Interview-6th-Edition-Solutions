class Program
{
    // time: O(n^2), n = no of rows, no of columns
    // space: O(n)
    public static void RotateMatrix(int[][] matrix)
    {
        int[] temp = new int[matrix.Length];

        int k = 0;

        for (k = 0; k < temp.Length; k++)
        {
            temp[k] = matrix[k][matrix.Length - 1];
        }

        k = 0;
        int i = 0;
        int j = 0;

        for (i = 0; i < matrix.Length; i++)
        {
            for (j = 0; j < matrix.Length - 1; j++)
            {
                matrix[j][matrix.Length - 1 - i] = matrix[i][j];
            }
        }

        for (k = 0; k < temp.Length; k++)
        {
            matrix[matrix.Length - 1][matrix.Length - 1 - k] = temp[k];
        }
    }


    // time: O(n^2), n = no of rows, no of columns
    // space: O(1)
    public static void RotateMatrixInPlace(int[][] matrix)
    {
        for (int layer = 0; layer < matrix.Length / 2; layer++)
        {
            int first = layer;
            int last = matrix.Length - 1 - layer;
            for (int i = first; i < last; i++)
            {
                int offset = last - i + first;
                int temp = matrix[first][i];

                matrix[first][i] = matrix[offset][first];
                matrix[offset][first] = matrix[last][offset];
                matrix[last][offset] = matrix[i][last];
                matrix[i][last] = temp;
            }
        }
    }

    private static void PrintMatrix(int[][] matrix)
    {
        Console.WriteLine("Matrix...");
        foreach (var row in matrix)
        {
            foreach (var element in row)
            {
                Console.Write($"{element:D2} ");
            }

            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        int[][] matrix =
        {
            new int[]{1,2,3,4,5,6},
            new int[]{7,8,9,10,11,12},
            new int[]{13,14,15,16,17,18},
            new int[]{19,20,21,22,23,24},
            new int[]{25,26,27,28,29,30},
            new int[]{31,32,33,34,35,36 }
        };

        PrintMatrix(matrix);
        RotateMatrixInPlace(matrix);
        PrintMatrix(matrix);
    }
}