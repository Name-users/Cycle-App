using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateTheme
    {
        void Paint(PaintEventArgs args, Size size);
        Updates<Button> SizeChanged(EventArgs args, Size size);

        String GetName();
        Point Location();
        // void SizeChanged();
        
        Updates<Button> Click(Size clientSize);
        Updates<Button> CloseTheme();
    }
}