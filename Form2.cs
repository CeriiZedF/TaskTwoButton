using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTwoButton
{
    public partial class Form2 : Form
    {
        private const int maxCount = 256;
        private int it = 0;
        private int x1;
        private int y1;
        private int x;
        private int y;
        private int x_mouse_down;
        private int y_mouse_down;
        private int width;
        private int height;
        private int flag1 = 0;
        private int flag2 = 0;

        int indexButton = 0;
        public Form2()
        {
            InitializeComponent();
        }

        

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            this.flag1 = 1;
            this.x_mouse_down = e.X;
            this.y_mouse_down = e.Y;
            this.x = e.X;
            this.y = e.Y;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            this.flag1 = 0;
            this.flag2 = 0;
            if (this.width < 20 || this.height < 20)
            {
                int num = (int)MessageBox.Show("Кнопка слишком маленького размера!", "Error");
                this.Controls[indexButton].Dispose();
            }
            else
            {
                this.x1 = e.X;
                this.y1 = e.Y;
                this.width = this.x1 - this.x_mouse_down;
                this.height = this.y1 - this.y_mouse_down;
                if (this.width <= 0 || this.height <= 0)
                {
                    if (this.width > 0 && this.height < 0)
                    {
                        this.y = this.y1;
                        this.height = Math.Abs(this.height);
                    }
                    else if (this.width < 0 && this.height > 0)
                    {
                        this.x = this.x1;
                        this.width = Math.Abs(this.width);
                    }
                    else if (this.width < 0 && this.height < 0)
                    {
                        this.x = this.x1;
                        this.y = this.y1;
                        this.height = Math.Abs(this.height);
                        this.width = Math.Abs(this.width);
                    }
                }
                this.Controls[indexButton].Location = new Point(this.x, this.y);
                this.Controls[indexButton].Size = new Size(this.width, this.height);
                ++this.it;
                indexButton++;
            }
            
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            this.x1 = e.X;
            this.y1 = e.Y;
            if (this.flag1 != 1)
                return;
            this.width = this.x1 - this.x_mouse_down;
            this.height = this.y1 - this.y_mouse_down;
            if (this.width <= 0 || this.height <= 0)
            {
                if (this.width > 0 && this.height < 0)
                {
                    this.y = this.y1;
                    this.height = Math.Abs(this.height);
                }
                else if (this.width < 0 && this.height > 0)
                {
                    this.x = this.x1;
                    this.width = Math.Abs(this.width);
                }
                else if (this.width < 0 && this.height < 0)
                {
                    this.x = this.x1;
                    this.y = this.y1;
                    this.height = Math.Abs(this.height);
                    this.width = Math.Abs(this.width);
                }
            }
            if (this.flag2 == 0)
            {
               
                this.SuspendLayout();
                Button button = new Button();
                button.Location = new Point(e.X, e.Y);
                button.Name = "button" + indexButton;
                button.Size = new Size(30, 30);
                button.TabIndex = indexButton;
                button.Text = "button" + indexButton;
                button.UseVisualStyleBackColor = true;
                this.Controls.Add(button);
                this.flag2 = 1;
            }
            else
            {
                this.Controls[indexButton].Location = new Point(this.x, this.y);
                this.Controls[indexButton].Size = new Size(this.width, this.height);
            }
        }
    }
}
