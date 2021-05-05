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
        // private readonly int StartCycleIndex;
        // private readonly int EndCycleIndex;
        // private readonly Stack<StateElements> stack;
        // private int CycleIndex;
        // private int Index;
        // private int Sum;
        // private bool EndProgramm;
        // private List<IGeometricShape> Shapes = new List<IGeometricShape>();
        // private Point LeftBorder = new Point(800, 100);

        public CycleFor() : base(1, 10)
        {
            
            // StartCycleIndex = 1;
            // EndCycleIndex = 10;
            // stack = new Stack<StateElements>();
            // InitializationFields();
            // InitializationShapes();
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
            BeginEllipse = new Ellipse(
                new Point(LeftBorder.X, LeftBorder.Y + 50),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 50, LeftBorder.Y + 50), TextLine = "begin"}
            );
            
            RectangleTextCode = new RectangleText(
                new Size(400, 400),
                Brushes.Red,
                new Text() {Point = new Point(LeftBorder.X + 350, LeftBorder.Y + 50), 
                    TextLine = UpdateTextCode()}
                );
            
            Cycle = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 150),
                    new Point(LeftBorder.X + 50, LeftBorder.Y + 125),
                    new Point(LeftBorder.X + 150, LeftBorder.Y + 125),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 150),
                    new Point(LeftBorder.X + 150, LeftBorder.Y + 175),
                    new Point(LeftBorder.X + 50, LeftBorder.Y + 175),
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 23, LeftBorder.Y + 130), TextLine = "i:=1; 10; +1"}
            );
            CycleBody = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 225),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 225),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 275),
                    new Point(LeftBorder.X, LeftBorder.Y + 275)
                },
                Brushes.White,
                new Text() {Point = new Point(LeftBorder.X + 25, LeftBorder.Y + 230), TextLine = "sum += i"}
                );
            Result = new ClosedLine(
                new[]
                {
                    new Point(LeftBorder.X, LeftBorder.Y + 350),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 350),
                    new Point(LeftBorder.X + 200, LeftBorder.Y + 375),
                    new Point(LeftBorder.X, LeftBorder.Y + 375)
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
            var arrEnd = CycleBody.Points.ToArray();
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2, LeftBorder.Y + 75),
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2, arrStart[1].Y),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2,arrStart[4].Y),
                new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[0].Y),
                pen,
                new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[3].Y),
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[3].Y + 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[3].Y + 25),
                    new Point(LeftBorder.X - 25,arrEnd[3].Y + 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X - 25,arrEnd[3].Y + 25),
                    new Point(LeftBorder.X - 25,arrStart[3].Y ),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X - 25,arrStart[3].Y ),
                    new Point(LeftBorder.X,arrStart[3].Y ),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(arrStart[3].X, arrStart[3].Y),
                    new Point(arrStart[3].X + 25, arrStart[3].Y),
                    pen,
                    new Text()
                )
            );

            arrEnd = Result.Points.ToArray();
            Shapes.Add(new Line(
                    new Point(arrStart[3].X + 25, arrStart[3].Y),
                    new Point(arrStart[3].X + 25, arrEnd[1].Y - 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(arrStart[3].X + 25, arrEnd[1].Y - 25),
                    new Point(LeftBorder.X + (arrEnd[1].X - arrEnd[0].X) / 2, arrEnd[1].Y - 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X + (arrEnd[1].X - arrEnd[0].X) / 2, arrEnd[1].Y - 25),
                    new Point(LeftBorder.X + (arrEnd[1].X - arrEnd[0].X) / 2, arrEnd[1].Y),
                    
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2, arrEnd[2].Y),
                    new Point(LeftBorder.X + (arrStart[3].X - arrStart[0].X) / 2, arrEnd[2].Y + 50),
                    pen,
                    new Text()
                )
            );
        }

        // private void AddShapes()
        // {
        //     Shapes = this.GetType()
        //         .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //         .Where(f => f.GetValue(this) is IGeometricShape)
        //         .Select(f => f.GetValue(this))
        //         .Cast<IGeometricShape>()
        //         .ToList();
        //     AddLines();
        // }

        // public IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status)
        // {
        //     if(Shapes.Count == 0)
        //         AddShapes();
        //     if (status == SubThemeStatus.Stay && Index == 0)
        //     {
        //         var currentState = GoNext(status);
        //         UpdateShapes(currentState.Colors);
        //         stack.Push(currentState);
        //     }
        //     else if (status == SubThemeStatus.NextStep && CycleIndex <= EndCycleIndex && !EndProgramm)
        //     {
        //         Index++;
        //         var currentState = GoNext(status);
        //         UpdateShapes(currentState.Colors);
        //         stack.Push(currentState);
        //     }
        //     else if (status == SubThemeStatus.BackStep && Index > StartCycleIndex)
        //     {
        //         var currentState = stack.Pop();
        //         EndProgramm = currentState.StateOfCode;
        //         Index = currentState.Index;
        //         CycleIndex = currentState.CycleIndex;
        //         Sum = currentState.Sum;
        //         UpdateShapes(currentState.Colors);
        //         // Index--;
        //     }
        //     // if(status != SubThemeStatus.Stay)
        //     //     GoNext(status);
        //     return Shapes.AsReadOnly();
        // }

        
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
            CycleBody.Color = colors[2];
            Result.Color = colors[3];
            EndEllipse.Color = colors[4];
        }

        // public void Close()
        // {
        //     Shapes.Clear();
        //     stack.Clear();
        //     InitializationFields();
        // }

        public override string GetName() => "For";
    }
}