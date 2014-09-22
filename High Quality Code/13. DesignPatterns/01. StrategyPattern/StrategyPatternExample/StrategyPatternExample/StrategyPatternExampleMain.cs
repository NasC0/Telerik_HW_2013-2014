namespace StrategyPatternExample
{
    class StrategyPatternExampleMain
    {
        private static bool isMobileDevice = false;
        private static bool isDesktopDevice = true;

        static void Main()
        {
            PrepareScreen prepareScreen = null;
            Data graphData = new Data();

            if (isMobileDevice)
            {
                prepareScreen = new PrepareScreen(new MobileScreenRender());
            }
            else if (isDesktopDevice)
            {
                prepareScreen = new PrepareScreen(new DesktopScreenRender());
            }

            prepareScreen.RenderScreen.RenderGraph(graphData);
        }
    }
}
