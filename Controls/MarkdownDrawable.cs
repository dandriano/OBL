using Markdig;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Text;
using Microsoft.Maui.Graphics.Text.Renderer;
using System;
using Font = Microsoft.Maui.Graphics.Font;

namespace OBL.Controls
{
    public class MarkdownDrawable : IDrawable
    {
        public SizeF Offset { get; set; }
        public string Text { get; set; } = string.Empty;
        public SizeF Size { get; set; }
        public float FontSize { get; set; }
        public Color FontColor { get; set; } = Colors.Black;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.Font = Font.Default;
            canvas.FontSize = FontSize;
            canvas.FontColor = FontColor;
            var attributedText = Read(Text);
            // https://stackoverflow.com/questions/76514800/system-notimplementedexception-after-trying-to-run-canvas-drawtext-in-net-maui
#if WINDOWS
            canvas.DrawString(attributedText.Text, 0, Offset.Height, Math.Max(0, Size.Width), Math.Max(0, Size.Height), HorizontalAlignment.Left, VerticalAlignment.Top);
#else
            canvas.DrawText(attributedText, 0, Offset.Height, Size.Width, Size.Height);
#endif
        }

        private static IAttributedText Read(string text)
        {
            var renderer = new AttributedTextRenderer();
            renderer.ObjectRenderers.Add(new CodeInlineRenderer());
            renderer.ObjectRenderers.Add(new CodeBlockRenderer());
            renderer.ObjectRenderers.Add(new HeadingRenderer());
            var builder = new MarkdownPipelineBuilder()
                          .UseEmojiAndSmiley()
                          .UseEmphasisExtras();
            var pipeline = builder.Build();
            Markdown.Convert(text ?? string.Empty, renderer, pipeline);
            return renderer.GetAttributedText();
        }


    }
}

