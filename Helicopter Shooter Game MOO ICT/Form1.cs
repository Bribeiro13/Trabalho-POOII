using System.Numerics;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Helicopter_Shooter_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        bool goUp, goDown, shot, gameOver;

        int destructions = 0;
        int barriersPassed = 0;

        int speed = 8;
        int UFOspeed = 10;

        Random rand = new Random();

        int playerSpeed = 7;
        int index = 0;

        private Color targetBackColor;
        private bool isTransitioning = false;
        private int transitionSteps = 30;
        private int currentStep = 0;

        private Label txtScoreRight;
        private Label lblGameOver; // Label para mostrar "Game Over" no centro

        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.LightSkyBlue;

            // Label do Score no canto superior direito
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
        }

        private void CenterGameOverLabel()
        {
            if (lblGameOver != null)
            {
                lblGameOver.Left = (this.ClientSize.Width - lblGameOver.Width) / 2;
                lblGameOver.Top = (this.ClientSize.Height - lblGameOver.Height) / 2;
            }
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = $"Destructions: {destructions}";
            txtScoreRight.Text = $"Score: {barriersPassed}";

            if (isTransitioning)
            {
                currentStep++;
                float amount = (float)currentStep / transitionSteps;
                this.BackColor = ColorLerp(this.BackColor, targetBackColor, amount);

                if (currentStep >= transitionSteps)
                {
                    this.BackColor = targetBackColor;
                    isTransitioning = false;
                }
            }

            if (goUp == true && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;
            }

            ufo.Left -= UFOspeed;

            if (ufo.Left + ufo.Width < 0)
            {
                ChangeUFO();
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "pillar")
                {
                    x.Left -= speed;

                    if (x.Left < -200)
                    {
                        x.Left = 1000;
                        barriersPassed++;
                    }

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        GameOver();
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Left += 25;

                    if (x.Left > 900)
                    {
                        RemoveBullet((PictureBox)x);
                    }
                    else
                    {
                        if (ufo.Bounds.IntersectsWith(x.Bounds))
                        {
                            RemoveBullet((PictureBox)x);
                            destructions++;
                            ChangeUFO();

                            if (destructions == 5)
                            {
                                StartBackgroundTransition(Color.Black);
                            }
                        }
                        else
                        {
                            foreach (Control pillar in this.Controls)
                            {
                                if (pillar is PictureBox && (string)pillar.Tag == "pillar")
                                {
                                    if (x.Bounds.IntersectsWith(pillar.Bounds))
                                    {
                                        RemoveBullet((PictureBox)x);
                                        break;
                                    }
                                }
                            }
                        }
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
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }

            if (e.KeyCode == Keys.Space && shot == false)
            {
                MakeBullet();
                shot = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (shot == true)
            {
                shot = false;
            }

            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            goUp = false;
            goDown = false;
            shot = false;
            gameOver = false;
            destructions = 0;
            barriersPassed = 0;
            speed = 8;
            UFOspeed = 10;

            txtScore.Text = $"Destructions: {destructions}";
            txtScoreRight.Text = $"Score: {barriersPassed}";

            ChangeUFO();

            player.Top = 119;

            pillar1.Left = 579;
            pillar2.Left = 253;

            StartBackgroundTransition(Color.LightSkyBlue);

            lblGameOver.Visible = false; // Esconde o label de Game Over ao reiniciar

            GameTimer.Start();
        }

        private void GameOver()
        {
            GameTimer.Stop();

            lblGameOver.Visible = true; // Mostra o texto Game Over no centro da tela

            txtScore.Text = $"Destructions: {destructions}";
            txtScoreRight.Text = $"Score: {barriersPassed}";

            gameOver = true;
        }

        private void RemoveBullet(PictureBox bullet)
        {
            this.Controls.Remove(bullet);
            bullet.Dispose();
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

        private void ChangeUFO()
        {
            if (index > 3)
            {
                index = 1;
            }
            else
            {
                index += 1;
            }

            switch (index)
            {
                case 1:
                    ufo.Image = Properties.Resources.alien1;
                    break;
                case 2:
                    ufo.Image = Properties.Resources.alien2;
                    break;
                case 3:
                    ufo.Image = Properties.Resources.alien3;
                    break;
            }

            ufo.Left = 1000;
            ufo.Top = rand.Next(20, this.ClientSize.Height - ufo.Height);
        }

        private Color ColorLerp(Color start, Color end, float amount)
        {
            int r = (int)(start.R + (end.R - start.R) * amount);
            int g = (int)(start.G + (end.G - start.G) * amount);
            int b = (int)(start.B + (end.B - start.B) * amount);
            return Color.FromArgb(r, g, b);
        }

        private void StartBackgroundTransition(Color newColor)
        {
            targetBackColor = newColor;
            currentStep = 0;
            isTransitioning = true;
        }
    }
}
