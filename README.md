# FlappyBrain QuickStart Guide

FlappyBrain is a lightweight neural network library designed for genetic algorithms, particularly suitable for AI in games like Flappy Bird. This guide will help you get started with the library.

## Installation

Install the FlappyBrain package via NuGet:

```
dotnet add package NeuralFlapper
```

Or via the NuGet Package Manager Console:

```
Install-Package NeuralFlapper
```

## Basic Usage

### Creating a Neural Network

```csharp
using FlappyBrain.Library;

// Create a neural network with:
// - 3 input nodes
// - 4 hidden nodes
// - 2 output nodes
// - Sigmoid activation function
var network = new FlappyBrainNetwork(
    inputNodes: 3, 
    hiddenNodes: 4, 
    outputNodes: 2, 
    activationFunction: ActivationFunction.Sigmoid
);
```

### Processing Inputs

```csharp
// Create an array of inputs
double[] inputs = new double[] { 0.5, 0.3, 0.9 };

// Calculate outputs
double[] outputs = network.CalculateWeights(inputs);

// Use the outputs
Console.WriteLine($"Output 1: {outputs[0]}");
Console.WriteLine($"Output 2: {outputs[1]}");
```

## Activation Functions

FlappyBrain supports multiple activation functions:

- `ActivationFunction.Sigmoid` - Standard sigmoid function: f(x) = 1/(1+e^(-x))
- `ActivationFunction.ReLU` - Rectified Linear Unit: f(x) = max(0, x)
- `ActivationFunction.LeakyReLU` - Leaky ReLU: f(x) = x if x > 0, otherwise 0.01x
- `ActivationFunction.Tanh` - Hyperbolic tangent: f(x) = tanh(x)

```csharp
// Example with ReLU activation function
var reluNetwork = new FlappyBrainNetwork(
    inputNodes: 3,
    hiddenNodes: 4,
    outputNodes: 2,
    activationFunction: ActivationFunction.ReLU
);
```

## Network Architecture

FlappyBrain implements a classic three-layer neural network:
- Input layer: Accepts your input values
- Hidden layer: Processes the inputs through weighted connections
- Output layer: Produces the final output values

The network uses matrix operations for efficient calculations.

## Accessing Network Properties

```csharp
// Get the number of nodes in each layer
int inputs = network.InputNodes;
int hidden = network.HiddenNodes;  
int outputs = network.OutputNodes;

// Get the activation function used
ActivationFunction activation = network.ActivationFunction;

// Access the weight matrices (advanced usage)
var weightLayers = network.Layers;
var inputToHiddenWeights = weightLayers[0];
var hiddenToOutputWeights = weightLayers[1];
```

## Example: Building a Simple AI Agent

```csharp
using FlappyBrain.Library;

// Create a neural network for a simple game AI
var aiAgent = new FlappyBrainNetwork(
    inputNodes: 4,  // For example: player position x,y and target position x,y
    hiddenNodes: 6, 
    outputNodes: 2, // For example: move direction x,y
    activationFunction: ActivationFunction.Tanh // Range from -1 to 1, good for movement
);

// In your game loop:
void Update()
{
    // Gather sensor data
    double[] sensorInputs = new double[] { 
        playerX / mapWidth,     // Normalize to 0-1 range
        playerY / mapHeight, 
        targetX / mapWidth, 
        targetY / mapHeight 
    };
    
    // Get agent's decision
    double[] decision = aiAgent.CalculateWeights(sensorInputs);
    
    // Apply movement (tanh output gives -1 to 1 range)
    float moveX = (float)decision[0]; 
    float moveY = (float)decision[1];
    
    // Move your agent accordingly
    MoveAgent(moveX, moveY);
}
```

## Notes for Genetic Algorithms

FlappyBrain is designed with genetic algorithms in mind. Here's a brief overview of how you might use it:

1. Create a population of networks
2. Evaluate each network's fitness based on performance
3. Select the best networks for reproduction
4. Apply mutation and crossover to create a new generation

While FlappyBrain doesn't include built-in genetic algorithm functions, its design makes it easy to implement your own genetic approach.

## Support

For issues or questions, visit the GitHub repository: [https://github.com/shinymajesty/flappybrain](https://github.com/shinymajesty/flappybrain)
