using System;

namespace StrategyPatternExample
{
    public class DesktopScreenRender : IRenderStrategy
    {

        public Image RenderGraph(Data graphData)
        {
            Console.WriteLine("Rendered for Desktop");
            return new Image();
        }
    }
}
