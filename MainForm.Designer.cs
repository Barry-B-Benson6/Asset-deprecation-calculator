namespace Asset_deprecation_calc
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnNewAsset = new System.Windows.Forms.Button();
            this.BtnViewAssets = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Header);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 73);
            this.panel1.TabIndex = 0;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(845, 73);
            this.Header.TabIndex = 0;
            this.Header.Text = "Assest Depreciation Calculator";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.BtnViewAssets, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnNewAsset, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 433);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnNewAsset
            // 
            this.BtnNewAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnNewAsset.Location = new System.Drawing.Point(3, 3);
            this.BtnNewAsset.Name = "BtnNewAsset";
            this.BtnNewAsset.Size = new System.Drawing.Size(194, 210);
            this.BtnNewAsset.TabIndex = 0;
            this.BtnNewAsset.Text = "Add new asset";
            this.BtnNewAsset.UseVisualStyleBackColor = true;
            this.BtnNewAsset.Click += new System.EventHandler(this.BtnNewAsset_Click);
            // 
            // BtnViewAssets
            // 
            this.BtnViewAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnViewAssets.Location = new System.Drawing.Point(3, 219);
            this.BtnViewAssets.Name = "BtnViewAssets";
            this.BtnViewAssets.Size = new System.Drawing.Size(194, 211);
            this.BtnViewAssets.TabIndex = 1;
            this.BtnViewAssets.Text = "View current assets";
            this.BtnViewAssets.UseVisualStyleBackColor = true;
            this.BtnViewAssets.Click += new System.EventHandler(this.BtnViewAssets_Click);
            // 
            // Display
            // 
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Location = new System.Drawing.Point(200, 73);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(645, 433);
            this.Display.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 506);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnViewAssets;
        private System.Windows.Forms.Button BtnNewAsset;
        private System.Windows.Forms.Panel Display;
    }
}

