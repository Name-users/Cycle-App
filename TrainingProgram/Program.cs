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
            Application.Run(new UserInterface(
                new List<ITemplateTheme>()
                {
                    new Cycles(new List<ITemplateSubTheme>()
                    {
                        new Cycle(), new CycleWhile(), new CycleDoWhile()
                    })
                }
                ));
        }
    }
}