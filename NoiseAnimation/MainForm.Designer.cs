
namespace NoiseAnimation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.noise = new System.Windows.Forms.PictureBox();
            this.buttond = new System.Windows.Forms.Button();
            this.buttonp = new System.Windows.Forms.Button();
            this.timerUpt = new System.Windows.Forms.Timer(this.components);
            this.tBIterationCount = new System.Windows.Forms.TextBox();
            this.bResetSizeNoise = new System.Windows.Forms.Button();
            this.tBSizeNoise = new System.Windows.Forms.TextBox();
            this.timerUptper = new System.Windows.Forms.Timer(this.components);
            this.cBTurnAnimation = new System.Windows.Forms.CheckBox();
            this.lCountIteration = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBSeedNoise = new System.Windows.Forms.TextBox();
            this.lSeedNoise = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.noise)).BeginInit();
            this.SuspendLayout();
            // 
            // noise
            // 
            this.noise.Location = new System.Drawing.Point(12, 12);
            this.noise.Name = "noise";
            this.noise.Size = new System.Drawing.Size(512, 512);
            this.noise.TabIndex = 0;
            this.noise.TabStop = false;
            this.noise.DoubleClick += new System.EventHandler(this.noise_DoubleClick);
            // 
            // buttond
            // 
            this.buttond.Location = new System.Drawing.Point(751, 78);
            this.buttond.Name = "buttond";
            this.buttond.Size = new System.Drawing.Size(130, 46);
            this.buttond.TabIndex = 1;
            this.buttond.Text = "DS";
            this.buttond.UseVisualStyleBackColor = true;
            this.buttond.Click += new System.EventHandler(this.buttond_Click);
            // 
            // buttonp
            // 
            this.buttonp.Location = new System.Drawing.Point(751, 192);
            this.buttonp.Name = "buttonp";
            this.buttonp.Size = new System.Drawing.Size(137, 49);
            this.buttonp.TabIndex = 2;
            this.buttonp.Text = "Per";
            this.buttonp.UseVisualStyleBackColor = true;
            this.buttonp.Click += new System.EventHandler(this.buttonp_Click);
            // 
            // timerUpt
            // 
            this.timerUpt.Tick += new System.EventHandler(this.timerUpt_Tick);
            // 
            // tBIterationCount
            // 
            this.tBIterationCount.Location = new System.Drawing.Point(716, 435);
            this.tBIterationCount.Multiline = true;
            this.tBIterationCount.Name = "tBIterationCount";
            this.tBIterationCount.Size = new System.Drawing.Size(209, 32);
            this.tBIterationCount.TabIndex = 3;
            // 
            // bResetSizeNoise
            // 
            this.bResetSizeNoise.Location = new System.Drawing.Point(809, 318);
            this.bResetSizeNoise.Name = "bResetSizeNoise";
            this.bResetSizeNoise.Size = new System.Drawing.Size(116, 24);
            this.bResetSizeNoise.TabIndex = 5;
            this.bResetSizeNoise.Text = "Пременить размер";
            this.bResetSizeNoise.UseVisualStyleBackColor = true;
            this.bResetSizeNoise.Click += new System.EventHandler(this.button1_Click);
            // 
            // tBSizeNoise
            // 
            this.tBSizeNoise.Location = new System.Drawing.Point(751, 321);
            this.tBSizeNoise.Name = "tBSizeNoise";
            this.tBSizeNoise.Size = new System.Drawing.Size(52, 20);
            this.tBSizeNoise.TabIndex = 7;
            this.tBSizeNoise.Text = "512";
            // 
            // timerUptper
            // 
            this.timerUptper.Interval = 1;
            this.timerUptper.Tick += new System.EventHandler(this.timerUptper_Tick);
            // 
            // cBTurnAnimation
            // 
            this.cBTurnAnimation.AutoSize = true;
            this.cBTurnAnimation.Checked = true;
            this.cBTurnAnimation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBTurnAnimation.Location = new System.Drawing.Point(762, 144);
            this.cBTurnAnimation.Name = "cBTurnAnimation";
            this.cBTurnAnimation.Size = new System.Drawing.Size(77, 17);
            this.cBTurnAnimation.TabIndex = 8;
            this.cBTurnAnimation.Text = "Анимация";
            this.cBTurnAnimation.UseVisualStyleBackColor = true;
            this.cBTurnAnimation.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lCountIteration
            // 
            this.lCountIteration.AutoSize = true;
            this.lCountIteration.Location = new System.Drawing.Point(713, 410);
            this.lCountIteration.Name = "lCountIteration";
            this.lCountIteration.Size = new System.Drawing.Size(156, 13);
            this.lCountIteration.TabIndex = 9;
            this.lCountIteration.Text = "Количество итераций метода";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(748, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Размер Шума";
            // 
            // tBSeedNoise
            // 
            this.tBSeedNoise.Location = new System.Drawing.Point(614, 92);
            this.tBSeedNoise.Name = "tBSeedNoise";
            this.tBSeedNoise.Size = new System.Drawing.Size(100, 20);
            this.tBSeedNoise.TabIndex = 11;
            this.tBSeedNoise.Text = "43";
            // 
            // lSeedNoise
            // 
            this.lSeedNoise.AutoSize = true;
            this.lSeedNoise.Location = new System.Drawing.Point(611, 66);
            this.lSeedNoise.Name = "lSeedNoise";
            this.lSeedNoise.Size = new System.Drawing.Size(77, 13);
            this.lSeedNoise.TabIndex = 12;
            this.lSeedNoise.Text = "Сид для шума";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 626);
            this.Controls.Add(this.lSeedNoise);
            this.Controls.Add(this.tBSeedNoise);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lCountIteration);
            this.Controls.Add(this.cBTurnAnimation);
            this.Controls.Add(this.tBSizeNoise);
            this.Controls.Add(this.bResetSizeNoise);
            this.Controls.Add(this.tBIterationCount);
            this.Controls.Add(this.buttonp);
            this.Controls.Add(this.buttond);
            this.Controls.Add(this.noise);
            this.Name = "MainForm";
            this.Text = "NoiseAnimation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.noise)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox noise;
        private System.Windows.Forms.Button buttond;
        private System.Windows.Forms.Button buttonp;
        private System.Windows.Forms.Timer timerUpt;
        private System.Windows.Forms.TextBox tBIterationCount;
        private System.Windows.Forms.Button bResetSizeNoise;
        private System.Windows.Forms.TextBox tBSizeNoise;
        private System.Windows.Forms.Timer timerUptper;
        private System.Windows.Forms.CheckBox cBTurnAnimation;
        private System.Windows.Forms.Label lCountIteration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBSeedNoise;
        private System.Windows.Forms.Label lSeedNoise;
    }
}

