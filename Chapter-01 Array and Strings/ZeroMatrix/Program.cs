class Program
{

    // time: O(n*m), n = no of rows, m = no of columns
    // space: O(1)
    public static void ZeroMatrix(int[][] matrix)
    {
        if (matrix == null || matrix.Length < 2) return;

        bool rowHasZero = false;
        bool colHasZero = false;

        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0)
                colHasZero = true;
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            if (matrix[0][i] == 0)
                rowHasZero = true;
        }


        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == 0)
                SetRow(matrix, i);
        }

        for (int i = 0; i < matrix[0].Length; i++)
        {
            if (matrix[0][i] == 0)
                SetColumn(matrix, i);
        }

        if (rowHasZero)
            SetRow(matrix, 0);

        if (colHasZero)
            SetColumn(matrix, 0);
    }

    private static void SetRow(int[][] matrix, int row)
    {
        for (int i = 0; i < matrix[0].Length; i++)
        {
            matrix[row][i] = 0;
        }
    }

    private static void SetColumn(int[][] matrix, int col)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i][col] = 0;
        }
    }

    private static void PrintMatrix(int[][] matrix)
    {
        Console.WriteLine("Matrix...");
        foreach (var row in matrix)
        {
            foreach (var element in row)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        int[][] matrix =
        {
            new int[]{1,1,1,1,1,1},
            new int[]{1,0,1,1,1,1},
            new int[]{0,1,1,1,0,1},
            new int[]{1,1,1,1,1,1}
        };

        PrintMatrix(matrix);
        ZeroMatrix(matrix);
        PrintMatrix(matrix);
    }
}