using System;
using System.Collections.Generic;
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
        private readonly Action<Control> hookAdd;
        private readonly Action<Control> hookRemove;
        private readonly List<ITemplateForSubTheme> themes;
        private List<Button> buttons = new List<Button>();
        private readonly List<string> buttonNames = new List<string>() {"For", "While", "Do While"};
        private bool ButtonExist => buttons.Count > 0;

        public ProgramCycles(Action<Control> hookAdd, Action<Control> hookRemove)
        {
            this.hookAdd = hookAdd;
            this.hookRemove = hookRemove;
            themes = new List<ITemplateForSubTheme>() {new CycleFor(), new CycleWhile(), new CycleDoWhile()};
        }

        public void Paint(PaintEventArgs args, Size size)
        {
            throw new NotImplementedException();
        }
        
        private void UpdateButtons(Size newSize)
        {
            RemoveButtons();
            for (var i = 0; i < themes.Count; i++)
            {
                var last = i - 1 < 0 ? 0 : buttons[i - 1].Bottom;
                buttons.Add(Farm.CreateButton(buttonNames[i],new Point(newSize.Width, last), themes[i].Click, newSize));
            }
            foreach (var button in buttons)
                hookAdd(button);
        }

        private void RemoveButtons()
        {
            foreach (var button in buttons)
                hookRemove(button);
            buttons.Clear();
        }
        
        public void SizeChanged(EventArgs args, Size clientSize)
        {
            if(!ButtonExist)
                return;
            var newSize = new Size((int) (clientSize.Width / 5), (int) (clientSize.Height / 5));
            UpdateButtons(newSize);
            foreach (var theme in themes)
                theme.SizeChanged(args, clientSize);
        }

        public void Click(Size clientSize)
        {
            var newSize = new Size((int) (clientSize.Width / 5), (int) (clientSize.Height / 5));
            UpdateButtons(newSize);
        }
        
        public void CloseTheme()
        {
            RemoveButtons();
        }
    }
}