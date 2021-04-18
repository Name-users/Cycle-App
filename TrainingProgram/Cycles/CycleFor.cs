using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleFor : ITemplateSubTheme
    {
        private IEllipse BeginEllipse;
        private IClosedLine Cycle;
        private IClosedLine CycleBody;
        private IClosedLine Result;
        private IEllipse EndEllipse;
        private int Index = 0;
        private List<IGeometricShape> Shapes = new List<IGeometricShape>();
        private Point Left = new Point(800, 100);

        public CycleFor()
        {
            var dx = 50;
            var dy = 50;
            InitializationShapes();
            AddLines();
            Shapes.Add(Cycle);
            Shapes.Add(CycleBody);
            Shapes.Add(Result);
            Shapes.Add(BeginEllipse);
            Shapes.Add(EndEllipse);
            
            
        }

        private void InitializationShapes()
        {
            BeginEllipse = new Ellipse(
                new Point(Left.X, Left.Y + 50),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(Left.X + 50, Left.Y + 50), TextLine = "begin"}
            );
            Cycle = new ClosedLine(
                new[]
                {
                    new Point(Left.X, Left.Y + 150),
                    new Point(Left.X + 50, Left.Y + 125),
                    new Point(Left.X + 150, Left.Y + 125),
                    new Point(Left.X + 200, Left.Y + 150),
                    new Point(Left.X + 150, Left.Y + 175),
                    new Point(Left.X + 50, Left.Y + 175),
                },
                Brushes.White,
                new Text() {Point = new Point(Left.X + 23, Left.Y + 130), TextLine = "i:=1; 10; +1"}
            );
            CycleBody = new ClosedLine(
                new[]
                {
                    new Point(Left.X, Left.Y + 225),
                    new Point(Left.X + 200, Left.Y + 225),
                    new Point(Left.X + 200, Left.Y + 275),
                    new Point(Left.X, Left.Y + 275)
                },
                Brushes.White,
                new Text() {Point = new Point(Left.X + 25, Left.Y + 230), TextLine = "sum += i"}
                );
            Result = new ClosedLine(
                new[]
                {
                    new Point(Left.X, Left.Y + 350),
                    new Point(Left.X + 200, Left.Y + 350),
                    new Point(Left.X + 200, Left.Y + 375),
                    new Point(Left.X, Left.Y + 375)
                },
                Brushes.White,
                new Text() {Point = new Point(Left.X + 50, Left.Y + 348), TextLine = "sum"}
            );
            
            EndEllipse = new Ellipse(
                new Point(Left.X, Result.Points.ToArray()[3].Y + 50),
                new Size(200, 30),
                Brushes.White,
                new Text() {Point = new Point(Left.X + 50, Result.Points.ToArray()[3].Y + 50), TextLine = "end"}
            );
        }

        private void AddLines()
        {
            var pen = new Pen(Color.Red,3);
            pen.CustomEndCap = new AdjustableArrowCap(4, 4);
            var arrStart = Cycle.Points.ToArray();
            var arrEnd = CycleBody.Points.ToArray();
            
            Shapes.Add(new Line(
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2, Left.Y + 75),
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2, arrStart[1].Y),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2,arrStart[4].Y),
                new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[0].Y),
                pen,
                new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[3].Y),
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[3].Y + 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2,arrEnd[3].Y + 25),
                    new Point(Left.X - 25,arrEnd[3].Y + 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(Left.X - 25,arrEnd[3].Y + 25),
                    new Point(Left.X - 25,arrStart[3].Y ),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(Left.X - 25,arrStart[3].Y ),
                    new Point(Left.X,arrStart[3].Y ),
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
                    new Point(Left.X + (arrEnd[1].X - arrEnd[0].X) / 2, arrEnd[1].Y - 25),
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(Left.X + (arrEnd[1].X - arrEnd[0].X) / 2, arrEnd[1].Y - 25),
                    new Point(Left.X + (arrEnd[1].X - arrEnd[0].X) / 2, arrEnd[1].Y),
                    
                    pen,
                    new Text()
                )
            );
            
            Shapes.Add(new Line(
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2, arrEnd[2].Y),
                    new Point(Left.X + (arrStart[3].X - arrStart[0].X) / 2, arrEnd[2].Y + 50),
                    pen,
                    new Text()
                )
            );
        }

        public IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status)
        {
            if (status == SubThemeStatus.NextStep)
                Index += Index < 11 ? 1 : 0;
            else if (status == SubThemeStatus.BackStep)
                Index -= Index > 0 ? 1 : 0;
            UpdateShapes();
            return Shapes.AsReadOnly();
        }

        private void UpdateShapes()
        {
            if (Index == 0)
                BeginEllipse.Color = Brushes.Green;
            if (Index == 11)
                EndEllipse.Color = Brushes.Green;
            else 
                if(Index % 2 == 1)
                    Cycle.Color = Brushes.Green;
                else
                    CycleBody.Color = Brushes.Green;
            
        }

        public void SizeChanged(EventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }
    
        public void Click(object sender, EventArgs args)
        {
            // throw new NotImplementedException();
        }
    
        public string GetName() => "For";
    }
}