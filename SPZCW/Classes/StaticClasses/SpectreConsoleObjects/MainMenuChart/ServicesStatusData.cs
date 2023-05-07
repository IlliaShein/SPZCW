using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects.MainMenuChart
{
    public class ServicesStatusData : AllServices
    {
        public float StoppedPercentage { get; private set; }
        public float RunningPercentage { get; private set; }
        public float OtherPercentage { get; private set; }

        private float _stoppedAmount { get;  set; }
        private float _runningAmount { get;  set; }
        private float _otherAmount { get;  set; }

        public ServicesStatusData()
        {
            Count();
            CalcPercentage();
        }

        private void Count()
        {
            for (int i = 0; i < Services.Length; i++)
            {
                if (Services[i].Status == ServiceControllerStatus.Stopped)
                {
                    _stoppedAmount++;
                }
                else if (Services[i].Status == ServiceControllerStatus.Running)
                {
                    _runningAmount++;
                }
                else
                {
                    _otherAmount++;
                }
            }
        }

        private void CalcPercentage()
        {
            StoppedPercentage = (100 * _stoppedAmount) / Services.Length;
            RunningPercentage = (100 * _runningAmount) / Services.Length;
            OtherPercentage = (100 * _otherAmount) / Services.Length;
        }
    }
}
