using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleDoWhile : CycleTemplate
    {
        private IRectangleText RectangleTextCode;
        private IEllipse BeginEllipse;
        private IClosedLine InitializationIndex;
        private IClosedLine ShapeSum;
        private IClosedLine ShapeIndex;
        private IClosedLine ShapeСondition;
        private IClosedLine Result;
        private IEllipse EndEllipse;
        public CycleDoWhile(int startCycleIndex, int endCycleIndex) : base(startCycleIndex, endCycleIndex)
        {
        }
        protected override void InitializationFields()
        {
            Index = 0;
        }

        protected override string UpdateTextCode()
        {
            return $"var\n     i, sum: integer;\nbegin\n    i := {StartCycleIndex}\n    repeat\n        sum += i;\n        i += 1;\n    until i > {EndCycleIndex};\n    write(sum);\nend.\nsum = {Sum}\ni = {CycleIndex}";
        }

        protected override void InitializationShapes()
        {
            
            RectangleTextCode = new RectangleText(
                new Size(400, 400),
                Brushes.Red,
                new Text() {Point = new Point(LeftBorder.X + 350, LeftBorder.Y + 50), 
                    TextLine = UpdateTextCode()}
            );
            
            BeginEllipse = new Ellipse(
                new Point(LeftBorder.X, LeftBorder.Y + 25),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, LeftBorder.Y + 25), TextLine = "begin"}
            );
            
            InitializationIndex = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, BeginEllipse.GetDown().Y + 25),
                    new Point(LeftBorder.X + 200, BeginEllipse.GetDown().Y + 25),
                    new Point(LeftBorder.X + 200, BeginEllipse.GetDown().Y + 75),
                    new Point(LeftBorder.X, BeginEllipse.GetDown().Y + 75)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, BeginEllipse.GetDown().Y + 30), TextLine = $"i := {StartCycleIndex}"}
            );
            
            ShapeSum = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, InitializationIndex.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, InitializationIndex.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, InitializationIndex.GetDown().Y + 100),
                    new Point(LeftBorder.X, InitializationIndex.GetDown().Y + 100)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, InitializationIndex.GetDown().Y + 55), TextLine = "sum += i"}
            );
            
            ShapeIndex = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, ShapeSum.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, ShapeSum.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, ShapeSum.GetDown().Y + 100),
                    new Point(LeftBorder.X, ShapeSum.GetDown().Y + 100)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, ShapeSum.GetDown().Y + 55), TextLine = "i += 1"}
            );
            
            ShapeСondition = new ClosedLine(
                new[]
                {
                    new Point(ShapeIndex.GetLeft().X, ShapeIndex.GetLeft().Y + 75),
                    new Point(ShapeIndex.GetDown().X, ShapeIndex.GetDown().Y + 25),
                    new Point(ShapeIndex.GetRight().X, ShapeIndex.GetRight().Y + 75),
                    new Point(ShapeIndex.GetDown().X, ShapeIndex.GetDown().Y + 75)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 60, ShapeIndex.GetDown().Y + 30), TextLine = $"i < {EndCycleIndex}"}
            );
            
            Result = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, ShapeСondition.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, ShapeСondition.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, ShapeСondition.GetDown().Y + 100),
                    new Point(LeftBorder.X, ShapeСondition.GetDown().Y + 100)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, ShapeСondition.GetDown().Y + 55), TextLine = "sum"}
            );
            
            EndEllipse = new Ellipse(
                new Point(LeftBorder.X, Result.GetDown().Y + 50),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, Result.GetDown().Y + 50), TextLine = "end"}
            );
        }

        protected override void AddLines()
        {
            var pen = new Pen(Color.Red,3);
            pen.CustomEndCap = new AdjustableArrowCap(4, 4);
            Shapes.AddRange(СonnectLines(pen, new []{BeginEllipse.GetDown(), InitializationIndex.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{InitializationIndex.GetDown(), ShapeSum.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{ShapeSum.GetDown(), ShapeIndex.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{ShapeIndex.GetDown(), ShapeСondition.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{ShapeСondition.GetDown(), Result.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []
            {
                ShapeСondition.GetRight(), new Point(ShapeСondition.GetRight().X + 25, ShapeСondition.GetRight().Y),
                new Point(ShapeСondition.GetRight().X + 25, ShapeSum.GetRight().Y),
                ShapeSum.GetRight()
            }));
            Shapes.AddRange(СonnectLines(pen, new []{Result.GetDown(), EndEllipse.GetUp()}));
        }
        
        protected override List<StateElements> CreateStates()
        {
            var result = new List<StateElements>();
            result.Add(new StateElements(){Colors = new[] {Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = CycleIndex, Sum = Sum});
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = StartCycleIndex, Sum = Sum});
            for (var i = StartCycleIndex; i < EndCycleIndex; i++)
            {
                Sum += i;
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = i, Sum = Sum});
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = i + 1, Sum = Sum});
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White}, CycleIndex = i + 1, Sum = Sum});
            }
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White}, CycleIndex = EndCycleIndex, Sum = Sum});
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green}, CycleIndex = EndCycleIndex, Sum = Sum});

            return result;
        }
        
        protected override void UpdateShapes(Brush[] colors)
        {
            RectangleTextCode.Text.TextLine = UpdateTextCode();
            BeginEllipse.Color = colors[0];
            InitializationIndex.Color = colors[1];
            ShapeSum.Color = colors[2];
            ShapeIndex.Color = colors[3];
            ShapeСondition.Color = colors[4];
            Result.Color = colors[5];
            EndEllipse.Color = colors[6];
        }

        public override string GetName() => "Do While";
    }
}