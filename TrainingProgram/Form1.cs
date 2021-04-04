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
    public partial class Form1 : Form
    {
        private ITemplateForTheme cycles;
        // private readonly Button buttonCycles;
        private List<Button> buttons = new List<Button>();
        private List<ITemplateForTheme> themes = new List<ITemplateForTheme>();
        public Form1()
        {
            InitializeComponent();
            cycles = new ProgramCycles(Controls.Add, Controls.Remove);
            SizeChanged += (sender, args) => { Invalidate(); cycles?.SizeChanged(args, ClientSize);};
            Load += (sender, args) => OnSizeChanged(EventArgs.Empty);
            // Paint += (sender, args) => drowingForms(sender, args);

            // buttonCycles = Farm.CreateButton(
            //     "Cycles",
            //     new Point(0, 0),
            //     (o, args) =>
            //     {
            //         // cycles = new ProgramCycles(Controls, ClientSize);
            //         cycles.Click(ClientSize);
            //     },
            //     new Size((int)(ClientSize.Width / 5), 100));
            // Controls.Add(buttonCycles);
            //
            // Controls.Add(Farm.CreateButton(
            //     "Other",
            //     new Point(0, buttonCycles.Bottom),
            //     (o, args) => cycles?.CloseTheme(),
            //     new Size((int)(ClientSize.Width / 5), 100)));
            AddButtons();
            
        }

        // private void UpdateAfterSizeChanged(EventArgs args, Size clientSize)
        // {
        //     foreach (var theme in themes)
        //     {
        //         var changes = theme.SizeChanged(args, clientSize);
        //     }
        // }

        private void AddButtons()
        {
            buttons.Add(Farm.CreateButton("Cycles",new Point(0, 0),(o, args) => { cycles.Click(ClientSize); }, new Size((int)(ClientSize.Width / 10), 100)));
            buttons.Add(Farm.CreateButton(
                "Other",
                new Point(0, 200),
                (o, args) => cycles?.CloseTheme(),
                new Size((int)(ClientSize.Width / 10), 100)));
            foreach (var button in buttons)
                Controls.Add(button);
        }

        private void drowingForms(object sender, PaintEventArgs args)
        {
            var graphics = args.Graphics;
            graphics.Clear(Color.Aqua);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawLine(new Pen(Color.Green, 5), 0, 0, 100, 50);
            Point[] pts =
            {
                new Point(0, ClientSize.Height / 2), 
                new Point(ClientSize.Width / 2, 0), 
                new Point(ClientSize.Width, ClientSize.Height / 2), 
                new Point(ClientSize.Width / 2, ClientSize.Height)
            };
            graphics.FillPolygon(Brushes.Black, pts);
            graphics.DrawString(
                "Some text here", 
                new Font("Arial", (int)(ClientSize.Width * ClientSize.Height * 0.0001)), 
                Brushes.Wheat, 
                new Point((int)(pts[0].X + ClientSize.Width * 0.2), pts[0].Y)
                );
        }



        // protected override void OnPaint(PaintEventArgs e)
        // {
        //     var graphics = e.Graphics;
        //     e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //     graphics.DrawLine(new Pen(Color.Green, 5), 0, 0, 100, 50);
        //     Point[] pts = { new Point(5, 45), new Point(35, 5), new Point(65, 45), new Point(35, 85)};
        //     e.Graphics.FillPolygon(Brushes.Black, pts);
        //     
        //     // graphics.DrawString("Some text here", new Font("Arial", 16), Brushes.Black, new Point(0, 250));
        //     // graphics.DrawString(
        //     //     "Some very long text",
        //     //     new Font("Arial", 16),
        //     //     Brushes.White,
        //     //     new Rectangle(100, 100, 100, 100),
        //     //     new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.FitBlackBox }
        //     // );
        // }
    }
}