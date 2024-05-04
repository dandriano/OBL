using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace OBL.Controls
{
    public class MarkdownGraphicsView : GraphicsView, IDisposable
    {

        private static void SmthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var ctrl = (MarkdownGraphicsView)bindable;
            ctrl.Render();
        }

        public static readonly BindableProperty TextProperty = BindableProperty
            .Create(nameof(Text), typeof(string), typeof(MarkdownGraphicsView), default(string), propertyChanged: SmthChanged);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty
            .Create(nameof(FontSize), typeof(float), typeof(MarkdownGraphicsView), default(float), propertyChanged: SmthChanged);
        public float FontSize
        {
            get => (float)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty
            .Create(nameof(TextColor), typeof(Color), typeof(MarkdownGraphicsView), default(Color), propertyChanged: SmthChanged);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        private PointF _lastInteractionPoint;
        public readonly MarkdownDrawable _drawable;

        public MarkdownGraphicsView()
        {
            StartInteraction += OnStartInteraction;
            DragInteraction += OnDragInteraction;

            Drawable = _drawable = new MarkdownDrawable();
        }

        private void Render()
        {
            _drawable.Text = Text;
            _drawable.Size = new SizeF((float)Width, (float)Height);
            _drawable.FontSize = FontSize;
            _drawable.FontColor = TextColor;
            Invalidate();
        }

        private void OnStartInteraction(object sender, TouchEventArgs e)
        {
            _lastInteractionPoint = e.Touches[0];
        }

        private void OnDragInteraction(object sender, TouchEventArgs e)
        {
            _drawable.Offset = new SizeF(_drawable.Offset.Width, _drawable.Offset.Height - (_lastInteractionPoint.Y - e.Touches[0].Y) / 50);
            Render();
        }

        public void Dispose()
        {
            StartInteraction -= OnStartInteraction;
            DragInteraction -= OnDragInteraction;
        }
    }
}
