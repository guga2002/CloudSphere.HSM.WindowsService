using HSM.WinService.UI.SystemService.SystemInterface;
using System.Speech.Synthesis;

namespace HSM.WinService.UI.SystemService.SystemServices
{
    public class SoundService:ISoundService
    {

        public async Task SpeakNow(string text,int speed=1)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    if (info.Culture.Name.StartsWith("ka-GE") && info.Name.Contains("Nat"))
                    {
                        synth.SelectVoice(info.Name);
                        break;
                    }
                }
                try
                {
                    synth.Rate = speed;
                    synth.Speak(text);
                }
                catch (Exception ex)
                {
                    await Task.Delay(100);
                    Console.WriteLine("shecdoma saubris dros" + ex.Message);
                }
            }
        }
    }
}
