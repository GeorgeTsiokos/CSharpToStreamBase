using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSharpToStreamBase
{
    public partial class PocForm : Form
    {
        public PocForm() => InitializeComponent();

        private void OnTextChanged(object sender, EventArgs e)
        {
            var (name, expression) = CSharpToStreamBaseConverter.Convert(_textBox.Text);

            _name.Text = name;
            _expression.Text = expression;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var clipboard = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboard))
                return;

            var (name, _) = CSharpToStreamBaseConverter.Convert(clipboard);

            if (name.Length == 0)
                return;

            _textBox.Text = clipboard;
        }


        private void OnClick(object sender, EventArgs e)
        {
            var text = ((Control) sender).Text;
            if (string.IsNullOrWhiteSpace(text))
                return;

            Clipboard.SetText(text);
        }

        private void OnPictureClick(object sender, EventArgs e)
        {
            var control = (Control) sender;
            var mouseEventArgs = (MouseEventArgs) e;

            if (mouseEventArgs.X > 50 || control.Size.Height - mouseEventArgs.Y > 50)
                return;

            Process.Start("https://github.com/GeorgeTsiokos/CSharpToStreamBase");
        }
    }
}