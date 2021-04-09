namespace DesignPatterns.Exercises.Section07_Bridge
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape
    {
        private readonly string name;

        private readonly IRenderer renderer;

        public Shape(string name, IRenderer renderer)
        {
            this.name = name;
            this.renderer = renderer;
        }

        public override string ToString()
        {
            return $"Drawing {name} as {renderer.WhatToRenderAs}";
        }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base("Triangle", renderer)
        { }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base("Square", renderer)
        { }
    }
}
