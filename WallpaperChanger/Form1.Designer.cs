namespace WallpaperChanger
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
            this.labelfilename = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Interval = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelfilename
            // 
            this.labelfilename.AutoSize = true;
            this.labelfilename.Location = new System.Drawing.Point(12, 227);
            this.labelfilename.Name = "labelfilename";
            this.labelfilename.Size = new System.Drawing.Size(262, 13);
            this.labelfilename.TabIndex = 0;
            this.labelfilename.Text = "C:\\Users\\Егардоз\\Pictures\\обои\\arsenii\'s funetal.jpg";
            this.labelfilename.Click += new System.EventHandler(this.labelfilename_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 115);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vjuh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Interval
            // 
            this.Interval.FormattingEnabled = true;
            this.Interval.Location = new System.Drawing.Point(247, 46);
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(179, 21);
            this.Interval.TabIndex = 2;
            this.Interval.SelectedIndexChanged += new System.EventHandler(this.Interval_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 261);
            this.Controls.Add(this.Interval);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelfilename);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labelfilename;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ComboBox Interval;
    }
}

