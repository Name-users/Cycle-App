using System.Collections.Generic;
using System.Drawing;

namespace TrainingProgram
{
    public interface IGeometricShape
    {
        Text Text { get; set; }
    }

    public interface IClosedLine : IGeometricShape
    {
        IReadOnlyCollection<Point> Points { get; }
        Brush Color { get; set; }
    }
    
    public interface IEllipse : IGeometricShape
    {
        Point Point { get; }
        Size Size { get; }
        Brush Color { get; set; }
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
        public bool IsEmpty;
    }

    public class ClosedLine : IClosedLine
    {
        public Text Text { get;  set; }
        public IReadOnlyCollection<Point> Points { get; private set;}
        public Brush Color { get;  set;}

        public ClosedLine(IReadOnlyCollection<Point> points, Brush color, Text text)
        {
            Points = points;
            Color = color;
            Text = text;
        }
    }
    
    public class Ellipse : IEllipse
    {
        public Text Text { get;  set; }
        public Point Point { get; private set;}
        public Brush Color { get;  set;}
        public Size Size { get; private set;}

        public Ellipse(Point point, Size size, Brush color, Text text)
        {
            Point = point;
            Color = color;
            Text = text;
            Size = size;
        }
    }
    
    public class Line : ILine
    {
        public Text Text { get; set; }
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