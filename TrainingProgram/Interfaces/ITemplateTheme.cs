using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateTheme
    {
        // void Paint(PaintEventArgs args, Size size);
        // void Paint();
        // Updates<Button> SizeChanged(EventArgs args, Size size);
        IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status);
        String GetName();
        Point Location();
        // //void SizeChanged();
        
        Updates<Button> Click(Size clientSize);
        Updates<Button> CloseTheme();
    }
}