namespace NordicBank
{
    partial class Transfer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.T_recievingEnd = new System.Windows.Forms.TextBox();
            this.t_transmitter = new System.Windows.Forms.TextBox();
            this.t_Amount = new System.Windows.Forms.TextBox();
            this.ErrorMsg = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MintCream;
            this.label1.Location = new System.Drawing.Point(36, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Överföring mellan dina konton";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.MintCream;
            this.label2.Location = new System.Drawing.Point(73, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Från:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.MintCream;
            this.label3.Location = new System.Drawing.Point(73, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saldo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.MintCream;
            this.label4.Location = new System.Drawing.Point(73, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Till:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "Överför";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // T_recievingEnd
            // 
            this.T_recievingEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.T_recievingEnd.Location = new System.Drawing.Point(145, 191);
            this.T_recievingEnd.Name = "T_recievingEnd";
            this.T_recievingEnd.Size = new System.Drawing.Size(162, 29);
            this.T_recievingEnd.TabIndex = 6;
            this.T_recievingEnd.Leave += new System.EventHandler(this.T_recievingEnd_Leave);
            // 
            // t_transmitter
            // 
            this.t_transmitter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.t_transmitter.Location = new System.Drawing.Point(145, 133);
            this.t_transmitter.Name = "t_transmitter";
            this.t_transmitter.Size = new System.Drawing.Size(162, 29);
            this.t_transmitter.TabIndex = 7;
            // 
            // t_Amount
            // 
            this.t_Amount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.t_Amount.Location = new System.Drawing.Point(145, 251);
            this.t_Amount.Name = "t_Amount";
            this.t_Amount.Size = new System.Drawing.Size(110, 29);
            this.t_Amount.TabIndex = 8;
            // 
            // ErrorMsg
            // 
            this.ErrorMsg.AutoSize = true;
            this.ErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.ErrorMsg.Location = new System.Drawing.Point(100, 272);
            this.ErrorMsg.Name = "ErrorMsg";
            this.ErrorMsg.Size = new System.Drawing.Size(0, 30);
            this.ErrorMsg.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 316);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 42);
            this.button2.TabIndex = 10;
            this.button2.Text = "Avsluta";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Transfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ErrorMsg);
            this.Controls.Add(this.t_Amount);
            this.Controls.Add(this.t_transmitter);
            this.Controls.Add(this.T_recievingEnd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "Transfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer";
            this.Load += new System.EventHandler(this.Transfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox T_recievingEnd;
        private System.Windows.Forms.TextBox t_transmitter;
        private System.Windows.Forms.TextBox t_Amount;
        private System.Windows.Forms.Label ErrorMsg;
        private System.Windows.Forms.Button button2;
    }
}