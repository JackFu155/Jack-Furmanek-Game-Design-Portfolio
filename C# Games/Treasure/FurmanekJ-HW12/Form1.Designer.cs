namespace FurmanekJ_HW12
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
            this.textcounter = new System.Windows.Forms.TextBox();
            this.texttocount = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.count = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.Label();
            this.resultbar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textcounter
            // 
            this.textcounter.Location = new System.Drawing.Point(40, 60);
            this.textcounter.Name = "textcounter";
            this.textcounter.Size = new System.Drawing.Size(343, 20);
            this.textcounter.TabIndex = 0;
            this.textcounter.TextChanged += new System.EventHandler(this.textcounter_TextChanged);
            // 
            // texttocount
            // 
            this.texttocount.AutoSize = true;
            this.texttocount.Location = new System.Drawing.Point(37, 25);
            this.texttocount.Name = "texttocount";
            this.texttocount.Size = new System.Drawing.Size(74, 13);
            this.texttocount.TabIndex = 1;
            this.texttocount.Text = "Text to Count:";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(278, 227);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 2;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(278, 162);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(75, 23);
            this.count.TabIndex = 3;
            this.count.Text = "Count";
            this.count.UseVisualStyleBackColor = true;
            this.count.Click += new System.EventHandler(this.count_Click);
            // 
            // results
            // 
            this.results.AutoSize = true;
            this.results.Location = new System.Drawing.Point(37, 120);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(45, 13);
            this.results.TabIndex = 4;
            this.results.Text = "Results:";
            // 
            // resultbar
            // 
            this.resultbar.Location = new System.Drawing.Point(40, 153);
            this.resultbar.Multiline = true;
            this.resultbar.Name = "resultbar";
            this.resultbar.Size = new System.Drawing.Size(221, 374);
            this.resultbar.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 587);
            this.Controls.Add(this.resultbar);
            this.Controls.Add(this.results);
            this.Controls.Add(this.count);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.texttocount);
            this.Controls.Add(this.textcounter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textcounter;
        private System.Windows.Forms.Label texttocount;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button count;
        private System.Windows.Forms.Label results;
        private System.Windows.Forms.TextBox resultbar;
    }
}

