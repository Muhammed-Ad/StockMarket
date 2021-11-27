
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
            this.TickerLabel.Location = new System.Drawing.Point(67, 73);
            this.TickerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TickerLabel.Name = "TickerLabel";
            this.TickerLabel.Size = new System.Drawing.Size(85, 25);
            this.TickerLabel.TabIndex = 0;
            this.TickerLabel.Text = "Ticker: ";
            // 
            // StocksComboBox
            // 
            this.StocksComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StocksComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StocksComboBox.FormattingEnabled = true;
            this.StocksComboBox.Location = new System.Drawing.Point(241, 69);
            this.StocksComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StocksComboBox.Name = "StocksComboBox";
            this.StocksComboBox.Size = new System.Drawing.Size(161, 33);
            this.StocksComboBox.TabIndex = 1;
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.StartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateLabel.ForeColor = System.Drawing.Color.White;
            this.StartDateLabel.Location = new System.Drawing.Point(67, 165);
            this.StartDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(71, 25);
            this.StartDateLabel.TabIndex = 2;
            this.StartDateLabel.Text = "Start: ";
            // 
            // EndDateLabel
            // 
            this.EndDateLabel.AutoSize = true;
            this.EndDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.EndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDateLabel.ForeColor = System.Drawing.Color.White;
            this.EndDateLabel.Location = new System.Drawing.Point(67, 250);
            this.EndDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EndDateLabel.Name = "EndDateLabel";
            this.EndDateLabel.Size = new System.Drawing.Size(63, 25);
            this.EndDateLabel.TabIndex = 3;
            this.EndDateLabel.Text = "End: ";
            // 
            // PeriodComboBoxLabel
            // 
            this.PeriodComboBoxLabel.AutoSize = true;
            this.PeriodComboBoxLabel.BackColor = System.Drawing.Color.Transparent;
            this.PeriodComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PeriodComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.PeriodComboBoxLabel.Location = new System.Drawing.Point(67, 340);
            this.PeriodComboBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PeriodComboBoxLabel.Name = "PeriodComboBoxLabel";
            this.PeriodComboBoxLabel.Size = new System.Drawing.Size(93, 25);
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
            this.PeriodComboBox.Location = new System.Drawing.Point(241, 337);
            this.PeriodComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PeriodComboBox.Name = "PeriodComboBox";
            this.PeriodComboBox.Size = new System.Drawing.Size(148, 33);
            this.PeriodComboBox.TabIndex = 5;
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDataButton.Location = new System.Drawing.Point(191, 448);
            this.LoadDataButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(149, 54);
            this.LoadDataButton.TabIndex = 6;
            this.LoadDataButton.Text = "Load Data";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDatePicker.Location = new System.Drawing.Point(241, 165);
            this.StartDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartDatePicker.MaxDate = new System.DateTime(2021, 11, 24, 0, 0, 0, 0);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(315, 26);
            this.StartDatePicker.TabIndex = 9;
            this.StartDatePicker.Value = new System.DateTime(2021, 11, 18, 0, 0, 0, 0);
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDatePicker.Location = new System.Drawing.Point(241, 250);
            this.EndDatePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EndDatePicker.MaxDate = new System.DateTime(2021, 11, 25, 0, 0, 0, 0);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(315, 26);
            this.EndDatePicker.TabIndex = 10;
            this.EndDatePicker.Value = new System.DateTime(2021, 11, 25, 0, 0, 0, 0);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::StockMarket.Properties.Resources.stock_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(589, 558);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

