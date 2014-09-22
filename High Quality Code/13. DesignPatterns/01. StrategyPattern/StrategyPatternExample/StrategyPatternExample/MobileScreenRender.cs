using System;

namespace StrategyPatternExample
{
    public class MobileScreenRender : IRenderStrategy
    {
        public Image RenderGraph(Data graphData)
        {
            Console.WriteLine("Rendered for Mobile screen");
            return new Image();
        }
    }
}
