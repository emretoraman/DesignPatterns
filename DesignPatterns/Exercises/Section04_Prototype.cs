namespace DesignPatterns.Exercises.Section04_Prototype
{
    public class Point
    {
        public int X, Y;

        public Point DeepCopy()
        {
            return new Point { X = X, Y = Y};
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return new Line
            {
                Start = Start.DeepCopy(),
                End = End.DeepCopy()
            };
        }

        public override string ToString()
        {
            return $"Start: {Start}, End: {End}";
        }
    }
}
