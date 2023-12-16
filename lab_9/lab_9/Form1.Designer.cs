namespace lab_9
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
            this.draw_polyh = new System.Windows.Forms.Button();
            this.choose_polyh = new System.Windows.Forms.ComboBox();
            this.Clear = new System.Windows.Forms.Button();
            this.choose_axis = new System.Windows.Forms.ComboBox();
            this.choose_proj = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(287, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(947, 562);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // draw_polyh
            // 
            this.draw_polyh.Location = new System.Drawing.Point(12, 12);
            this.draw_polyh.Name = "draw_polyh";
            this.draw_polyh.Size = new System.Drawing.Size(205, 47);
            this.draw_polyh.TabIndex = 1;
            this.draw_polyh.Text = "Нарисовать фигуру";
            this.draw_polyh.UseVisualStyleBackColor = true;
            this.draw_polyh.Click += new System.EventHandler(this.draw_polyh_Click);
            // 
            // choose_polyh
            // 
            this.choose_polyh.FormattingEnabled = true;
            this.choose_polyh.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
            this.choose_polyh.Location = new System.Drawing.Point(12, 65);
            this.choose_polyh.Name = "choose_polyh";
            this.choose_polyh.Size = new System.Drawing.Size(205, 24);
            this.choose_polyh.TabIndex = 2;
            this.choose_polyh.Text = "Выбрать фигуру";
            this.choose_polyh.SelectedIndexChanged += new System.EventHandler(this.choose_polyh_SelectedIndexChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(12, 527);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(205, 47);
            this.Clear.TabIndex = 3;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // choose_axis
            // 
            this.choose_axis.FormattingEnabled = true;
            this.choose_axis.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
            this.choose_axis.Location = new System.Drawing.Point(12, 95);
            this.choose_axis.Name = "choose_axis";
            this.choose_axis.Size = new System.Drawing.Size(205, 24);
            this.choose_axis.TabIndex = 4;
            this.choose_axis.Text = "Выбрать ось";
            this.choose_axis.SelectedIndexChanged += new System.EventHandler(this.choose_axis_SelectedIndexChanged);
            // 
            // choose_proj
            // 
            this.choose_proj.FormattingEnabled = true;
            this.choose_proj.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
            this.choose_proj.Location = new System.Drawing.Point(12, 125);
            this.choose_proj.Name = "choose_proj";
            this.choose_proj.Size = new System.Drawing.Size(205, 24);
            this.choose_proj.TabIndex = 5;
            this.choose_proj.Text = "Выбрать проекцию";
            this.choose_proj.SelectedIndexChanged += new System.EventHandler(this.choose_proj_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 586);
            this.Controls.Add(this.choose_proj);
            this.Controls.Add(this.choose_axis);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.choose_polyh);
            this.Controls.Add(this.draw_polyh);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button draw_polyh;
        private System.Windows.Forms.ComboBox choose_polyh;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.ComboBox choose_axis;
        private System.Windows.Forms.ComboBox choose_proj;
    }
}

