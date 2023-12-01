namespace Lab_8
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            choose_polyh = new ComboBox();
            choose_axis = new ComboBox();
            draw_polyh = new Button();
            choose_proj = new ComboBox();
            Clear_but = new Button();
            load_polyn = new Button();
            save_polyh = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(276, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(927, 659);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // choose_polyh
            // 
            choose_polyh.FormattingEnabled = true;
            choose_polyh.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            choose_polyh.Location = new Point(12, 70);
            choose_polyh.Name = "choose_polyh";
            choose_polyh.Size = new Size(247, 28);
            choose_polyh.TabIndex = 1;
            choose_polyh.Text = "Выберите фигуру";
            choose_polyh.SelectedIndexChanged += choose_polyh_SelectedIndexChanged;
            // 
            // choose_axis
            // 
            choose_axis.FormattingEnabled = true;
            choose_axis.Items.AddRange(new object[] { "X", "Y", "Z" });
            choose_axis.Location = new Point(12, 104);
            choose_axis.Name = "choose_axis";
            choose_axis.Size = new Size(247, 28);
            choose_axis.TabIndex = 2;
            choose_axis.Text = "Выберите ось координат";
            choose_axis.SelectedIndexChanged += choose_axis_SelectedIndexChanged;
            // 
            // draw_polyh
            // 
            draw_polyh.Location = new Point(12, 12);
            draw_polyh.Name = "draw_polyh";
            draw_polyh.Size = new Size(247, 52);
            draw_polyh.TabIndex = 3;
            draw_polyh.Text = "Нарисовать фигуру";
            draw_polyh.UseVisualStyleBackColor = true;
            draw_polyh.Click += draw_polyh_Click;
            // 
            // choose_proj
            // 
            choose_proj.FormattingEnabled = true;
            choose_proj.Items.AddRange(new object[] { "Изометрия", "Аксонометрия", "Перспектива" });
            choose_proj.Location = new Point(12, 138);
            choose_proj.Name = "choose_proj";
            choose_proj.Size = new Size(247, 28);
            choose_proj.TabIndex = 4;
            choose_proj.Text = "Выберите проекцию";
            choose_proj.SelectedIndexChanged += choose_proj_SelectedIndexChanged;
            // 
            // Clear_but
            // 
            Clear_but.Location = new Point(12, 616);
            Clear_but.Name = "Clear_but";
            Clear_but.Size = new Size(247, 52);
            Clear_but.TabIndex = 5;
            Clear_but.Text = "Очистить";
            Clear_but.UseVisualStyleBackColor = true;
            Clear_but.Click += Clear_but_Click;
            // 
            // load_polyn
            // 
            load_polyn.Location = new Point(12, 172);
            load_polyn.Name = "load_polyn";
            load_polyn.Size = new Size(125, 52);
            load_polyn.TabIndex = 6;
            load_polyn.Text = "Загрузить фигуру";
            load_polyn.UseVisualStyleBackColor = true;
            load_polyn.Click += load_polyn_Click;
            // 
            // save_polyh
            // 
            save_polyh.Location = new Point(143, 172);
            save_polyh.Name = "save_polyh";
            save_polyh.Size = new Size(116, 52);
            save_polyh.TabIndex = 7;
            save_polyh.Text = "Сохранить фигуру";
            save_polyh.UseVisualStyleBackColor = true;
            save_polyh.Click += save_polyh_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 680);
            Controls.Add(save_polyh);
            Controls.Add(load_polyn);
            Controls.Add(Clear_but);
            Controls.Add(choose_proj);
            Controls.Add(draw_polyh);
            Controls.Add(choose_axis);
            Controls.Add(choose_polyh);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox choose_polyh;
        private ComboBox choose_axis;
        private Button draw_polyh;
        private ComboBox choose_proj;
        private Button Clear_but;
        private Button load_polyn;
        private Button save_polyh;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
