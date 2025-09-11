namespace Football_Pentalty_Shootout_Game_MOO_ICT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblScore = new Label();
            lblMissed = new Label();
            left = new PictureBox();
            right = new PictureBox();
            topLeft = new PictureBox();
            top = new PictureBox();
            topRight = new PictureBox();
            goalKeeper = new PictureBox();
            football = new PictureBox();
            KeeperTimer = new System.Windows.Forms.Timer(components);
            BallTimer = new System.Windows.Forms.Timer(components);
            chkGoal1 = new CheckBox();
            chkGoal2 = new CheckBox();
            chkGoal3 = new CheckBox();
            chkGoal4 = new CheckBox();
            chkGoal5 = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            chkGoal10 = new CheckBox();
            chkGoal9 = new CheckBox();
            chkGoal8 = new CheckBox();
            chkGoal7 = new CheckBox();
            chkGoal6 = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)left).BeginInit();
            ((System.ComponentModel.ISupportInitialize)right).BeginInit();
            ((System.ComponentModel.ISupportInitialize)topLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)top).BeginInit();
            ((System.ComponentModel.ISupportInitialize)topRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)goalKeeper).BeginInit();
            ((System.ComponentModel.ISupportInitialize)football).BeginInit();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.Transparent;
            lblScore.Location = new Point(32, 95);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(103, 37);
            lblScore.TabIndex = 0;
            lblScore.Text = "Gols: 0";
            // 
            // lblMissed
            // 
            lblMissed.AutoSize = true;
            lblMissed.BackColor = Color.Transparent;
            lblMissed.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold);
            lblMissed.ForeColor = Color.White;
            lblMissed.Location = new Point(743, 144);
            lblMissed.Name = "lblMissed";
            lblMissed.Size = new Size(156, 40);
            lblMissed.TabIndex = 1;
            lblMissed.Text = "Defesas: 0";
            // 
            // left
            // 
            left.BackColor = Color.Yellow;
            left.Image = Properties.Resources.target;
            left.Location = new Point(201, 238);
            left.Name = "left";
            left.Size = new Size(40, 40);
            left.SizeMode = PictureBoxSizeMode.StretchImage;
            left.TabIndex = 2;
            left.TabStop = false;
            left.Tag = "left";
            left.Click += SetGoalTargetEvent;
            // 
            // right
            // 
            right.BackColor = Color.Yellow;
            right.Image = Properties.Resources.target;
            right.Location = new Point(675, 238);
            right.Name = "right";
            right.Size = new Size(40, 40);
            right.SizeMode = PictureBoxSizeMode.StretchImage;
            right.TabIndex = 3;
            right.TabStop = false;
            right.Tag = "right";
            right.Click += SetGoalTargetEvent;
            // 
            // topLeft
            // 
            topLeft.BackColor = Color.Yellow;
            topLeft.Image = Properties.Resources.target;
            topLeft.Location = new Point(201, 78);
            topLeft.Name = "topLeft";
            topLeft.Size = new Size(40, 40);
            topLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            topLeft.TabIndex = 4;
            topLeft.TabStop = false;
            topLeft.Tag = "topLeft";
            topLeft.Click += SetGoalTargetEvent;
            // 
            // top
            // 
            top.BackColor = Color.Yellow;
            top.Image = Properties.Resources.target;
            top.Location = new Point(437, 76);
            top.Name = "top";
            top.Size = new Size(40, 40);
            top.SizeMode = PictureBoxSizeMode.StretchImage;
            top.TabIndex = 5;
            top.TabStop = false;
            top.Tag = "top";
            top.Click += SetGoalTargetEvent;
            // 
            // topRight
            // 
            topRight.BackColor = Color.Yellow;
            topRight.Image = Properties.Resources.target;
            topRight.Location = new Point(675, 76);
            topRight.Name = "topRight";
            topRight.Size = new Size(40, 40);
            topRight.SizeMode = PictureBoxSizeMode.StretchImage;
            topRight.TabIndex = 6;
            topRight.TabStop = false;
            topRight.Tag = "topRight";
            topRight.Click += SetGoalTargetEvent;
            // 
            // goalKeeper
            // 
            goalKeeper.BackColor = Color.Transparent;
            goalKeeper.Image = Properties.Resources.stand_small;
            goalKeeper.Location = new Point(418, 169);
            goalKeeper.Name = "goalKeeper";
            goalKeeper.Size = new Size(82, 126);
            goalKeeper.SizeMode = PictureBoxSizeMode.AutoSize;
            goalKeeper.TabIndex = 7;
            goalKeeper.TabStop = false;
            // 
            // football
            // 
            football.BackColor = Color.Transparent;
            football.Image = Properties.Resources.football;
            football.Location = new Point(430, 500);
            football.Name = "football";
            football.Size = new Size(50, 51);
            football.SizeMode = PictureBoxSizeMode.AutoSize;
            football.TabIndex = 8;
            football.TabStop = false;
            // 
            // KeeperTimer
            // 
            KeeperTimer.Interval = 20;
            KeeperTimer.Tick += KeeperTimerEvent;
            // 
            // BallTimer
            // 
            BallTimer.Interval = 20;
            BallTimer.Tick += BallTimerEvent;
            // 
            // chkGoal1
            // 
            chkGoal1.AutoSize = true;
            chkGoal1.Location = new Point(32, 62);
            chkGoal1.Name = "chkGoal1";
            chkGoal1.Size = new Size(15, 14);
            chkGoal1.TabIndex = 9;
            chkGoal1.UseVisualStyleBackColor = true;
            // 
            // chkGoal2
            // 
            chkGoal2.AutoSize = true;
            chkGoal2.Location = new Point(53, 62);
            chkGoal2.Name = "chkGoal2";
            chkGoal2.Size = new Size(15, 14);
            chkGoal2.TabIndex = 10;
            chkGoal2.UseVisualStyleBackColor = true;
            // 
            // chkGoal3
            // 
            chkGoal3.AutoSize = true;
            chkGoal3.Location = new Point(74, 62);
            chkGoal3.Name = "chkGoal3";
            chkGoal3.Size = new Size(15, 14);
            chkGoal3.TabIndex = 11;
            chkGoal3.UseVisualStyleBackColor = true;
            // 
            // chkGoal4
            // 
            chkGoal4.AutoSize = true;
            chkGoal4.Location = new Point(95, 62);
            chkGoal4.Name = "chkGoal4";
            chkGoal4.Size = new Size(15, 14);
            chkGoal4.TabIndex = 12;
            chkGoal4.UseVisualStyleBackColor = true;
            // 
            // chkGoal5
            // 
            chkGoal5.AutoSize = true;
            chkGoal5.Location = new Point(116, 62);
            chkGoal5.Name = "chkGoal5";
            chkGoal5.Size = new Size(15, 14);
            chkGoal5.TabIndex = 13;
            chkGoal5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(8, 144);
            label1.Name = "label1";
            label1.Size = new Size(146, 37);
            label1.TabIndex = 14;
            label1.Text = "Defesas: 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(768, 95);
            label2.Name = "label2";
            label2.Size = new Size(103, 37);
            label2.TabIndex = 15;
            label2.Text = "Gols: 0";
            // 
            // chkGoal10
            // 
            chkGoal10.AutoSize = true;
            chkGoal10.Location = new Point(855, 62);
            chkGoal10.Name = "chkGoal10";
            chkGoal10.Size = new Size(15, 14);
            chkGoal10.TabIndex = 20;
            chkGoal10.UseVisualStyleBackColor = true;
            // 
            // chkGoal9
            // 
            chkGoal9.AutoSize = true;
            chkGoal9.Location = new Point(834, 62);
            chkGoal9.Name = "chkGoal9";
            chkGoal9.Size = new Size(15, 14);
            chkGoal9.TabIndex = 19;
            chkGoal9.UseVisualStyleBackColor = true;
            // 
            // chkGoal8
            // 
            chkGoal8.AutoSize = true;
            chkGoal8.Location = new Point(813, 62);
            chkGoal8.Name = "chkGoal8";
            chkGoal8.Size = new Size(15, 14);
            chkGoal8.TabIndex = 18;
            chkGoal8.UseVisualStyleBackColor = true;
            // 
            // chkGoal7
            // 
            chkGoal7.AutoSize = true;
            chkGoal7.Location = new Point(792, 62);
            chkGoal7.Name = "chkGoal7";
            chkGoal7.Size = new Size(15, 14);
            chkGoal7.TabIndex = 17;
            chkGoal7.UseVisualStyleBackColor = true;
            // 
            // chkGoal6
            // 
            chkGoal6.AutoSize = true;
            chkGoal6.Location = new Point(771, 62);
            chkGoal6.Name = "chkGoal6";
            chkGoal6.Size = new Size(15, 14);
            chkGoal6.TabIndex = 16;
            chkGoal6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.HotTrack;
            label3.Location = new Point(23, 9);
            label3.Name = "label3";
            label3.Size = new Size(122, 37);
            label3.TabIndex = 21;
            label3.Text = "Time EU";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(749, 9);
            label4.Name = "label4";
            label4.Size = new Size(142, 37);
            label4.TabIndex = 22;
            label4.Text = "Time CPU";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(899, 678);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(chkGoal10);
            Controls.Add(chkGoal9);
            Controls.Add(chkGoal8);
            Controls.Add(chkGoal7);
            Controls.Add(chkGoal6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chkGoal5);
            Controls.Add(chkGoal4);
            Controls.Add(chkGoal3);
            Controls.Add(chkGoal2);
            Controls.Add(chkGoal1);
            Controls.Add(football);
            Controls.Add(goalKeeper);
            Controls.Add(topRight);
            Controls.Add(top);
            Controls.Add(topLeft);
            Controls.Add(right);
            Controls.Add(left);
            Controls.Add(lblMissed);
            Controls.Add(lblScore);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Football Penalty Shootout Game MOOICT";
            ((System.ComponentModel.ISupportInitialize)left).EndInit();
            ((System.ComponentModel.ISupportInitialize)right).EndInit();
            ((System.ComponentModel.ISupportInitialize)topLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)top).EndInit();
            ((System.ComponentModel.ISupportInitialize)topRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)goalKeeper).EndInit();
            ((System.ComponentModel.ISupportInitialize)football).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label lblScore;
        private Label lblMissed;
        private PictureBox left;
        private PictureBox right;
        private PictureBox topLeft;
        private PictureBox top;
        private PictureBox topRight;
        private PictureBox goalKeeper;
        private PictureBox football;
        private System.Windows.Forms.Timer KeeperTimer;
        private System.Windows.Forms.Timer BallTimer;
        private CheckBox chkGoal1;
        private CheckBox chkGoal2;
        private CheckBox chkGoal3;
        private CheckBox chkGoal4;
        private CheckBox chkGoal5;
        private Label label1;
        private Label label2;
        private CheckBox chkGoal10;
        private CheckBox chkGoal9;
        private CheckBox chkGoal8;
        private CheckBox chkGoal7;
        private CheckBox chkGoal6;
        private Label label3;
        private Label label4;
    }
}