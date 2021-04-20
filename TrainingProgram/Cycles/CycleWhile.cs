using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class CycleWhile : ITemplateSubTheme
    {
        public IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status)
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

        public void Close()
        {
            // throw new NotImplementedException();
        }

        public string GetName() => "While";
    }
}