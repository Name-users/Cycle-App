using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;


namespace TrainingProgram
{
    
    public class CycleWhile : CycleTemplate
    {
        private IRectangleText RectangleTextCode;
        private IEllipse BeginEllipse;
        private IClosedLine InitializationIndex;
        private IClosedLine Cycle;
        private IClosedLine CycleBodySum;
        private IClosedLine CycleBodyIndex;
        private IClosedLine Result;
        private IEllipse EndEllipse;
        public CycleWhile(int startCycleIndex, int endCycleIndex) : base(startCycleIndex, endCycleIndex)
        {
        }
        protected override void InitializationFields()
        {
            Index = 0;
        }

        protected override string UpdateTextCode()
        {
            return $"var\n     i, sum: integer;\nbegin\n    i := {StartCycleIndex}\n    while i < {EndCycleIndex} do begin\n        sum += i;\n        i += 1;\n    end;\n    write(sum);\nend.\nsum = {Sum}\ni = {CycleIndex}";
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
            
            Cycle = new ClosedLine(
                new[]
                {
                    new Point(InitializationIndex.GetLeft().X, InitializationIndex.GetLeft().Y + 75),
                    new Point(InitializationIndex.GetDown().X, InitializationIndex.GetDown().Y + 25),
                    new Point(InitializationIndex.GetRight().X, InitializationIndex.GetRight().Y + 75),
                    new Point(InitializationIndex.GetDown().X, InitializationIndex.GetDown().Y + 75)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 60, InitializationIndex.GetDown().Y + 30), TextLine = $"i < {EndCycleIndex}"}
            );
            CycleBodySum = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, Cycle.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, Cycle.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, Cycle.GetDown().Y + 100),
                    new Point(LeftBorder.X, Cycle.GetDown().Y + 100)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, Cycle.GetDown().Y + 60), TextLine = "sum += i"}
                );
            CycleBodyIndex = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, CycleBodySum.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, CycleBodySum.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, CycleBodySum.GetDown().Y + 100),
                    new Point(LeftBorder.X, CycleBodySum.GetDown().Y + 100)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, CycleBodySum.GetDown().Y + 60), TextLine = "i += 1"}
            );
            Result = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, CycleBodyIndex.GetDown().Y + 75),
                    new Point(LeftBorder.X + 200, CycleBodyIndex.GetDown().Y + 75),
                    new Point(LeftBorder.X + 200, CycleBodyIndex.GetDown().Y + 125),
                    new Point(LeftBorder.X, CycleBodyIndex.GetDown().Y + 125)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, CycleBodyIndex.GetDown().Y + 80), TextLine = "sum"}
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
            Shapes.AddRange(СonnectLines(pen, new []{InitializationIndex.GetDown(), Cycle.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{Cycle.GetDown(), CycleBodySum.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{CycleBodySum.GetDown(), CycleBodyIndex.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []
            {
                Cycle.GetRight(), new Point(Cycle.GetRight().X + 25, Cycle.GetRight().Y),
                new Point(Cycle.GetRight().X + 25, Result.GetUp().Y - 25),
                new Point(Result.GetUp().X, Result.GetUp().Y - 25),
                Result.GetUp()
            }));
            Shapes.AddRange(СonnectLines(pen, new []
            {
                CycleBodyIndex.GetDown(), new Point(CycleBodyIndex.GetDown().X, CycleBodyIndex.GetDown().Y + 25),
                new Point(Cycle.GetLeft().X - 25, CycleBodyIndex.GetDown().Y + 25),
                new Point(Cycle.GetLeft().X - 25, Cycle.GetLeft().Y),
                Cycle.GetLeft()
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
                CycleIndex = i;
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = CycleIndex, Sum = Sum});
                Sum += CycleIndex;
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = CycleIndex, Sum = Sum});
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White}, CycleIndex = CycleIndex + 1, Sum = Sum});
            }
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = EndCycleIndex, Sum = Sum});
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White}, CycleIndex = EndCycleIndex, Sum = Sum});
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green}, CycleIndex = EndCycleIndex, Sum = Sum});

            return result;
        }
        
        protected override void UpdateShapes(Brush[] colors)
        {
            RectangleTextCode.Text.TextLine = UpdateTextCode();
            BeginEllipse.Color = colors[0];
            InitializationIndex.Color = colors[1];
            Cycle.Color = colors[2];
            CycleBodySum.Color = colors[3];
            CycleBodyIndex.Color = colors[4];
            Result.Color = colors[5];
            EndEllipse.Color = colors[6];
        }

        public override string GetName() => "While";
    }
}