namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects.MainMenuChart
{
    public class ServicesMachineNameData : AllServices
    {
        public float LocalPercentage { get; private set; }
        public float OtherPercentage { get; private set; }

        private float _localAmount { get; set; }
        private float _otherAmount { get; set; }

        public ServicesMachineNameData()
        {
            CountMachineName();
            CalcMachineNamePercantage();
        }

        private void CountMachineName()
        {
            for (int i = 0; i < Services.Length; i++)
            {
                if (Services[i].MachineName == ".")
                {
                    _localAmount++;
                }
                else
                {
                    _otherAmount++;
                }
            }
        }

        private void CalcMachineNamePercantage()
        {
            LocalPercentage = (100 * _localAmount) / Services.Length;
            OtherPercentage = (100 * _otherAmount) / Services.Length;
        }
    }
}
