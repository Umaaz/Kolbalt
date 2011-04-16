using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using TextBox = System.Windows.Forms.TextBox;

namespace MediaApp.Forms.Popups
{
    public class InputBox
    {
        public static DialogResult Show(string title, string promptText, String defaultText, ref String value)
        {
            var form = new Form();
            var label = new Label();
            var textBox = new TextBox();
            var buttonOk = new Button();
            var buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = defaultText;
            
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            var dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
        static Point _labelStartpoint = new Point(18, 25);
        static Point _textBoxStartpoint = new Point(21, 41);
        private static TextBox NewTextBox(String defaultText, int index)
        {
            var aTextBox = new TextBox
            {
                Text = defaultText,
                Location = new Point(_textBoxStartpoint.X, ((index) * 39)+ _textBoxStartpoint.Y),
                Tag = index,
                Visible = true,
                Size = new Size(258,20)
                
            };
            return aTextBox;
        }

        private static Label NewLabel(String message, int index)
        {
            var alabel = new Label
            {
                Text = message,
                Location = new Point(_labelStartpoint.X, ((index) * 39) + _labelStartpoint.Y),
                Tag = index,
                Visible = true
            };
            return alabel;
        }
        
        public static DialogResult Show(String title, String[] promptText, String[] defaultText, ref List<String> results,Boolean requestConfirmation)
        {
            var dresult = DialogResult.None;
            var result = false;
            while (result == false)
            {
                dresult = Show(title, promptText, defaultText, ref results);
                if (dresult != DialogResult.OK) continue;
                var message = "Are you sure the following information is correct?\n";
                for (int i = 0; i < promptText.Count(); i++)
                {
                    message += promptText[i] + " " + results[i] + "/n";
                }

                if (MessageBox.Show(message,"Please Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    result = true;
                }
            }
            return dresult;
        }

        public static DialogResult Show(String title, String[] promptText, String[] defaultText, ref List<String> results)
        {
            if(promptText.Count() != defaultText.Count())
            {
                throw new ArgumentOutOfRangeException(@"promptText",@"promptText.count() must equal defaultText.count()");
            }
            var form = new Form();
            var labels = new List<Label>();
            var textBoxes = new List<TextBox>();
            var buttonOk = new Button();
            var buttonCancel = new Button();

            for (int i = 0; i < promptText.Count(); i++)
            {
                var alabel = NewLabel(promptText[i], i);
                labels.Add(alabel);
                form.Controls.Add(alabel);

                var atextbox = NewTextBox(defaultText[i], i);
                textBoxes.Add(atextbox);
                form.Controls.Add(atextbox);
                atextbox.BringToFront();
            }

            var right = labels.Max(x => x.Right);

            form.Text = title;

            buttonOk.Text = "Ok";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            

            form.ClientSize = new Size(396, 107 + ((promptText.Count()-1) * _textBoxStartpoint.Y));
            form.Controls.AddRange(new Control[] {buttonOk, buttonCancel});
            form.ClientSize = new Size(Math.Max(300, right + 10), form.ClientSize.Height);
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            buttonOk.SetBounds(form.ClientSize.Width - 85, form.ClientSize.Height - 33, 75, 23);
            buttonCancel.SetBounds(form.ClientSize.Width - 160, form.ClientSize.Height - 33, 75, 23);

            var dialogResult = form.ShowDialog();
            results.AddRange(textBoxes.Select(textBox => textBox.Text));
            return dialogResult;
        }


    }
}
