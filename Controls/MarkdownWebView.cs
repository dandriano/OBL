using Markdig;
using Microsoft.Maui.Controls;

namespace OBL.Controls
{
    public class MarkdownWebView : WebView
    {
        private static void SmthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (MarkdownWebView)bindable;
            ctrl.Refresh();
        }

        public static readonly BindableProperty TextProperty = BindableProperty
            .Create(nameof(Text), typeof(string), typeof(MarkdownWebView), propertyChanged: SmthChanged);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public void Refresh()
        {
            var builder = new MarkdownPipelineBuilder()
               .UseEmojiAndSmiley()
               .UseEmphasisExtras();
            var pipeline = builder.Build();

            Source = new HtmlWebViewSource()
            {
                Html = Markdown.ToHtml(Text ?? string.Empty, pipeline),
            };
        }
    }
}
