using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleFor : CycleTemplate
    {
        private IRectangleText RectangleTextCode;
        private IEllipse BeginEllipse;
        private IClosedLine Cycle;
        private IClosedLine CycleBody;
        private IClosedLine Result;
        private IEllipse EndEllipse;

        public CycleFor(int start, int end) : base(start, end)
        {
        }

        protected override void InitializationFields()
        {
            Index = 0;
            Sum = 0;
        }

        protected override string UpdateTextCode()
        {
            return $"var\n     i, sum: integer;\nbegin\n    for i:={StartCycleIndex} to {EndCycleIndex} do\n        sum += i;\n    write(sum);\nend.\nsum = {Sum}\ni = {CycleIndex}";
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
                new Point(LeftBorder.X, LeftBorder.Y + 50),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, LeftBorder.Y + 50), TextLine = "begin"}
            );

            Cycle = new ClosedLine(
                new[]
                {
                    // new Point(LeftBorder.X, LeftBorder.Y + 150),
                    // new Point(LeftBorder.X + 50, LeftBorder.Y + 125),
                    // new Point(LeftBorder.X + 150, LeftBorder.Y + 125),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 150),
                    // new Point(LeftBorder.X + 150, LeftBorder.Y + 175),
                    // new Point(LeftBorder.X + 50, LeftBorder.Y + 175),
                    new Point(LeftBorder.X, BeginEllipse.GetDown().Y + 50),
                    new Point(LeftBorder.X + 50, BeginEllipse.GetDown().Y + 25),
                    new Point(LeftBorder.X + 150, BeginEllipse.GetDown().Y + 25),
                    new Point(LeftBorder.X + 200, BeginEllipse.GetDown().Y + 50),
                    new Point(LeftBorder.X + 150, BeginEllipse.GetDown().Y + 75),
                    new Point(LeftBorder.X + 50, BeginEllipse.GetDown().Y + 75),
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 23, BeginEllipse.GetDown().Y + 30), TextLine = "i:=1; 10; +1"}
            );
            CycleBody = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, Cycle.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, Cycle.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, Cycle.GetDown().Y + 100),
                    new Point(LeftBorder.X, Cycle.GetDown().Y + 100)
                    // new Point(LeftBorder.X, LeftBorder.Y + 225),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 225),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 275),
                    // new Point(LeftBorder.X, LeftBorder.Y + 275)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 25, Cycle.GetDown().Y + 55), TextLine = "sum += i"}
                );
            Result = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, CycleBody.GetDown().Y + 75),
                    new Point(LeftBorder.X + 200, CycleBody.GetDown().Y + 75),
                    new Point(LeftBorder.X + 200, CycleBody.GetDown().Y + 125),
                    new Point(LeftBorder.X, CycleBody.GetDown().Y + 125)
                    // new Point(LeftBorder.X, LeftBorder.Y + 350),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 350),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 375),
                    // new Point(LeftBorder.X, LeftBorder.Y + 375)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, CycleBody.GetDown().Y + 80), TextLine = "sum"}
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
            Shapes.AddRange(СonnectLines(pen, new []{BeginEllipse.GetDown(), Cycle.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []{Cycle.GetDown(), CycleBody.GetUp()}));
            Shapes.AddRange(СonnectLines(pen, new []
            {
                Cycle.GetRight(), new Point(Cycle.GetRight().X + 25, Cycle.GetRight().Y),
                new Point(Cycle.GetRight().X + 25, Result.GetUp().Y - 25),
                new Point(Result.GetUp().X, Result.GetUp().Y - 25),
                Result.GetUp()
            }));
            Shapes.AddRange(СonnectLines(pen, new []
            {
                CycleBody.GetDown(), new Point(CycleBody.GetDown().X, CycleBody.GetDown().Y + 25),
                new Point(Cycle.GetLeft().X - 25, CycleBody.GetDown().Y + 25),
                new Point(Cycle.GetLeft().X - 25, Cycle.GetLeft().Y),
                Cycle.GetLeft()
            }));
            Shapes.AddRange(СonnectLines(pen, new []{Result.GetDown(), EndEllipse.GetUp()}));
        }

        protected override List<StateElements> CreateStates()
        {
            var result = new List<StateElements>();
            result.Add(new StateElements(){Colors = new[] {Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = CycleIndex, Sum = Sum});
            for (var i = StartCycleIndex; i < EndCycleIndex; i++)
            {
                CycleIndex = i;
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = CycleIndex, Sum = Sum});
                Sum += CycleIndex;
                result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White}, CycleIndex = CycleIndex, Sum = Sum});
            }
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White}, CycleIndex = EndCycleIndex, Sum = Sum});
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White}, CycleIndex = EndCycleIndex, Sum = Sum});
            result.Add(new StateElements(){Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green}, CycleIndex = EndCycleIndex, Sum = Sum});

            return result;
            return new List<StateElements>();
            // Brush[] colors = null;
            // if (Index == StartCycleIndex - 1)
            // {
            //     colors = new[] {Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White};
            //     
            // }            // else if(status == SubThemeStatus.Stay) return;
            // else if (CycleIndex == EndCycleIndex && Index % 2 == 0)
            // {
            //     EndProgramm = false;
            //     colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White};
            // }
            // else if (CycleIndex == EndCycleIndex && Index % 2 == 1)
            // {
            //     EndProgramm = true;
            //     colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green};
            // }
            // else
            // {
            //     if (Index % 2 == 1)
            //     {
            //         if (status == SubThemeStatus.NextStep) CycleIndex++;
            //         else if (status == SubThemeStatus.BackStep) CycleIndex--;
            //         colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White};
            //     }
            //     else
            //     {
            //         if (status == SubThemeStatus.NextStep) Sum += CycleIndex;
            //         else if (status == SubThemeStatus.BackStep) Sum -= CycleIndex;
            //         colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White};
            //     }
            // }
            // return new StateElements()
            //     {StateOfCode = EndProgramm, Colors = colors, Index = Index, CycleIndex = CycleIndex, Sum = Sum};
        }
        
        protected override void UpdateShapes(Brush[] colors)
        {
            RectangleTextCode.Text.TextLine = UpdateTextCode();
            BeginEllipse.Color = colors[0];
            Cycle.Color = colors[1];
            CycleBody.Color = colors[2];
            Result.Color = colors[3];
            EndEllipse.Color = colors[4];
        }

        public override string GetName() => "For";
    }
}