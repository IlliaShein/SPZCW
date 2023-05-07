using Spectre.Console;
using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses
{
    public static class MainMenuChart
    {
        public static BreakdownChart GetMainMenuChartByStatus()
        {
            ServiceController[] services = ServiceController.GetServices();

            int stoppedAmount = 0;
            int runningAmount = 0;
            int otherAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].Status == ServiceControllerStatus.Stopped)
                {
                    stoppedAmount++;
                }
                else if (services[i].Status == ServiceControllerStatus.Running)
                {
                    runningAmount++;
                }
                else
                {
                    otherAmount++;
                }
            }

            float stoppedPercentage = (100 * stoppedAmount) / services.Length;
            float runningPercentage = (100 * runningAmount) / services.Length;
            float otherPercentage = (100 * otherAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Stopped", stoppedPercentage, Colors.Color1())
                    .AddItem("Running", runningPercentage, Colors.Color2())
                    .AddItem("Other", otherPercentage, Colors.Color3());
        }

        public static BreakdownChart GetMainMenuChartByStartType()
        {
            ServiceController[] services = ServiceController.GetServices();

            int automaticAmount = 0;
            int manualAmount = 0;
            int disabledAmount = 0;
            int systemAmount = 0;
            int bootAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].StartType == ServiceStartMode.Automatic)
                {
                    automaticAmount++;
                }
                else if (services[i].StartType == ServiceStartMode.Manual)
                {
                    manualAmount++;
                }
                else if (services[i].StartType == ServiceStartMode.Disabled)
                {
                    disabledAmount++;
                }
                else if (services[i].StartType == ServiceStartMode.System)
                {
                    systemAmount++;
                }
                else // services[i].StartType == ServiceStartMode.Boot
                {
                    bootAmount++;
                }
            }

            float automaticPercentage = (100 * automaticAmount) / services.Length;
            float manualPercentage = (100 * manualAmount) / services.Length;
            float disabledPercentage = (100 * disabledAmount) / services.Length;
            float systemPercentage = (100 * systemAmount) / services.Length;
            float bootPercentage = (100 * bootAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Automatic", automaticPercentage, Colors.Color1())
                    .AddItem("Manual", manualPercentage, Colors.Color2())
                    .AddItem("Disabled", disabledPercentage, Colors.Color3())
                    .AddItem("System", systemPercentage, Colors.Color4())
                    .AddItem("Boot", bootPercentage, Colors.Color5());

        }

        public static BreakdownChart GetMainMenuChartByServiceType()
        {
            ServiceController[] services = ServiceController.GetServices();

            int kernelDriverAmount = 0;
            int fileSystemDriverAmount = 0;
            int adapterAmount = 0;
            int interactiveProcessAmount = 0;
            int recognizerDriverAmount = 0;
            int win32OwnProcessAmount = 0;
            int win32ShareProcessAmount = 0;
            int otherAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].ServiceType == ServiceType.KernelDriver)
                {
                    kernelDriverAmount++;
                }
                else if (services[i].ServiceType == ServiceType.FileSystemDriver)
                {
                    fileSystemDriverAmount++;
                }
                else if (services[i].ServiceType == ServiceType.Adapter)
                {
                    adapterAmount++;
                }
                else if (services[i].ServiceType == ServiceType.InteractiveProcess)
                {
                    interactiveProcessAmount++;
                }
                else if (services[i].ServiceType == ServiceType.RecognizerDriver)
                {
                    recognizerDriverAmount++;
                }
                else if (services[i].ServiceType == ServiceType.Win32OwnProcess)
                {
                    win32OwnProcessAmount++;
                }
                else if (services[i].ServiceType == ServiceType.Win32ShareProcess)
                {
                    win32ShareProcessAmount++;
                }
                else
                {
                    otherAmount++;
                }
            }

            float kernelDrivePercentage = (100 * kernelDriverAmount) / services.Length;
            float fileSystemDriverPercentage = (100 * fileSystemDriverAmount) / services.Length;
            float adapterPercentage = (100 * adapterAmount) / services.Length;
            float interactiveProcessPercentage = (100 * interactiveProcessAmount) / services.Length;
            float recognizerDriverPercentage = (100 * recognizerDriverAmount) / services.Length;
            float win32OwnProcessPercentage = (100 * win32OwnProcessAmount) / services.Length;
            float win32ShareProcessPercentage = (100 * win32ShareProcessAmount) / services.Length;
            float otherPercentage = (100 * otherAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Win32OwnProcess", win32OwnProcessPercentage, Colors.Color1())
                    .AddItem("Win32ShareProcess", win32ShareProcessPercentage, Colors.Color2())
                    .AddItem("KernelDriver", kernelDrivePercentage, Colors.Color3())
                    .AddItem("FileSystemDriver", fileSystemDriverPercentage, Colors.Color4())
                    .AddItem("Adapter", adapterPercentage, Colors.Color5())
                    .AddItem("InteractiveProcess", interactiveProcessPercentage, Colors.Color4())
                    .AddItem("RecognizerDriver", recognizerDriverPercentage, Colors.Color3())
                    .AddItem("Other", otherPercentage, Colors.Color2());
        }

        public static BreakdownChart GetMainMenuChartByMachineName()
        {
            ServiceController[] services = ServiceController.GetServices();

            int localAmount = 0;
            int otherAmount = 0;

            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].MachineName == ".")
                {
                    localAmount++;
                }
                else
                {
                    otherAmount++;
                }
            }

            float localPercentage = (100 * localAmount) / services.Length;
            float otherPercentage = (100 * otherAmount) / services.Length;

            return new BreakdownChart()
                    .FullSize()
                    .ShowPercentage()
                    .AddItem("Localhost", localPercentage, Colors.Color1())
                    .AddItem("Other", otherPercentage, Colors.Color2());
        }
    }
}
