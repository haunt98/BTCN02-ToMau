namespace BTCN_02_ToMau
{
    partial class FormMain
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
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFillAlgo = new System.Windows.Forms.ComboBox();
            this.colorDialogFill = new System.Windows.Forms.ColorDialog();
            this.buttonDisplayColor = new System.Windows.Forms.Button();
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonCancelFill = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxShapeType = new System.Windows.Forms.ComboBox();
            this.buttonRandShape = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownNumShape = new System.Windows.Forms.NumericUpDown();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFillTimer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumShape)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(15, 116);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(682, 315);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onMouseClickFill);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fill Algorithm";
            // 
            // comboBoxFillAlgo
            // 
            this.comboBoxFillAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFillAlgo.FormattingEnabled = true;
            this.comboBoxFillAlgo.Location = new System.Drawing.Point(83, 13);
            this.comboBoxFillAlgo.Name = "comboBoxFillAlgo";
            this.comboBoxFillAlgo.Size = new System.Drawing.Size(118, 21);
            this.comboBoxFillAlgo.TabIndex = 2;
            // 
            // buttonDisplayColor
            // 
            this.buttonDisplayColor.Location = new System.Drawing.Point(440, 41);
            this.buttonDisplayColor.Name = "buttonDisplayColor";
            this.buttonDisplayColor.Size = new System.Drawing.Size(34, 35);
            this.buttonDisplayColor.TabIndex = 3;
            this.buttonDisplayColor.UseVisualStyleBackColor = true;
            this.buttonDisplayColor.Click += new System.EventHandler(this.buttonDisplayColor_Click);
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(480, 47);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(75, 23);
            this.buttonFill.TabIndex = 4;
            this.buttonFill.Text = "Fill";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // buttonCancelFill
            // 
            this.buttonCancelFill.Location = new System.Drawing.Point(561, 47);
            this.buttonCancelFill.Name = "buttonCancelFill";
            this.buttonCancelFill.Size = new System.Drawing.Size(95, 23);
            this.buttonCancelFill.TabIndex = 5;
            this.buttonCancelFill.Text = "Cancel Fill";
            this.buttonCancelFill.UseVisualStyleBackColor = true;
            this.buttonCancelFill.Click += new System.EventHandler(this.buttonCancelFill_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shape Type";
            // 
            // comboBoxShapeType
            // 
            this.comboBoxShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShapeType.FormattingEnabled = true;
            this.comboBoxShapeType.Location = new System.Drawing.Point(291, 13);
            this.comboBoxShapeType.Name = "comboBoxShapeType";
            this.comboBoxShapeType.Size = new System.Drawing.Size(118, 21);
            this.comboBoxShapeType.TabIndex = 7;
            // 
            // buttonRandShape
            // 
            this.buttonRandShape.Location = new System.Drawing.Point(223, 47);
            this.buttonRandShape.Name = "buttonRandShape";
            this.buttonRandShape.Size = new System.Drawing.Size(103, 23);
            this.buttonRandShape.TabIndex = 8;
            this.buttonRandShape.Text = "Random Shape";
            this.buttonRandShape.UseVisualStyleBackColor = true;
            this.buttonRandShape.Click += new System.EventHandler(this.buttonRandShape_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number of Shape";
            // 
            // numericUpDownNumShape
            // 
            this.numericUpDownNumShape.Location = new System.Drawing.Point(108, 50);
            this.numericUpDownNumShape.Name = "numericUpDownNumShape";
            this.numericUpDownNumShape.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownNumShape.TabIndex = 10;
            this.numericUpDownNumShape.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(334, 47);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 11;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(622, 13);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(75, 23);
            this.buttonHelp.TabIndex = 12;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(415, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fill shape timer";
            // 
            // textBoxFillTimer
            // 
            this.textBoxFillTimer.Enabled = false;
            this.textBoxFillTimer.Location = new System.Drawing.Point(503, 13);
            this.textBoxFillTimer.Name = "textBoxFillTimer";
            this.textBoxFillTimer.Size = new System.Drawing.Size(100, 20);
            this.textBoxFillTimer.TabIndex = 14;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 443);
            this.Controls.Add(this.textBoxFillTimer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.numericUpDownNumShape);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRandShape);
            this.Controls.Add(this.comboBoxShapeType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancelFill);
            this.Controls.Add(this.buttonFill);
            this.Controls.Add(this.buttonDisplayColor);
            this.Controls.Add(this.comboBoxFillAlgo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "FormMain";
            this.Text = "To Mau";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumShape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFillAlgo;
        private System.Windows.Forms.ColorDialog colorDialogFill;
        private System.Windows.Forms.Button buttonDisplayColor;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonCancelFill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxShapeType;
        private System.Windows.Forms.Button buttonRandShape;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownNumShape;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFillTimer;
    }
}

