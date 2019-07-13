namespace Manifest
{
    partial class FormAddPersonToLoad
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxInstructors = new System.Windows.Forms.ComboBox();
            this.comboBoxVideo = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxManNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAltitude = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxJumpType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelLoad = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jumper name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(292, 305);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(470, 31);
            this.textBoxName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "TI or AFFI 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Video or AFFI 2";
            // 
            // comboBoxInstructors
            // 
            this.comboBoxInstructors.FormattingEnabled = true;
            this.comboBoxInstructors.Location = new System.Drawing.Point(291, 390);
            this.comboBoxInstructors.Name = "comboBoxInstructors";
            this.comboBoxInstructors.Size = new System.Drawing.Size(471, 33);
            this.comboBoxInstructors.TabIndex = 6;
            // 
            // comboBoxVideo
            // 
            this.comboBoxVideo.FormattingEnabled = true;
            this.comboBoxVideo.Location = new System.Drawing.Point(291, 470);
            this.comboBoxVideo.Name = "comboBoxVideo";
            this.comboBoxVideo.Size = new System.Drawing.Size(471, 33);
            this.comboBoxVideo.TabIndex = 7;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(348, 534);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(185, 52);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add Person";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Manifest Num";
            // 
            // textBoxManNum
            // 
            this.textBoxManNum.Location = new System.Drawing.Point(291, 157);
            this.textBoxManNum.Name = "textBoxManNum";
            this.textBoxManNum.Size = new System.Drawing.Size(121, 31);
            this.textBoxManNum.TabIndex = 2;
            this.textBoxManNum.Leave += new System.EventHandler(this.TextBoxManNum_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Altitude";
            // 
            // textBoxAltitude
            // 
            this.textBoxAltitude.Location = new System.Drawing.Point(291, 205);
            this.textBoxAltitude.Name = "textBoxAltitude";
            this.textBoxAltitude.Size = new System.Drawing.Size(200, 31);
            this.textBoxAltitude.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Type";
            // 
            // comboBoxJumpType
            // 
            this.comboBoxJumpType.FormattingEnabled = true;
            this.comboBoxJumpType.Items.AddRange(new object[] {
            "14,500 - $26.00",
            "PRPAY - $0.00",
            "COUPON - $0.00",
            "TAN - $225.00",
            "TANVST - $325.00",
            "TANGFT - $0.00",
            "TANADV - $0.00",
            "IAFF2 - $200.00",
            "IAFF1 - $175.00",
            "GRWTS - $51.00",
            "COACHJ - $26.00",
            "COACHI - $0.00",
            "OBS - $30.00",
            "AWTS13 - $200.00",
            "AWTS47 - $175.00",
            "ADJ 47 - $170.00",
            "ACW 13 - $195.00",
            "ACW 47 - $170.00",
            "GRCW - $48.00"});
            this.comboBoxJumpType.Location = new System.Drawing.Point(291, 91);
            this.comboBoxJumpType.Name = "comboBoxJumpType";
            this.comboBoxJumpType.Size = new System.Drawing.Size(386, 33);
            this.comboBoxJumpType.TabIndex = 1;
            this.comboBoxJumpType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxJumpType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Price";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(291, 256);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(200, 31);
            this.textBoxPrice.TabIndex = 4;
            // 
            // labelLoad
            // 
            this.labelLoad.AutoSize = true;
            this.labelLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoad.Location = new System.Drawing.Point(284, 29);
            this.labelLoad.Name = "labelLoad";
            this.labelLoad.Size = new System.Drawing.Size(89, 37);
            this.labelLoad.TabIndex = 16;
            this.labelLoad.Text = "Load";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "Leave blank for tandem";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(321, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(278, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Leave blank for fun jumpers";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 442);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(432, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Leave blank for no video or 1 instructor AFF";
            // 
            // FormAddPersonToLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 641);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelLoad);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxJumpType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAltitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxManNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxVideo);
            this.Controls.Add(this.comboBoxInstructors);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FormAddPersonToLoad";
            this.Text = "Add Person to Load";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxInstructors;
        private System.Windows.Forms.ComboBox comboBoxVideo;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxManNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAltitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxJumpType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelLoad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}