namespace Mugen.Views
{
    partial class ChildView
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxParameter = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonUpdateParameter = new System.Windows.Forms.Button();
            this.progressBarIsBusy = new System.Windows.Forms.ProgressBar();
            this.labelBusyMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxParameter, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBarIsBusy, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelBusyMessage, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 226);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Passed parameter:";
            // 
            // textBoxParameter
            // 
            this.textBoxParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxParameter.Location = new System.Drawing.Point(104, 3);
            this.textBoxParameter.Margin = new System.Windows.Forms.Padding(3, 3, 11, 3);
            this.textBoxParameter.Name = "textBoxParameter";
            this.textBoxParameter.Size = new System.Drawing.Size(349, 20);
            this.textBoxParameter.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Controls.Add(this.buttonUpdateParameter);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(101, 26);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(363, 31);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(260, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateParameter
            // 
            this.buttonUpdateParameter.Location = new System.Drawing.Point(154, 3);
            this.buttonUpdateParameter.Name = "buttonUpdateParameter";
            this.buttonUpdateParameter.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdateParameter.TabIndex = 2;
            this.buttonUpdateParameter.Text = "Update parameter";
            this.buttonUpdateParameter.UseVisualStyleBackColor = true;
            // 
            // progressBarIsBusy
            // 
            this.progressBarIsBusy.Location = new System.Drawing.Point(104, 60);
            this.progressBarIsBusy.Name = "progressBarIsBusy";
            this.progressBarIsBusy.Size = new System.Drawing.Size(207, 23);
            this.progressBarIsBusy.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarIsBusy.TabIndex = 4;
            this.progressBarIsBusy.Visible = false;
            // 
            // labelBusyMessage
            // 
            this.labelBusyMessage.AutoSize = true;
            this.labelBusyMessage.Location = new System.Drawing.Point(104, 86);
            this.labelBusyMessage.Name = "labelBusyMessage";
            this.labelBusyMessage.Size = new System.Drawing.Size(95, 13);
            this.labelBusyMessage.TabIndex = 5;
            this.labelBusyMessage.Text = "labelBusyMessage";
            this.labelBusyMessage.Visible = false;
            // 
            // ChildView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 226);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChildView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChildView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxParameter;
        private System.Windows.Forms.Button buttonUpdateParameter;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBarIsBusy;
        private System.Windows.Forms.Label labelBusyMessage;
    }
}