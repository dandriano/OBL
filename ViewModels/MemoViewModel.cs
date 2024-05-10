using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;
using System.IO;
using System.Threading.Tasks;

namespace OBL.ViewModels
{
    public class MemoViewModel : ObservableObject
    {
        private string _text = string.Empty;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private Color _textColor = Colors.Black;
        public Color TextColor
        {
            get => _textColor;
            set => SetProperty(ref _textColor, value);
        }

        private float _fontSize = 18;
        public float FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize, value);
        }

        public MemoViewModel()
        {
            Task.Run(async () =>
            {
                using (var stream = await FileSystem.OpenAppPackageFileAsync("source.md"))
                {
                    if (stream != null)
                    {
                        Text = new StreamReader(stream).ReadToEnd();
                    }
                };
            });
        }
    }
}