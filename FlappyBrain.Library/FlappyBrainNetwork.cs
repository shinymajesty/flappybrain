using FlappyBrain.Library;
using FlappyBrain.Matrices;
using System;

namespace FlappyBrain.Library
{
    public class FlappyBrainNetwork
    {
        #region variableDeclaration
        public int InputNodes { get; private set; }
        public int OutputNodes { get; private set; }
        public int HiddenNodes { get; private set; }
        public ActivationFunction ActivationFunction { get; private set; }
        private readonly Random random = new();
        private double[,] Inputs { get; set; }
        private double[,] _w1 { get; set; }
        private double[,] _w2 { get; set; }
        private double[,] Outputs { get; set; }
        public double[][,] Layers => [_w1, _w2];
        #endregion

        public FlappyBrainNetwork(int inputNodes, int hiddenNodes, int outputNodes, ActivationFunction activationFunction)
        {
            this.InputNodes = inputNodes;
            this.HiddenNodes = hiddenNodes;
            this.OutputNodes = outputNodes;
            this.ActivationFunction = activationFunction;

            this.Inputs = new double[inputNodes, 1];
            this.Outputs = new double[outputNodes, 1];

            this._w1 = new double[hiddenNodes, inputNodes];
            this._w2 = new double[outputNodes, hiddenNodes]; // corrected: output × hidden
            InitializeRandomWeights(_w1);
            InitializeRandomWeights(_w2);
        }

        private void InitializeRandomWeights(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = random.NextDouble() * 2 - 1; // [-1, 1] range for better spread
        }

        public double[] CalculateWeights(double[] inputs)
        {
            if (inputs.Length != this.Inputs.GetLength(0))
                throw new ArgumentException("Input values provided do not match the node count");

            // Copy inputs into matrix
            for (int row = 0; row < this.Inputs.GetLength(0); row++)
                this.Inputs[row, 0] = inputs[row];

            OperationDelegate activation = this.ActivationFunction switch
            {
                ActivationFunction.Sigmoid => SigmoidFunction,
                ActivationFunction.ReLU => ReLU,
                ActivationFunction.LeakyReLU => LeakyReLU,
                ActivationFunction.Tanh => Tanh,
                _ => SigmoidFunction
            };

            // Input → Hidden
            var hidden = FlappyMatrix.MultiplyMatrix(_w1, Inputs);
            hidden = FlappyMatrix.PerformOperation(hidden, activation);

            // Hidden → Output
            var output = FlappyMatrix.MultiplyMatrix(_w2, hidden);
            output = FlappyMatrix.PerformOperation(output, activation); // Apply final activation

            // Flatten to 1D array
            double[] outputArray = new double[output.GetLength(0)];
            for (int i = 0; i < output.GetLength(0); i++)
                outputArray[i] = output[i, 0];

            return outputArray;
        }

        // Standard sigmoid (no flattening)
        private double SigmoidFunction(double x) => 1.0 / (1.0 + Math.Exp(-x));

        private double ReLU(double x) => Math.Max(0, x);

        private double LeakyReLU(double x) => x > 0 ? x : 0.01 * x;

        private double Tanh(double x) => Math.Tanh(x);
    }
}
