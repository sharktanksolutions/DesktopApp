namespace supershop.EntryForms
{
    partial class PhoneEntry
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
            this.gradientPanel1 = new supershop.GradientPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backSpace = new supershop.RoundButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.enterButton = new supershop.RoundButton();
            this.roundButton9 = new supershop.RoundButton();
            this.roundButton8 = new supershop.RoundButton();
            this.roundButton10 = new supershop.RoundButton();
            this.roundButton11 = new supershop.RoundButton();
            this.roundButton12 = new supershop.RoundButton();
            this.roundButton4 = new supershop.RoundButton();
            this.roundButton5 = new supershop.RoundButton();
            this.roundButton6 = new supershop.RoundButton();
            this.roundButton3 = new supershop.RoundButton();
            this.roundButton2 = new supershop.RoundButton();
            this.roundButton1 = new supershop.RoundButton();
            this.gradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Controls.Add(this.enterButton);
            this.gradientPanel1.Controls.Add(this.roundButton9);
            this.gradientPanel1.Controls.Add(this.roundButton8);
            this.gradientPanel1.Controls.Add(this.roundButton10);
            this.gradientPanel1.Controls.Add(this.roundButton11);
            this.gradientPanel1.Controls.Add(this.roundButton12);
            this.gradientPanel1.Controls.Add(this.roundButton4);
            this.gradientPanel1.Controls.Add(this.roundButton5);
            this.gradientPanel1.Controls.Add(this.roundButton6);
            this.gradientPanel1.Controls.Add(this.roundButton3);
            this.gradientPanel1.Controls.Add(this.roundButton2);
            this.gradientPanel1.Controls.Add(this.roundButton1);
            this.gradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(462, 624);
            this.gradientPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.backSpace);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 131);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Phone Number";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 3;
            this.textBox1.MinimumSize = new System.Drawing.Size(50, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 37);
            this.textBox1.TabIndex = 0;
            this.textBox1.Click += new System.EventHandler(this.textInput_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // backSpace
            // 
            this.backSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.backSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.backSpace.BorderColor = System.Drawing.Color.Empty;
            this.backSpace.ButtonColor = System.Drawing.Color.Empty;
            this.backSpace.Enabled = false;
            this.backSpace.FlatAppearance.BorderSize = 0;
            this.backSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backSpace.Image = global::supershop.Properties.Resources.iconsBackSpace;
            this.backSpace.Location = new System.Drawing.Point(313, 30);
            this.backSpace.Name = "backSpace";
            this.backSpace.OnHoverBorderColor = System.Drawing.Color.Empty;
            this.backSpace.OnHoverButtonColor = System.Drawing.Color.Empty;
            this.backSpace.OnHoverTextColor = System.Drawing.Color.Empty;
            this.backSpace.Size = new System.Drawing.Size(117, 85);
            this.backSpace.TabIndex = 16;
            this.backSpace.TextColor = System.Drawing.Color.Empty;
            this.backSpace.UseVisualStyleBackColor = false;
            this.backSpace.Click += new System.EventHandler(this.backSpace_Click);
            this.backSpace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backSpace_MouseUp);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 46);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.MaxLength = 3;
            this.textBox2.MinimumSize = new System.Drawing.Size(50, 50);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 37);
            this.textBox2.TabIndex = 7;
            this.textBox2.Click += new System.EventHandler(this.textInput_Click);
            this.textBox2.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.AcceptsReturn = true;
            this.textBox3.Location = new System.Drawing.Point(211, 46);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.MaxLength = 4;
            this.textBox3.MinimumSize = new System.Drawing.Size(90, 50);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(95, 37);
            this.textBox3.TabIndex = 8;
            this.textBox3.Click += new System.EventHandler(this.textInput_Click);
            this.textBox3.TextChanged += new System.EventHandler(this.textInput_TextChanged);
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown_1);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.enterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enterButton.BorderColor = System.Drawing.Color.Empty;
            this.enterButton.ButtonColor = System.Drawing.Color.Empty;
            this.enterButton.FlatAppearance.BorderSize = 0;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Image = global::supershop.Properties.Resources.checkIcon;
            this.enterButton.Location = new System.Drawing.Point(214, 527);
            this.enterButton.Name = "enterButton";
            this.enterButton.OnHoverBorderColor = System.Drawing.Color.Empty;
            this.enterButton.OnHoverButtonColor = System.Drawing.Color.Empty;
            this.enterButton.OnHoverTextColor = System.Drawing.Color.Empty;
            this.enterButton.Size = new System.Drawing.Size(85, 85);
            this.enterButton.TabIndex = 14;
            this.enterButton.TextColor = System.Drawing.Color.Empty;
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // roundButton9
            // 
            this.roundButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundButton9.BorderColor = System.Drawing.Color.Empty;
            this.roundButton9.ButtonColor = System.Drawing.Color.Empty;
            this.roundButton9.FlatAppearance.BorderSize = 0;
            this.roundButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton9.Image = global::supershop.Properties.Resources.deleteIcon;
            this.roundButton9.Location = new System.Drawing.Point(13, 527);
            this.roundButton9.Name = "roundButton9";
            this.roundButton9.OnHoverBorderColor = System.Drawing.Color.Empty;
            this.roundButton9.OnHoverButtonColor = System.Drawing.Color.Empty;
            this.roundButton9.OnHoverTextColor = System.Drawing.Color.Empty;
            this.roundButton9.Size = new System.Drawing.Size(85, 85);
            this.roundButton9.TabIndex = 13;
            this.roundButton9.TextColor = System.Drawing.Color.Empty;
            this.roundButton9.UseVisualStyleBackColor = false;
            this.roundButton9.Click += new System.EventHandler(this.roundButton9_Click);
            // 
            // roundButton8
            // 
            this.roundButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton8.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton8.FlatAppearance.BorderSize = 0;
            this.roundButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton8.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton8.Location = new System.Drawing.Point(118, 532);
            this.roundButton8.Name = "roundButton8";
            this.roundButton8.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton8.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton8.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton8.Size = new System.Drawing.Size(80, 80);
            this.roundButton8.TabIndex = 10;
            this.roundButton8.Text = "0";
            this.roundButton8.TextColor = System.Drawing.Color.White;
            this.roundButton8.UseVisualStyleBackColor = false;
            this.roundButton8.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton10
            // 
            this.roundButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton10.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton10.FlatAppearance.BorderSize = 0;
            this.roundButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton10.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton10.Location = new System.Drawing.Point(220, 440);
            this.roundButton10.Margin = new System.Windows.Forms.Padding(5);
            this.roundButton10.Name = "roundButton10";
            this.roundButton10.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton10.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton10.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton10.Padding = new System.Windows.Forms.Padding(5);
            this.roundButton10.Size = new System.Drawing.Size(80, 80);
            this.roundButton10.TabIndex = 8;
            this.roundButton10.Text = "9";
            this.roundButton10.TextColor = System.Drawing.Color.White;
            this.roundButton10.UseVisualStyleBackColor = false;
            this.roundButton10.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton11
            // 
            this.roundButton11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton11.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton11.FlatAppearance.BorderSize = 0;
            this.roundButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton11.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton11.Location = new System.Drawing.Point(118, 440);
            this.roundButton11.Name = "roundButton11";
            this.roundButton11.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton11.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton11.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton11.Size = new System.Drawing.Size(80, 80);
            this.roundButton11.TabIndex = 7;
            this.roundButton11.Text = "8";
            this.roundButton11.TextColor = System.Drawing.Color.White;
            this.roundButton11.UseVisualStyleBackColor = false;
            this.roundButton11.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton12
            // 
            this.roundButton12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton12.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton12.FlatAppearance.BorderSize = 0;
            this.roundButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton12.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton12.Location = new System.Drawing.Point(18, 440);
            this.roundButton12.Name = "roundButton12";
            this.roundButton12.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton12.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton12.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton12.Size = new System.Drawing.Size(80, 80);
            this.roundButton12.TabIndex = 6;
            this.roundButton12.Text = "7";
            this.roundButton12.TextColor = System.Drawing.Color.White;
            this.roundButton12.UseVisualStyleBackColor = false;
            this.roundButton12.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton4
            // 
            this.roundButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton4.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton4.FlatAppearance.BorderSize = 0;
            this.roundButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton4.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton4.Location = new System.Drawing.Point(220, 353);
            this.roundButton4.Name = "roundButton4";
            this.roundButton4.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton4.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton4.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton4.Size = new System.Drawing.Size(80, 80);
            this.roundButton4.TabIndex = 5;
            this.roundButton4.Text = "6";
            this.roundButton4.TextColor = System.Drawing.Color.White;
            this.roundButton4.UseVisualStyleBackColor = false;
            this.roundButton4.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton5
            // 
            this.roundButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton5.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton5.FlatAppearance.BorderSize = 0;
            this.roundButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton5.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton5.Location = new System.Drawing.Point(118, 353);
            this.roundButton5.Name = "roundButton5";
            this.roundButton5.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton5.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton5.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton5.Size = new System.Drawing.Size(80, 80);
            this.roundButton5.TabIndex = 4;
            this.roundButton5.Text = "5";
            this.roundButton5.TextColor = System.Drawing.Color.White;
            this.roundButton5.UseVisualStyleBackColor = false;
            this.roundButton5.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton6
            // 
            this.roundButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.roundButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton6.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton6.FlatAppearance.BorderSize = 0;
            this.roundButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton6.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton6.Location = new System.Drawing.Point(18, 353);
            this.roundButton6.Name = "roundButton6";
            this.roundButton6.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton6.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton6.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton6.Size = new System.Drawing.Size(80, 80);
            this.roundButton6.TabIndex = 3;
            this.roundButton6.Text = "4";
            this.roundButton6.TextColor = System.Drawing.Color.White;
            this.roundButton6.UseVisualStyleBackColor = false;
            this.roundButton6.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton3
            // 
            this.roundButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton3.FlatAppearance.BorderSize = 0;
            this.roundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton3.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton3.Location = new System.Drawing.Point(220, 267);
            this.roundButton3.Name = "roundButton3";
            this.roundButton3.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton3.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton3.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton3.Size = new System.Drawing.Size(80, 80);
            this.roundButton3.TabIndex = 2;
            this.roundButton3.Text = "3";
            this.roundButton3.TextColor = System.Drawing.Color.White;
            this.roundButton3.UseVisualStyleBackColor = false;
            this.roundButton3.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton2.Location = new System.Drawing.Point(118, 267);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton2.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton2.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton2.Size = new System.Drawing.Size(80, 80);
            this.roundButton2.TabIndex = 1;
            this.roundButton2.Text = "2";
            this.roundButton2.TextColor = System.Drawing.Color.White;
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.buttonInput);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton1.Location = new System.Drawing.Point(18, 267);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton1.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton1.Size = new System.Drawing.Size(80, 80);
            this.roundButton1.TabIndex = 0;
            this.roundButton1.Text = "1";
            this.roundButton1.TextColor = System.Drawing.Color.White;
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.buttonInput);
            // 
            // PhoneEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 648);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "PhoneEntry";
            this.Text = "PhoneEntry";
            this.Load += new System.EventHandler(this.PhoneEntry_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private RoundButton roundButton1;
        private RoundButton roundButton8;
        private RoundButton roundButton10;
        private RoundButton roundButton11;
        private RoundButton roundButton12;
        private RoundButton roundButton4;
        private RoundButton roundButton5;
        private RoundButton roundButton6;
        private RoundButton roundButton3;
        private RoundButton roundButton2;
        private RoundButton roundButton9;
        private RoundButton enterButton;
        private RoundButton backSpace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}