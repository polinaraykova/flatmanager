
namespace Reg
{
    partial class ManagerForm
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
            this.components = new System.ComponentModel.Container();
            this.addresTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.squareTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rentTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.descrTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rateTextBox = new System.Windows.Forms.TextBox();
            this.addFlat = new System.Windows.Forms.Button();
            this.FlatsListBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.orderBtn = new System.Windows.Forms.Button();
            this.orderedBtn = new System.Windows.Forms.Button();
            this.UsersListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.banBtn = new System.Windows.Forms.Button();
            this.unbanBtn = new System.Windows.Forms.Button();
            this.flatsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.flatsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.flatsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addresTextBox
            // 
            this.addresTextBox.Location = new System.Drawing.Point(25, 57);
            this.addresTextBox.Name = "addresTextBox";
            this.addresTextBox.Size = new System.Drawing.Size(133, 20);
            this.addresTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Площадь";
            // 
            // squareTextBox
            // 
            this.squareTextBox.Location = new System.Drawing.Point(164, 57);
            this.squareTextBox.Name = "squareTextBox";
            this.squareTextBox.Size = new System.Drawing.Size(133, 20);
            this.squareTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кол-во комнат";
            // 
            // numTextBox
            // 
            this.numTextBox.Location = new System.Drawing.Point(303, 57);
            this.numTextBox.Name = "numTextBox";
            this.numTextBox.Size = new System.Drawing.Size(133, 20);
            this.numTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Аренда в сутки";
            // 
            // rentTextBox
            // 
            this.rentTextBox.Location = new System.Drawing.Point(442, 57);
            this.rentTextBox.Name = "rentTextBox";
            this.rentTextBox.Size = new System.Drawing.Size(133, 20);
            this.rentTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Описание";
            // 
            // descrTextBox
            // 
            this.descrTextBox.Location = new System.Drawing.Point(25, 112);
            this.descrTextBox.Name = "descrTextBox";
            this.descrTextBox.Size = new System.Drawing.Size(272, 88);
            this.descrTextBox.TabIndex = 10;
            this.descrTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Статус";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(325, 128);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(133, 20);
            this.statusTextBox.TabIndex = 11;
            this.statusTextBox.Text = "0";
            this.statusTextBox.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Оценка";
            this.label7.Visible = false;
            // 
            // rateTextBox
            // 
            this.rateTextBox.Location = new System.Drawing.Point(325, 180);
            this.rateTextBox.Name = "rateTextBox";
            this.rateTextBox.Size = new System.Drawing.Size(133, 20);
            this.rateTextBox.TabIndex = 13;
            this.rateTextBox.Text = "0";
            this.rateTextBox.Visible = false;
            // 
            // addFlat
            // 
            this.addFlat.Location = new System.Drawing.Point(464, 164);
            this.addFlat.Name = "addFlat";
            this.addFlat.Size = new System.Drawing.Size(111, 36);
            this.addFlat.TabIndex = 15;
            this.addFlat.Text = "Добавить";
            this.addFlat.UseVisualStyleBackColor = true;
            this.addFlat.Click += new System.EventHandler(this.addFlat_Click);
            // 
            // FlatsListBox
            // 
            this.FlatsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.FlatsListBox.FormattingEnabled = true;
            this.FlatsListBox.Location = new System.Drawing.Point(25, 244);
            this.FlatsListBox.Name = "FlatsListBox";
            this.FlatsListBox.Size = new System.Drawing.Size(759, 108);
            this.FlatsListBox.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Квартиры";
            // 
            // orderBtn
            // 
            this.orderBtn.Location = new System.Drawing.Point(581, 359);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(203, 26);
            this.orderBtn.TabIndex = 18;
            this.orderBtn.Text = "Одобрить заявку на аренду";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // orderedBtn
            // 
            this.orderedBtn.Location = new System.Drawing.Point(25, 359);
            this.orderedBtn.Name = "orderedBtn";
            this.orderedBtn.Size = new System.Drawing.Size(203, 26);
            this.orderedBtn.TabIndex = 19;
            this.orderedBtn.Text = "Просмотреть договор";
            this.orderedBtn.UseVisualStyleBackColor = true;
            this.orderedBtn.Click += new System.EventHandler(this.orderedBtn_Click);
            // 
            // UsersListBox
            // 
            this.UsersListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.UsersListBox.FormattingEnabled = true;
            this.UsersListBox.Location = new System.Drawing.Point(25, 478);
            this.UsersListBox.Name = "UsersListBox";
            this.UsersListBox.Size = new System.Drawing.Size(759, 108);
            this.UsersListBox.TabIndex = 20;
            this.UsersListBox.SelectedIndexChanged += new System.EventHandler(this.UsersListBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "клиенты";
            // 
            // banBtn
            // 
            this.banBtn.Location = new System.Drawing.Point(25, 592);
            this.banBtn.Name = "banBtn";
            this.banBtn.Size = new System.Drawing.Size(203, 26);
            this.banBtn.TabIndex = 22;
            this.banBtn.Text = "Заблокировать клиента";
            this.banBtn.UseVisualStyleBackColor = true;
            this.banBtn.Click += new System.EventHandler(this.banBtn_Click);
            // 
            // unbanBtn
            // 
            this.unbanBtn.Location = new System.Drawing.Point(581, 592);
            this.unbanBtn.Name = "unbanBtn";
            this.unbanBtn.Size = new System.Drawing.Size(203, 26);
            this.unbanBtn.TabIndex = 23;
            this.unbanBtn.Text = "Разблокировать клиента";
            this.unbanBtn.UseVisualStyleBackColor = true;
            this.unbanBtn.Click += new System.EventHandler(this.unbanBtn_Click);
            // 
            // flatsBindingSource1
            // 
            this.flatsBindingSource1.DataSource = typeof(Reg.Flats);
            // 
            // flatsBindingSource
            // 
            this.flatsBindingSource.DataSource = typeof(Reg.Flats);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 644);
            this.Controls.Add(this.unbanBtn);
            this.Controls.Add(this.banBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.UsersListBox);
            this.Controls.Add(this.orderedBtn);
            this.Controls.Add(this.orderBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FlatsListBox);
            this.Controls.Add(this.addFlat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rateTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.descrTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rentTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.squareTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addresTextBox);
            this.Name = "ManagerForm";
            this.Text = "Форма менеджера";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flatsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addresTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox squareTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rentTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox descrTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rateTextBox;
        private System.Windows.Forms.Button addFlat;
        private System.Windows.Forms.ListBox FlatsListBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Button orderedBtn;
        private System.Windows.Forms.BindingSource flatsBindingSource;
        private System.Windows.Forms.BindingSource flatsBindingSource1;
        private System.Windows.Forms.ListBox UsersListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button banBtn;
        private System.Windows.Forms.Button unbanBtn;
    }
}