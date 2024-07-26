using HSM.WinService.Applications.Interfaces;
using HSM.WinService.UI.SystemService.SystemInterface;
using Microsoft.Extensions.Logging;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace HSM.WinService.UI
{
    public partial class MainForm : Form
    {

        private readonly ISoundService makeSound;
        private readonly IUdpComunicationService udpComunication;
        private readonly IActionService ActionService;
        private readonly IContactServices contactServices;
        private readonly ILogger<MainForm> logger;
        public MainForm(ISoundService MakeSound, IContactServices contactServices,IUdpComunicationService Udp,IActionService actSer, ILogger<MainForm> logger)
        {
            InitializeComponent();
            this.makeSound = MakeSound;
            this.contactServices = contactServices;
            this.udpComunication = Udp;
            this.ActionService = actSer;
            this.logger = logger;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            ToMuchAlarm("20");
            while (true)
            {
                try
                {
                    await checkvolume(); // check  computer audio volume
                    var UdpCodes = udpComunication.Receive(); // receive udp codes
                    List<string> Codes = UdpCodes.Split(',').ToList();
                    if (Codes.Count > 0)
                    {
                        foreach (var code in Codes)
                        {
                            await MakeAdvertisment(code);
                        }
                    }
                    if(Codes.Count()>10)
                    {
                        ToMuchAlarm(Codes.Count().ToString());
                    }
                }
                catch (Exception exp)
                {
                    logger.LogError(exp.Message, exp.StackTrace);
                }
            }
        }

        #region ToMuchAlarm

        public void ToMuchAlarm(string count)
        {
            NewMessageIntro();
            makeSound.SpeakNow($"ყურადღება, ყურადღება, განგაში. სენსორებზე გვაქვს ხარვეზი, რაოდენობა: {count}. გადაამოწმე ოპერატიულად. სენსორების დეტალური სია, შეგიძლია იხილო მთავარ მონიტორზე");
            PlayAudio("C:\\Users\\aapkh\\Downloads\\War.mp3");
        }
        #endregion

        #region MakeAlert
        private async Task MakeAlert(string message)
        {
            await contactServices.SendMessageAlertWithEmail(message);
            await makeSound.SpeakNow("ყურადღება, ყურადღება, განგაში. გვაქვს გადაუდებელი სიტუაცია, გადაამოწმე ოპერატიულად !!.");
            Call112();
            PlayAudio("C:\\Users\\aapkh\\Downloads\\War.mp3");
        }
        #endregion

        #region MakeAdvertisment
        private async Task MakeAdvertisment(string code)
        {
            var action = await ActionService.GetByCodeAsync(code);
            if (action != null)
            {
                if (action.IsEmergencySituation == true)
                {

                    await MakeAlert(action.Action_Ka);
                }
                else
                {
                    await makeSound.SpeakNow(action.Action_Ka, 1);
                }
            }
        }
        #endregion

        #region CheckVolume
        private async Task  checkvolume()
        {
            int count = 0;
            int countsayelse = 0;

            MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator();
            MMDevice defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            float level = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100;
            DateTime currentTime = DateTime.Now;

            Console.WriteLine(currentTime.Hour);
            if (currentTime != null && currentTime.Hour >= 10 && currentTime.Hour <= 21)
            {
                countsayelse = 0;
                if (level <= 74)
                {
                    await makeSound.SpeakNow("ყურადღება, გადავდივარ დღის რეჟიმზე",2);
                    count++;
                    await makeSound.SpeakNow("მე ვარ სოფია, იმისათვის, რომ ვიმუშაო  სრულყოფილად, მესაჭიროება ვისაუბრო ხმამაღლა, გხოვთ ნუ შემიზღუდავთ უფლებებს, ნუ დაუწევთ ხმას ან  ნუ გამორთავთ დინამიკს, მადლობა ყურადღებისთვის.",1);
                    await makeSound.SpeakNow("ვაყენებ ხმას ჩემთვის მისაღებ ნორმაზე",-1);
                    defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = 0.65f;
                    if (count >= 3)
                    {
                        await makeSound.SpeakNow($"მე საშინლად გაბრაზებული ვარ,  რომ არ ითვალისწინებ ჩემს თხოვნას. უკვე {count}-ჯერ დაუწიე ხმას , გთხოვ სამუშაო საათებში ნუ დაუწევ ხმას.");
                        count = 0;
                    }
                }
            }
            else
            {
                if (countsayelse == 0 || level >= 20 || level <= 10)
                {
                    await makeSound.SpeakNow("ღამის საათებში. ხმას ვაყენებ შედარებით  დაბალზე, იყავით ყურადღებით. მადლობა.");
                    defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = 0.15f;
                    count = 0;
                    countsayelse++;
                }
            }
        }
        #endregion

        #region PlayAudio
        public void PlayAudio(string path)
        {
            using (var audioFile = new AudioFileReader(path))

            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }

            }
        }
        #endregion

        #region Call112
        public  void Call112()
        {
           PlayAudio("C:\\Users\\aapkh\\Downloads\\112.mp3");
        }
        #endregion

        #region New message for you

        public void NewMessageIntro()
        {
            PlayAudio("C:\\Users\\aapkh\\Downloads\\NewMessage.mp3");
        }
        #endregion
    }
}
