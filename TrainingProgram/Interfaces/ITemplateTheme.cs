using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public interface ITemplateTheme
    {
        IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status);
        String GetName();
        
        Updates<Button> Click(Size clientSize);
        Updates<Button> CloseTheme();
    }
}