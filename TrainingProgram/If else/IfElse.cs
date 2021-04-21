using System.Collections.Generic;
using System.Drawing;

namespace TrainingProgram.If_else
{
    public class IfElse : TemplateTheme
    {
        public IfElse(List<ITemplateSubTheme> themes) : base(themes)
        {
        }

        public override string GetName() => "If / Else";

        // public override Point Location() => new Point(0, 100);
    }
}