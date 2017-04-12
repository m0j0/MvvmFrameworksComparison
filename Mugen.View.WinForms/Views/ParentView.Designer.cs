namespace Mugen.Views
{
    partial class ParentView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxCanOpenChildWindow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxParameter = new System.Windows.Forms.TextBox();
            this.buttonOpenChildWindow = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxCanOpenChildWindow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxParameter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenChildWindow, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 277);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBoxCanOpenChildWindow
            // 
            this.checkBoxCanOpenChildWindow.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxCanOpenChildWindow, 2);
            this.checkBoxCanOpenChildWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCanOpenChildWindow.Location = new System.Drawing.Point(3, 3);
            this.checkBoxCanOpenChildWindow.Name = "checkBoxCanOpenChildWindow";
            this.checkBoxCanOpenChildWindow.Size = new System.Drawing.Size(408, 17);
            this.checkBoxCanOpenChildWindow.TabIndex = 0;
            this.checkBoxCanOpenChildWindow.Text = "Can open child window";
            this.checkBoxCanOpenChildWindow.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parameter to child view model:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxParameter
            // 
            this.textBoxParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxParameter.Location = new System.Drawing.Point(160, 26);
            this.textBoxParameter.Name = "textBoxParameter";
            this.textBoxParameter.Size = new System.Drawing.Size(251, 20);
            this.textBoxParameter.TabIndex = 2;
            // 
            // buttonOpenChildWindow
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonOpenChildWindow, 2);
            this.buttonOpenChildWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonOpenChildWindow.Location = new System.Drawing.Point(3, 52);
            this.buttonOpenChildWindow.Name = "buttonOpenChildWindow";
            this.buttonOpenChildWindow.Size = new System.Drawing.Size(408, 25);
            this.buttonOpenChildWindow.TabIndex = 3;
            this.buttonOpenChildWindow.Text = "Open child window";
            this.buttonOpenChildWindow.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 277);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainView";
            this.Text = "MainView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxCanOpenChildWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParameter;
        private System.Windows.Forms.Button buttonOpenChildWindow;
    }
}