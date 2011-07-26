namespace OnlineBalanceBoardScale
{
    partial class Form1
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
            this.bateria = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.screen = new DmitryBrant.CustomControls.SevenSegmentArray();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bateria
            // 
            this.bateria.Location = new System.Drawing.Point(201, 232);
            this.bateria.MarqueeAnimationSpeed = 10;
            this.bateria.Maximum = 10;
            this.bateria.Name = "bateria";
            this.bateria.Size = new System.Drawing.Size(100, 10);
            this.bateria.TabIndex = 0;
            this.bateria.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::OnlineBalanceBoardScale.Imagenes.Balanza;
            this.pictureBox1.InitialImage = global::OnlineBalanceBoardScale.Imagenes.Balanza;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(503, 312);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // screen
            // 
            this.screen.ArrayCount = 4;
            this.screen.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(225)))), ((int)(((byte)(206)))));
            this.screen.ColorDark = System.Drawing.Color.Silver;
            this.screen.ColorLight = System.Drawing.Color.Black;
            this.screen.DecimalShow = true;
            this.screen.ElementPadding = new System.Windows.Forms.Padding(4);
            this.screen.ElementWidth = 10;
            this.screen.ItalicFactor = 0F;
            this.screen.Location = new System.Drawing.Point(201, 47);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(95, 40);
            this.screen.TabIndex = 6;
            this.screen.TabStop = false;
            this.screen.Value = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Purple;
            this.ClientSize = new System.Drawing.Size(503, 311);
            this.Controls.Add(this.screen);
            this.Controls.Add(this.bateria);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Purple;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar bateria;
        private DmitryBrant.CustomControls.SevenSegmentArray screen;

    }
}

