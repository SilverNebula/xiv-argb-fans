namespace light_ctl
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonStyle1 = new System.Windows.Forms.Button();
            this.buttonStyle2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonReset, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStyle1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonStyle2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(47, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 153);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.AutoSize = true;
            this.buttonReset.Location = new System.Drawing.Point(3, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(212, 70);
            this.buttonReset.TabIndex = 0;
            this.buttonReset.Text = "(Q)Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // buttonStyle1
            // 
            this.buttonStyle1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStyle1.Location = new System.Drawing.Point(221, 3);
            this.buttonStyle1.Name = "buttonStyle1";
            this.buttonStyle1.Size = new System.Drawing.Size(213, 70);
            this.buttonStyle1.TabIndex = 1;
            this.buttonStyle1.Text = "(W)Style1";
            this.buttonStyle1.UseVisualStyleBackColor = true;
            this.buttonStyle1.Click += new System.EventHandler(this.button_style1_Click);
            // 
            // buttonStyle2
            // 
            this.buttonStyle2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStyle2.Location = new System.Drawing.Point(3, 79);
            this.buttonStyle2.Name = "buttonStyle2";
            this.buttonStyle2.Size = new System.Drawing.Size(212, 71);
            this.buttonStyle2.TabIndex = 2;
            this.buttonStyle2.Text = "Style2";
            this.buttonStyle2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(221, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(213, 71);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // consoleBox
            // 
            this.consoleBox.AcceptsTab = true;
            this.consoleBox.Location = new System.Drawing.Point(52, 292);
            this.consoleBox.MaxLength = 65535;
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(681, 116);
            this.consoleBox.TabIndex = 1;
            this.consoleBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonReset;
        private Button buttonStyle1;
        private Button buttonStyle2;
        private Button button4;
        private TextBox consoleBox;
    }
}