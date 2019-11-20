using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;

namespace openTK3D
{
    public partial class Form1 : Form
    {
        Auxiliar estruturar = new Auxiliar();
        int lateral = 0, lateral2 = 0;
        int size_muro = 100;
        Vector3d dir = new Vector3d(0, -450, 120);        //dire��o da c�mera
        Vector3d pos = new Vector3d(0, -550, 120);     //posi��o da c�mera
        float camera_rotation = 0;                     //rotação no eixo Z
        float camera_rotation2 = 0;
        float valor = 0f;
        public int portao;
        public int textura_parede;
        public int porta;
        public int textura_paredeI;
        public int assoalho;
        public int piso;
        public int marmore;
        public int cozinha_piso;
        public int parede_marrom;
        public int piso_armazem;
        public int portaexterior;
        public int janela;
        public int janela_banheiro;
        public int telhas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //limpa os buffers
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity(); //zera a matriz de proje��o com a matriz identidade

            Matrix4d lookat = Matrix4d.LookAt(pos.X, pos.Y, pos.Z, dir.X, dir.Y, dir.Z, 0, 0, 1);

            //aplica a transformacao na matriz de rotacao
            GL.LoadMatrix(ref lookat);
            //GL.Rotate(camera_rotation, 0, 0, 1);

            GL.Enable(EnableCap.DepthTest);


            //EIXOS X, Y, Z
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(500, 0, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 500, 0);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 500);
            GL.End();

            casaDraw();
            //Utilizamos o Enable para ativar o desenho com as texturas
           
