using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateForTheme
    {
        void Paint(PaintEventArgs args, Size size);
        void SizeChanged(EventArgs args, Size size);
        // void SizeChanged();
        
        void Click(Control.ControlCollection control, Size clientSize);
        void Click();
    }
}