namespace ATM
{
    partial class Show_balance_form
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
            this.Back_to_main_menu = new System.Windows.Forms.Button();
            this.Cancel_from_balance_menu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ATM_balance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_bankonotes_number = new System.Windows.Forms.Label();
            this.label_max_banknotes = new System.Windows.Forms.Label();
            this.label_info_by_banknotes_values = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Back_to_main_menu
            // 
            this.Back_to_main_menu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Back_to_main_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back_to_main_menu.Location = new System.Drawing.Point(22, 272);
            this.Back_to_main_menu.Name = "Back_to_main_menu";
            this.Back_to_main_menu.Size = new System.Drawing.Size(243, 76);
            this.Back_to_main_menu.TabIndex = 0;
            this.Back_to_main_menu.Text = "ВОЗВРАТ В ГЛАВНОЕ МЕНЮ";
            this.Back_to_main_menu.UseVisualStyleBackColor = false;
            this.Back_to_main_menu.Click += new System.EventHandler(this.Back_to_main_menu_Click);
            // 
            // Cancel_from_balance_menu
            // 
            this.Cancel_from_balance_menu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Cancel_from_balance_menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel_from_balance_menu.Location = new System.Drawing.Point(360, 272);
            this.Cancel_from_balance_menu.Name = "Cancel_from_balance_menu";
            this.Cancel_from_balance_menu.Size = new System.Drawing.Size(243, 76);
            this.Cancel_from_balance_menu.TabIndex = 1;
            this.Cancel_from_balance_menu.Text = "ЗАВЕРШИТЬ РАБОТУ";
            this.Cancel_from_balance_menu.UseVisualStyleBackColor = false;
            this.Cancel_from_balance_menu.Click += new System.EventHandler(this.Cancel_from_balance_menu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(1, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Баланс банкомата (рубли):";
            // 
            // label_ATM_balance
            // 
            this.label_ATM_balance.AutoSize = true;
            this.label_ATM_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ATM_balance.ForeColor = System.Drawing.SystemColors.Info;
            this.label_ATM_balance.Location = new System.Drawing.Point(370, 22);
            this.label_ATM_balance.Name = "label_ATM_balance";
            this.label_ATM_balance.Size = new System.Drawing.Size(67, 31);
            this.label_ATM_balance.TabIndex = 3;
            this.label_ATM_balance.Text = "0.00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(1, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Общее количество купюр:";
            // 
            // label_bankonotes_number
            // 
            this.label_bankonotes_number.AutoSize = true;
            this.label_bankonotes_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_bankonotes_number.ForeColor = System.Drawing.SystemColors.Info;
            this.label_bankonotes_number.Location = new System.Drawing.Point(370, 53);
            this.label_bankonotes_number.Name = "label_bankonotes_number";
            this.label_bankonotes_number.Size = new System.Drawing.Size(59, 31);
            this.label_bankonotes_number.TabIndex = 5;
            this.label_bankonotes_number.Text = "000";
            // 
            // label_max_banknotes
            // 
            this.label_max_banknotes.AutoSize = true;
            this.label_max_banknotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_max_banknotes.ForeColor = System.Drawing.SystemColors.Info;
            this.label_max_banknotes.Location = new System.Drawing.Point(497, 59);
            this.label_max_banknotes.Name = "label_max_banknotes";
            this.label_max_banknotes.Size = new System.Drawing.Size(77, 25);
            this.label_max_banknotes.TabIndex = 6;
            this.label_max_banknotes.Text = "из 200";
            // 
            // label_info_by_banknotes_values
            // 
            this.label_info_by_banknotes_values.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_by_banknotes_values.ForeColor = System.Drawing.SystemColors.Info;
            this.label_info_by_banknotes_values.Location = new System.Drawing.Point(110, 115);
            this.label_info_by_banknotes_values.Name = "label_info_by_banknotes_values";
            this.label_info_by_banknotes_values.Size = new System.Drawing.Size(419, 141);
            this.label_info_by_banknotes_values.TabIndex = 8;
            this.label_info_by_banknotes_values.Text = "купюры и количества";
            this.label_info_by_banknotes_values.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Show_balance_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(615, 372);
            this.Controls.Add(this.label_info_by_banknotes_values);
            this.Controls.Add(this.label_max_banknotes);
            this.Controls.Add(this.label_bankonotes_number);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_ATM_balance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_from_balance_menu);
            this.Controls.Add(this.Back_to_main_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Show_balance_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Баланс банкомата";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back_to_main_menu;
        private System.Windows.Forms.Button Cancel_from_balance_menu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_ATM_balance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_bankonotes_number;
        private System.Windows.Forms.Label label_max_banknotes;
        private System.Windows.Forms.Label label_info_by_banknotes_values;
    }
}