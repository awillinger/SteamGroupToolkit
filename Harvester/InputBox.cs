using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harvester
{
    public class InputBox : Form
    {
        public static void Show(String title, String info, EventHandler ex)
        {
            Form form = new Form();
            form.Text = title;
            form.ShowIcon = false;
            form.Size = new System.Drawing.Size(350, 170);
            form.FormBorderStyle = FormBorderStyle.FixedSingle;

            Label info_text = new Label();
            info_text.Text = info;
            info_text.Parent = form;
            info_text.Size = new System.Drawing.Size(330, 55);
            info_text.Location = new System.Drawing.Point(10, 10);

            TextBox box = new TextBox();
            box.Location = new System.Drawing.Point(10, 75);
            box.Size = new System.Drawing.Size(320, 25);
            box.Name = "ip_tData";
            box.Parent = form;

            Button ok = new Button();
            ok.Location = new System.Drawing.Point(120, 105);
            ok.Size = new System.Drawing.Size(50, 25);
            ok.Name = "ip_bOk";
            ok.Text = "OK";
            ok.Parent = form;
            ok.Click += new EventHandler(delegate(object o1, EventArgs ea)
                {
                });

            Button cancel = new Button();
            cancel.Location = new System.Drawing.Point(180, 105);
            cancel.Size = new System.Drawing.Size(50, 25);
            cancel.Name = "ip_bCancel";
            cancel.Text = "Cancel";
            cancel.Parent = form;
            cancel.Click += new EventHandler(delegate(object o1, EventArgs ea)
                {
                    form.Close();
                });

            form.ResumeLayout();
            form.Show();
        }
    }
}
