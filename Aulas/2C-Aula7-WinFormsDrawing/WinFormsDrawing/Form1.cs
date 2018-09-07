using System.Drawing;
using System.Windows.Forms;

namespace WinFormsDrawing
{
    // partial - esse arquivo contém apenas uma parte do código
    // completo da classe
    // : Form - A classe FrmMain "herda" as caracteristicas de Form.
    public partial class FrmMain : Form
    {
        Bitmap papel;
        Graphics mao;
        Pen caneta;
        SolidBrush pincel;

        // Método construtor
        // - Mesmo nome da classe
        // - não possui tipo de retorno
        public FrmMain()
        {
            InitializeComponent();

            papel = new Bitmap(canvas.Width, canvas.Height);
            canvas.Image = papel;
            mao = Graphics.FromImage(papel);

            caneta = new Pen(Color.Blue, 3);
            pincel = new SolidBrush(Color.Gray);
             
            DrawTabuleiro();
            ////DrawSmile(250, 250, 100);
        }

        public void DrawX(int x, int y, int tam, Color cor)
        {
            caneta.Color = cor;
            caneta.Width = 2;
            mao.DrawLine(caneta, x, y, x+tam, y+tam);
            mao.DrawLine(caneta, x+tam, y, x, y+tam);
        }
        public void DrawO(int x, int y, int tam, Color cor)
        {
            caneta.Color = cor;
            caneta.Width = 2;
            mao.DrawEllipse(caneta, x, y, tam, tam);
        }

        private void DrawTabuleiro()
        {
            int x1 = canvas.Width / 3;
            int x2 = x1 * 2;
            int y1 = canvas.Height / 3;
            int y2 = y1 * 2;

            mao.DrawLine(caneta, x1, 1, x1, canvas.Height);
            mao.DrawLine(caneta, x2, 1, x2, canvas.Height);
            mao.DrawLine(caneta, 1, y1, canvas.Width, y1);
            mao.DrawLine(caneta, 1, y2, canvas.Width, y2);
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            int tam;
            if (e.Button == MouseButtons.Left)
            {
                tam = 40;
                DrawX(e.X - tam / 2, e.Y - tam / 2, tam, Color.Green);
            }
            else if (e.Button == MouseButtons.Right)
            {
                tam = 50;
                DrawO(e.X - tam / 2, e.Y - tam / 2, tam, Color.Red);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                DrawSmile(e.X, e.Y, 60);
            }

            canvas.Invalidate();

        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's')
                MessageBox.Show("Você ganhou R$ 1.000.000,00!", "MessageBox da Sorte", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }


        private void DrawSmile(int x, int y, int tam)
        {
            pincel.Color = Color.Yellow;
            mao.FillEllipse(pincel, x-tam/2, y-tam/2, tam, tam);

            /*pincel.Color = Color.Black;
            mao.FillEllipse(pincel, x, y, (int)((3 / 8.0) * tam), tam);
            pincel.Color = Color.Black;
            mao.FillEllipse(pincel, x, y, (int)((5 / 8.0) * tam), tam);*/
        }

    }
}
