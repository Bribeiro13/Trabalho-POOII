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

        // Gols
        int goal1 = 0;
        int goal2 = 0;

        // Defesas
        int defense1 = 0;
        int defense2 = 0;

        string state;
        string playerTarget;
        bool aimSet = false;

        bool isGoalkeeperTurn = false;
        string keeperChoice = "";

        Random random = new Random();

        Label lblTurn;

        List<CheckBox> firstSet = new List<CheckBox>();
        List<CheckBox> secondSet = new List<CheckBox>();
        bool useSecondSet = false;
        bool firstPlayAfterReset = false; // evita inverter turno logo após reset

        public Form1()
        {
            InitializeComponent();

            goalTarget = new List<PictureBox> { left, right, top, topLeft, topRight };

            // Label do turno
            lblTurn = new Label();
            lblTurn.Name = "lblTurn";
            lblTurn.Text = "CHUTE!";
            lblTurn.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTurn.ForeColor = Color.Red;
            lblTurn.BackColor = Color.Transparent;
            lblTurn.AutoSize = true;
            this.Controls.Add(lblTurn);

            firstSet = new List<CheckBox> { chkGoal1, chkGoal2, chkGoal3, chkGoal4, chkGoal5 };
            secondSet = new List<CheckBox> { chkGoal6, chkGoal7, chkGoal8, chkGoal9, chkGoal10 };

            useSecondSet = false;
            UpdateTurnLabel();
        }

        private void UpdateTurnLabel()
        {
            lblTurn.Text = isGoalkeeperTurn ? "DEFENDA!" : "CHUTE!";

            // Centraliza no meio da tela
            int centerX = (this.ClientSize.Width - lblTurn.Width) / 2;
            int centerY = (this.ClientSize.Height - lblTurn.Height) / 2;

            lblTurn.Location = new Point(centerX, centerY);
        }


        private void SetGoalTargetEvent(object sender, EventArgs e)
        {
            var senderObject = (PictureBox)sender;

            if (!isGoalkeeperTurn) // turno de chute
            {
                if (aimSet) return;

                BallTimer.Start();
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
            }
            else // turno de defesa
            {
                keeperChoice = senderObject.Tag.ToString();
                state = keeperChoice;
                ChangeGoalKeeperImageByState(state);

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

                aimSet = true;
                BallTimer.Start();
            }

            UpdateTurnLabel();
        }

        private void KeeperTimerEvent(object sender, EventArgs e)
        {
            switch (state)
            {
                case "left": goalKeeper.Left -= 6; goalKeeper.Top = 204; break;
                case "right": goalKeeper.Left += 6; goalKeeper.Top = 204; break;
                case "top": goalKeeper.Top -= 6; break;
                case "topLeft": goalKeeper.Left -= 6; goalKeeper.Top -= 3; break;
                case "topRight": goalKeeper.Left += 6; goalKeeper.Top -= 3; break;
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

                    CheckScore();

                    // Alternância do turno corrigida
                    if (firstPlayAfterReset)
                    {
                        firstPlayAfterReset = false;
                    }
                    else
                    {
                        isGoalkeeperTurn = !isGoalkeeperTurn;
                    }

                    UpdateTurnLabel();
                }
            }
        }

        private bool IsSetComplete(List<CheckBox> set)
        {
            foreach (var cb in set)
                if (!cb.Checked) return false;
            return true;
        }

        private void CheckScore()
        {
            if (state == playerTarget) // defesa
            {
                // QUEM ESTÁ DEFENDENDO AGORA?
                if (useSecondSet) // conjunto 2 defendendo
                {
                    defense2++;
                    lblMissed.Text = "Defesas: " + defense2;
                }
                else // conjunto 1 defendendo
                {
                    defense1++;
                    label1.Text = "Defesas: " + defense1;
                }

                useSecondSet = !useSecondSet; // alterna grupo para próxima rodada
            }
            else // gol
            {
                List<CheckBox> setToUse = useSecondSet ? secondSet : firstSet;

                foreach (var cb in setToUse)
                    if (!cb.Checked) { cb.Checked = true; break; }

                if (useSecondSet) // chutando conjunto 2
                {
                    goal2++;
                    label2.Text = "Gols: " + goal2;
                }
                else // chutando conjunto 1
                {
                    goal1++;
                    lblScore.Text = "Gols: " + goal1;
                }

                useSecondSet = !useSecondSet; // alterna grupo para próxima rodada

                // verifica vitória
                if (IsSetComplete(firstSet))
                {
                    MessageBox.Show("Conjunto 1 venceu!");
                    ResetGame();
                }
                else if (IsSetComplete(secondSet))
                {
                    MessageBox.Show("Conjunto 2 venceu!");
                    ResetGame();
                }
            }
        }

        private void ResetGame()
        {
            foreach (var cb in firstSet) cb.Checked = false;
            foreach (var cb in secondSet) cb.Checked = false;

            goal1 = 0; goal2 = 0;
            defense1 = 0; defense2 = 0;

            lblScore.Text = "Gols: 0";
            label2.Text = "Gols: 0";
            label1.Text = "Defesas: 0";
            lblMissed.Text = "Defesas: 0";

            useSecondSet = false;
            isGoalkeeperTurn = false;

            state = null;
            playerTarget = null;
            aimSet = false;

            firstPlayAfterReset = true; // garante que CHUTE! aparece primeiro

            UpdateTurnLabel();
        }

        private void ChangeGoalKeeperImage()
        {
            KeeperTimer.Start();
            int i = random.Next(0, KeeperPosition.Count);
            state = KeeperPosition[i];

            switch (i)
            {
                case 0: goalKeeper.Image = Properties.Resources.left_save_small; break;
                case 1: goalKeeper.Image = Properties.Resources.right_save_small; break;
                case 2: goalKeeper.Image = Properties.Resources.top_save_small; break;
                case 3: goalKeeper.Image = Properties.Resources.top_left_save_small; break;
                case 4: goalKeeper.Image = Properties.Resources.top_right_save_small; break;
            }
        }

        private void ChangeGoalKeeperImageByState(string pos)
        {
            KeeperTimer.Start();
            state = pos;

            switch (pos)
            {
                case "left": goalKeeper.Image = Properties.Resources.left_save_small; break;
                case "right": goalKeeper.Image = Properties.Resources.right_save_small; break;
                case "top": goalKeeper.Image = Properties.Resources.top_save_small; break;
                case "topLeft": goalKeeper.Image = Properties.Resources.top_left_save_small; break;
                case "topRight": goalKeeper.Image = Properties.Resources.top_right_save_small; break;
            }
        }
    }
}
