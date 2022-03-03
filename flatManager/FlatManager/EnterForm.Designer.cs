
namespace Reg
{
    partial class EnterForm
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
            this.userEnter = new System.Windows.Forms.Button();
            this.managerEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userEnter
            // 
            this.userEnter.Location = new System.Drawing.Point(12, 52);
            this.userEnter.Name = "userEnter";
            this.userEnter.Size = new System.Drawing.Size(181, 62);
            this.userEnter.TabIndex = 0;
            this.userEnter.Text = "Вход для пользователя";
            this.userEnter.UseVisualStyleBackColor = true;
            this.userEnter.Click += new System.EventHandler(this.userEnter_Click);
            // 
            // managerEnter
            // 
            this.managerEnter.Location = new System.Drawing.Point(12, 145);
            this.managerEnter.Name = "managerEnter";
            this.managerEnter.Size = new System.Drawing.Size(181, 62);
            this.managerEnter.TabIndex = 1;
            this.managerEnter.Text = "Вход для менеджера";
            this.managerEnter.UseVisualStyleBackColor = true;
            this.managerEnter.Click += new System.EventHandler(this.managerEnter_Click);
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 258);
            this.Controls.Add(this.managerEnter);
            this.Controls.Add(this.userEnter);
            this.Name = "EnterForm";
            this.Text = "Вход";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button userEnter;
        private System.Windows.Forms.Button managerEnter;
    }
}