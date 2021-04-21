namespace TrainingProgram
{
    public static class Extends
    {
        public static int Multiply(this int value, double coefficient) => (int)(value * coefficient);
        public static int Add(this int value, double other) => (int)(value + other);
        public static int Subtract(this int value, double other) => (int)(value - other);
    }
}