using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Football_Pentalty_Shootout_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        List<string> KeeperPosition = new List<string> { "left", "right", "top", "topLeft", "topRight" };
        List<PictureBox> goalTarget;
        int ballX = 0;
        int ballY = 0;
        int goal = 0;
        int miss = 0;
        string state;             // posição do goleiro
        string playerTarget;      // onde a bola vai
        bool aimSet = false;

        // alternância
        bool isGoalkeeperTurn = false; // false = você chuta; true = você defende
        string keeperChoice = "";      // sua escolha quando for goleiro

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            goalTarget = new List<PictureBox> { left, right, top, topLeft, topRight };
        }

        private void SetGoalTargetEvent(object sender, EventArgs e)
        {
            var senderObject = (PictureBox)sender;

            // turno de chute seu
            if (!isGoalkeeperTurn)
            {
                if (aimSet) return;

                BallTimer.Start();

                // goleiro sempre escolhe posição aleatória
                ChangeGoalKeeperImage();

                senderObject.BackColor = Color.Beige;

                switch (senderObject.Tag.ToString())
                {
                    case "topRight": ballX = -7; ballY = 15; break;
                    case "right": ballX = -11; ballY = 15; break;
                    case "top": ballX = 0; ballY = 20; break;
                    case "topLeft": ballX = 8; ballY = 15; break;
                    case "left": ballX = 7; ballY = 8; break;
                }

                playerTarget = senderObject.Tag.ToString();
                aimSet = true;

                CheckScore();

                // próxima rodada você será o goleiro
                isGoalkeeperTurn = true;
                keeperChoice = "";
            }
            else // turno de goleiro
            {
                // você escolhe onde defender
                keeperChoice = senderObject.Tag.ToString();
                state = keeperChoice; // define posição do goleiro
                ChangeGoalKeeperImageByState(state); // goleiro vai para sua escolha

                // sorteia chute aleatório para o CPU
                int randIndex = random.Next(goalTarget.Count);
                string cpuShot = goalTarget[randIndex].Tag.ToString();
                playerTarget = cpuShot;

                switch (cpuShot)
                {
                    case "topRight": ballX = -7; ballY = 15; break;
                    case "right": ballX = -11; ballY = 15; break;
                    case "top": ballX = 0; ballY = 20; break;
                    case "topLeft": ballX = 8; ballY = 15; break;
                    case "left": ballX = 7; ballY = 8; break;
                }

                // começa a bola
                aimSet = true;
                BallTimer.Start();

                CheckScore();

                // volta pro próximo turno você ser chutador
                isGoalkeeperTurn = false;
            }
        }

        private void KeeperTimerEvent(object sender, EventArgs e)
        {
            switch (state)
            {
                case "left":
                    goalKeeper.Left -= 6;
                    goalKeeper.Top = 204;
                    break;
                case "right":
                    goalKeeper.Left += 6;
                    goalKeeper.Top = 204;
                    break;
                case "top":
                    goalKeeper.Top -= 6;
                    break;
                case "topLeft":
                    goalKeeper.Left -= 6;
                    goalKeeper.Top -= 3;
                    break;
                case "topRight":
                    goalKeeper.Left += 6;
                    goalKeeper.Top -= 3;
                    break;
            }

            foreach (PictureBox x in goalTarget)
            {
                if (goalKeeper.Bounds.IntersectsWith(x.Bounds))
                {
                    KeeperTimer.Stop();
                    goalKeeper.Location = new Point(418, 169);
                    goalKeeper.Image = Properties.Resources.stand_small;
                }
            }
        }

        private void BallTimerEvent(object sender, EventArgs e)
        {
            football.Left -= ballX;
            football.Top -= ballY;

            foreach (PictureBox x in goalTarget)
            {
                if (football.Bounds.IntersectsWith(x.Bounds))
                {
                    football.Location = new Point(430, 500);
                    ballX = 0;
                    ballY = 0;
                    aimSet = false;
                    BallTimer.Stop();
                }
            }
        }

        private void CheckScore()
        {
            if (state == playerTarget)
            {
                miss++;
                lblMissed.Text = "Missed: " + miss;
            }
            else
            {
                goal++;
                lblScore.Text = "Scored: " + goal;
            }
        }

        private void ChangeGoalKeeperImage()
        {
            KeeperTimer.Start();
            int i = random.Next(0, KeeperPosition.Count);
            state = KeeperPosition[i];

            switch (i)
            {
                case 0:
                    goalKeeper.Image = Properties.Resources.left_save_small;
                    break;
                case 1:
                    goalKeeper.Image = Properties.Resources.right_save_small;
                    break;
                case 2:
                    goalKeeper.Image = Properties.Resources.top_save_small;
                    break;
                case 3:
                    goalKeeper.Image = Properties.Resources.top_left_save_small;
                    break;
                case 4:
                    goalKeeper.Image = Properties.Resources.top_right_save_small;
                    break;
            }
        }

        private void ChangeGoalKeeperImageByState(string pos)
        {
            KeeperTimer.Start();
            state = pos;

            switch (pos)
            {
                case "left":
                    goalKeeper.Image = Properties.Resources.left_save_small; break;
                case "right":
                    goalKeeper.Image = Properties.Resources.right_save_small; break;
                case "top":
                    goalKeeper.Image = Properties.Resources.top_save_small; break;
                case "topLeft":
                    goalKeeper.Image = Properties.Resources.top_left_save_small; break;
                case "topRight":
                    goalKeeper.Image = Properties.Resources.top_right_save_small; break;
            }
        }
    }
}
