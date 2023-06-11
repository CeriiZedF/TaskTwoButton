namespace TaskTwoButton
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.button1.Location = new Point((r.Next(button1.Width, this.Width) - button1.Width), r.Next(button1.Height, this.Height) - button1.Height);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = (r.Next(button1.Width, this.Width) - button1.Width).ToString();
        }

       
    }
}