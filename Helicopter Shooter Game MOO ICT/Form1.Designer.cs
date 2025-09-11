namespace Helicopter_Shooter_Game_MOO_ICT
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
            pillar1 = new PictureBox();
            pillar2 = new PictureBox();
            player = new PictureBox();
            ufo = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            txtScore = new Label();
            ((System.ComponentModel.ISupportInitialize)pillar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pillar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ufo).BeginInit();
            SuspendLayout();
            // 
            // pillar1
            // 
            pillar1.Image = Properties.Resources.pillar;
            pillar1.Location = new Point(676, -8);
            pillar1.Margin = new Padding(4, 3, 4, 3);
            pillar1.Name = "pillar1";
            pillar1.Size = new Size(71, 232);
            pillar1.SizeMode = PictureBoxSizeMode.StretchImage;
            pillar1.TabIndex = 0;
            pillar1.TabStop = false;
            pillar1.Tag = "pillar";
            // 
            // pillar2
            // 
            pillar2.Image = Properties.Resources.pillar;
            pillar2.Location = new Point(295, 337);
            pillar2.Margin = new Padding(4, 3, 4, 3);
            pillar2.Name = "pillar2";
            pillar2.Size = new Size(71, 232);
            pillar2.SizeMode = PictureBoxSizeMode.StretchImage;
            pillar2.TabIndex = 0;
            pillar2.TabStop = false;
            pillar2.Tag = "pillar";
            // 
            // player
            // 
            player.Image = Properties.Resources.Halicopter;
            player.Location = new Point(119, 137);
            player.Margin = new Padding(4, 3, 4, 3);
            player.Name = "player";
            player.Size = new Size(100, 54);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 1;
            player.TabStop = false;
            // 
            // ufo
            // 
            ufo.Image = Properties.Resources.alien1;
            ufo.Location = new Point(954, 299);
            ufo.Margin = new Padding(4, 3, 4, 3);
            ufo.Name = "ufo";
            ufo.Size = new Size(68, 72);
            ufo.SizeMode = PictureBoxSizeMode.AutoSize;
            ufo.TabIndex = 2;
            ufo.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += MainTimerEvent;
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.ForeColor = Color.White;
            txtScore.Location = new Point(15, 15);
            txtScore.Margin = new Padding(4, 0, 4, 0);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(88, 24);
            txtScore.TabIndex = 3;
            txtScore.Text = "Score: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            BackgroundImage = Properties.Resources.download;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1079, 552);
            Controls.Add(txtScore);
            Controls.Add(ufo);
            Controls.Add(player);
            Controls.Add(pillar2);
            Controls.Add(pillar1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Helicopter Shooter Game MOO ICT";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)pillar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pillar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)ufo).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pillar1;
        private System.Windows.Forms.PictureBox pillar2;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox ufo;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label txtScore;
    }
}
