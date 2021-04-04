using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateForTheme
    {
        void Paint(PaintEventArgs args, Size size);
        Updates<Button> SizeChanged(EventArgs args, Size size);

        Button ThemeButton(Size size);
        // void SizeChanged();
        
        Updates<Button> Click(Size clientSize);
        Updates<Button> CloseTheme();
    }
}