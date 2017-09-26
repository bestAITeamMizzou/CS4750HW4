namespace CS4750HW4
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
            this.btnBeginner = new System.Windows.Forms.Button();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.btnMaster = new System.Windows.Forms.Button();
            this.btnTournament = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cmbRow = new System.Windows.Forms.ComboBox();
            this.cmbColumn = new System.Windows.Forms.ComboBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.btnPlace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBeginner
            // 
            this.btnBeginner.Location = new System.Drawing.Point(12, 458);
            this.btnBeginner.Name = "btnBeginner";
            this.btnBeginner.Size = new System.Drawing.Size(89, 26);
            this.btnBeginner.TabIndex = 0;
            this.btnBeginner.Text = "Beginner";
            this.btnBeginner.UseVisualStyleBackColor = true;
            this.btnBeginner.Click += new System.EventHandler(this.btnBeginner_Click);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Location = new System.Drawing.Point(107, 458);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(89, 26);
            this.btnAdvanced.TabIndex = 1;
            this.btnAdvanced.Text = "Advanced";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // btnMaster
            // 
            this.btnMaster.Location = new System.Drawing.Point(202, 458);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(89, 26);
            this.btnMaster.TabIndex = 2;
            this.btnMaster.Text = "Master";
            this.btnMaster.UseVisualStyleBackColor = true;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // btnTournament
            // 
            this.btnTournament.Location = new System.Drawing.Point(297, 458);
            this.btnTournament.Name = "btnTournament";
            this.btnTournament.Size = new System.Drawing.Size(89, 26);
            this.btnTournament.TabIndex = 3;
            this.btnTournament.Text = "Tournament";
            this.btnTournament.UseVisualStyleBackColor = true;
            this.btnTournament.Click += new System.EventHandler(this.btnTournament_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(93, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(293, 440);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // cmbRow
            // 
            this.cmbRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRow.FormattingEnabled = true;
            this.cmbRow.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cmbRow.Location = new System.Drawing.Point(12, 25);
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Size = new System.Drawing.Size(75, 21);
            this.cmbRow.TabIndex = 5;
            // 
            // cmbColumn
            // 
            this.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn.FormattingEnabled = true;
            this.cmbColumn.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbColumn.Location = new System.Drawing.Point(12, 65);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.Size = new System.Drawing.Size(75, 21);
            this.cmbColumn.TabIndex = 6;
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Location = new System.Drawing.Point(12, 9);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(29, 13);
            this.lblRow.TabIndex = 7;
            this.lblRow.Text = "Row";
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(12, 49);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(42, 13);
            this.lblColumn.TabIndex = 8;
            this.lblColumn.Text = "Column";
            // 
            // btnPlace
            // 
            this.btnPlace.Location = new System.Drawing.Point(12, 92);
            this.btnPlace.Name = "btnPlace";
            this.btnPlace.Size = new System.Drawing.Size(75, 23);
            this.btnPlace.TabIndex = 9;
            this.btnPlace.Text = "Place";
            this.btnPlace.UseVisualStyleBackColor = true;
            this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 496);
            this.Controls.Add(this.btnPlace);
            this.Controls.Add(this.lblColumn);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.cmbColumn);
            this.Controls.Add(this.cmbRow);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnTournament);
            this.Controls.Add(this.btnMaster);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.btnBeginner);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginner;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnTournament;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cmbRow;
        private System.Windows.Forms.ComboBox cmbColumn;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Button btnPlace;
    }
}

