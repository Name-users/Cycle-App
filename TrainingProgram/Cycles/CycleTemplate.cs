using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TrainingProgram
{
    public abstract class CycleTemplate : ITemplateSubTheme
    {
        protected List<IGeometricShape> Shapes = new List<IGeometricShape>();
        protected readonly Stack<StateElements> StackOfStates = new Stack<StateElements>();
        protected Point LeftBorder = new Point(800, 100);
        protected int CycleIndex;
        protected int Index;
        protected int Sum;
        protected bool EndProgramm;
        protected readonly int StartCycleIndex;
        protected readonly int EndCycleIndex;
        private string Description;

        public CycleTemplate(int startCycleIndex, int endCycleIndex)
        {
            StartCycleIndex = startCycleIndex;
            EndCycleIndex = endCycleIndex;
            Description = ReadFromFile($"{GetName()}.txt");
            InitializationFields();
            AddShapes();
            AddLines();
        }

        protected abstract void InitializationFields();

        protected abstract string UpdateTextCode();
        protected abstract void InitializationShapes();
        protected abstract void AddLines();
        private void AddShapes()
        {
            InitializationShapes();
            Shapes = this.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.GetValue(this) is IGeometricShape)
                .Select(f => f.GetValue(this))
                .Cast<IGeometricShape>()
                .ToList();
            // Shapes.Add(new RectangleText(
            //     new Size(400, 400),
            //     Brushes.Red,
            //     new Text() {Point = new Point(LeftBorder.X - 350, LeftBorder.Y + 50), 
            //         TextLine = Description}
            // ));
        }

        private string ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return $"{System.IO.Directory.GetCurrentDirectory()}";
            using (var fstream = File.OpenRead(fileName))
            {
                var array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                return System.Text.Encoding.Default.GetString(array);
            }
        }

        public List<Line> СonnectLines(Pen pen, Point[] points)
        {
            return Enumerable
                .Range(0, points.Length - 1)
                .Select(i => new Line(points[i], points[i + 1], pen, new Text()))
                .ToList();
        }

        protected abstract StateElements GoNext(SubThemeStatus status);
        protected abstract void UpdateShapes(Brush[] colors);
        
        public virtual IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status)
        {
            if(Shapes.Count == 0)
                AddShapes();
            if (status == SubThemeStatus.Stay && Index == 0)
            {
                var currentState = GoNext(status);
                UpdateShapes(currentState.Colors);
                StackOfStates.Push(currentState);
            }
            else if (status == SubThemeStatus.NextStep && CycleIndex <= EndCycleIndex && !EndProgramm)
            {
                Index++;
                var currentState = GoNext(status);
                UpdateShapes(currentState.Colors);
                StackOfStates.Push(currentState);
            }
            else if (status == SubThemeStatus.BackStep && Index > StartCycleIndex)
            {
                var currentState = StackOfStates.Pop();
                EndProgramm = currentState.StateOfCode;
                Index = currentState.Index;
                CycleIndex = currentState.CycleIndex;
                Sum = currentState.Sum;
                UpdateShapes(currentState.Colors);
            }
            return Shapes.AsReadOnly();
        }
        // public abstract IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status);
        public void Close()
        {
            // Shapes.Clear();
            StackOfStates.Clear();
            InitializationFields();
        }
        public abstract string GetName();
    }
}