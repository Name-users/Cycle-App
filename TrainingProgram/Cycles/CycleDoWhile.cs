using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleDoWhile : ITemplateSubTheme
    {
        public void Paint(PaintEventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }

        public IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status)
        {
            return null;
        }

        public void SizeChanged(EventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }

        public void Click(object sender, EventArgs args)
        {
            // throw new NotImplementedException();
        }

        public string GetName() => "Do While";
    }
}