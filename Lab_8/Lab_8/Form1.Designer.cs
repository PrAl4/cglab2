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
            LeftRight = new TrackBar();
            UpDown = new TrackBar();
            BackForward = new TrackBar();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            NonFaceButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LeftRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackForward).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(538, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1128, 659);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // choose_polyh
            // 
            choose_polyh.FormattingEnabled = true;
            choose_polyh.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            choose_polyh.Location = new Point(12, 70);
            choose_polyh.Name = "choose_polyh";
            choose_polyh.Size = new Size(213, 28);
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
            choose_axis.Size = new Size(213, 28);
            choose_axis.TabIndex = 2;
            choose_axis.Text = "Выберите ось координат";
            choose_axis.SelectedIndexChanged += choose_axis_SelectedIndexChanged;
            // 
            // draw_polyh
            // 
            draw_polyh.Location = new Point(12, 12);
            draw_polyh.Name = "draw_polyh";
            draw_polyh.Size = new Size(213, 52);
            draw_polyh.TabIndex = 3;
            draw_polyh.Text = "Нарисовать фигуру";
            draw_polyh.UseVisualStyleBackColor = true;
            draw_polyh.Click += draw_polyh_Click;
            // 
            // choose_proj
            // 
            choose_proj.FormattingEnabled = true;
            choose_proj.Items.AddRange(new object[] { "Изометрия", "Аксонометрия", "Перспектива", "Параллель" });
            choose_proj.Location = new Point(12, 138);
            choose_proj.Name = "choose_proj";
            choose_proj.Size = new Size(213, 28);
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
            load_polyn.Size = new Size(213, 52);
            load_polyn.TabIndex = 6;
            load_polyn.Text = "Загрузить фигуру";
            load_polyn.UseVisualStyleBackColor = true;
            load_polyn.Click += load_polyn_Click;
            // 
            // save_polyh
            // 
            save_polyh.Location = new Point(12, 230);
            save_polyh.Name = "save_polyh";
            save_polyh.Size = new Size(213, 52);
            save_polyh.TabIndex = 7;
            save_polyh.Text = "Сохранить фигуру";
            save_polyh.UseVisualStyleBackColor = true;
            save_polyh.Click += save_polyh_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LeftRight
            // 
            LeftRight.Location = new Point(382, 12);
            LeftRight.Name = "LeftRight";
            LeftRight.Size = new Size(150, 56);
            LeftRight.TabIndex = 8;
            LeftRight.Scroll += LeftRight_Scroll;
            LeftRight.Maximum = 50;
            LeftRight.Minimum = -50;
            LeftRight.TickFrequency = 5;
            LeftRight.LargeChange = 3;
            LeftRight.SmallChange = 2;
            // 
            // UpDown
            // 
            UpDown.Location = new Point(382, 70);
            UpDown.Name = "UpDown";
            UpDown.Size = new Size(150, 56);
            UpDown.TabIndex = 9;
            UpDown.Scroll += UpDown_Scroll;
            UpDown.Maximum = 50;
            UpDown.Minimum = -50;
            UpDown.TickFrequency = 5;
            UpDown.LargeChange = 3;
            UpDown.SmallChange = 2;
            // 
            // BackForward
            // 
            BackForward.Location = new Point(382, 132);
            BackForward.Name = "BackForward";
            BackForward.Size = new Size(150, 56);
            BackForward.TabIndex = 10;
            BackForward.Scroll += BackForward_Scroll;
            BackForward.Maximum = 50;
            BackForward.Minimum = -50;
            BackForward.TickFrequency = 5;
            BackForward.LargeChange = 3;
            BackForward.SmallChange = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(239, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(147, 27);
            textBox1.TabIndex = 11;
            textBox1.Text = "Влево - Вправо";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(239, 70);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(147, 27);
            textBox2.TabIndex = 12;
            textBox2.Text = "Вниз - Вверх";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(239, 132);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(147, 27);
            textBox3.TabIndex = 13;
            textBox3.Text = "Назад - Вперед";
            // 
            // NonFaceButton
            // 
            NonFaceButton.Location = new Point(12, 288);
            NonFaceButton.Name = "NonFaceButton";
            NonFaceButton.Size = new Size(213, 52);
            NonFaceButton.TabIndex = 14;
            NonFaceButton.Text = "Отсечение граней";
            NonFaceButton.UseVisualStyleBackColor = true;
            NonFaceButton.Click += NonFaceButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1678, 680);
            Controls.Add(NonFaceButton);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(BackForward);
            Controls.Add(UpDown);
            Controls.Add(LeftRight);
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
            ((System.ComponentModel.ISupportInitialize)LeftRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackForward).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TrackBar LeftRight;
        private TrackBar UpDown;
        private TrackBar BackForward;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button NonFaceButton;
    }
}
