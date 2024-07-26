namespace HSM.WinService.UI.SystemService.SystemInterface
{
    public interface ISoundService
    {
        Task SpeakNow(string text, int speed = 1);
    }
}
