using System.Collections.Generic;
using System.Drawing;

namespace TrainingProgram
{
    public interface IGeometricShape
    {
        Text Text { get; }
    }

    public interface IClosedLine : IGeometricShape
    {
        IReadOnlyCollection<Point> Points { get; }
        Brush Color { get; }
    }
    
    public interface ILine : IGeometricShape
    {
        Point Start { get; }
        Point End { get; }
        Pen Pen { get; }
    }

    public struct Text
    {
        public Point Point;
        public string TextLine;
    }

    public class ClosedLine : IClosedLine
    {
        public Text Text { get; private set; }
        public IReadOnlyCollection<Point> Points { get; private set;}
        public Brush Color { get; private set;}

        public ClosedLine(IReadOnlyCollection<Point> points, Brush color, Text text)
        {
            Points = points;
            Color = color;
            Text = text;
        }
    }
    
    public class Line : ILine
    {
        public Text Text { get; }
        public Point Start { get; }
        public Point End { get; }
        public Pen Pen { get; }

        public Line(Point start, Point end, Pen pen, Text text)
        {
            Start = start;
            End = end;
            Pen = pen;
            Text = text;
        }
    }
}