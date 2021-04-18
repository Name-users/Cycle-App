using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleWhile : ITemplateSubTheme
    {
        public void Paint(PaintEventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }

        public IReadOnlyCollection<IGeometricShape> Paint()
        {
            // throw new NotImplementedException();
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
    
        public string GetName() => "While";
    }
}