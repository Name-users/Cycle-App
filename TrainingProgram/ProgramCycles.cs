using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public class Farm
    {
        public static Button CreateButton(string text, Point position, Action<object, EventArgs> func, Size size)
        {
            var button = new Button(){Text = text, Location = position, Size = size};
            button.Click += (sender, args) => func(sender, args);
            return button;
        }
    }

    public class ProgramCycles : ITemplateForTheme
    {
        private readonly Control.ControlCollection control;
        private readonly CycleFor cycleFor = new CycleFor();
        private readonly CycleWhile cycleWhile = new CycleWhile();
        private readonly CycleDoWhile cycleDoWhile = new CycleDoWhile();
        
        private  Button buttonFor = new Button();
        private  Button buttonWhile = new Button();
        private  Button buttonDoWhile = new Button();
        private bool buttonExist = false;
    
        // ~ProgramCycles() 
        // {
        //     control.Remove(buttonFor);
        //     control.Remove(buttonWhile);
        //     control.Remove(buttonDoWhile);
        // }

        public ProgramCycles(Control.ControlCollection control, Size clientSize)
        {
            this.control = control;
        }

        public void Paint(PaintEventArgs args, Size size)
        {
            throw new NotImplementedException();
        }

        // private void CreateButton(Size newSize)
        // {
        //     buttonFor = Farm.CreateButton(
        //         "For", 
        //         new Point(newSize.Width, 0), 
        //         cycleFor.Click, 
        //         newSize);
        //     buttonWhile = Farm.CreateButton("While", new Point(newSize.Width, buttonFor.Bottom), cycleWhile.Click, newSize);
        //     buttonDoWhile = Farm.CreateButton("Do While", new Point(newSize.Width, buttonWhile.Bottom), cycleDoWhile.Click, newSize);
        //
        // }
        //
        // private void CheckExistButton()
        // {
        //     if (buttonExist)
        //     {
        //         control.Remove(buttonFor);
        //         control.Remove(buttonWhile);
        //         control.Remove(buttonDoWhile);
        //         buttonExist = false;
        //     }
        // }
        //
        // private void AddButton()
        // {
        //     if (!buttonExist)
        //     {
        //         control.Add(buttonFor);
        //         control.Add(buttonWhile);
        //         control.Add(buttonDoWhile);
        //         buttonExist = true;
        //     }
        // }
        
        private void AddButtons(Size newSize)
        {
            RemoveButtons();
            buttonFor = Farm.CreateButton("For",new Point(newSize.Width, 0),cycleFor.Click, newSize);
            buttonWhile = Farm.CreateButton("While", new Point(newSize.Width, buttonFor.Bottom), cycleWhile.Click, newSize);
            buttonDoWhile = Farm.CreateButton("Do While", new Point(newSize.Width, buttonWhile.Bottom), cycleDoWhile.Click, newSize);
            control.Add(buttonFor);
            control.Add(buttonWhile);
            control.Add(buttonDoWhile);
            buttonExist = true;
        }

        private void RemoveButtons()
        {
            if (buttonExist)
            {
                control.Remove(buttonFor);
                control.Remove(buttonWhile);
                control.Remove(buttonDoWhile);
                buttonExist = false;
            }
        }

        

        public void SizeChanged(EventArgs args, Size clientSize)
        {
            if(!buttonExist)
                return;
            var newSize = new Size((int) (clientSize.Width / 5), (int) (clientSize.Height / 5));
            // RemoveButtons();
            AddButtons(newSize);
            // AddButton();
            // buttonFor.Size = newSize;
            // buttonWhile.Size = newSize;
            // buttonDoWhile.Size = newSize;
            cycleFor.SizeChanged(args, clientSize);
            cycleWhile.SizeChanged(args, clientSize);
            cycleDoWhile.SizeChanged(args, clientSize);
        }

        public void Click(Control.ControlCollection control, Size clientSize)
        {
            var newSize = new Size((int) (clientSize.Width / 5), (int) (clientSize.Height / 5));
            // RemoveButtons();
            AddButtons(newSize);
            // AddButton();
        }
        
        public void Click()
        {
            RemoveButtons();
        }
    }
}