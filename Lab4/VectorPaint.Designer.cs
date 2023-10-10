namespace WindowsFormsApp1
{
    partial class VectorPaint
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_add_polygon = new System.Windows.Forms.Button();
            this.canvas12 = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.cur_info = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.with_bar = new System.Windows.Forms.TrackBar();
            this.btn_apply = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.canvas12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add_polygon
            // 
            this.btn_add_polygon.Location = new System.Drawing.Point(0, 23);
            this.btn_add_polygon.Name = "btn_add_polygon";
            this.btn_add_polygon.Size = new System.Drawing.Size(97, 89);
            this.btn_add_polygon.TabIndex = 0;
            this.btn_add_polygon.Text = "Добавить точку";
            this.btn_add_polygon.UseVisualStyleBackColor = true;
            this.btn_add_polygon.Click += new System.EventHandler(this.btn_add_polygon_Click);
            // 
            // canvas12
            // 
            this.canvas12.BackColor = System.Drawing.SystemColors.Control;
            this.canvas12.Location = new System.Drawing.Point(8, 118);
            this.canvas12.Name = "canvas12";
            this.canvas12.Size = new System.Drawing.Size(550, 343);
            this.canvas12.TabIndex = 1;
            this.canvas12.TabStop = false;
            this.canvas12.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(212, 23);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(94, 89);
            this.btn_clear.TabIndex = 2;
            this.btn_clear.Text = "Отчистить ";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // cur_info
            // 
            this.cur_info.AutoSize = true;
            this.cur_info.Location = new System.Drawing.Point(362, 23);
            this.cur_info.Name = "cur_info";
            this.cur_info.Size = new System.Drawing.Size(33, 13);
            this.cur_info.TabIndex = 3;
            this.cur_info.Text = "инфо";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(362, 61);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(40, 13);
            this.status.TabIndex = 4;
            this.status.Text = "статус";
            this.status.Click += new System.EventHandler(this.status_Click);
            // 
            // with_bar
            // 
            this.with_bar.Location = new System.Drawing.Point(572, 293);
            this.with_bar.Minimum = 1;
            this.with_bar.Name = "with_bar";
            this.with_bar.Size = new System.Drawing.Size(119, 45);
            this.with_bar.TabIndex = 68;
            this.with_bar.Value = 5;
            this.with_bar.ValueChanged += new System.EventHandler(this.with_bar_ValueChanged);
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(103, 23);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(103, 89);
            this.btn_apply.TabIndex = 6;
            this.btn_apply.Text = "Создать полигон из точек";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.MenuText;
            this.button4.Location = new System.Drawing.Point(572, 130);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 43);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Location = new System.Drawing.Point(574, 211);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 44);
            this.button5.TabIndex = 8;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btn_color_2_Click);
            // 
            // VectorPaint
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.with_bar);
            this.Controls.Add(this.status);
            this.Controls.Add(this.cur_info);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.canvas12);
            this.Controls.Add(this.btn_add_polygon);
            this.Name = "VectorPaint";
            this.Size = new System.Drawing.Size(835, 480);
            ((System.ComponentModel.ISupportInitialize)(this.canvas12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.with_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_add_polygon;
        private System.Windows.Forms.PictureBox canvas12;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label cur_info;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TrackBar with_bar;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
    }
}
