using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

// evita ambiguidade entre System.Threading.Timer e System.Windows.Forms.Timer
using Timer = System.Windows.Forms.Timer;

namespace Helicopter_Shooter_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        bool gameOver = false;
        int destructions = 0;
        int barriersPassed = 0;
        int speed = 8;
        int UFOspeed = 10;
        int index = 0;
        Random rand = new Random();

        // gravidade e impulso
        float gravity = 2f;          // queda mais lenta
        float jumpStrength = -10f;   // impulso para cima
        float velocityY = 0f;        // velocidade vertical

        // transição de fundo
        bool isBackgroundTransitioning = false;
        Image nextBackground;
        float transitionAlpha = 0f;

        private Label txtScoreRight;
        private Label lblGameOver;

        // delay dos pilares
        bool pilaresAtivos = false;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.BackColor = Color.LightSkyBlue;

            // Score no canto superior direito
            txtScoreRight = new Label();
            txtScoreRight.AutoSize = true;
            txtScoreRight.Font = txtScore.Font;
            txtScoreRight.ForeColor = txtScore.ForeColor;
            txtScoreRight.TextAlign = ContentAlignment.TopRight;
            txtScoreRight.Location = new Point(this.ClientSize.Width - 150, 10);
            txtScoreRight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Controls.Add(txtScoreRight);

            this.Resize += (s, e) =>
            {
                txtScoreRight.Location = new Point(this.ClientSize.Width - 150, 10);
                CenterGameOverLabel();
            };

            // Label centralizado para Game Over
            lblGameOver = new Label();
            lblGameOver.AutoSize = true;
            lblGameOver.Font = new Font("Arial", 32, FontStyle.Bold);
            lblGameOver.ForeColor = Color.Red;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Text = "GAME OVER!\nPress Enter to Restart";
            lblGameOver.TextAlign = ContentAlignment.MiddleCenter;
            lblGameOver.Visible = false;
            this.Controls.Add(lblGameOver);
            CenterGameOverLabel();

            // eventos
            this.KeyDown += KeyIsDown;
            this.KeyUp += KeyIsUp;
            this.MouseDown += Form1_MouseDown;

            GameTimer.Start();

            // inicializa pilares fora da tela à direita
            pillar1.Left = this.ClientSize.Width + 100;
            pillar2.Left = this.ClientSize.Width + 400;

            // Timer para ativar pilares após 1,3 segundos
            Timer delayTimer = new Timer();
            delayTimer.Interval = 1300;
            delayTimer.Tick += (s, e) =>
            {
                pilaresAtivos = true;
                delayTimer.Stop();
            };
            delayTimer.Start();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = $"Destructions: {destructions}";
            txtScoreRight.Text = $"Score: {barriersPassed}";

            // transição de fundo ao atingir 7 destructions
            if (destructions == 7 && !isBackgroundTransitioning)
            {
                isBackgroundTransitioning = true;
                nextBackground = Properties.Resources.download__1_; // sua nova imagem de fundo
                transitionAlpha = 0f;
            }

            if (isBackgroundTransitioning)
            {
                transitionAlpha += 0.02f; // velocidade da transição
                if (transitionAlpha >= 1f)
                {
                    transitionAlpha = 1f;
                    isBackgroundTransitioning = false;
                    this.BackgroundImage = nextBackground;
                }

                // cria Bitmap temporário para desenhar fade
                Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    if (this.BackgroundImage != null)
                        g.DrawImage(this.BackgroundImage, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                    ColorMatrix cm = new ColorMatrix();
                    cm.Matrix33 = transitionAlpha;
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetColorMatrix(cm);

                    g.DrawImage(nextBackground, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),
                                0, 0, nextBackground.Width, nextBackground.Height, GraphicsUnit.Pixel, ia);
                }

                this.BackgroundImage = bmp;
            }

            // gravidade
            velocityY += gravity * 0.15f;
            player.Top += (int)velocityY;

            if (player.Top < 0)
            {
                player.Top = 0;
                velocityY = 0;
            }
            if (player.Top + player.Height > this.ClientSize.Height)
            {
                player.Top = this.ClientSize.Height - player.Height;
                velocityY = 0;
            }

            // UFO
            ufo.Left -= UFOspeed;
            if (ufo.Left + ufo.Width < 0)
            {
                ChangeUFO();
            }

            // pilares (só se ativos)
            if (pilaresAtivos)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "pillar")
                    {
                        x.Left -= speed;
                        if (x.Left < -200)
                        {
                            x.Left = this.ClientSize.Width + rand.Next(100, 300);
                            barriersPassed++;
                        }

                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            GameOver();
                        }
                    }
                }
            }

            // balas (não atravessam pilares)
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    bool removeBullet = false;

                    // colisão com pilares
                    foreach (Control pillar in this.Controls)
                    {
                        if (pillar is PictureBox && (string)pillar.Tag == "pillar")
                        {
                            if (x.Bounds.IntersectsWith(pillar.Bounds))
                            {
                                removeBullet = true;
                                break;
                            }
                        }
                    }

                    if (removeBullet)
                    {
                        RemoveBullet((PictureBox)x);
                        continue;
                    }

                    // movimento da bala
                    x.Left += 25;

                    // remove se sair da tela
                    if (x.Left > this.ClientSize.Width)
                    {
                        RemoveBullet((PictureBox)x);
                    }
                    else if (ufo.Bounds.IntersectsWith(x.Bounds))
                    {
                        RemoveBullet((PictureBox)x);
                        destructions++;
                        ChangeUFO();
                    }
                }
            }

            if (player.Bounds.IntersectsWith(ufo.Bounds))
            {
                GameOver();
            }

            if (destructions > 10)
            {
                speed = 12;
                UFOspeed = 18;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                velocityY = -10f; // pulo
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gameOver)
            {
                RestartGame();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MakeBullet();
            }
        }

        private void MakeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.BackColor = Color.Maroon;
            bullet.Height = 5;
            bullet.Width = 10;
            bullet.Left = player.Left + player.Width;
            bullet.Top = player.Top + player.Height / 2;
            bullet.Tag = "bullet";
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void RemoveBullet(PictureBox bullet)
        {
            this.Controls.Remove(bullet);
            bullet.Dispose();
        }

        private void ChangeUFO()
        {
            if (index > 3) index = 1;
            else index++;

            switch (index)
            {
                case 1: ufo.Image = Properties.Resources.alien1; break;
                case 2: ufo.Image = Properties.Resources.alien2; break;
                case 3: ufo.Image = Properties.Resources.alien3; break;
            }

            ufo.Left = 1000;
            ufo.Top = rand.Next(20, this.ClientSize.Height - ufo.Height);
        }

        private void GameOver()
        {
            GameTimer.Stop();

            lblGameOver.Text = $"GAME OVER!\nDestructions: {destructions}\nScore: {barriersPassed}\n\nPress Enter to Restart";
            lblGameOver.Visible = true;
            lblGameOver.BringToFront();

            txtScore.Text = $"Destructions: {destructions}";
            txtScoreRight.Text = $"Score: {barriersPassed}";

            gameOver = true;
            CenterGameOverLabel();
        }

        private void RestartGame()
        {
            gameOver = false;
            destructions = 0;
            barriersPassed = 0;
            speed = 8;
            UFOspeed = 10;
            velocityY = 0;
            pilaresAtivos = false;

            txtScore.Text = $"Destructions: {destructions}";
            txtScoreRight.Text = $"Score: {barriersPassed}";

            ChangeUFO();
            player.Top = 119;

            // pilares fora da tela à direita
            pillar1.Left = this.ClientSize.Width + 100;
            pillar2.Left = this.ClientSize.Width + 400;

            lblGameOver.Text = "GAME OVER!\nPress Enter to Restart";
            lblGameOver.Visible = false;

            GameTimer.Start();

            // Timer para ativar pilares após 1,3 segundos
            Timer delayTimer = new Timer();
            delayTimer.Interval = 1300;
            delayTimer.Tick += (s, e) =>
            {
                pilaresAtivos = true;
                delayTimer.Stop();
            };
            delayTimer.Start();
        }

        private void CenterGameOverLabel()
        {
            if (lblGameOver != null)
            {
                lblGameOver.Left = (this.ClientSize.Width - lblGameOver.Width) / 2;
                lblGameOver.Top = (this.ClientSize.Height - lblGameOver.Height) / 2;
            }
        }
    }
}
