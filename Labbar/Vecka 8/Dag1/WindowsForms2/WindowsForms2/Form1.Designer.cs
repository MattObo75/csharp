namespace WindowsForms2
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
            lblVal = new Label();
            txtVal = new TextBox();
            cmdBeslut = new Button();
            cmbDesserts = new ComboBox();
            cmdValtDessert = new Button();
            lblDessert = new Label();
            btnClose = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // lblVal
            // 
            lblVal.AutoSize = true;
            lblVal.BackColor = Color.Transparent;
            lblVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal.Location = new Point(86, 23);
            lblVal.Name = "lblVal";
            lblVal.Size = new Size(306, 21);
            lblVal.TabIndex = 0;
            lblVal.Text = "Gillar du C# ? Svara Ja, Nej eller Kanske";
            // 
            // txtVal
            // 
            txtVal.Location = new Point(86, 57);
            txtVal.Name = "txtVal";
            txtVal.Size = new Size(164, 23);
            txtVal.TabIndex = 1;
            // 
            // cmdBeslut
            // 
            cmdBeslut.AutoEllipsis = true;
            cmdBeslut.BackColor = SystemColors.ButtonShadow;
            cmdBeslut.BackgroundImageLayout = ImageLayout.Center;
            cmdBeslut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdBeslut.Location = new Point(86, 100);
            cmdBeslut.Name = "cmdBeslut";
            cmdBeslut.Size = new Size(117, 26);
            cmdBeslut.TabIndex = 2;
            cmdBeslut.Text = "Skicka svar";
            cmdBeslut.UseVisualStyleBackColor = false;
            cmdBeslut.Click += cmdBeslut_Click;
            // 
            // cmbDesserts
            // 
            cmbDesserts.FormattingEnabled = true;
            cmbDesserts.Location = new Point(435, 56);
            cmbDesserts.Name = "cmbDesserts";
            cmbDesserts.Size = new Size(160, 23);
            cmbDesserts.TabIndex = 3;
            cmbDesserts.SelectedIndexChanged += cmbDesserts_SelectedIndexChanged;
            // 
            // cmdValtDessert
            // 
            cmdValtDessert.BackColor = SystemColors.ButtonShadow;
            cmdValtDessert.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmdValtDessert.Location = new Point(435, 100);
            cmdValtDessert.Name = "cmdValtDessert";
            cmdValtDessert.Size = new Size(115, 25);
            cmdValtDessert.TabIndex = 4;
            cmdValtDessert.Text = "Bekräfta val";
            cmdValtDessert.UseVisualStyleBackColor = false;
            cmdValtDessert.Click += cmdValtDessert_Click;
            // 
            // lblDessert
            // 
            lblDessert.AutoSize = true;
            lblDessert.BackColor = Color.Transparent;
            lblDessert.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDessert.Location = new Point(435, 23);
            lblDessert.Name = "lblDessert";
            lblDessert.Size = new Size(97, 21);
            lblDessert.TabIndex = 5;
            lblDessert.Text = "Välj dessert";
            // 
            // btnClose
            // 
            btnClose.BackColor = SystemColors.ButtonShadow;
            btnClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(645, 214);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 32);
            btnClose.TabIndex = 6;
            btnClose.Text = "Avsluta";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = SystemColors.ButtonShadow;
            btnReset.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(573, 165);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(152, 33);
            btnReset.TabIndex = 7;
            btnReset.Text = "Återställ formuläret";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(749, 450);
            Controls.Add(btnReset);
            Controls.Add(btnClose);
            Controls.Add(lblDessert);
            Controls.Add(cmdValtDessert);
            Controls.Add(cmbDesserts);
            Controls.Add(cmdBeslut);
            Controls.Add(txtVal);
            Controls.Add(lblVal);
            Name = "Form1";
            Text = "Windows formulär";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVal;
        private TextBox txtVal;
        private Button cmdBeslut;
        private ComboBox cmbDesserts;
        private Button cmdValtDessert;
        private Label lblDessert;
        private Button btnClose;
        private Button btnReset;
    }
}
