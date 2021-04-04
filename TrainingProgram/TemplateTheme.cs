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

    public abstract class TemplateTheme : ITemplateTheme
    {

        private readonly List<ITemplateSubTheme> themes;
        private ITemplateSubTheme currentSubTheme;
        private List<Button> buttons = new List<Button>();
        private bool ButtonExist => buttons.Count > 0;

        public TemplateTheme(List<ITemplateSubTheme> themes)
        {
            this.themes = themes;
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
                var currentTheme = themes[i];
                var button = new Button(){Text = currentTheme.GetName(), Location = new Point(newSize.Width, last), Size = newSize};
                button.Click += (sender, args) =>
                {
                    currentSubTheme = currentTheme;
                    currentTheme.Click(sender, args);
                };
                buttons.Add(button);
            }
            return new Updates<Button>(buttons.AsReadOnly(), remove.AsReadOnly());
        }

        public abstract String GetName();
        public abstract Point Location();

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