using Spectre.Console;
using SPZCW.Classes.StaticClasses.SpectreConsoleObjects.MainMenuChart;

namespace SPZCW.Classes.StaticClasses
{
    public static class MainMenuChart
    {
        public static BreakdownChart GetMainMenuChartByStatus()
        {
            ServicesStatusData servicesStatusData = new ServicesStatusData();

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Stopped", (int)servicesStatusData.StoppedPercentage, Colors.Color1)
                    .AddItem("Running", (int)servicesStatusData.RunningPercentage, Colors.Color2)
                    .AddItem("Other", (int)servicesStatusData.OtherPercentage, Colors.Color3);
        }

        public static BreakdownChart GetMainMenuChartByStartType()
        {
            ServicesStartTypeData servicesStartTypeData = new ServicesStartTypeData();

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Automatic", (int)servicesStartTypeData.AutomaticPercentage, Colors.Color1)
                    .AddItem("Manual", (int)servicesStartTypeData.ManualPercentage, Colors.Color2)
                    .AddItem("Disabled", (int)servicesStartTypeData.DisabledPercentage, Colors.Color3)
                    .AddItem("System", (int)servicesStartTypeData.SystemPercentage, Colors.Color4)
                    .AddItem("Boot", (int)servicesStartTypeData.BootPercentage, Colors.Color5);
        }

        public static BreakdownChart GetMainMenuChartByServiceType()
        {
            ServicesTypesData servicesTypesData = new ServicesTypesData();

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Win32OwnProcess", (int)servicesTypesData.Win32OwnProcessPercentage, Colors.Color1)
                    .AddItem("Win32ShareProcess", (int)servicesTypesData.Win32ShareProcessPercentage, Colors.Color2)
                    .AddItem("KernelDriver", (int)servicesTypesData.KernelDriverPercentage, Colors.Color3)
                    .AddItem("FileSystemDriver", (int)servicesTypesData.FileSystemDriverPercentage, Colors.Color4)
                    .AddItem("Adapter", (int)servicesTypesData.AdapterPercentage, Colors.Color5)
                    .AddItem("InteractiveProcess", (int)servicesTypesData.InteractiveProcessPercentage, Colors.Color4)
                    .AddItem("RecognizerDriver", (int)servicesTypesData.RecognizerDriverPercentage, Colors.Color3)
                    .AddItem("Other", (int)servicesTypesData.OtherPercentage, Colors.Color2);
        }

        public static BreakdownChart GetMainMenuChartByMachineName()
        {
            ServicesMachineNameData servicesMachineNameData = new ServicesMachineNameData();

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Localhost", (int)servicesMachineNameData.LocalPercentage, Colors.Color1)
                    .AddItem("Other", (int)servicesMachineNameData.OtherPercentage, Colors.Color2);
        }
    }
}
