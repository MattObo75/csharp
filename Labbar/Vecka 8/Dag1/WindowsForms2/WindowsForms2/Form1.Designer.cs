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
            lblVal = new Label();
            txtVal = new TextBox();
            cmdBeslut = new Button();
            cmbDesserts = new ComboBox();
            cmdValtDessert = new Button();
            SuspendLayout();
            // 
            // lblVal
            // 
            lblVal.AutoSize = true;
            lblVal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVal.Location = new Point(93, 53);
            lblVal.Name = "lblVal";
            lblVal.Size = new Size(0, 21);
            lblVal.TabIndex = 0;
            // 
            // txtVal
            // 
            txtVal.Location = new Point(93, 100);
            txtVal.Name = "txtVal";
            txtVal.Size = new Size(211, 23);
            txtVal.TabIndex = 1;
            // 
            // cmdBeslut
            // 
            cmdBeslut.Location = new Point(93, 145);
            cmdBeslut.Name = "cmdBeslut";
            cmdBeslut.Size = new Size(117, 26);
            cmdBeslut.TabIndex = 2;
            cmdBeslut.Text = "Beslut";
            cmdBeslut.UseVisualStyleBackColor = true;
            cmdBeslut.Click += cmdBeslut_Click;
            // 
            // cmbDesserts
            // 
            cmbDesserts.FormattingEnabled = true;
            cmbDesserts.Location = new Point(360, 99);
            cmbDesserts.Name = "cmbDesserts";
            cmbDesserts.Size = new Size(160, 23);
            cmbDesserts.TabIndex = 3;
            cmbDesserts.SelectedIndexChanged += cmbDesserts_SelectedIndexChanged;
            // 
            // cmdValtDessert
            // 
            cmdValtDessert.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdValtDessert.Location = new Point(360, 148);
            cmdValtDessert.Name = "cmdValtDessert";
            cmdValtDessert.Size = new Size(160, 23);
            cmdValtDessert.TabIndex = 4;
            cmdValtDessert.Text = "Bekräfta dessert";
            cmdValtDessert.UseVisualStyleBackColor = true;
            cmdValtDessert.Click += cmdValtDessert_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmdValtDessert);
            Controls.Add(cmbDesserts);
            Controls.Add(cmdBeslut);
            Controls.Add(txtVal);
            Controls.Add(lblVal);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVal;
        private TextBox txtVal;
        private Button cmdBeslut;
        private ComboBox cmbDesserts;
        private Button cmdValtDessert;
    }
}
