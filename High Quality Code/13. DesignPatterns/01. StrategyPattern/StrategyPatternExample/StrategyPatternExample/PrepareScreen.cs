using System;

namespace StrategyPatternExample
{
    public class PrepareScreen
    {
        private IRenderStrategy renderScreen;

        public PrepareScreen(IRenderStrategy renderStrategy)
        {
            this.RenderScreen = renderStrategy;
        }

        public IRenderStrategy RenderScreen
        {
            get
            {
                return this.renderScreen;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Screen rendering strategy must be initialized.");
                }

                this.renderScreen = value;
            }
        }
    }
}
