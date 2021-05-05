using System.Collections.Generic;

namespace TrainingProgram
{
    public abstract class CycleTemplate : ITemplateSubTheme
    {
        protected List<IGeometricShape> Shapes = new List<IGeometricShape>();
        protected readonly Stack<StateElements> StackOfStates = new Stack<StateElements>();
        protected abstract void InitializationFields();

        protected abstract string UpdateTextCode();
        public abstract IReadOnlyCollection<IGeometricShape> Paint(SubThemeStatus status);
        public abstract void Close();
        public abstract string GetName();
    }
}