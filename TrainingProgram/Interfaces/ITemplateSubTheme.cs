using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateSubTheme
    {
        IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status);
        void SizeChanged(EventArgs args, Size size);
        void Click(object sender, EventArgs args);
        void Close();
        String GetName();
    }
}