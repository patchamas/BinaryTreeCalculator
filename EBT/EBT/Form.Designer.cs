namespace EBT
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtExpression = new System.Windows.Forms.TextBox();
            this.treeView_Expr = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(197, 12);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtExpression
            // 
            this.txtExpression.Location = new System.Drawing.Point(12, 14);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(179, 20);
            this.txtExpression.TabIndex = 1;
            this.txtExpression.Text = "(2*(5-1))+(3+2)";
            this.txtExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // treeView_Expr
            // 
            this.treeView_Expr.Location = new System.Drawing.Point(12, 40);
            this.treeView_Expr.Name = "treeView_Expr";
            this.treeView_Expr.Size = new System.Drawing.Size(260, 209);
            this.treeView_Expr.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.treeView_Expr);
            this.Controls.Add(this.txtExpression);
            this.Controls.Add(this.btnCalculate);
            this.Name = "Form1";
            this.Text = "BinaryTree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtExpression;
        private System.Windows.Forms.TreeView treeView_Expr;
    }
}

