
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Jpeg file(*.jpg)|*.jpg|All files(*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filename);
            }
            catch
            {
                MessageBox.Show(" ОШИБКА!\n Не получилось заuрузить изображение.");
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Jpeg file(*.jpg)|*.jpg|All files(*.*)|*.*";


                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                // сохраняем текст в файл
                // pictureBox2.Image.Save(filename, ImageFormat.Jpeg);
                pictureBox2.Image.Save(filename, ImageFormat.Jpeg);
            }
            catch
            {
                MessageBox.Show(" ОШИБКА!\n Не получилось сохранить изображение.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Bitmap img1 = new Bitmap(pictureBox1.Image);
                Bitmap img2 = new Bitmap(img1.Width, img1.Height);
                for (int j = 0; j < img1.Height; j++)
                    for (int i = 0; i < img1.Width; i++)
                    {
                        // получаем компоненты цветов пикселя
                        float R = img1.GetPixel(i, j).R;
                        float G = img1.GetPixel(i, j).G;
                        float B = img1.GetPixel(i, j).B;

                        // собираем новый пиксель по частям (по каналам)
                        double Kr = 0.2126;
                        double Kg = 0.7152;
                        double Kb = 0.0722;
                        int y = Convert.ToInt32(Kr * R + Kg * G + Kb * B);
                        // добавляем его в Bitmap нового изображения
                        img2.SetPixel(i, j, Color.FromArgb(y, y, y));
                    }
                // выводим черно-белый Bitmap в pictureBox2
                pictureBox2.Image = img2;
            }
            catch
            {
                MessageBox.Show(" ОШИБКА!\n Не получилось переработать изображение.");
            }
        }
    }
}
