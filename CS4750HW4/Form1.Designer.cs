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
            this.rtxtDisplay = new System.Windows.Forms.RichTextBox();
            this.cmbRow = new System.Windows.Forms.ComboBox();
            this.cmbColumn = new System.Windows.Forms.ComboBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.btnPlace = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkAIOnly = new System.Windows.Forms.CheckBox();
            this.chkSingleTurn = new System.Windows.Forms.CheckBox();
            this.lblOptions = new System.Windows.Forms.Label();
            this.chkFinishGame = new System.Windows.Forms.CheckBox();
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
            // rtxtDisplay
            // 
            this.rtxtDisplay.Location = new System.Drawing.Point(107, 12);
            this.rtxtDisplay.Name = "rtxtDisplay";
            this.rtxtDisplay.ReadOnly = true;
            this.rtxtDisplay.Size = new System.Drawing.Size(279, 440);
            this.rtxtDisplay.TabIndex = 4;
            this.rtxtDisplay.Text = "";
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
            "4",
            "5"});
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
            "4"});
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
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 429);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chkAIOnly
            // 
            this.chkAIOnly.AutoSize = true;
            this.chkAIOnly.Location = new System.Drawing.Point(12, 176);
            this.chkAIOnly.Name = "chkAIOnly";
            this.chkAIOnly.Size = new System.Drawing.Size(60, 17);
            this.chkAIOnly.TabIndex = 11;
            this.chkAIOnly.Text = "AI Only";
            this.chkAIOnly.UseVisualStyleBackColor = true;
            // 
            // chkSingleTurn
            // 
            this.chkSingleTurn.AutoSize = true;
            this.chkSingleTurn.Location = new System.Drawing.Point(12, 199);
            this.chkSingleTurn.Name = "chkSingleTurn";
            this.chkSingleTurn.Size = new System.Drawing.Size(80, 17);
            this.chkSingleTurn.TabIndex = 12;
            this.chkSingleTurn.Text = "Single Turn";
            this.chkSingleTurn.UseVisualStyleBackColor = true;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.Location = new System.Drawing.Point(12, 160);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(43, 13);
            this.lblOptions.TabIndex = 13;
            this.lblOptions.Text = "Options";
            // 
            // chkFinishGame
            // 
            this.chkFinishGame.AutoSize = true;
            this.chkFinishGame.Location = new System.Drawing.Point(12, 222);
            this.chkFinishGame.Name = "chkFinishGame";
            this.chkFinishGame.Size = new System.Drawing.Size(84, 17);
            this.chkFinishGame.TabIndex = 14;
            this.chkFinishGame.Text = "Finish Game";
            this.chkFinishGame.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 496);
            this.Controls.Add(this.chkFinishGame);
            this.Controls.Add(this.lblOptions);
            this.Controls.Add(this.chkSingleTurn);
            this.Controls.Add(this.chkAIOnly);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnPlace);
            this.Controls.Add(this.lblColumn);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.cmbColumn);
            this.Controls.Add(this.cmbRow);
            this.Controls.Add(this.rtxtDisplay);
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
        private System.Windows.Forms.RichTextBox rtxtDisplay;
        private System.Windows.Forms.ComboBox cmbRow;
        private System.Windows.Forms.ComboBox cmbColumn;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkAIOnly;
        private System.Windows.Forms.CheckBox chkSingleTurn;
        private System.Windows.Forms.Label lblOptions;
        private System.Windows.Forms.CheckBox chkFinishGame;
    }
}

