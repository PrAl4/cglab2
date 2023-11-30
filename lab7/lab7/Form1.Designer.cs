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
            this.choose_polyhedron.Location = new System.Drawing.Point(15, 242);
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
            this.choose_axis.Location = new System.Drawing.Point(15, 272);
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
            this.choose_proection.Location = new System.Drawing.Point(16, 302);
            this.choose_proection.Name = "choose_proection";
            this.choose_proection.Size = new System.Drawing.Size(174, 24);
            this.choose_proection.TabIndex = 5;
            this.choose_proection.Text = "Выберите проекцию";
            this.choose_proection.SelectedIndexChanged += new System.EventHandler(this.choose_proection_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 665);
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
    }
}

