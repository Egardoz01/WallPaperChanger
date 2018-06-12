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
            System.Windows.Forms.Button btnStart;
            System.Windows.Forms.Button btnStop;
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.cbInterval = new System.Windows.Forms.ComboBox();
            this.cbChangeWithStart = new System.Windows.Forms.CheckBox();
            this.cbRememberSeenImg = new System.Windows.Forms.CheckBox();
            this.cbChangeWithStop = new System.Windows.Forms.CheckBox();
            this.cbChangeWithNewInterval = new System.Windows.Forms.CheckBox();
            btnStart = new System.Windows.Forms.Button();
            btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(207, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(124, 31);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            btnStop.Location = new System.Drawing.Point(207, 57);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(124, 31);
            btnStop.TabIndex = 4;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbInterval
            // 
            this.cbInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterval.FormattingEnabled = true;
            this.cbInterval.Location = new System.Drawing.Point(12, 12);
            this.cbInterval.Name = "cbInterval";
            this.cbInterval.Size = new System.Drawing.Size(179, 21);
            this.cbInterval.TabIndex = 2;
            this.cbInterval.SelectedIndexChanged += new System.EventHandler(this.cbInterval_SelectedIndexChanged);
            // 
            // cbChangeWithStart
            // 
            this.cbChangeWithStart.AutoSize = true;
            this.cbChangeWithStart.Location = new System.Drawing.Point(12, 65);
            this.cbChangeWithStart.Name = "cbChangeWithStart";
            this.cbChangeWithStart.Size = new System.Drawing.Size(107, 17);
            this.cbChangeWithStart.TabIndex = 5;
            this.cbChangeWithStart.Text = "change with start";
            this.cbChangeWithStart.UseVisualStyleBackColor = true;
            // 
            // cbRememberSeenImg
            // 
            this.cbRememberSeenImg.AutoSize = true;
            this.cbRememberSeenImg.Location = new System.Drawing.Point(12, 89);
            this.cbRememberSeenImg.Name = "cbRememberSeenImg";
            this.cbRememberSeenImg.Size = new System.Drawing.Size(134, 17);
            this.cbRememberSeenImg.TabIndex = 6;
            this.cbRememberSeenImg.Text = "remember seen images";
            this.cbRememberSeenImg.UseVisualStyleBackColor = true;
            // 
            // cbChangeWithStop
            // 
            this.cbChangeWithStop.AutoSize = true;
            this.cbChangeWithStop.Location = new System.Drawing.Point(12, 113);
            this.cbChangeWithStop.Name = "cbChangeWithStop";
            this.cbChangeWithStop.Size = new System.Drawing.Size(107, 17);
            this.cbChangeWithStop.TabIndex = 7;
            this.cbChangeWithStop.Text = "change with stop";
            this.cbChangeWithStop.UseVisualStyleBackColor = true;
            // 
            // cbChangeWithNewInterval
            // 
            this.cbChangeWithNewInterval.AutoSize = true;
            this.cbChangeWithNewInterval.Location = new System.Drawing.Point(12, 137);
            this.cbChangeWithNewInterval.Name = "cbChangeWithNewInterval";
            this.cbChangeWithNewInterval.Size = new System.Drawing.Size(144, 17);
            this.cbChangeWithNewInterval.TabIndex = 8;
            this.cbChangeWithNewInterval.Text = "change with new interval";
            this.cbChangeWithNewInterval.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 262);
            this.Controls.Add(this.cbChangeWithNewInterval);
            this.Controls.Add(this.cbChangeWithStop);
            this.Controls.Add(this.cbRememberSeenImg);
            this.Controls.Add(this.cbChangeWithStart);
            this.Controls.Add(btnStop);
            this.Controls.Add(btnStart);
            this.Controls.Add(this.cbInterval);
            this.Name = "Form1";
            this.Text = "Wallpaper Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ComboBox cbInterval;
        private System.Windows.Forms.CheckBox cbChangeWithStart;
        private System.Windows.Forms.CheckBox cbRememberSeenImg;
        private System.Windows.Forms.CheckBox cbChangeWithStop;
        private System.Windows.Forms.CheckBox cbChangeWithNewInterval;
    }
}

