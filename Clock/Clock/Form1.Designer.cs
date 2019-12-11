namespace Clock
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dialBox = new System.Windows.Forms.PictureBox();
            this.hrBox = new System.Windows.Forms.PictureBox();
            this.minBox = new System.Windows.Forms.PictureBox();
            this.secBox = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dialBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dialBox
            // 
            this.dialBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialBox.BackColor = System.Drawing.Color.Transparent;
            this.dialBox.Location = new System.Drawing.Point(12, 12);
            this.dialBox.Name = "dialBox";
            this.dialBox.Size = new System.Drawing.Size(947, 1000);
            this.dialBox.TabIndex = 0;
            this.dialBox.TabStop = false;
            // 
            // hrBox
            // 
            this.hrBox.BackColor = System.Drawing.Color.Transparent;
            this.hrBox.Location = new System.Drawing.Point(12, 12);
            this.hrBox.Name = "hrBox";
            this.hrBox.Size = new System.Drawing.Size(800, 800);
            this.hrBox.TabIndex = 1;
            this.hrBox.TabStop = false;
            // 
            // minBox
            // 
            this.minBox.BackColor = System.Drawing.Color.Transparent;
            this.minBox.Location = new System.Drawing.Point(12, 12);
            this.minBox.Name = "minBox";
            this.minBox.Size = new System.Drawing.Size(800, 800);
            this.minBox.TabIndex = 2;
            this.minBox.TabStop = false;
            // 
            // secBox
            // 
            this.secBox.BackColor = System.Drawing.Color.Transparent;
            this.secBox.Location = new System.Drawing.Point(12, 12);
            this.secBox.Name = "secBox";
            this.secBox.Size = new System.Drawing.Size(800, 800);
            this.secBox.TabIndex = 3;
            this.secBox.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(818, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(250, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 961);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.minBox);
            this.Controls.Add(this.hrBox);
            this.Controls.Add(this.dialBox);
            this.Controls.Add(this.secBox);
            this.Name = "Form1";
            this.Text = "Clock";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dialBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox dialBox;
        private System.Windows.Forms.PictureBox hrBox;
        private System.Windows.Forms.PictureBox minBox;
        private System.Windows.Forms.PictureBox secBox;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

