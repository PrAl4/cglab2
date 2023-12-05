namespace lab7
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
            this.Download_from_file = new System.Windows.Forms.Button();
            this.Save_in_file = new System.Windows.Forms.Button();
            this.choose_polyhedron = new System.Windows.Forms.ComboBox();
            this.choose_axis = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.choose_proection = new System.Windows.Forms.ComboBox();
            this.Scale = new System.Windows.Forms.Button();
            this.Shift = new System.Windows.Forms.Button();
            this.Rotation = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.valueXDouble = new System.Windows.Forms.TextBox();
            this.ValueYDouble = new System.Windows.Forms.TextBox();
            this.ValueZDouble = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.valueAngle = new System.Windows.Forms.TextBox();
            this.draw_axiss = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(291, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(874, 645);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Download_from_file
            // 
            this.Download_from_file.Location = new System.Drawing.Point(15, 18);
            this.Download_from_file.Name = "Download_from_file";
            this.Download_from_file.Size = new System.Drawing.Size(175, 62);
            this.Download_from_file.TabIndex = 1;
            this.Download_from_file.Text = "Загрузить из файла";
            this.Download_from_file.UseVisualStyleBackColor = true;
            this.Download_from_file.Click += new System.EventHandler(this.Download_from_file_Click);
            // 
            // Save_in_file
            // 
            this.Save_in_file.Location = new System.Drawing.Point(15, 86);
            this.Save_in_file.Name = "Save_in_file";
            this.Save_in_file.Size = new System.Drawing.Size(175, 62);
            this.Save_in_file.TabIndex = 2;
            this.Save_in_file.Text = "Сохранить в файл";
            this.Save_in_file.UseVisualStyleBackColor = true;
            this.Save_in_file.Click += new System.EventHandler(this.Save_in_file_Click);
            // 
            // choose_polyhedron
            // 
            this.choose_polyhedron.FormattingEnabled = true;
            this.choose_polyhedron.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
            this.choose_polyhedron.Location = new System.Drawing.Point(16, 154);
            this.choose_polyhedron.Name = "choose_polyhedron";
            this.choose_polyhedron.Size = new System.Drawing.Size(174, 24);
            this.choose_polyhedron.TabIndex = 3;
            this.choose_polyhedron.Text = "Выберите фигуру";
            this.choose_polyhedron.SelectedIndexChanged += new System.EventHandler(this.choose_polyhedron_SelectedIndexChanged);
            // 
            // choose_axis
            // 
            this.choose_axis.FormattingEnabled = true;
            this.choose_axis.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.choose_axis.Location = new System.Drawing.Point(15, 184);
            this.choose_axis.Name = "choose_axis";
            this.choose_axis.Size = new System.Drawing.Size(174, 24);
            this.choose_axis.TabIndex = 4;
            this.choose_axis.Text = "Выберите ось";
            this.choose_axis.SelectedIndexChanged += new System.EventHandler(this.choose_axis_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Текстовые файлы|*.txt;";
            // 
            // choose_proection
            // 
            this.choose_proection.FormattingEnabled = true;
            this.choose_proection.Items.AddRange(new object[] {
            "Изометрия",
            "Аксонометрия",
            "Перспектива"});
            this.choose_proection.Location = new System.Drawing.Point(16, 214);
            this.choose_proection.Name = "choose_proection";
            this.choose_proection.Size = new System.Drawing.Size(174, 24);
            this.choose_proection.TabIndex = 5;
            this.choose_proection.Text = "Выберите проекцию";
            this.choose_proection.SelectedIndexChanged += new System.EventHandler(this.choose_proection_SelectedIndexChanged);
            // 
            // Scale
            // 
            this.Scale.Location = new System.Drawing.Point(15, 244);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(175, 42);
            this.Scale.TabIndex = 6;
            this.Scale.Text = "Масштабирование";
            this.Scale.UseVisualStyleBackColor = true;
            this.Scale.Click += new System.EventHandler(this.Scale_Click);
            // 
            // Shift
            // 
            this.Shift.Location = new System.Drawing.Point(16, 292);
            this.Shift.Name = "Shift";
            this.Shift.Size = new System.Drawing.Size(175, 42);
            this.Shift.TabIndex = 7;
            this.Shift.Text = "Смещение";
            this.Shift.UseVisualStyleBackColor = true;
            this.Shift.Click += new System.EventHandler(this.Shift_Click);
            // 
            // Rotation
            // 
            this.Rotation.Location = new System.Drawing.Point(15, 340);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(175, 42);
            this.Rotation.TabIndex = 8;
            this.Rotation.Text = "Поворот";
            this.Rotation.UseVisualStyleBackColor = true;
            this.Rotation.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 388);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(31, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "X";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 388);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(31, 22);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Y";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(160, 388);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(31, 22);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "Z";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(15, 591);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(175, 62);
            this.Clear.TabIndex = 15;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // valueXDouble
            // 
            this.valueXDouble.Location = new System.Drawing.Point(16, 416);
            this.valueXDouble.Name = "valueXDouble";
            this.valueXDouble.Size = new System.Drawing.Size(31, 22);
            this.valueXDouble.TabIndex = 16;
            this.valueXDouble.TextChanged += new System.EventHandler(this.valueXDouble_TextChanged);
            // 
            // ValueYDouble
            // 
            this.ValueYDouble.Location = new System.Drawing.Point(88, 416);
            this.ValueYDouble.Name = "ValueYDouble";
            this.ValueYDouble.Size = new System.Drawing.Size(31, 22);
            this.ValueYDouble.TabIndex = 17;
            this.ValueYDouble.TextChanged += new System.EventHandler(this.ValueYDouble_TextChanged);
            // 
            // ValueZDouble
            // 
            this.ValueZDouble.Location = new System.Drawing.Point(160, 416);
            this.ValueZDouble.Name = "ValueZDouble";
            this.ValueZDouble.Size = new System.Drawing.Size(31, 22);
            this.ValueZDouble.TabIndex = 18;
            this.ValueZDouble.TextChanged += new System.EventHandler(this.ValueZDouble_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(16, 460);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(77, 22);
            this.textBox4.TabIndex = 19;
            this.textBox4.Text = "Угол";
            // 
            // valueAngle
            // 
            this.valueAngle.Location = new System.Drawing.Point(102, 460);
            this.valueAngle.Name = "valueAngle";
            this.valueAngle.Size = new System.Drawing.Size(88, 22);
            this.valueAngle.TabIndex = 20;
            this.valueAngle.TextChanged += new System.EventHandler(this.valueAngle_TextChanged);
            // 
            // draw_axiss
            // 
            this.draw_axiss.Location = new System.Drawing.Point(16, 543);
            this.draw_axiss.Name = "draw_axiss";
            this.draw_axiss.Size = new System.Drawing.Size(175, 42);
            this.draw_axiss.TabIndex = 21;
            this.draw_axiss.Text = "Показать оси";
            this.draw_axiss.UseVisualStyleBackColor = true;
            this.draw_axiss.Click += new System.EventHandler(this.draw_axiss_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 665);
            this.Controls.Add(this.draw_axiss);
            this.Controls.Add(this.valueAngle);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.ValueZDouble);
            this.Controls.Add(this.ValueYDouble);
            this.Controls.Add(this.valueXDouble);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.Shift);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.choose_proection);
            this.Controls.Add(this.choose_axis);
            this.Controls.Add(this.choose_polyhedron);
            this.Controls.Add(this.Save_in_file);
            this.Controls.Add(this.Download_from_file);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Download_from_file;
        private System.Windows.Forms.Button Save_in_file;
        private System.Windows.Forms.ComboBox choose_polyhedron;
        private System.Windows.Forms.ComboBox choose_axis;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox choose_proection;
        private System.Windows.Forms.Button Scale;
        private System.Windows.Forms.Button Shift;
        private System.Windows.Forms.Button Rotation;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.TextBox valueXDouble;
        private System.Windows.Forms.TextBox ValueYDouble;
        private System.Windows.Forms.TextBox ValueZDouble;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox valueAngle;
        private System.Windows.Forms.Button draw_axiss;
    }
}

