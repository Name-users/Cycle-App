using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainingProgram
{
    public class Updates<T>
    {
        public IReadOnlyCollection<T> Remove;
        public IReadOnlyCollection<T> Add;

        public Updates(IReadOnlyCollection<T> add, IReadOnlyCollection<T> remove)
        {
            Add = add;
            Remove = remove;
        }
    }

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
        // private readonly Action<Control> hookAdd;
        // private readonly Action<Control> hookRemove;
        private readonly List<ITemplateForSubTheme> themes;
        private List<Button> buttons = new List<Button>();
        private readonly List<string> buttonNames = new List<string>() {"For", "While", "Do While"};
        private bool ButtonExist => buttons.Count > 0;

        public ProgramCycles(Action<Control> hookAdd, Action<Control> hookRemove)
        {
            themes = new List<ITemplateForSubTheme>() {new CycleFor(), new CycleWhile(), new CycleDoWhile()};
        }

        public void Paint(PaintEventArgs args, Size size)
        {
            throw new NotImplementedException();
        }
        
        private Updates<Button> UpdateButtons(Size newSize)
        {
            var remove = buttons;
            buttons = new List<Button>();
            for (var i = 0; i < themes.Count; i++)
            {
                var last = i - 1 < 0 ? 0 : buttons[i - 1].Bottom;
                buttons.Add(Farm.CreateButton(buttonNames[i],new Point(newSize.Width, last), themes[i].Click, newSize));
            }
            return new Updates<Button>(buttons.AsReadOnly(), remove.AsReadOnly());
        }

        public String GetName() => "Cycles";
        public Point Location() => new Point(0, 0);
        
        

        public Button ThemeButton(Size size)
        {
             return new Button(){Text = GetName(), Location = Location(), Size = size};
            // return Farm.CreateButton("Cycles",new Point(0, 0),
            //     (o, args) =>
            //     {
            //         foreach(var button in cycles.Click(ClientSize).Add)
            //             Controls.Add(button);
            //     }, 
            //     new Size((int)(ClientSize.Width / 10), 100)))
        }

        public Updates<Button> SizeChanged(EventArgs args, Size clientSize)
        {
            if(!ButtonExist)
                return new Updates<Button>(new List<Button>(), new List<Button>());
            var newSize = new Size((int) (clientSize.Width / 5), (int) (clientSize.Height / 5));
            foreach (var theme in themes)
                theme.SizeChanged(args, clientSize);
            return UpdateButtons(newSize);
        }

        public Updates<Button> Click(Size clientSize)
        {
            if(ButtonExist)
                return new Updates<Button>(new List<Button>(), new List<Button>());
            var newSize = new Size((int) (clientSize.Width / 5), (int) (clientSize.Height / 5));
            return UpdateButtons(newSize);
        }
        
        public Updates<Button> CloseTheme()
        {
            var remove = buttons;
            buttons = new List<Button>();
            return new Updates<Button>(new List<Button>(), remove);
        }
    }
}