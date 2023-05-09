using System.ServiceProcess;

namespace SPZCW.Classes.StaticClasses.SpectreConsoleObjects.MainMenuChart
{
    class ServicesTypesData : AllServices
    {
        public float KernelDriverPercentage { get; private set; }
        public float FileSystemDriverPercentage { get; private set; }
        public float AdapterPercentage { get; private set; }
        public float InteractiveProcessPercentage { get; private set; }
        public float RecognizerDriverPercentage { get; private set; }
        public float Win32OwnProcessPercentage { get; private set; }
        public float Win32ShareProcessPercentage { get; private set; }
        public float OtherPercentage { get; private set; }

        private float _kernelDriverAmount { get; set; }
        private float _fileSystemDriverAmount { get; set; }
        private float _adapterAmount { get; set; }
        private float _interactiveProcessAmount { get; set; }
        private float _recognizerDriverAmount { get; set; }
        private float _win32OwnProcessAmount { get; set; }
        private float _win32ShareProcessAmount { get; set; }
        private float _otherAmount { get; set; }

        public ServicesTypesData()
        {
            CountServiceType();
            CalcServiceTypePercentage();
        }
        private void CountServiceType()
        {
            for (int i = 0; i < Services.Length; i++)
            {
                if (Services[i].ServiceType == ServiceType.KernelDriver)
                {
                    _kernelDriverAmount++;
                }
                else if (Services[i].ServiceType == ServiceType.FileSystemDriver)
                {
                    _fileSystemDriverAmount++;
                }
                else if (Services[i].ServiceType == ServiceType.Adapter)
                {
                    _adapterAmount++;
                }
                else if (Services[i].ServiceType == ServiceType.InteractiveProcess)
                {
                    _interactiveProcessAmount++;
                }
                else if (Services[i].ServiceType == ServiceType.RecognizerDriver)
                {
                    _recognizerDriverAmount++;
                }
                else if (Services[i].ServiceType == ServiceType.Win32OwnProcess)
                {
                    _win32OwnProcessAmount++;
                }
                else if (Services[i].ServiceType == ServiceType.Win32ShareProcess)
                {
                    _win32ShareProcessAmount++;
                }
                else
                {
                    _otherAmount++;
                }
            }
        }

        private void CalcServiceTypePercentage()
        {
            KernelDriverPercentage = (100 * _kernelDriverAmount) / Services.Length;
            FileSystemDriverPercentage = (100 * _fileSystemDriverAmount) / Services.Length;
            AdapterPercentage = (100 * _adapterAmount) / Services.Length;
            InteractiveProcessPercentage = (100 * _interactiveProcessAmount) / Services.Length;
            RecognizerDriverPercentage = (100 * _recognizerDriverAmount) / Services.Length;
            Win32OwnProcessPercentage = (100 * _win32OwnProcessAmount) / Services.Length;
            Win32ShareProcessPercentage = (100 * _win32ShareProcessAmount) / Services.Length;
            OtherPercentage = (100 * _otherAmount) / Services.Length;
        }
    }
}
