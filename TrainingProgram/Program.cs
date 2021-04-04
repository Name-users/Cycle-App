using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new Form1(
                new List<ITemplateForTheme>()
                {
                    new ProgramCycles(new List<ITemplateForSubTheme>()
                    {
                        new CycleFor(), new CycleWhile(), new CycleDoWhile()
                    })
                }
                ));
        }
    }
}