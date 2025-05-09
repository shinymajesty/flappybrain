using FlappyBrain.Matrices;
namespace Flappybrain.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] A = new double[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            double[,] B = new double[3, 2] { { 7, 8 }, { 9, 10 }, { 11, 12 } };


            double[,] C = new double[2, 2] { { 1, 2 }, { 3, 4 } }; 
            double[,] D = new double[2, 2] { { 1, 2 }, { 3, 4 } };

            Console.WriteLine("A:\n"+FlappyMatrix.PrintMatrix(A)); 
            Console.WriteLine("B:\n" + FlappyMatrix.PrintMatrix(B));


            Console.WriteLine("Matrix sum:\n" + FlappyMatrix.PrintMatrix(FlappyMatrix.AddMatrix(C, D)));
            Console.WriteLine("Matrix subtraction:\n" + FlappyMatrix.PrintMatrix(FlappyMatrix.SubtractMatrix(C, D)));
            Console.WriteLine("Matrix product:\n" + FlappyMatrix.PrintMatrix(FlappyMatrix.MultiplyMatrix(A,B)));
            Console.WriteLine("Matrix scalar multiplication:\n" + FlappyMatrix.PrintMatrix(FlappyMatrix.ScalarMultiplication(C, 2)));
            Console.WriteLine("Matrix transpose:\n" + FlappyMatrix.PrintMatrix(FlappyMatrix.TransposeMatrix(A)));
        }
    }
}
