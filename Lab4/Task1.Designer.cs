namespace WindowsFormsApp1
{
    partial class Task1
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
            this.vectorPaint1 = new WindowsFormsApp1.VectorPaint();
            this.SuspendLayout();
            // 
            // vectorPaint1
            // 
            this.vectorPaint1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.vectorPaint1.Location = new System.Drawing.Point(3, 1);
            this.vectorPaint1.Name = "vectorPaint1";
            this.vectorPaint1.Size = new System.Drawing.Size(866, 536);
            this.vectorPaint1.TabIndex = 0;
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 531);
            this.Controls.Add(this.vectorPaint1);
            this.Name = "Task1";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Task1_FormClosing);
            this.Load += new System.EventHandler(this.Task1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VectorPaint vectorPaint1;
    }
}