            glControl1.SwapBuffers(); //troca os buffers de frente e de fundo 

        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);         // definindo a cor de limpeza do fundo da tela
            GL.Enable(EnableCap.Light0);

            SetupViewport();                      //configura a janela de pintura
        }

        private void SetupViewport() //configura a janela de proje��o 
        {
            int w = glControl1.Width; //largura da janela
            int h = glControl1.Height; //altura da janela

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(1f, w / (float)h, 1f, 2000.0f);
            GL.LoadIdentity(); //zera a matriz de proje��o com a matriz identidade

            portao = LoadTexture("Texturas/portao.jpg");
            textura_parede = LoadTexture("Texturas/paredehd.jpg");
            porta = LoadTexture("Texturas/porta.jpg");
            textura_paredeI = LoadTexture("Texturas/texturaparedeI.jpg");
            assoalho = LoadTexture("Texturas/assoalho.jpg");
            piso = LoadTexture("Texturas/piso.jpg");
            marmore = LoadTexture("Texturas/marmore.jpg");
            cozinha_piso = LoadTexture("Texturas/cozinhapiso.jpg");
            parede_marrom = LoadTexture("Texturas/paredemarrom.jpg");
            piso_armazem = LoadTexture("Texturas/pisoarmazem.jpg");
            portaexterior = LoadTexture("Texturas/portaexterior.jpg");
            janela = LoadTexture("Texturas/janela.jpg");
            janela_banheiro = LoadTexture("Texturas/janelabanheiro.jpg");
            telhas = LoadTexture("Texturas/telhas.jpg");
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            
            GL.Viewport(0, 0, w, h); // usa toda area de pintura da glcontrol
            lateral = w / 2;
            lateral2 = w / 2;

        }

        static int LoadTexture(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException(filename);

            int id;//= GL.GenTexture(); 

            GL.GenTextures(1, out id);
            GL.BindTexture(TextureTarget.Texture2D, id);
            
            Bitmap bmp = new Bitmap(filename);

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return id;
        }

        private void calcula_direcao()
        {
            dir.X = pos.X + (Math.Sin(camera_rotation * Math.PI / 180) * 1000);
            dir.Y = pos.Y + (Math.Cos(camera_rotation * Math.PI / 180) * 1000);
            dir.Z = pos.Z + (Math.Tan(camera_rotation2 * Math.PI / 180) * 1000);
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.X > lateral)
            {
                camera_rotation += 2;
            }
            if (e.X < lateral)
            {
                camera_rotation -= 2;
            }
            if (e.Y > lateral2)
            {
                camera_rotation2 -= 0.6f;
            }
            if (e.Y < lateral2)
            {
                camera_rotation2 += 0.6f;
            }
            lateral = e.X;
            lateral2 = e.Y;
            calcula_direcao();
            glControl1.Invalidate();
        }

        private void glControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            float a = camera_rotation;
            int tipoTecla = 0;
            int sinal = 1;

            if (e.KeyCode == Keys.Q)
            {
                valor += 10;
                pos.Z += 100;
                glControl1.Invalidate();
            }
            if (e.KeyCode == Keys.E)
            {
                valor -= 10;
                pos.Z -= 100;
                glControl1.Invalidate();
            }
            if (e.KeyCode == Keys.A)
            {
                sinal = 0;
                a -= 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.D)
            {
                sinal = 0;
                a += 90;
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.W)
            {
                tipoTecla = 1;
            }
            if (e.KeyCode == Keys.S)
            {
                sinal = -1;
                a += 180;
                tipoTecla = 1;
            }

            if (e.KeyCode == Keys.Right)
            {
                a += 3;
                tipoTecla = 2;
            }
            if (e.KeyCode == Keys.Left)
            {
                a -= 3;
                tipoTecla = 2;
            }
            if (e.KeyCode == Keys.Up)
            {
                pos.Z += 2;
            }
            if (e.KeyCode == Keys.Down)
            {
                pos.Z -= 2;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (tipoTecla == 1)
            {
                if (a < 0) a += 360;
                if (a > 360) a -= 360;
                //label2.Text = lateral.ToString();
                pos.X += (Math.Sin(a * Math.PI / 180) * 100);
                pos.Y += (Math.Cos(a * Math.PI / 180) * 100);
                pos.Z += (Math.Sin(camera_rotation2 * Math.PI / 180) * 100) * sinal;
                calcula_direcao();
                glControl1.Invalidate();
            }

            if (tipoTecla == 2)
            {
                camera_rotation = a;
                calcula_direcao();
                glControl1.Invalidate();
            }
            //txtPosX.Text = Convert.ToInt16(pos.X).ToString();
            //txtPosY.Text = Convert.ToInt16(pos.Y).ToString();
            //txtPosZ.Text = Convert.ToInt16(pos.Z).ToString();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glControl1.Width = Form1.ActiveForm.Width - 10;
            glControl1.Height = Form1.ActiveForm.Height - 10;
            if (Form1.ActiveForm.Visible)
            {
                SetupViewport();
            }
            glControl1.Invalidate();
        }

        private void casaDraw()
        {
            /*PAREDES EXTERIORES
          //
            */
            int espessura = 10;
            //PORTA
            estruturar.desenhaparedex(810, 295, 0, 80, size_muro, espessura, Color.White, porta, 1);
            estruturar.desenhaparedex(810, 1305, 50, 80, 30, espessura, Color.White, janela, 1);

            //JANELA


            //CHAO
            estruturar.horizontal(0, 0, 0, 3500, 3500, Color.DarkGray);
            estruturar.horizontal(805, 0, 1, 90, 350, Color.Gray);

            //paredes BLOCO CETRAL
            estruturar.desenhaparedex(700, 1000, 0, 300, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedex(700, 300, 0, 300, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedey(500, 500, 0, 300, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedey(1200, 500, 0, 300, size_muro, espessura, Color.White, textura_parede, 1);

            //Paredes BLOCO DA DIREIRA
            estruturar.desenhaparedex(725, 1300, 0, 250, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedey(600, 900, 0, 250, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedey(1100, 900, 0, 250, size_muro, espessura, Color.White, textura_parede, 1);

            //Paredes BLOCO DO FUNDO
            estruturar.desenhaparedey(100, 430, 0, 430, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedex(100, 430, 0, 400, size_muro, espessura, Color.White, textura_parede, 1);
            estruturar.desenhaparedex(100, 860, 0, 400, size_muro, espessura, Color.White, textura_parede, 1);
            //DIAGONAIS DIREITA
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(700, 1000, 100);
            GL.Vertex3(700, 1000, 0);
            GL.Vertex3(500, 800, 0);
            GL.Vertex3(500, 800, 100);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(1000, 1000, 100);
            GL.Vertex3(1000, 1000, 0);
            GL.Vertex3(1200, 800, 0);
            GL.Vertex3(1200, 800, 100);
            GL.End();


            //DIAGONAIS CENTRAL
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(700, 300, 100);
            GL.Vertex3(700, 300, 0);
            GL.Vertex3(500, 500, 0);
            GL.Vertex3(500, 500, 100);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(1000, 300, 100);
            GL.Vertex3(1000, 300, 0);
            GL.Vertex3(1200, 500, 0);
            GL.Vertex3(1200, 500, 100);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(700, 1000, 100);
            GL.Vertex3(700, 1000, 0);
            GL.Vertex3(500, 800, 0);
            GL.Vertex3(500, 800, 100);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(1000, 1000, 100);
            GL.Vertex3(1000, 1000, 0);
            GL.Vertex3(1200, 800, 0);
            GL.Vertex3(1200, 800, 100);
            GL.End();

            //DIAGONAIS BLOCOS DE TRAS

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(725, 1300, 100);
            GL.Vertex3(725, 1300, 0);
            GL.Vertex3(600, 1150, 0);
            GL.Vertex3(600, 1150, 100);
            GL.End();

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textura_parede);
            GL.Color3(Color.Transparent);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex3(975, 1300, 100);
            GL.Vertex3(975, 1300, 0);
            GL.Vertex3(1100, 1150, 0);
            GL.Vertex3(1100, 1150, 100);
            GL.End();

        }
    }
}
