using FlappyBrain.Library;
using FlappyBrain.Matrices;

namespace FlappyBrain.Library;

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
        this._w2 = new double[hiddenNodes, outputNodes];
        InitializeRandomWeights(_w1);
        InitializeRandomWeights(_w2);
        
    }

    private void InitializeRandomWeights(double[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++) 
            for(int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = random.NextDouble();

    }

    public double[] CalculateWeights(double[] inputs)
    {
        if (inputs.Length != this.Inputs.GetLength(0)) throw new ArgumentException("Input values provided do not match the node count");
        for(int row = 0; row < this.Inputs.GetLength(0); row++)
            this.Inputs[row, 0] = inputs[row];

        var hiddenNodeValues = FlappyMatrix.MultiplyMatrix(this._w1, this.Inputs);

        
        hiddenNodeValues = FlappyMatrix.PerformOperation(hiddenNodeValues, SigmoidFunction);
        hiddenNodeValues = FlappyMatrix.TransposeMatrix(hiddenNodeValues);
        var result = FlappyMatrix.MultiplyMatrix(hiddenNodeValues, this._w2);
        result = FlappyMatrix.PerformOperation(result, SigmoidFunction);

        result = result.GetLength(0) > result.GetLength(1) ? result : FlappyMatrix.TransposeMatrix(result);

        var outputs = new double[result.GetLength(0)];
            for (int row = 0; row < result.GetLength(0); row++) outputs[row] = result[row, 0];

        return outputs;
    }

    private double SigmoidFunction(double x)
    {
        var exponential_expression = Math.Exp(x);
        return (exponential_expression) / (1 + exponential_expression);
    }
}
