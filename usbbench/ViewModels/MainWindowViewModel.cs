using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Collections.ObjectModel; //observable collection
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Avalonia.Media;
using usbBench.ViewModels;
using usbBench.Models;

namespace usbBench.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            IncomingData = new ObservableCollection<string>();

            VID = "4B4";
            PID = "80";
            ConnectedText = "Disconnected";
        }

        public ObservableCollection<string> IncomingData { get; }
        //constructor

        private string _connectedText;
        public string ConnectedText
        {
            get { return _connectedText; }
            set
            {
                this.RaiseAndSetIfChanged(ref _connectedText, value);
            }
        }

        private string _vid;
        public string VID
        {
            get { return _vid; }
            set
            {
                this.RaiseAndSetIfChanged(ref _vid, value);
            }
        }

        private string _pid;
        public string PID
        {
            get { return _pid; }
            set
            {
                this.RaiseAndSetIfChanged(ref _vid, value);
            }
        }

        CancellationTokenSource cts = new CancellationTokenSource();


        public UsbDev PSoC = new UsbDev();
    
        public void Connect()
        {
/*
            PSoC = new USB(0x4B4,0x80);
            if (PSoC!=null)
            {
                ConnectedText="CONNECTED";
            }
            */
        }

        public async void StartTransfer()
        {
            CancellationToken token = cts.Token;

            try
            {
                //PSoC.pid = Int32.Parse(PID, System.Globalisation.NumberStyles.HexNumber;
                //PSoC.vid = Int32.Parse(VID..

                await Task.Run(()=> PSoC.Transfer(), token);
                if (true)//(Usb.incomingData !=null)
                {
                    IncomingData.Add("Usb.incomingData + timestamp");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void StopPrint()
        {
            cts.Cancel();

            cts = new CancellationTokenSource();
        }
    }
}
