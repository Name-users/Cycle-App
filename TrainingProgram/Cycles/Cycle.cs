﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace TrainingProgram
{
    public class Cycle : ITemplateSubTheme
    {
        public void Paint(PaintEventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }
    
        public void SizeChanged(EventArgs args, Size size)
        {
            // throw new NotImplementedException();
        }
    
        public void Click(object sender, EventArgs args)
        {
            // throw new NotImplementedException();
        }
    
        public string GetName() => "For";
    }
}