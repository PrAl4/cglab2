using System.Drawing;

namespace pravednikLAB5Task2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Draw = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.dpth = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rghnss = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(184, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(927, 555);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MD);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MU);
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(11, 14);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(141, 65);
            this.Draw.TabIndex = 1;
            this.Draw.Text = "Нарисовать";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(11, 101);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(141, 65);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // dpth
            // 
            this.dpth.Location = new System.Drawing.Point(11, 261);
            this.dpth.Name = "dpth";
            this.dpth.Size = new System.Drawing.Size(140, 22);
            this.dpth.TabIndex = 4;
            this.dpth.TextChanged += new System.EventHandler(this.dpth_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 221);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Глубина:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(11, 306);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 22);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "Шероховатость:";
            // 
            // rghnss
            // 
            this.rghnss.Location = new System.Drawing.Point(11, 352);
            this.rghnss.Name = "rghnss";
            this.rghnss.Size = new System.Drawing.Size(140, 22);
            this.rghnss.TabIndex = 6;
            this.rghnss.TextChanged += new System.EventHandler(this.rghnss_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 566);
            this.Controls.Add(this.rghnss);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dpth);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox dpth;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox rghnss;
    }
}

