
namespace StockMarketProject
{
    partial class StartingForm
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
            this.TickerLabel = new System.Windows.Forms.Label();
            this.StocksComboBox = new System.Windows.Forms.ComboBox();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.EndDateLabel = new System.Windows.Forms.Label();
            this.PeriodComboBoxLabel = new System.Windows.Forms.Label();
            this.PeriodComboBox = new System.Windows.Forms.ComboBox();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.StartTextBox = new System.Windows.Forms.TextBox();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TickerLabel
            // 
            this.TickerLabel.AutoSize = true;
            this.TickerLabel.Location = new System.Drawing.Point(45, 31);
            this.TickerLabel.Name = "TickerLabel";
            this.TickerLabel.Size = new System.Drawing.Size(43, 13);
            this.TickerLabel.TabIndex = 0;
            this.TickerLabel.Text = "Ticker: ";
            // 
            // StocksComboBox
            // 
            this.StocksComboBox.FormattingEnabled = true;
            this.StocksComboBox.Location = new System.Drawing.Point(94, 28);
            this.StocksComboBox.Name = "StocksComboBox";
            this.StocksComboBox.Size = new System.Drawing.Size(121, 21);
            this.StocksComboBox.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(45, 77);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(35, 13);
            this.StartDateLabel.TabIndex = 2;
            this.StartDateLabel.Text = "Start: ";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.Location = new System.Drawing.Point(45, 115);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(32, 13);
            this.EndDateLabel.TabIndex = 3;
            this.EndDateLabel.Text = "End: ";
            // 
            // PeriodComboBoxLabel
            // 
            this.PeriodComboBoxLabel.AutoSize = true;
            this.PeriodComboBoxLabel.Location = new System.Drawing.Point(45, 161);
            this.PeriodComboBoxLabel.Name = "PeriodComboBoxLabel";
            this.PeriodComboBoxLabel.Size = new System.Drawing.Size(46, 13);
            this.PeriodComboBoxLabel.TabIndex = 4;
            this.PeriodComboBoxLabel.Text = "Period:  ";
            // 
            // PeriodComboBox
            // 
            this.PeriodComboBox.FormattingEnabled = true;
            this.PeriodComboBox.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Weekly"});
            this.PeriodComboBox.Location = new System.Drawing.Point(94, 158);
            this.PeriodComboBox.Name = "PeriodComboBox";
            this.PeriodComboBox.Size = new System.Drawing.Size(121, 21);
            this.PeriodComboBox.TabIndex = 5;
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(94, 231);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 6;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // StartTextBox
            // 
            this.StartTextBox.Location = new System.Drawing.Point(94, 74);
            this.StartTextBox.Name = "StartTextBox";
            this.StartTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartTextBox.TabIndex = 7;
            // 
            // EndTextBox
            // 
            this.EndTextBox.Location = new System.Drawing.Point(94, 115);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(100, 20);
            this.EndTextBox.TabIndex = 8;
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 324);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.StartTextBox);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.PeriodComboBox);
            this.Controls.Add(this.PeriodComboBoxLabel);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.StocksComboBox);
            this.Controls.Add(this.TickerLabel);
            this.Name = "StartingForm";
            this.Text = "Stock Market";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TickerLabel;
        private System.Windows.Forms.ComboBox StocksComboBox;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label EndDateLabel;
        private System.Windows.Forms.Label PeriodComboBoxLabel;
        private System.Windows.Forms.ComboBox PeriodComboBox;
        private System.Windows.Forms.Button LoadDataButton;
        private System.Windows.Forms.TextBox StartTextBox;
        private System.Windows.Forms.TextBox EndTextBox;
    }
}

