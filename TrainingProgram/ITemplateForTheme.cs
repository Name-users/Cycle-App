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
        
        void Click(Size clientSize);
        void CloseTheme();
    }
}