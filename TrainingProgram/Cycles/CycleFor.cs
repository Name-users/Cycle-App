using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleFor : ITemplateSubTheme
    {
        private IClosedLine Cycle;
        private IClosedLine CycleBody;
        private IClosedLine Result;
        private List<IGeometricShape> Shapes = new List<IGeometricShape>();

        public CycleFor()
        {
            var oX = 300;
            var oY = 300;
            Cycle = new ClosedLine(
                new[]
                {
                    new Point(oX, oY + 50),
                    new Point(oX + 100, oY + 50),
                    new Point(oX + 50, oY),
                    new Point(oX + 50, oY + 100),
                },
                Brushes.White,
                new Text() {Point = new Point(oX + 2, oY + 2), TextLine = "TestLine"}
            );
            Shapes.Add(Cycle);
        }

        public IReadOnlyCollection<IGeometricShape> Paint()
        {
            return Shapes.AsReadOnly();
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