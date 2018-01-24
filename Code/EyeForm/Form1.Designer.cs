namespace EyeForm
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
            this.image_PICBX = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCountFace = new System.Windows.Forms.Label();
            this.lbCountEyes = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbYLeftEye = new System.Windows.Forms.Label();
            this.lbXLeftEye = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbYRightEye = new System.Windows.Forms.Label();
            this.lbXRightEye = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // image_PICBX
            // 
            this.image_PICBX.Location = new System.Drawing.Point(13, 29);
            this.image_PICBX.Name = "image_PICBX";
            this.image_PICBX.Size = new System.Drawing.Size(316, 231);
            this.image_PICBX.TabIndex = 0;
            this.image_PICBX.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số khuôn mặt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số mắt";
            // 
            // lbCountFace
            // 
            this.lbCountFace.AutoSize = true;
            this.lbCountFace.Location = new System.Drawing.Point(170, 301);
            this.lbCountFace.Name = "lbCountFace";
            this.lbCountFace.Size = new System.Drawing.Size(13, 13);
            this.lbCountFace.TabIndex = 3;
            this.lbCountFace.Text = "0";
            // 
            // lbCountEyes
            // 
            this.lbCountEyes.AutoSize = true;
            this.lbCountEyes.Location = new System.Drawing.Point(137, 336);
            this.lbCountEyes.Name = "lbCountEyes";
            this.lbCountEyes.Size = new System.Drawing.Size(13, 13);
            this.lbCountEyes.TabIndex = 4;
            this.lbCountEyes.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbYLeftEye);
            this.groupBox1.Controls.Add(this.lbXLeftEye);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(336, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 231);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Left Eye";
            // 
            // lbYLeftEye
            // 
            this.lbYLeftEye.AutoSize = true;
            this.lbYLeftEye.Location = new System.Drawing.Point(80, 51);
            this.lbYLeftEye.Name = "lbYLeftEye";
            this.lbYLeftEye.Size = new System.Drawing.Size(13, 13);
            this.lbYLeftEye.TabIndex = 7;
            this.lbYLeftEye.Text = "0";
            // 
            // lbXLeftEye
            // 
            this.lbXLeftEye.AutoSize = true;
            this.lbXLeftEye.Location = new System.Drawing.Point(80, 27);
            this.lbXLeftEye.Name = "lbXLeftEye";
            this.lbXLeftEye.Size = new System.Drawing.Size(13, 13);
            this.lbXLeftEye.TabIndex = 6;
            this.lbXLeftEye.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y of Left Eye";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "X of Left Eye";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbYRightEye);
            this.groupBox2.Controls.Add(this.lbXRightEye);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(532, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(167, 231);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Right Eye";
            // 
            // lbYRightEye
            // 
            this.lbYRightEye.AutoSize = true;
            this.lbYRightEye.Location = new System.Drawing.Point(80, 51);
            this.lbYRightEye.Name = "lbYRightEye";
            this.lbYRightEye.Size = new System.Drawing.Size(13, 13);
            this.lbYRightEye.TabIndex = 7;
            this.lbYRightEye.Text = "0";
            // 
            // lbXRightEye
            // 
            this.lbXRightEye.AutoSize = true;
            this.lbXRightEye.Location = new System.Drawing.Point(80, 27);
            this.lbXRightEye.Name = "lbXRightEye";
            this.lbXRightEye.Size = new System.Drawing.Size(13, 13);
            this.lbXRightEye.TabIndex = 6;
            this.lbXRightEye.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Y of Right Eye";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "X of Right Eye";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbCountEyes);
            this.Controls.Add(this.lbCountFace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.image_PICBX);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.image_PICBX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image_PICBX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCountFace;
        private System.Windows.Forms.Label lbCountEyes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbYLeftEye;
        private System.Windows.Forms.Label lbXLeftEye;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbYRightEye;
        private System.Windows.Forms.Label lbXRightEye;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

