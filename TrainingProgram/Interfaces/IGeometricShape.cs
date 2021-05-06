using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
        Point GetRight();
        Point GetLeft();
        Point GetUp();
        Point GetDown();
    }
    
    public interface IEllipse : IGeometricShape
    {
        Point Point { get; }
        Size Size { get; }
        Brush Color { get; set; }
        
        Point GetRight();
        Point GetLeft();
        Point GetUp();
        Point GetDown();
    }
    
    public interface IRectangleText : IGeometricShape
    {
        Size Size { get; }
        Brush Color { get; set; }
    }
    
    public interface ILine : IGeometricShape
    {
        Point Start { get; }
        Point End { get; }
        Pen Pen { get; }
    }

    public class Text
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

        public Point GetRight()
        {
            var points = Points.ToList();
            var max = points.Max(s => s.X);
            var result = points.Where(p => p.X == max).ToArray();
            return new Point(result[0].X ,result.Sum(p => p.Y) / result.Length);
        }
        
        public Point GetLeft()
        {
            var points = Points.ToList();
            var min = points.Min(s => s.X);
            var result = points.Where(p => p.X == min).ToArray();
            return new Point(result[0].X ,result.Sum(p => p.Y) / result.Length);
        }
        
        public Point GetUp()
        {
            var points = Points.ToList();
            var min = points.Min(s => s.Y);
            var result = points.Where(p => p.Y == min).ToArray();
            return new Point(result.Sum(p => p.X) / result.Length ,result[0].Y);
        }
        
        public Point GetDown()
        {
            var points = Points.ToList();
            var max = points.Max(s => s.Y);
            var result = points.Where(p => p.Y == max).ToArray();
            return new Point(result.Sum(p => p.X) / result.Length ,result[0].Y);
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
        public Point GetRight()
        {
            return new Point(Point.X + Size.Width, Point.Y + Size.Height / 2);
        }

        public Point GetLeft()
        {
            return new Point(Point.X, Point.Y + Size.Height / 2);
        }

        public Point GetUp()
        {
            return new Point(Point.X + Size.Width / 2, Point.Y);
        }

        public Point GetDown()
        {
            return new Point(Point.X + Size.Width / 2, Point.Y + Size.Height);
        }

    }
    
    public class RectangleText : IRectangleText
    {
        public Text Text { get;  set; }
        public Size Size { get; }
        public Brush Color { get; set; }

        public RectangleText(Size size, Brush color, Text text)
        {
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