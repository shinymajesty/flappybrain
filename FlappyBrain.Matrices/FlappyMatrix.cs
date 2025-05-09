namespace FlappyBrain.Matrices
{

    public static class FlappyMatrix
    {
        public static double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);

            if (cA != rB)
            {
                throw new Exception("Matrix A's column count must match Matrix B's row count.");
            }
            else
            {
                double temp = 0;
                double[,] kHasil = new double[rA, cB];

                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    }
                }

                return kHasil;
            }
        }
        public static double[,] ScalarMultiplication(double[,] A, double scalar)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            double[,] result = new double[rA, cA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    result[i, j] = A[i, j] * scalar;
                }
            }
            return result;
        }
        public static double[,] AddMatrix(double[,] A, double[,] B)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);

            if(rA != rB || cA != cB)
            {
                throw new Exception("Matrix A and B must have the same dimensions.");
            }
            else
            {
                double[,] result = new double[rA, cA];
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cA; j++)
                    {
                        result[i, j] = A[i, j] + B[i, j];
                    }
                }
                return result;
            }
        }
        public static double[,] SubtractMatrix(double[,] A, double[,] B) => AddMatrix(A, ScalarMultiplication(B, -1));
        public static double[,] TransposeMatrix(double[,] A)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            double[,] result = new double[cA, rA];
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    result[j, i] = A[i, j];
                }
            }
            return result;
        }
        public static string PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            string result = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j].ToString("F2") + "\t";
                }
                result += "\n";
            }
            return result;
        }
    }
}
