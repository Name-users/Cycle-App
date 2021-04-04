using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingProgram
{
    public partial class UserInterface : Form
    {
        private List<Button> buttonsThemes = new List<Button>();
        private List<ITemplateTheme> themes = new List<ITemplateTheme>();
        private ITemplateTheme currentTheme;
        public UserInterface(List<ITemplateTheme> themes)
        {
            InitializeComponent();
            this.themes = themes;
            SizeChanged += (sender, args) => { Invalidate(); UpdateAfterSizeChanged(args, ClientSize);};
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            AddThemeButtons();
        }

        private void UpdateAfterSizeChanged(EventArgs args, Size clientSize)
        {
            foreach (var theme in themes)
            {
                var changes = theme.SizeChanged(args, clientSize);
                foreach (var button in changes.Add)
                    Controls.Add(button);
                foreach (var button in changes.Remove)
                    Controls.Remove(button);
            }
        }

        private void AddThemeButtons()
        {
            foreach (var theme in themes)
            {
                var button = new Button()
                {
                    Text = theme.GetName(), 
                    Location = theme.Location(), 
                    Size = new Size((int)(ClientSize.Width / 10), 100)
                };
                button.Click += (o, args) =>
                {
                    if (currentTheme != null)
                        foreach (var b in currentTheme.CloseTheme().Remove)
                            Controls.Remove(b);
                    foreach (var b in theme.Click(ClientSize).Add)
                        Controls.Add(b);
                    currentTheme = theme;
                };
                buttonsThemes.Add(button);
            }
            foreach (var button in buttonsThemes)
                Controls.Add(button);
        }
    }
}