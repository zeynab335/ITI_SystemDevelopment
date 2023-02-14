namespace Paint
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
            this.Open = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCls = new System.Windows.Forms.Button();
            this.btnCst = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.rtx = new System.Windows.Forms.RichTextBox();
            this.saveDg = new System.Windows.Forms.SaveFileDialog();
            this.openDg = new System.Windows.Forms.OpenFileDialog();
            this.fontDg = new System.Windows.Forms.FontDialog();
            this.colorDg = new System.Windows.Forms.ColorDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(12, 12);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(182, 51);
            this.Open.TabIndex = 0;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFont.Location = new System.Drawing.Point(12, 389);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(182, 49);
            this.btnFont.TabIndex = 1;
            this.btnFont.Text = "Font";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Location = new System.Drawing.Point(316, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(201, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCls
            // 
            this.btnCls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCls.Location = new System.Drawing.Point(612, 13);
            this.btnCls.Name = "btnCls";
            this.btnCls.Size = new System.Drawing.Size(176, 50);
            this.btnCls.TabIndex = 3;
            this.btnCls.Text = "Close";
            this.btnCls.UseVisualStyleBackColor = true;
            this.btnCls.Click += new System.EventHandler(this.btnCls_Click);
            // 
            // btnCst
            // 
            this.btnCst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCst.Location = new System.Drawing.Point(612, 389);
            this.btnCst.Name = "btnCst";
            this.btnCst.Size = new System.Drawing.Size(176, 45);
            this.btnCst.TabIndex = 4;
            this.btnCst.Text = "Custom";
            this.btnCst.UseVisualStyleBackColor = true;
            this.btnCst.Click += new System.EventHandler(this.btnCst_Click);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnColor.Location = new System.Drawing.Point(316, 389);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(201, 49);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // rtx
            // 
            this.rtx.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rtx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtx.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.rtx.Location = new System.Drawing.Point(13, 83);
            this.rtx.Name = "rtx";
            this.rtx.Size = new System.Drawing.Size(775, 288);
            this.rtx.TabIndex = 6;
            this.rtx.Text = "";
            // 
            // openDg
            // 
            this.openDg.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtx);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnCst);
            this.Controls.Add(this.btnCls);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.Open);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCls;
        private System.Windows.Forms.Button btnCst;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.RichTextBox rtx;
        private System.Windows.Forms.SaveFileDialog saveDg;
        private System.Windows.Forms.OpenFileDialog openDg;
        private System.Windows.Forms.FontDialog fontDg;
        private System.Windows.Forms.ColorDialog colorDg;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

