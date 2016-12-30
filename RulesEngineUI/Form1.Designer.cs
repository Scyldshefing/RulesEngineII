namespace RulesEngineUI
{
    partial class Form1
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
            this.CustomerNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Balance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LateScore = new System.Windows.Forms.TextBox();
            this.SegementCode = new System.Windows.Forms.TextBox();
            this.EarlyScore = new System.Windows.Forms.TextBox();
            this.MissedPayments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.StrategyCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.WaiverInPlace = new System.Windows.Forms.ComboBox();
            this.PaymentFrequency = new System.Windows.Forms.ComboBox();
            this.ArrearsStatus = new System.Windows.Forms.ComboBox();
            this.GetStrategy = new System.Windows.Forms.Button();
            this.CountryCode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FormatRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Number";
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.Location = new System.Drawing.Point(309, 13);
            this.CustomerNumber.Name = "CustomerNumber";
            this.CustomerNumber.Size = new System.Drawing.Size(407, 38);
            this.CustomerNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Balance";
            // 
            // Balance
            // 
            this.Balance.Location = new System.Drawing.Point(309, 57);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(407, 38);
            this.Balance.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Late Score";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "Early Score";
            // 
            // LateScore
            // 
            this.LateScore.Location = new System.Drawing.Point(309, 101);
            this.LateScore.Name = "LateScore";
            this.LateScore.Size = new System.Drawing.Size(407, 38);
            this.LateScore.TabIndex = 6;
            // 
            // SegementCode
            // 
            this.SegementCode.Location = new System.Drawing.Point(309, 189);
            this.SegementCode.Name = "SegementCode";
            this.SegementCode.Size = new System.Drawing.Size(407, 38);
            this.SegementCode.TabIndex = 8;
            // 
            // EarlyScore
            // 
            this.EarlyScore.Location = new System.Drawing.Point(309, 145);
            this.EarlyScore.Name = "EarlyScore";
            this.EarlyScore.Size = new System.Drawing.Size(407, 38);
            this.EarlyScore.TabIndex = 7;
            // 
            // MissedPayments
            // 
            this.MissedPayments.Location = new System.Drawing.Point(309, 277);
            this.MissedPayments.Name = "MissedPayments";
            this.MissedPayments.Size = new System.Drawing.Size(407, 38);
            this.MissedPayments.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Segment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Arrears Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 32);
            this.label7.TabIndex = 13;
            this.label7.Text = "Missed Payments";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 32);
            this.label8.TabIndex = 15;
            this.label8.Text = "Strategy Code";
            // 
            // StrategyCode
            // 
            this.StrategyCode.Location = new System.Drawing.Point(309, 321);
            this.StrategyCode.Name = "StrategyCode";
            this.StrategyCode.Size = new System.Drawing.Size(407, 38);
            this.StrategyCode.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(268, 32);
            this.label9.TabIndex = 17;
            this.label9.Text = "Payment Frequency";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 412);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 32);
            this.label10.TabIndex = 19;
            this.label10.Text = "Waiver in Place";
            // 
            // WaiverInPlace
            // 
            this.WaiverInPlace.FormattingEnabled = true;
            this.WaiverInPlace.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.WaiverInPlace.Location = new System.Drawing.Point(309, 412);
            this.WaiverInPlace.Name = "WaiverInPlace";
            this.WaiverInPlace.Size = new System.Drawing.Size(407, 39);
            this.WaiverInPlace.TabIndex = 20;
            // 
            // PaymentFrequency
            // 
            this.PaymentFrequency.FormattingEnabled = true;
            this.PaymentFrequency.Items.AddRange(new object[] {
            "W",
            "F",
            "M"});
            this.PaymentFrequency.Location = new System.Drawing.Point(309, 365);
            this.PaymentFrequency.Name = "PaymentFrequency";
            this.PaymentFrequency.Size = new System.Drawing.Size(407, 39);
            this.PaymentFrequency.TabIndex = 21;
            // 
            // ArrearsStatus
            // 
            this.ArrearsStatus.FormattingEnabled = true;
            this.ArrearsStatus.Items.AddRange(new object[] {
            "EC",
            "EA",
            "LA"});
            this.ArrearsStatus.Location = new System.Drawing.Point(309, 233);
            this.ArrearsStatus.Name = "ArrearsStatus";
            this.ArrearsStatus.Size = new System.Drawing.Size(121, 39);
            this.ArrearsStatus.TabIndex = 22;
            // 
            // GetStrategy
            // 
            this.GetStrategy.Location = new System.Drawing.Point(309, 523);
            this.GetStrategy.Name = "GetStrategy";
            this.GetStrategy.Size = new System.Drawing.Size(279, 54);
            this.GetStrategy.TabIndex = 23;
            this.GetStrategy.Text = "Get Strategy Score";
            this.GetStrategy.UseVisualStyleBackColor = true;
            this.GetStrategy.Click += new System.EventHandler(this.GetStrategy_Click);
            // 
            // CountryCode
            // 
            this.CountryCode.FormattingEnabled = true;
            this.CountryCode.Items.AddRange(new object[] {
            "UK",
            "ROI"});
            this.CountryCode.Location = new System.Drawing.Point(309, 464);
            this.CountryCode.Name = "CountryCode";
            this.CountryCode.Size = new System.Drawing.Size(121, 39);
            this.CountryCode.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 464);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 32);
            this.label11.TabIndex = 24;
            this.label11.Text = "Country Code";
            // 
            // FormatRules
            // 
            this.FormatRules.Location = new System.Drawing.Point(309, 599);
            this.FormatRules.Name = "FormatRules";
            this.FormatRules.Size = new System.Drawing.Size(279, 63);
            this.FormatRules.TabIndex = 26;
            this.FormatRules.Text = "Format Rules";
            this.FormatRules.UseVisualStyleBackColor = true;
            this.FormatRules.Click += new System.EventHandler(this.FormatRules_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 932);
            this.Controls.Add(this.FormatRules);
            this.Controls.Add(this.CountryCode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GetStrategy);
            this.Controls.Add(this.ArrearsStatus);
            this.Controls.Add(this.PaymentFrequency);
            this.Controls.Add(this.WaiverInPlace);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.StrategyCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MissedPayments);
            this.Controls.Add(this.SegementCode);
            this.Controls.Add(this.EarlyScore);
            this.Controls.Add(this.LateScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomerNumber);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CustomerNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Balance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LateScore;
        private System.Windows.Forms.TextBox SegementCode;
        private System.Windows.Forms.TextBox EarlyScore;
        private System.Windows.Forms.TextBox MissedPayments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox StrategyCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox WaiverInPlace;
        private System.Windows.Forms.ComboBox PaymentFrequency;
        private System.Windows.Forms.ComboBox ArrearsStatus;
        private System.Windows.Forms.Button GetStrategy;
        private System.Windows.Forms.ComboBox CountryCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button FormatRules;
    }
}

