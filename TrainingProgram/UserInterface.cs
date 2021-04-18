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
            // KeyPreview = true;
            // KeyDown += (sender, args) => MessageBox.Show("Down");
            // Invalidate();
            Paint += (sender, args) => Drowing(args.Graphics);
            // SizeChanged += (sender, args) =>
            // {
            //     Invalidate(); 
            //     UpdateAfterSizeChanged(args, new Size(ClientSize.Width / 10, ClientSize.Height / 10));
            // };
            // var a = this.MaximumSize;
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
        // private void UpdateAfterSizeChanged(EventArgs args, Size clientSize)
        // {
        //     foreach (var theme in themes)
        //     {
        //         var changes = theme.SizeChanged(args, clientSize);
        //         foreach (var button in changes.Add)
        //             Controls.Add(button);
        //         foreach (var button in changes.Remove)
        //             Controls.Remove(button);
        //     }
        // }
        
        private void drowingForms(object sender, PaintEventArgs args)
        {
            // Graphics;
            var graphics = args.Graphics;
            graphics.Clear(Color.Aqua);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Color.Red,3);
            pen.CustomEndCap = new AdjustableArrowCap(6, 6);
            graphics.DrawLine(pen, 0, 0, 200, 300);
            // graphics.FillPolygon(Brushes.Black, new Point[]{new Point(0, 0), new Point(200, 300)});
            Point[] pts =
            {
                new Point(0, ClientSize.Height / 2), 
                new Point(ClientSize.Width / 2, 0), 
                new Point(ClientSize.Width, ClientSize.Height / 2), 
                new Point(ClientSize.Width / 2, ClientSize.Height)
            };
            graphics.FillPolygon(Brushes.White, pts);
            graphics.DrawString(
                "Some text here", 
                new Font("Arial", (int)(ClientSize.Width * ClientSize.Height * 0.0001)), 
                Brushes.Wheat, 
                new Point((int)(pts[0].X + ClientSize.Width * 0.2), pts[0].Y)
            );
        }
        
        private void Drowing(Graphics graphics)
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
                    // Invalidate();
                    // MessageBox.Show($"{currentTheme.GetName()}");
                };
                buttonsThemes.Add(button);
            }
            foreach (var button in buttonsThemes)
                Controls.Add(button);
        }
    }
}