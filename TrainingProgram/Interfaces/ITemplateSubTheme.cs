using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateSubTheme
    {
        IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status);
        void Close();
        String GetName();
    }
}