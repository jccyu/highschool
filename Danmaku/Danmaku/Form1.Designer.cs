namespace Danmaku
{
    partial class frm
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
            this.ptb = new System.Windows.Forms.PictureBox();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.lblHP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb
            // 
            this.ptb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ptb.Location = new System.Drawing.Point(12, 12);
            this.ptb.Name = "ptb";
            this.ptb.Size = new System.Drawing.Size(300, 480);
            this.ptb.TabIndex = 0;
            this.ptb.TabStop = false;
            this.ptb.Paint += new System.Windows.Forms.PaintEventHandler(this.ptb_Paint);
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 40;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // lblHP
            // 
            this.lblHP.AutoSize = true;
            this.lblHP.Location = new System.Drawing.Point(319, 13);
            this.lblHP.Name = "lblHP";
            this.lblHP.Size = new System.Drawing.Size(78, 13);
            this.lblHP.TabIndex = 1;
            this.lblHP.Text = "Boss HP: 2000";
            // 
            // frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 501);
            this.Controls.Add(this.lblHP);
            this.Controls.Add(this.ptb);
            this.Name = "frm";
            this.Text = "Danmaku";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ptb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Label lblHP;
    }
}

