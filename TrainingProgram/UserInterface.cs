using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private SubThemeStatus currentSubThemeStatus = SubThemeStatus.Stay;

        public UserInterface(List<ITemplateTheme> themes)
        {
            InitializeComponent();
            this.themes = themes;
            Paint += (sender, args) => Drawing(args.Graphics);
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            AddThemeButtons(new Size(Size.Width / 10, Size.Height / 10));
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!(currentTheme is null))
            {
                if (keyData == (Keys.Left))
                    currentSubThemeStatus = SubThemeStatus.BackStep;
                if (keyData == (Keys.Right))
                    currentSubThemeStatus = SubThemeStatus.NextStep;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void Drawing(Graphics graphics)
        {
            graphics.Clear(Color.Aqua);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (currentTheme != null)
            {
                var shapes = currentTheme.Paint(currentSubThemeStatus);
                currentSubThemeStatus = SubThemeStatus.Stay;
                if(shapes != null)
                {
                    foreach (var shape in shapes)
                    {
                        if (shape is IClosedLine closedLine)
                            graphics.FillPolygon(closedLine.Color, closedLine.Points.ToArray());
                        else if (shape is ILine line)
                            graphics.DrawLine(line.Pen, line.Start.X, line.Start.Y, line.End.X, line.End.Y);
                        else if (shape is IEllipse ellipse)
                            graphics.FillEllipse(ellipse.Color, ellipse.Point.X, ellipse.Point.Y, ellipse.Size.Width, ellipse.Size.Height);
                        if(!shape.Text.IsEmpty)
                            graphics.DrawString(
                                    shape.Text.TextLine,
                                    new Font("Arial", 20),
                                    Brushes.Black,
                                    shape.Text.Point
                                );
                    }
                }
            }
        }

        private void AddThemeButtons(Size clientSize)
        {
            foreach (var theme in themes)
            {
                var lastPoint = new Point(0, 0);
                if(buttonsThemes.Count > 0)
                    lastPoint = new Point(0, buttonsThemes[buttonsThemes.Count - 1].Bottom);
                var button = new Button()
                {
                    Text = theme.GetName(), 
                    Location = lastPoint, 
                    Size = clientSize
                };
                button.Click += (o, args) =>
                {
                    if (currentTheme != null)
                        foreach (var b in currentTheme.CloseTheme().Remove)
                            Controls.Remove(b);
                    foreach (var b in theme.Click(clientSize).Add)
                    {
                        b.Click += (sender, eventArgs) => Invalidate();
                        Controls.Add(b);
                    }
                    currentTheme = theme;
                };
                buttonsThemes.Add(button);
            }
            foreach (var button in buttonsThemes)
                Controls.Add(button);
        }
    }
}