namespace ATM
{
    partial class Main_menu_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_menu_form));
            this.button_money_withdrawal = new System.Windows.Forms.Button();
            this.button_money_replenishment = new System.Windows.Forms.Button();
            this.button_show_ATM_balance_form = new System.Windows.Forms.Button();
            this.button_main_menu_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_money_withdrawal
            // 
            this.button_money_withdrawal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.button_money_withdrawal, "button_money_withdrawal");
            this.button_money_withdrawal.Name = "button_money_withdrawal";
            this.button_money_withdrawal.UseVisualStyleBackColor = false;
            this.button_money_withdrawal.Click += new System.EventHandler(this.button_money_withdrawal_Click);
            // 
            // button_money_replenishment
            // 
            this.button_money_replenishment.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.button_money_replenishment, "button_money_replenishment");
            this.button_money_replenishment.Name = "button_money_replenishment";
            this.button_money_replenishment.UseVisualStyleBackColor = false;
            this.button_money_replenishment.Click += new System.EventHandler(this.button_money_replenishment_Click);
            // 
            // button_show_ATM_balance_form
            // 
            this.button_show_ATM_balance_form.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.button_show_ATM_balance_form, "button_show_ATM_balance_form");
            this.button_show_ATM_balance_form.Name = "button_show_ATM_balance_form";
            this.button_show_ATM_balance_form.UseVisualStyleBackColor = false;
            this.button_show_ATM_balance_form.Click += new System.EventHandler(this.button_show_ATM_balance_form_Click);
            // 
            // button_main_menu_close
            // 
            this.button_main_menu_close.BackColor = System.Drawing.SystemColors.InactiveCaption;
            resources.ApplyResources(this.button_main_menu_close, "button_main_menu_close");
            this.button_main_menu_close.Name = "button_main_menu_close";
            this.button_main_menu_close.UseVisualStyleBackColor = false;
            this.button_main_menu_close.Click += new System.EventHandler(this.button_main_menu_close_Click);
            // 
            // Main_menu_form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.button_main_menu_close);
            this.Controls.Add(this.button_show_ATM_balance_form);
            this.Controls.Add(this.button_money_replenishment);
            this.Controls.Add(this.button_money_withdrawal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_menu_form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_money_withdrawal;
        private System.Windows.Forms.Button button_money_replenishment;
        private System.Windows.Forms.Button button_show_ATM_balance_form;
        private System.Windows.Forms.Button button_main_menu_close;
    }
}

