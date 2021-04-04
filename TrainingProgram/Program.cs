using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingProgram.If_else;

namespace TrainingProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserInterface(
                new List<ITemplateTheme>()
                {
                    new Cycles(new List<ITemplateSubTheme>()
                    {
                        new CycleFor(), new CycleWhile(), new CycleDoWhile()
                    }),
                    new IfElse(new List<ITemplateSubTheme>())
                }
                ));
        }
    }
}