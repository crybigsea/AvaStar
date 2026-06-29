using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input.Platform;

namespace AvaStar.Services
{
    public class ClipboardService(IClassicDesktopStyleApplicationLifetime liftime)
    {
        public void CopyToClipboard(string text) => liftime.MainWindow?.Clipboard?.SetTextAsync(text);
    }
}
