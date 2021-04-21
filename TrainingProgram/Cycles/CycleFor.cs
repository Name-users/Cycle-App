using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleFor : ITemplateSubTheme
    {
        private IRectangleText RectangleTextCode;
        private IEllipse BeginEllipse;
        private IClosedLine Cycle;
        private IClosedLine CycleBody;
        private IClosedLine Result;
        private IEllipse EndEllipse;
        private readonly int StartCycleIndex;
        private readonly int EndCycleIndex;
        private int CycleIndex;
        private List<IGeometricShape> Shapes = new List<IGeometricShape>();
        private Point LeftBorder = new Point(800, 100);

        public CycleFor()
        {
            InitializationShapes();
            
            // AddShapes();
            
            // Shapes.Add(Cycle);
            // Shapes.Add(CycleBody);
            // Shapes.Add(Result);
            // Shapes.Add(BeginEllipse);
            // Shapes.Add(EndEllipse);
            StartCycleIndex = 1;
            EndCycleIndex = 10;
            CycleIndex = StartCycleIndex - 1;
            // CycleIndex = StartStatus - 1;
        }

        private void InitializationShapes()
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
                    TextLine = "var\n     i, sum: integer;\nbegin\n    for i:=1 to 10 do\n        sum += i;\n    write(sum);\nend."}
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

        private void AddLines()
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

        private void AddShapes()
        {
            Shapes = this.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetValue(this) is IGeometricShape)
                .Select(f => f.GetValue(this))
                .Cast<IGeometricShape>()
                .ToList();
            AddLines();
        }

        public IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status)
        {
            if(Shapes.Count == 0)
                AddShapes();
            if (status == SubThemeStatus.NextStep)
                CycleIndex += CycleIndex < EndCycleIndex + 1 ? 1 : 0;
            else if (status == SubThemeStatus.BackStep)
                CycleIndex -= CycleIndex > StartCycleIndex - 1 ? 1 : 0;
            UpdateShapes();
            return Shapes.AsReadOnly();
            
            // if (status == SubThemeStatus.NextStep)
            //     if (CycleIndex < EndCycleIndex + 1)
            //     {
            //         if (flag)
            //             CycleIndex++;
            //         CurrentStatus++;
            //         flag = !flag;
            //     }
            // if (status == SubThemeStatus.BackStep)
            //     if (CycleIndex > StartCycleIndex - 1)
            //     {
            //         if (flag)
            //             CycleIndex--;
            //         CurrentStatus--;
            //         flag = !flag;
            //     }
            // UpdateShapes();
            // return Shapes.AsReadOnly();
            
            // if (status == SubThemeStatus.NextStep && CycleIndex < EndCycleIndex + 1)
            // {
            //     if(flag)
            //         CycleIndex++;
            //     flag = !flag;
            // }
            // else if (status == SubThemeStatus.BackStep)
            //     CycleIndex -= CycleIndex > StartCycleIndex - 1 ? 1 : 0;
            // UpdateShapes();
            // return Shapes.AsReadOnly();
        }

        private void UpdateShapes()
        {
            if (CycleIndex == StartCycleIndex - 1)
                ChangeColor(Brushes.Green, Brushes.White, Brushes.White, Brushes.White,Brushes.White);
            else if (CycleIndex == EndCycleIndex)
                ChangeColor(Brushes.White, Brushes.White, Brushes.White, Brushes.Green,Brushes.White);
            else if (CycleIndex == EndCycleIndex + 1)
                ChangeColor(Brushes.White, Brushes.White, Brushes.White, Brushes.White,Brushes.Green);
            else 
                if(CycleIndex % 2 == 1)
                    ChangeColor(Brushes.White, Brushes.Green, Brushes.White, Brushes.White,Brushes.White);
                else
                    ChangeColor(Brushes.White, Brushes.White, Brushes.Green, Brushes.White,Brushes.White);
        }

        private void ChangeColor(Brush beginEllipse, Brush cycle, Brush cycleBody, Brush result, Brush endEllipse)
        {
            BeginEllipse.Color = beginEllipse;
            Cycle.Color = cycle;
            CycleBody.Color = cycleBody;
            Result.Color = result;
            EndEllipse.Color = endEllipse;
        }

        public void SizeChanged(EventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }
    
        public void Click(object sender, EventArgs args)
        {
            // throw new NotImplementedException();
        }

        public void Close()
        {
            Shapes.Clear();
            CycleIndex = 0;
        }

        public string GetName() => "For";
    }
}