using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateSubTheme
    {
        IReadOnlyCollection<IGeometricShape> Paint();
        void SizeChanged(EventArgs args, Size size);
        void Click(object sender, EventArgs args);
        String GetName();
    }
}