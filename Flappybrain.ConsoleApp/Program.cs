using FlappyBrain.Matrices;
using FlappyBrain.Library;
namespace Flappybrain.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var x = new FlappyBrainNetwork(4, 6, 1, FlappyBrain.Library.ActivationFunction.Sigmoid);

                Console.WriteLine(String.Join(' ', x.CalculateWeights(new double[4] {random.Next(0 , 1000), random.Next(0, 2000) , random.Next(0, 1000), random.Next(0, 30)  })));
            }
            
        }
    }
}
