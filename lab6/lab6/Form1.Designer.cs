using System.Drawing;

namespace lab6
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
            this.displayingShape = new System.Windows.Forms.Button();
            this.Tetr = new System.Windows.Forms.RadioButton();
            this.Oct = new System.Windows.Forms.RadioButton();
            this.Geks = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ReflectionShape = new System.Windows.Forms.Button();
            this.coordinates = new System.Windows.Forms.ComboBox();
            this.sclaing = new System.Windows.Forms.Button();
            this.RotationAxis = new System.Windows.Forms.Button();
            this.RotationArbitary = new System.Windows.Forms.Button();
            this.rotationCoorditates = new System.Windows.Forms.ComboBox();
            this.projectionType = new System.Windows.Forms.ComboBox();
            this.ShowAxis = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // displayingShape
            // 
            this.displayingShape.Location = new System.Drawing.Point(10, 11);
            this.displayingShape.Name = "displayingShape";
            this.displayingShape.Size = new System.Drawing.Size(145, 53);
            this.displayingShape.TabIndex = 0;
            this.displayingShape.Text = "Отобразить фигуру";
            this.displayingShape.UseVisualStyleBackColor = true;
            this.displayingShape.Click += new System.EventHandler(this.displayingShape_Click);
            // 
            // Tetr
            // 
            this.Tetr.AutoSize = true;
            this.Tetr.Location = new System.Drawing.Point(10, 70);
            this.Tetr.Name = "Tetr";
            this.Tetr.Size = new System.Drawing.Size(92, 20);
            this.Tetr.TabIndex = 1;
            this.Tetr.TabStop = true;
            this.Tetr.Text = "Тэтраэдр";
            this.Tetr.UseVisualStyleBackColor = true;
            this.Tetr.CheckedChanged += new System.EventHandler(this.Tetr_CheckedChanged);
            // 
            // Oct
            // 
            this.Oct.AutoSize = true;
            this.Oct.Location = new System.Drawing.Point(10, 122);
            this.Oct.Name = "Oct";
            this.Oct.Size = new System.Drawing.Size(84, 20);
            this.Oct.TabIndex = 2;
            this.Oct.TabStop = true;
            this.Oct.Text = "Октаэдр";
            this.Oct.UseVisualStyleBackColor = true;
            this.Oct.CheckedChanged += new System.EventHandler(this.Oct_CheckedChanged);
            // 
            // Geks
            // 
            this.Geks.AutoSize = true;
            this.Geks.Location = new System.Drawing.Point(10, 96);
            this.Geks.Name = "Geks";
            this.Geks.Size = new System.Drawing.Size(89, 20);
            this.Geks.TabIndex = 2;
            this.Geks.TabStop = true;
            this.Geks.Text = "Гексаэдр";
            this.Geks.UseVisualStyleBackColor = true;
            this.Geks.CheckedChanged += new System.EventHandler(this.Geks_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(247, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1022, 741);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ReflectionShape
            // 
            this.ReflectionShape.Location = new System.Drawing.Point(10, 273);
            this.ReflectionShape.Name = "ReflectionShape";
            this.ReflectionShape.Size = new System.Drawing.Size(145, 53);
            this.ReflectionShape.TabIndex = 4;
            this.ReflectionShape.Text = "Отразить фигуру";
            this.ReflectionShape.UseVisualStyleBackColor = true;
            this.ReflectionShape.Click += new System.EventHandler(this.ReflectionShape_Click);
            // 
            // coordinates
            // 
            this.coordinates.FormattingEnabled = true;
            this.coordinates.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.coordinates.Location = new System.Drawing.Point(10, 332);
            this.coordinates.Name = "coordinates";
            this.coordinates.Size = new System.Drawing.Size(121, 24);
            this.coordinates.TabIndex = 5;
            this.coordinates.Text = "Координата";
            this.coordinates.SelectedIndexChanged += new System.EventHandler(this.coordinates_SelectedIndexChanged);
            // 
            // sclaing
            // 
            this.sclaing.Location = new System.Drawing.Point(10, 376);
            this.sclaing.Name = "sclaing";
            this.sclaing.Size = new System.Drawing.Size(145, 53);
            this.sclaing.TabIndex = 6;
            this.sclaing.Text = "Масштабирование";
            this.sclaing.UseVisualStyleBackColor = true;
            this.sclaing.Click += new System.EventHandler(this.sclaing_Click);
            // 
            // RotationAxis
            // 
            this.RotationAxis.Location = new System.Drawing.Point(10, 497);
            this.RotationAxis.Name = "RotationAxis";
            this.RotationAxis.Size = new System.Drawing.Size(145, 53);
            this.RotationAxis.TabIndex = 7;
            this.RotationAxis.Text = "Вращение вокруг оси";
            this.RotationAxis.UseVisualStyleBackColor = true;
            this.RotationAxis.Click += new System.EventHandler(this.RotationAxis_Click);
            // 
            // RotationArbitary
            // 
            this.RotationArbitary.Location = new System.Drawing.Point(10, 556);
            this.RotationArbitary.Name = "RotationArbitary";
            this.RotationArbitary.Size = new System.Drawing.Size(145, 53);
            this.RotationArbitary.TabIndex = 8;
            this.RotationArbitary.Text = "Вращение вокруг произвольной";
            this.RotationArbitary.UseVisualStyleBackColor = true;
            this.RotationArbitary.Click += new System.EventHandler(this.RotationArbitary_Click);
            // 
            // rotationCoorditates
            // 
            this.rotationCoorditates.FormattingEnabled = true;
            this.rotationCoorditates.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.rotationCoorditates.Location = new System.Drawing.Point(10, 615);
            this.rotationCoorditates.Name = "rotationCoorditates";
            this.rotationCoorditates.Size = new System.Drawing.Size(121, 24);
            this.rotationCoorditates.TabIndex = 10;
            this.rotationCoorditates.Text = "Координата";
            // 
            // projectionType
            // 
            this.projectionType.FormattingEnabled = true;
            this.projectionType.Items.AddRange(new object[] {
            "Изометрия",
            "Аксонометрия",
            "Перспектива"});
            this.projectionType.Location = new System.Drawing.Point(10, 158);
            this.projectionType.Name = "projectionType";
            this.projectionType.Size = new System.Drawing.Size(121, 24);
            this.projectionType.TabIndex = 11;
            this.projectionType.Text = "Проекция";
            this.projectionType.SelectedIndexChanged += new System.EventHandler(this.projectionType_SelectedIndexChanged);
            // 
            // ShowAxis
            // 
            this.ShowAxis.Location = new System.Drawing.Point(10, 214);
            this.ShowAxis.Name = "ShowAxis";
            this.ShowAxis.Size = new System.Drawing.Size(145, 53);
            this.ShowAxis.TabIndex = 12;
            this.ShowAxis.Text = "Показать координатную ось";
            this.ShowAxis.UseVisualStyleBackColor = true;
            this.ShowAxis.Click += new System.EventHandler(this.ShowAxis_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(10, 694);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(145, 53);
            this.Clear.TabIndex = 13;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 759);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.ShowAxis);
            this.Controls.Add(this.projectionType);
            this.Controls.Add(this.rotationCoorditates);
            this.Controls.Add(this.RotationArbitary);
            this.Controls.Add(this.RotationAxis);
            this.Controls.Add(this.sclaing);
            this.Controls.Add(this.coordinates);
            this.Controls.Add(this.ReflectionShape);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Geks);
            this.Controls.Add(this.Oct);
            this.Controls.Add(this.Tetr);
            this.Controls.Add(this.displayingShape);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button displayingShape;
        private System.Windows.Forms.RadioButton Tetr;
        private System.Windows.Forms.RadioButton Oct;
        private System.Windows.Forms.RadioButton Geks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ReflectionShape;
        private System.Windows.Forms.ComboBox coordinates;
        private System.Windows.Forms.Button sclaing;
        private System.Windows.Forms.Button RotationAxis;
        private System.Windows.Forms.Button RotationArbitary;
        private System.Windows.Forms.ComboBox rotationCoorditates;
        private System.Windows.Forms.ComboBox projectionType;
        private System.Windows.Forms.Button ShowAxis;
        private System.Windows.Forms.Button Clear;
    }
}

