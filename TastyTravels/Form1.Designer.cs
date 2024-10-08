namespace WindowsFormsApp1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.RNameTB = new System.Windows.Forms.TextBox();
            this.RCookingTimeTB = new System.Windows.Forms.TextBox();
            this.RCcalTB = new System.Windows.Forms.TextBox();
            this.RDefinitionTB = new System.Windows.Forms.TextBox();
            this.SelectImageButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StepLabel = new System.Windows.Forms.Label();
            this.DefenitionTB = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PreviousPictureButton = new System.Windows.Forms.Button();
            this.NextPictureButton = new System.Windows.Forms.Button();
            this.RCarbsTB = new System.Windows.Forms.TextBox();
            this.RFatsTB = new System.Windows.Forms.TextBox();
            this.RProteinTB = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.NextStepButton = new System.Windows.Forms.Button();
            this.PreviousStepButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RNameTB
            // 
            this.RNameTB.Location = new System.Drawing.Point(57, 34);
            this.RNameTB.Name = "RNameTB";
            this.RNameTB.Size = new System.Drawing.Size(238, 20);
            this.RNameTB.TabIndex = 0;
            this.RNameTB.Text = "Название рецепта";
            // 
            // RCookingTimeTB
            // 
            this.RCookingTimeTB.Location = new System.Drawing.Point(67, 490);
            this.RCookingTimeTB.Name = "RCookingTimeTB";
            this.RCookingTimeTB.Size = new System.Drawing.Size(228, 20);
            this.RCookingTimeTB.TabIndex = 2;
            this.RCookingTimeTB.Text = "Время приготовления";
            // 
            // RCcalTB
            // 
            this.RCcalTB.Location = new System.Drawing.Point(67, 516);
            this.RCcalTB.Name = "RCcalTB";
            this.RCcalTB.Size = new System.Drawing.Size(228, 20);
            this.RCcalTB.TabIndex = 3;
            this.RCcalTB.Text = "Калорийность";
            // 
            // RDefinitionTB
            // 
            this.RDefinitionTB.Location = new System.Drawing.Point(57, 387);
            this.RDefinitionTB.Multiline = true;
            this.RDefinitionTB.Name = "RDefinitionTB";
            this.RDefinitionTB.Size = new System.Drawing.Size(507, 97);
            this.RDefinitionTB.TabIndex = 4;
            this.RDefinitionTB.Text = "Описание";
            // 
            // SelectImageButton
            // 
            this.SelectImageButton.Location = new System.Drawing.Point(207, 343);
            this.SelectImageButton.Name = "SelectImageButton";
            this.SelectImageButton.Size = new System.Drawing.Size(198, 38);
            this.SelectImageButton.TabIndex = 7;
            this.SelectImageButton.Text = "Добавить картинку";
            this.SelectImageButton.UseVisualStyleBackColor = true;
            this.SelectImageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(57, 610);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(507, 150);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(64, 809);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(36, 13);
            this.StepLabel.TabIndex = 9;
            this.StepLabel.Text = "Шаг 1";
            // 
            // DefenitionTB
            // 
            this.DefenitionTB.Location = new System.Drawing.Point(57, 838);
            this.DefenitionTB.Multiline = true;
            this.DefenitionTB.Name = "DefenitionTB";
            this.DefenitionTB.Size = new System.Drawing.Size(507, 113);
            this.DefenitionTB.TabIndex = 10;
            this.DefenitionTB.Text = "Описание";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 1222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(507, 38);
            this.button2.TabIndex = 11;
            this.button2.Text = "Добавить картинку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(78, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(451, 259);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // PreviousPictureButton
            // 
            this.PreviousPictureButton.Location = new System.Drawing.Point(49, 78);
            this.PreviousPictureButton.Name = "PreviousPictureButton";
            this.PreviousPictureButton.Size = new System.Drawing.Size(23, 259);
            this.PreviousPictureButton.TabIndex = 14;
            this.PreviousPictureButton.Text = "<";
            this.PreviousPictureButton.UseVisualStyleBackColor = true;
            this.PreviousPictureButton.Click += new System.EventHandler(this.PreviousPictureButton_Click);
            // 
            // NextPictureButton
            // 
            this.NextPictureButton.Location = new System.Drawing.Point(535, 78);
            this.NextPictureButton.Name = "NextPictureButton";
            this.NextPictureButton.Size = new System.Drawing.Size(23, 259);
            this.NextPictureButton.TabIndex = 15;
            this.NextPictureButton.Text = ">";
            this.NextPictureButton.UseVisualStyleBackColor = true;
            this.NextPictureButton.Click += new System.EventHandler(this.NextPictureButton_Click);
            // 
            // RCarbsTB
            // 
            this.RCarbsTB.Location = new System.Drawing.Point(67, 568);
            this.RCarbsTB.Name = "RCarbsTB";
            this.RCarbsTB.Size = new System.Drawing.Size(228, 20);
            this.RCarbsTB.TabIndex = 16;
            this.RCarbsTB.Text = "Углеводы";
            // 
            // RFatsTB
            // 
            this.RFatsTB.Location = new System.Drawing.Point(324, 516);
            this.RFatsTB.Name = "RFatsTB";
            this.RFatsTB.Size = new System.Drawing.Size(228, 20);
            this.RFatsTB.TabIndex = 17;
            this.RFatsTB.Text = "Жиры";
            // 
            // RProteinTB
            // 
            this.RProteinTB.Location = new System.Drawing.Point(67, 542);
            this.RProteinTB.Name = "RProteinTB";
            this.RProteinTB.Size = new System.Drawing.Size(228, 20);
            this.RProteinTB.TabIndex = 18;
            this.RProteinTB.Text = "Белки";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(57, 957);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(507, 259);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(570, 822);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(23, 438);
            this.NextStepButton.TabIndex = 22;
            this.NextStepButton.Text = ">";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousStepButton
            // 
            this.PreviousStepButton.Location = new System.Drawing.Point(25, 822);
            this.PreviousStepButton.Name = "PreviousStepButton";
            this.PreviousStepButton.Size = new System.Drawing.Size(23, 438);
            this.PreviousStepButton.TabIndex = 21;
            this.PreviousStepButton.Text = "<";
            this.PreviousStepButton.UseVisualStyleBackColor = true;
            this.PreviousStepButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(324, 489);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 21);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(25, 1266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(568, 70);
            this.button1.TabIndex = 24;
            this.button1.Text = "Добавить рецепт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(625, 784);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.NextStepButton);
            this.Controls.Add(this.PreviousStepButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.RProteinTB);
            this.Controls.Add(this.RFatsTB);
            this.Controls.Add(this.RCarbsTB);
            this.Controls.Add(this.NextPictureButton);
            this.Controls.Add(this.PreviousPictureButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DefenitionTB);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.SelectImageButton);
            this.Controls.Add(this.RDefinitionTB);
            this.Controls.Add(this.RCcalTB);
            this.Controls.Add(this.RCookingTimeTB);
            this.Controls.Add(this.RNameTB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox RNameTB;
        private System.Windows.Forms.TextBox RCookingTimeTB;
        private System.Windows.Forms.TextBox RCcalTB;
        private System.Windows.Forms.TextBox RDefinitionTB;
        private System.Windows.Forms.Button SelectImageButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.TextBox DefenitionTB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PreviousPictureButton;
        private System.Windows.Forms.Button NextPictureButton;
        private System.Windows.Forms.TextBox RCarbsTB;
        private System.Windows.Forms.TextBox RFatsTB;
        private System.Windows.Forms.TextBox RProteinTB;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.Button PreviousStepButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

