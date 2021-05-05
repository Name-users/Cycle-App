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
                new Text() {Point = new Point(LeftBorder.X + 50, LeftBorder.Y + 50), TextLine = "begin"}
            );
            
            InitializationIndex = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 100),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 100),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 125),
                    new Point(LeftBorder.X, LeftBorder.Y + 125)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 25, LeftBorder.Y + 230), TextLine = "i := 1"}
            );
            
            Cycle = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 175),
                    new Point(LeftBorder.X + 50, LeftBorder.Y + 150),
                    new Point(LeftBorder.X + 150, LeftBorder.Y + 150),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 175),
                    new Point(LeftBorder.X + 150, LeftBorder.Y + 200),
                    new Point(LeftBorder.X + 50, LeftBorder.Y + 200),
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 23, LeftBorder.Y + 130), TextLine = "i < 10"}
            );
            CycleBodySum = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 250),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 250),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 275),
                    new Point(LeftBorder.X, LeftBorder.Y + 275)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 25, LeftBorder.Y + 230), TextLine = "sum += i"}
                );
            CycleBodyIndex = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 325),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 325),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 350),
                    new Point(LeftBorder.X, LeftBorder.Y + 350)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 25, LeftBorder.Y + 230), TextLine = "i += 1"}
            );
            Result = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 425),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 425),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 450),
                    new Point(LeftBorder.X, LeftBorder.Y + 450)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, LeftBorder.Y + 348), TextLine = "sum"}
            );
            
            EndEllipse = new Ellipse(
                new Point(LeftBorder.X, Result.Points.ToArray()[3].Y + 50),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, Result.Points.ToArray()[3].Y + 50), TextLine = "end"}
            );
        }

        protected override void AddLines()
        {
            var pen = new Pen(Color.Red,3);
            pen.CustomEndCap = new AdjustableArrowCap(4, 4);
            var arrStart = Cycle.Points.ToArray();
            var arrEnd = CycleBodySum.Points.ToArray();
            Shapes.AddRange(СonnectLines(pen, new []
            {
                new Point(LeftBorder.X + 100, LeftBorder.Y + 50), InitializationIndex.GetUp()
            }));
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
            Shapes.AddRange(СonnectLines(pen, new []
            {
                Result.GetDown(), new Point(LeftBorder.X + 100, Result.GetDown().Y + 50)
            }));
        }
        
        protected override StateElements GoNext(SubThemeStatus status)
        {
            Brush[] colors = null;
            if (Index == StartCycleIndex - 1)
            {
                colors = new[] {Brushes.Green, Brushes.White, Brushes.White, Brushes.White, Brushes.White};
                
            }            // else if(status == SubThemeStatus.Stay) return;
            else if (CycleIndex == EndCycleIndex && Index % 2 == 0)
            {
                EndProgramm = false;
                colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.Green, Brushes.White};
            }
            else if (CycleIndex == EndCycleIndex && Index % 2 == 1)
            {
                EndProgramm = true;
                colors = new[] {Brushes.White, Brushes.White, Brushes.White, Brushes.White, Brushes.Green};
            }
            else
            {
                if (Index % 2 == 1)
                {
                    if (status == SubThemeStatus.NextStep) CycleIndex++;
                    else if (status == SubThemeStatus.BackStep) CycleIndex--;
                    colors = new[] {Brushes.White, Brushes.Green, Brushes.White, Brushes.White, Brushes.White};
                }
                else
                {
                    if (status == SubThemeStatus.NextStep) Sum += CycleIndex;
                    else if (status == SubThemeStatus.BackStep) Sum -= CycleIndex;
                    colors = new[] {Brushes.White, Brushes.White, Brushes.Green, Brushes.White, Brushes.White};
                }
            }
            return new StateElements()
                {StateOfCode = EndProgramm, Colors = colors, Index = Index, CycleIndex = CycleIndex, Sum = Sum};
        }
        
        protected override void UpdateShapes(Brush[] colors)
        {
            RectangleTextCode.Text.TextLine = UpdateTextCode();
            BeginEllipse.Color = colors[0];
            Cycle.Color = colors[1];
            CycleBodySum.Color = colors[2];
            Result.Color = colors[3];
            EndEllipse.Color = colors[4];
        }

        public override string GetName() => "While";

        
    }
}