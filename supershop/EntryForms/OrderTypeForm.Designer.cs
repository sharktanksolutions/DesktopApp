namespace supershop.EntryForms
{
    partial class OrderTypeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.roundButton3 = new supershop.RoundButton();
            this.roundButton2 = new supershop.RoundButton();
            this.roundButton1 = new supershop.RoundButton();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(75)))), ((int)(((byte)(70)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.roundButton3);
            this.gradientPanel1.Controls.Add(this.roundButton2);
            this.gradientPanel1.Controls.Add(this.roundButton1);
            this.gradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(648, 260);
            this.gradientPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // roundButton3
            // 
            this.roundButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton3.FlatAppearance.BorderSize = 0;
            this.roundButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton3.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton3.Location = new System.Drawing.Point(448, 56);
            this.roundButton3.Name = "roundButton3";
            this.roundButton3.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton3.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton3.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton3.Size = new System.Drawing.Size(186, 78);
            this.roundButton3.TabIndex = 2;
            this.roundButton3.Text = "Delivery";
            this.roundButton3.TextColor = System.Drawing.Color.White;
            this.roundButton3.UseVisualStyleBackColor = false;
            this.roundButton3.Click += new System.EventHandler(this.roundButton3_Click);
            // 
            // roundButton2
            // 
            this.roundButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton2.FlatAppearance.BorderSize = 0;
            this.roundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton2.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton2.Location = new System.Drawing.Point(244, 56);
            this.roundButton2.Name = "roundButton2";
            this.roundButton2.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton2.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton2.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton2.Size = new System.Drawing.Size(182, 78);
            this.roundButton2.TabIndex = 1;
            this.roundButton2.Text = "Pick Up";
            this.roundButton2.TextColor = System.Drawing.Color.White;
            this.roundButton2.UseVisualStyleBackColor = false;
            this.roundButton2.Click += new System.EventHandler(this.roundButton2_Click);
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(225)))), ((int)(((byte)(181)))));
            this.roundButton1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(91)))), ((int)(((byte)(83)))));
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("Century Gothic", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundButton1.Location = new System.Drawing.Point(37, 56);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.roundButton1.OnHoverButtonColor = System.Drawing.Color.Yellow;
            this.roundButton1.OnHoverTextColor = System.Drawing.Color.Gray;
            this.roundButton1.Size = new System.Drawing.Size(182, 78);
            this.roundButton1.TabIndex = 0;
            this.roundButton1.Text = "Take Out";
            this.roundButton1.TextColor = System.Drawing.Color.White;
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // OrderTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 284);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "OrderTypeForm";
            this.Text = "OrderType";
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private RoundButton roundButton3;
        private RoundButton roundButton2;
        private RoundButton roundButton1;
    }
}