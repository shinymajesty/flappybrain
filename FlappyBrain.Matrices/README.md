# FlappyBrain.Matrices QuickStart Guide

FlappyBrain.Matrices is a complementary package to the NeuralFlapper library, providing essential matrix operations for neural network calculations. This guide will help you understand and use the matrix utilities.

## Installation

Install the FlappyBrain.Matrices package via NuGet:

```
dotnet add package NeuralFlapperMatrices
```

Or via the NuGet Package Manager Console:

```
Install-Package NeuralFlapperMatrices
```

## Basic Usage

### Importing the Library

```csharp
using FlappyBrain.Matrices;
```

### Matrix Multiplication

```csharp
// Create two matrices
double[,] matrixA = new double[,] {
    { 1, 2, 3 },
    { 4, 5, 6 }
};  // 2x3 matrix

double[,] matrixB = new double[,] {
    { 7, 8 },
    { 9, 10 },
    { 11, 12 }
};  // 3x2 matrix

// Multiply matrices
double[,] result = FlappyMatrix.MultiplyMatrix(matrixA, matrixB);
// Result is a 2x2 matrix
```

### Scalar Multiplication

```csharp
double[,] matrix = new double[,] {
    { 1, 2 },
    { 3, 4 }
};

// Multiply by scalar value
double scalar = 2.5;
double[,] result = FlappyMatrix.ScalarMultiplication(matrix, scalar);
// Result: { {2.5, 5.0}, {7.5, 10.0} }
```

### Matrix Addition

```csharp
double[,] matrixA = new double[,] {
    { 1, 2 },
    { 3, 4 }
};

double[,] matrixB = new double[,] {
    { 5, 6 },
    { 7, 8 }
};

double[,] result = FlappyMatrix.AddMatrix(matrixA, matrixB);
// Result: { {6, 8}, {10, 12} }
```

### Matrix Subtraction

```csharp
double[,] matrixA = new double[,] {
    { 10, 20 },
    { 30, 40 }
};

double[,] matrixB = new double[,] {
    { 5, 10 },
    { 15, 20 }
};

double[,] result = FlappyMatrix.SubtractMatrix(matrixA, matrixB);
// Result: { {5, 10}, {15, 20} }
```

### Matrix Transposition

```csharp
double[,] matrix = new double[,] {
    { 1, 2, 3 },
    { 4, 5, 6 }
};  // 2x3 matrix

double[,] transposed = FlappyMatrix.TransposeMatrix(matrix);
// Result is a 3x2 matrix: { {1, 4}, {2, 5}, {3, 6} }
```

### Applying Operations to Matrices

The `PerformOperation` method allows you to apply a custom operation to each element in a matrix using a delegate function.

```csharp
// Define a custom operation
double SquareRoot(double value) => Math.Sqrt(value);

double[,] matrix = new double[,] {
    { 4, 9 },
    { 16, 25 }
};

// Apply the square root operation to each element
double[,] result = FlappyMatrix.PerformOperation(matrix, SquareRoot);
// Result: { {2, 3}, {4, 5} }
```

You can also use lambda expressions for inline operations:

```csharp
double[,] matrix = new double[,] {
    { 1, 2 },
    { 3, 4 }
};

// Square each element
double[,] squared = FlappyMatrix.PerformOperation(matrix, x => x * x);
// Result: { {1, 4}, {9, 16} }
```

### Printing Matrices

To visualize matrices for debugging or display purposes:

```csharp
double[,] matrix = new double[,] {
    { 1.234, 5.678 },
    { 9.012, 3.456 }
};

string matrixString = FlappyMatrix.PrintMatrix(matrix);
Console.WriteLine(matrixString);
// Output:
// 1.23    5.68
// 9.01    3.46
```


## Error Handling

The matrix operations include error checking for incompatible dimensions:

- Matrix multiplication requires the column count of the first matrix to match the row count of the second matrix
- Addition and subtraction require matrices of the same dimensions

When dimension requirements aren't met, the methods throw exceptions with descriptive error messages.

## Support

For issues or questions, visit the GitHub repository: [https://github.com/shinymajesty/flappybrain](https://github.com/shinymajesty/flappybrain)
