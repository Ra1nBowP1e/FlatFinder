namespace Курсач
{
    partial class AddAdvertisement
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
            this.button_add = new System.Windows.Forms.Button();
            this.textbox_cost = new System.Windows.Forms.TextBox();
            this.textBox_adress = new System.Windows.Forms.TextBox();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.textBox_author = new System.Windows.Forms.TextBox();
            this.textBox_authornumber = new System.Windows.Forms.TextBox();
            this.cost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.labelmagePath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_add
            // 
            this.button_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.button_add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_add.FlatAppearance.BorderSize = 0;
            this.button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button_add.Location = new System.Drawing.Point(0, 6);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(800, 46);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "Добавить объявление";
            this.button_add.UseVisualStyleBackColor = false;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // textbox_cost
            // 
            this.textbox_cost.Location = new System.Drawing.Point(124, 35);
            this.textbox_cost.Name = "textbox_cost";
            this.textbox_cost.Size = new System.Drawing.Size(229, 20);
            this.textbox_cost.TabIndex = 1;
            // 
            // textBox_adress
            // 
            this.textBox_adress.Location = new System.Drawing.Point(124, 85);
            this.textBox_adress.Name = "textBox_adress";
            this.textBox_adress.Size = new System.Drawing.Size(229, 20);
            this.textBox_adress.TabIndex = 2;
            // 
            // textBox_count
            // 
            this.textBox_count.Location = new System.Drawing.Point(124, 137);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.Size = new System.Drawing.Size(229, 20);
            this.textBox_count.TabIndex = 3;
            // 
            // textBox_author
            // 
            this.textBox_author.Location = new System.Drawing.Point(124, 189);
            this.textBox_author.Name = "textBox_author";
            this.textBox_author.Size = new System.Drawing.Size(229, 20);
            this.textBox_author.TabIndex = 4;
            // 
            // textBox_authornumber
            // 
            this.textBox_authornumber.Location = new System.Drawing.Point(124, 245);
            this.textBox_authornumber.Name = "textBox_authornumber";
            this.textBox_authornumber.Size = new System.Drawing.Size(229, 20);
            this.textBox_authornumber.TabIndex = 5;
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.cost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cost.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cost.Location = new System.Drawing.Point(12, 35);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(33, 13);
            this.cost.TabIndex = 6;
            this.cost.Text = "Цена";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Адресс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Количество комнат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(12, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Имя владельца";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(12, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Номер владельца";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(12, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Изображение";
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.buttonSelectImage.FlatAppearance.BorderSize = 0;
            this.buttonSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectImage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSelectImage.Location = new System.Drawing.Point(124, 348);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(229, 25);
            this.buttonSelectImage.TabIndex = 12;
            this.buttonSelectImage.Text = "Добавить изображение";
            this.buttonSelectImage.UseVisualStyleBackColor = false;
            this.buttonSelectImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // labelmagePath
            // 
            this.labelmagePath.AutoSize = true;
            this.labelmagePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.labelmagePath.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelmagePath.Location = new System.Drawing.Point(121, 382);
            this.labelmagePath.Name = "labelmagePath";
            this.labelmagePath.Size = new System.Drawing.Size(113, 13);
            this.labelmagePath.TabIndex = 13;
            this.labelmagePath.Text = "Путь к изображению";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBoxDescription);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labelmagePath);
            this.panel1.Controls.Add(this.cost);
            this.panel1.Controls.Add(this.buttonSelectImage);
            this.panel1.Controls.Add(this.textbox_cost);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_authornumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_adress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_author);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_count);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 14;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(124, 298);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(229, 20);
            this.textBoxDescription.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Описание";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 52);
            this.panel2.TabIndex = 16;
            // 
            // AddAdvertisement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "AddAdvertisement";
            this.Text = "Создать объявление";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.TextBox textbox_cost;
        private System.Windows.Forms.TextBox textBox_adress;
        private System.Windows.Forms.TextBox textBox_count;
        private System.Windows.Forms.TextBox textBox_author;
        private System.Windows.Forms.TextBox textBox_authornumber;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.Label labelmagePath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
    }
}