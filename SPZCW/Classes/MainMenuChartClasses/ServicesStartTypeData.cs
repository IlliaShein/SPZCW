using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects.MainMenuChart
{
    public class ServicesStartTypeData : AllServices
    {
        public float AutomaticPercentage { get; private set; }
        public float ManualPercentage { get; private set; }
        public float DisabledPercentage { get; private set; }
        public float SystemPercentage { get; private set; }
        public float BootPercentage { get; private set; }

        private float _automaticAmount { get; set; }
        private float _manualAmount { get; set; }
        private float _disabledAmount { get; set; }
        private float _systemAmount { get; set; }
        private float _bootAmount { get; set; }

        public ServicesStartTypeData()
        {
            Count();
            CalcPercentage();
        }

        private void Count()
        {
            for (int i = 0; i < Services.Length; i++)
            {
                if (Services[i].StartType == ServiceStartMode.Automatic)
                {
                    _automaticAmount++;
                }
                else if (Services[i].StartType == ServiceStartMode.Manual)
                {
                    _manualAmount++;
                }
                else if (Services[i].StartType == ServiceStartMode.Disabled)
                {
                    _disabledAmount++;
                }
                else if (Services[i].StartType == ServiceStartMode.System)
                {
                    _systemAmount++;
                }
                else // services[i].StartType == ServiceStartMode.Boot
                {
                    _bootAmount++;
                }
            }
        }

        private void CalcPercentage()
        {
            AutomaticPercentage = (100 * _automaticAmount) / Services.Length;
            ManualPercentage = (100 * _manualAmount) / Services.Length;
            DisabledPercentage = (100 * _disabledAmount) / Services.Length;
            SystemPercentage = (100 * _systemAmount) / Services.Length;
            BootPercentage = (100 * _bootAmount) / Services.Length;
        }
    }
}
