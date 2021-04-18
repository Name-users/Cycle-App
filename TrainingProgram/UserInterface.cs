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
        public UserInterface(List<ITemplateTheme> themes)
        {
            InitializeComponent();
            this.themes = themes;
            Invalidate();
            Paint += (sender, args) => drowingForms(sender, args);
            // SizeChanged += (sender, args) =>
            // {
            //     Invalidate(); 
            //     UpdateAfterSizeChanged(args, new Size(ClientSize.Width / 10, ClientSize.Height / 10));
            // };
            // var a = this.MaximumSize;
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            AddThemeButtons(new Size(Size.Width / 10, Size.Height / 10));
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
        
        private void Drowing(object sender, PaintEventArgs args)
        {
            
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