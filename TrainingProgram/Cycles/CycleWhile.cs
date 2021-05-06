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
            CycleIndex = StartCycleIndex - 1;
            Index = CycleIndex;
            Sum = 0;
            EndProgramm = false;
        }

        protected override string UpdateTextCode()
        {
            return $"var\n     i, sum: integer;\nbegin\n    for i:=1 to 10 do\n        sum += i;\n    write(sum);\nend.\nsum = {Sum}\ni = {CycleIndex} \n{Index}";
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
                    new Point(LeftBorder.X + 200, BeginEllipse.GetDown().Y + 50),
                    new Point(LeftBorder.X, BeginEllipse.GetDown().Y + 50)
                    // new Point(LeftBorder.X, LeftBorder.Y + 100),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 100),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 125),
                    // new Point(LeftBorder.X, LeftBorder.Y + 125)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, BeginEllipse.GetDown().Y + 25), TextLine = "i := 1"}
            );
            
            Cycle = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, InitializationIndex.GetDown().Y + 50),
                    new Point(LeftBorder.X + 50, InitializationIndex.GetDown().Y + 25),
                    new Point(LeftBorder.X + 150, InitializationIndex.GetDown().Y + 25),
                    new Point(LeftBorder.X + 200, InitializationIndex.GetDown().Y + 50),
                    new Point(LeftBorder.X + 150, InitializationIndex.GetDown().Y + 75),
                    new Point(LeftBorder.X + 50, InitializationIndex.GetDown().Y + 75),
                    // new Point(LeftBorder.X, LeftBorder.Y + 175),
                    // new Point(LeftBorder.X + 50, LeftBorder.Y + 150),
                    // new Point(LeftBorder.X + 150, LeftBorder.Y + 150),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 175),
                    // new Point(LeftBorder.X + 150, LeftBorder.Y + 200),
                    // new Point(LeftBorder.X + 50, LeftBorder.Y + 200),
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, InitializationIndex.GetDown().Y + 30), TextLine = "i < 10"}
            );
            CycleBodySum = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, Cycle.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, Cycle.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, Cycle.GetDown().Y + 75),
                    new Point(LeftBorder.X, Cycle.GetDown().Y + 75)
                    // new Point(LeftBorder.X, LeftBorder.Y + 250),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 250),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 275),
                    // new Point(LeftBorder.X, LeftBorder.Y + 275)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, Cycle.GetDown().Y + 50), TextLine = "sum += i"}
                );
            CycleBodyIndex = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, CycleBodySum.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, CycleBodySum.GetDown().Y + 50),
                    new Point(LeftBorder.X + 200, CycleBodySum.GetDown().Y + 75),
                    new Point(LeftBorder.X, CycleBodySum.GetDown().Y + 75)
                    // new Point(LeftBorder.X, LeftBorder.Y + 325),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 325),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 350),
                    // new Point(LeftBorder.X, LeftBorder.Y + 350)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, CycleBodySum.GetDown().Y + 50), TextLine = "i += 1"}
            );
            Result = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, CycleBodyIndex.GetDown().Y + 75),
                    new Point(LeftBorder.X + 200, CycleBodyIndex.GetDown().Y + 75),
                    new Point(LeftBorder.X + 200, CycleBodyIndex.GetDown().Y + 100),
                    new Point(LeftBorder.X, CycleBodyIndex.GetDown().Y + 100)
                    // new Point(LeftBorder.X, LeftBorder.Y + 425),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 425),
                    // new Point(LeftBorder.X + 200, LeftBorder.Y + 450),
                    // new Point(LeftBorder.X, LeftBorder.Y + 450)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, CycleBodyIndex.GetDown().Y + 75), TextLine = "sum"}
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
        
        protected override List<StateElements> GoNext()
        {
            Brush[] colors = null;
            var result = new List<StateElements>();
            result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, Index = Index, CycleIndex = CycleIndex, Sum = Sum});
            result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, Index = Index, CycleIndex = 1, Sum = Sum});
            for (var i = 1; i < 10; i++)
            {
                CycleIndex = i;
                result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, Index = Index, CycleIndex = CycleIndex, Sum = Sum});
                Sum += CycleIndex;
                result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White}, Index = Index, CycleIndex = CycleIndex, Sum = Sum});
                result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White}, Index = Index, CycleIndex = CycleIndex + 1, Sum = Sum});
            }
            result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White}, Index = Index, CycleIndex = CycleIndex + 1, Sum = Sum});
            result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White}, Index = Index, CycleIndex = CycleIndex + 1, Sum = Sum});
            result.Add(new StateElements(){StateOfCode = EndProgramm, Colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green}, Index = Index, CycleIndex = CycleIndex + 1, Sum = Sum});

            return result;
            
            // if (Index == 0)
            // {
            //     colors = new[] {Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White};
            // }
            // else if (Index == 1)
            // {
            //     CycleIndex = 1;
            //     colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White};
            // }
            // else if (CycleIndex == EndCycleIndex && Index % 2 == 0)
            // {
            //     EndProgramm = false;
            //     colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White};
            // }
            // else if (CycleIndex == EndCycleIndex && Index % 2 == 1)
            // {
            //     EndProgramm = true;
            //     colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green};
            // } 
            // else
            // {
            //     if (Index % 3 == 1)
            //     {
            //         if (status == SubThemeStatus.NextStep) CycleIndex++;
            //         else if (status == SubThemeStatus.BackStep) CycleIndex--;
            //         colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White};
            //     }
            //     if (Index % 3 == 0)
            //     {
            //         if (status == SubThemeStatus.NextStep) Sum += CycleIndex;
            //         else if (status == SubThemeStatus.BackStep) Sum -= CycleIndex;
            //         colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White};
            //     }
            //     if (Index % 3 == 2)
            //     {
            //         colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White};
            //     }
            // }
            // return new StateElements()
            //     {StateOfCode = EndProgramm, Colors = colors, Index = Index, CycleIndex = CycleIndex, Sum = Sum};
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