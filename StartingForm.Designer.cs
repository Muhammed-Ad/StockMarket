
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
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // TickerLabel
            // 
            this.TickerLabel.AutoSize = true;
            this.TickerLabel.BackColor = System.Drawing.Color.Transparent;
            this.TickerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TickerLabel.ForeColor = System.Drawing.Color.White;
            this.TickerLabel.Location = new System.Drawing.Point(50, 59);
            this.TickerLabel.Name = "TickerLabel";
            this.TickerLabel.Size = new System.Drawing.Size(67, 20);
            this.TickerLabel.TabIndex = 0;
            this.TickerLabel.Text = "Ticker: ";
            // 
            // StocksComboBox
            // 
            this.StocksComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StocksComboBox.FormattingEnabled = true;
            this.StocksComboBox.Location = new System.Drawing.Point(181, 56);
            this.StocksComboBox.Name = "StocksComboBox";
            this.StocksComboBox.Size = new System.Drawing.Size(122, 28);
            this.StocksComboBox.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.StartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateLabel.ForeColor = System.Drawing.Color.White;
            this.StartDateLabel.Location = new System.Drawing.Point(50, 134);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(59, 20);
            this.StartDateLabel.TabIndex = 2;
            this.StartDateLabel.Text = "Start: ";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.EndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateLabel.ForeColor = System.Drawing.Color.White;
            this.EndDateLabel.Location = new System.Drawing.Point(50, 203);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(51, 20);
            this.EndDateLabel.TabIndex = 3;
            this.EndDateLabel.Text = "End: ";
            // 
            // PeriodComboBoxLabel
            // 
            this.PeriodComboBoxLabel.AutoSize = true;
            this.PeriodComboBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.PeriodComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.PeriodComboBoxLabel.Location = new System.Drawing.Point(50, 276);
            this.PeriodComboBoxLabel.Name = "PeriodComboBoxLabel";
            this.PeriodComboBoxLabel.Size = new System.Drawing.Size(75, 20);
            this.PeriodComboBoxLabel.TabIndex = 4;
            this.PeriodComboBoxLabel.Text = "Period:  ";
            // 
            // PeriodComboBox
            // 
            this.PeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PeriodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodComboBox.FormattingEnabled = true;
            this.PeriodComboBox.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Weekly"});
            this.PeriodComboBox.Location = new System.Drawing.Point(181, 268);
            this.PeriodComboBox.Name = "PeriodComboBox";
            this.PeriodComboBox.Size = new System.Drawing.Size(112, 28);
            this.PeriodComboBox.TabIndex = 5;
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDataButton.Location = new System.Drawing.Point(143, 364);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(112, 44);
            this.LoadDataButton.TabIndex = 6;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDatePicker.Location = new System.Drawing.Point(181, 134);
            this.StartDatePicker.MaxDate = new System.DateTime(2021, 11, 24, 0, 0, 0, 0);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(237, 22);
            this.StartDatePicker.TabIndex = 9;
            this.StartDatePicker.Value = new System.DateTime(2021, 11, 18, 0, 0, 0, 0);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDatePicker.Location = new System.Drawing.Point(181, 203);
            this.EndDatePicker.MaxDate = new System.DateTime(2021, 11, 25, 0, 0, 0, 0);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(237, 22);
            this.EndDatePicker.TabIndex = 10;
            this.EndDatePicker.Value = new System.DateTime(2021, 11, 25, 0, 0, 0, 0);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StockMarket.Properties.Resources.stock_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(442, 453);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.PeriodComboBox);
            this.Controls.Add(this.PeriodComboBoxLabel);
            this.Controls.Add(this.EndDateLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.StocksComboBox);
            this.Controls.Add(this.TickerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
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
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
    }
}

