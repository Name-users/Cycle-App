using System.Collections.Generic;
using System.Drawing;

namespace TrainingProgram
{
    public class Cycles : TemplateTheme
    {
        public Cycles(List<ITemplateSubTheme> themes) : base(themes)
        {
        }

        public override string GetName() => "Cycles";
    }
}