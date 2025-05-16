namespace FlappyBrain.Tests
{
    public class UnitTest1
    {
        private double SigmoidFunction(double x) => 1.0 / (1.0 + Math.Exp(-x));

        [Fact]
        public void Sigmoid_NaNInput_ReturnsNaN()
        {
            double result = SigmoidFunction(double.NaN);
            Assert.True(double.IsNaN(result), "Expected NaN for input NaN.");
        }

        [Fact]
        public void Sigmoid_PositiveInfinity_ReturnsOne()
        {
            double result = SigmoidFunction(double.PositiveInfinity);
            Assert.Equal(1.0, result, precision: 15); // Precision allows for floating-point tolerance
        }

        [Fact]
        public void Sigmoid_NegativeInfinity_ReturnsZero()
        {
            double result = SigmoidFunction(double.NegativeInfinity);
            Assert.Equal(0.0, result, precision: 15);
        }

        [Fact]
        public void Sigmoid_Zero_ReturnsHalf()
        {
            double result = SigmoidFunction(0.0);
            Assert.Equal(0.5, result, precision: 15);
        }

        [Fact]
        public void Sigmoid_LargeNegative_ReturnsApproxZero()
        {
            double result = SigmoidFunction(-1000.0);
            Assert.Equal(0.0, result, precision: 15);
        }

        [Fact]
        public void Sigmoid_LargePositive_ReturnsApproxOne()
        {
            double result = SigmoidFunction(1000.0);
            Assert.Equal(1.0, result, precision: 15);
        }
    }
}
