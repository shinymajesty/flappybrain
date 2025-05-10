using FlappyBrain.Matrices;
using FlappyBrain.Library;
namespace Flappybrain.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = new FlappyBrainNetwork(2, 3, 2, FlappyBrain.Library.ActivationFunction.Sigmoid);

            Console.WriteLine(String.Join(' ' , x.CalculateWeights(new double[2] { 0.5, 1.4 })));
        }
    }
}
