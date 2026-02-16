namespace WindowsForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblVisa = new Label();
            cmdVisa = new Button();
            cmdDolj = new Button();
            cmdStang = new Button();
            txtText = new TextBox();
            SuspendLayout();
            // 
            // lblVisa
            // 
            lblVisa.AutoSize = true;
            lblVisa.BackColor = Color.Transparent;
            lblVisa.BorderStyle = BorderStyle.Fixed3D;
            lblVisa.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVisa.Location = new Point(23, 9);
            lblVisa.Name = "lblVisa";
            lblVisa.Size = new Size(2, 34);
            lblVisa.TabIndex = 0;
            // 
            // cmdVisa
            // 
            cmdVisa.BackColor = Color.Green;
            cmdVisa.Location = new Point(376, 56);
            cmdVisa.Name = "cmdVisa";
            cmdVisa.Size = new Size(75, 23);
            cmdVisa.TabIndex = 1;
            cmdVisa.Text = "Visa";
            cmdVisa.UseVisualStyleBackColor = false;
            cmdVisa.Click += cmdVisa_Click;
            // 
            // cmdDolj
            // 
            cmdDolj.BackColor = Color.Green;
            cmdDolj.Location = new Point(475, 56);
            cmdDolj.Name = "cmdDolj";
            cmdDolj.Size = new Size(75, 23);
            cmdDolj.TabIndex = 2;
            cmdDolj.Text = "Dölj";
            cmdDolj.UseVisualStyleBackColor = false;
            cmdDolj.Click += cmdDolj_Click;
            // 
            // cmdStang
            // 
            cmdStang.BackColor = Color.Green;
            cmdStang.Location = new Point(572, 56);
            cmdStang.Name = "cmdStang";
            cmdStang.Size = new Size(75, 23);
            cmdStang.TabIndex = 3;
            cmdStang.Text = "Stäng";
            cmdStang.UseVisualStyleBackColor = false;
            cmdStang.Click += cmdStang_Click;
            // 
            // txtText
            // 
            txtText.Location = new Point(376, 96);
            txtText.Name = "txtText";
            txtText.Size = new Size(202, 23);
            txtText.TabIndex = 4;
            txtText.TextChanged += txtText_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(747, 450);
            Controls.Add(txtText);
            Controls.Add(cmdStang);
            Controls.Add(cmdDolj);
            Controls.Add(cmdVisa);
            Controls.Add(lblVisa);
            Name = "Form1";
            Text = "Mitt första Windows Form program";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVisa;
        private Button cmdVisa;
        private Button cmdDolj;
        private Button cmdStang;
        private TextBox txtText;
    }
}
