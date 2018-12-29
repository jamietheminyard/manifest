namespace Manifest
{
    partial class AddUserForm
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
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxManNum = new System.Windows.Forms.TextBox();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTI = new System.Windows.Forms.CheckBox();
            this.checkBoxAFF = new System.Windows.Forms.CheckBox();
            this.checkBoxCoach = new System.Windows.Forms.CheckBox();
            this.checkBoxVideo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(162, 89);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(227, 31);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(162, 139);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(227, 31);
            this.textBoxLastName.TabIndex = 2;
            // 
            // textBoxManNum
            // 
            this.textBoxManNum.Location = new System.Drawing.Point(162, 37);
            this.textBoxManNum.Name = "textBoxManNum";
            this.textBoxManNum.Size = new System.Drawing.Size(100, 31);
            this.textBoxManNum.TabIndex = 0;
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.Location = new System.Drawing.Point(265, 236);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(172, 47);
            this.buttonAddPerson.TabIndex = 3;
            this.buttonAddPerson.Text = "Add Person";
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Manifest #";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Name";
            // 
            // checkBoxTI
            // 
            this.checkBoxTI.AutoSize = true;
            this.checkBoxTI.Location = new System.Drawing.Point(490, 37);
            this.checkBoxTI.Name = "checkBoxTI";
            this.checkBoxTI.Size = new System.Drawing.Size(217, 29);
            this.checkBoxTI.TabIndex = 7;
            this.checkBoxTI.Text = "Tandem Instructor";
            this.checkBoxTI.UseVisualStyleBackColor = true;
            // 
            // checkBoxAFF
            // 
            this.checkBoxAFF.AutoSize = true;
            this.checkBoxAFF.Location = new System.Drawing.Point(490, 89);
            this.checkBoxAFF.Name = "checkBoxAFF";
            this.checkBoxAFF.Size = new System.Drawing.Size(179, 29);
            this.checkBoxAFF.TabIndex = 8;
            this.checkBoxAFF.Text = "AFF Instructor";
            this.checkBoxAFF.UseVisualStyleBackColor = true;
            // 
            // checkBoxCoach
            // 
            this.checkBoxCoach.AutoSize = true;
            this.checkBoxCoach.Location = new System.Drawing.Point(490, 139);
            this.checkBoxCoach.Name = "checkBoxCoach";
            this.checkBoxCoach.Size = new System.Drawing.Size(106, 29);
            this.checkBoxCoach.TabIndex = 9;
            this.checkBoxCoach.Text = "Coach";
            this.checkBoxCoach.UseVisualStyleBackColor = true;
            // 
            // checkBoxVideo
            // 
            this.checkBoxVideo.AutoSize = true;
            this.checkBoxVideo.Location = new System.Drawing.Point(490, 191);
            this.checkBoxVideo.Name = "checkBoxVideo";
            this.checkBoxVideo.Size = new System.Drawing.Size(173, 29);
            this.checkBoxVideo.TabIndex = 10;
            this.checkBoxVideo.Text = "Videographer";
            this.checkBoxVideo.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 339);
            this.Controls.Add(this.checkBoxVideo);
            this.Controls.Add(this.checkBoxCoach);
            this.Controls.Add(this.checkBoxAFF);
            this.Controls.Add(this.checkBoxTI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddPerson);
            this.Controls.Add(this.textBoxManNum);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Name = "AddUserForm";
            this.Text = "Add A Person";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxManNum;
        private System.Windows.Forms.Button buttonAddPerson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxTI;
        private System.Windows.Forms.CheckBox checkBoxAFF;
        private System.Windows.Forms.CheckBox checkBoxCoach;
        private System.Windows.Forms.CheckBox checkBoxVideo;
    }
}