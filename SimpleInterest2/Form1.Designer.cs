namespace SimpleInterest2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.tAmt = new System.Windows.Forms.TextBox();
            this.tInterest = new System.Windows.Forms.TextBox();
            this.tStartDate = new System.Windows.Forms.TextBox();
            this.tEndDate = new System.Windows.Forms.TextBox();
            this.tResult = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatePMTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatePPMTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amortizationScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nominal Annual Interest";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Date";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(22, 144);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 4;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // tAmt
            // 
            this.tAmt.Location = new System.Drawing.Point(168, 13);
            this.tAmt.Name = "tAmt";
            this.tAmt.Size = new System.Drawing.Size(100, 20);
            this.tAmt.TabIndex = 5;
            this.tAmt.Text = "10000";
            // 
            // tInterest
            // 
            this.tInterest.Location = new System.Drawing.Point(168, 42);
            this.tInterest.Name = "tInterest";
            this.tInterest.Size = new System.Drawing.Size(100, 20);
            this.tInterest.TabIndex = 6;
            this.tInterest.Text = "12";
            // 
            // tStartDate
            // 
            this.tStartDate.Location = new System.Drawing.Point(168, 74);
            this.tStartDate.Name = "tStartDate";
            this.tStartDate.Size = new System.Drawing.Size(100, 20);
            this.tStartDate.TabIndex = 7;
            this.tStartDate.Text = "1/28/17";
            // 
            // tEndDate
            // 
            this.tEndDate.Location = new System.Drawing.Point(168, 106);
            this.tEndDate.Name = "tEndDate";
            this.tEndDate.Size = new System.Drawing.Size(100, 20);
            this.tEndDate.TabIndex = 8;
            this.tEndDate.Text = "2/28/17";
            // 
            // tResult
            // 
            this.tResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tResult.Location = new System.Drawing.Point(16, 185);
            this.tResult.Name = "tResult";
            this.tResult.Size = new System.Drawing.Size(434, 67);
            this.tResult.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.calculatePMTToolStripMenuItem,
            this.calculatePPMTToolStripMenuItem,
            this.amortizationScheduleToolStripMenuItem,
            this.randomDatesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 136);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // calculatePMTToolStripMenuItem
            // 
            this.calculatePMTToolStripMenuItem.Name = "calculatePMTToolStripMenuItem";
            this.calculatePMTToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.calculatePMTToolStripMenuItem.Text = "Calculate PMT";
            this.calculatePMTToolStripMenuItem.Click += new System.EventHandler(this.calculatePMTToolStripMenuItem_Click);
            // 
            // calculatePPMTToolStripMenuItem
            // 
            this.calculatePPMTToolStripMenuItem.Name = "calculatePPMTToolStripMenuItem";
            this.calculatePPMTToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.calculatePPMTToolStripMenuItem.Text = "Calculate PPMT";
            this.calculatePPMTToolStripMenuItem.Click += new System.EventHandler(this.calculatePPMTToolStripMenuItem_Click);
            // 
            // amortizationScheduleToolStripMenuItem
            // 
            this.amortizationScheduleToolStripMenuItem.Name = "amortizationScheduleToolStripMenuItem";
            this.amortizationScheduleToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.amortizationScheduleToolStripMenuItem.Text = "Amortization Schedule";
            this.amortizationScheduleToolStripMenuItem.Click += new System.EventHandler(this.amortizationScheduleToolStripMenuItem_Click);
            // 
            // randomDatesToolStripMenuItem
            // 
            this.randomDatesToolStripMenuItem.Name = "randomDatesToolStripMenuItem";
            this.randomDatesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.randomDatesToolStripMenuItem.Text = "Random Dates";
            this.randomDatesToolStripMenuItem.Click += new System.EventHandler(this.randomDatesToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tResult);
            this.Controls.Add(this.tEndDate);
            this.Controls.Add(this.tStartDate);
            this.Controls.Add(this.tInterest);
            this.Controls.Add(this.tAmt);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "Form1";
            this.Text = "Simple Interest";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox tAmt;
        private System.Windows.Forms.TextBox tInterest;
        private System.Windows.Forms.TextBox tStartDate;
        private System.Windows.Forms.TextBox tEndDate;
        private System.Windows.Forms.Label tResult;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatePMTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatePPMTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amortizationScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomDatesToolStripMenuItem;
    }
}

