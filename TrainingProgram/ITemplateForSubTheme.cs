using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateForSubTheme
    {
        void Paint(PaintEventArgs args, Size size);
        void SizeChanged(EventArgs args, Size size);
        void Click(object sender, EventArgs args);
    }
}