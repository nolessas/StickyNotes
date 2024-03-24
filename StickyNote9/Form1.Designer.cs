//Form1.designer.cs
namespace StickyNote9
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

       
        private void InitializeComponent()
        {
            this.Color = new System.Windows.Forms.Button();
            this.Pin = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Color
            // 
            this.Color.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Color.Location = new System.Drawing.Point(0, 294);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(328, 31);
            this.Color.TabIndex = 0;
            this.Color.Text = "Color";
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // Pin
            // 
            this.Pin.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pin.Location = new System.Drawing.Point(0, 0);
            this.Pin.Name = "Pin";
            this.Pin.Size = new System.Drawing.Size(328, 24);
            this.Pin.TabIndex = 1;
            this.Pin.Text = "Pin";
            this.Pin.UseVisualStyleBackColor = true;
            this.Pin.CheckedChanged += new System.EventHandler(this.Pin_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 270);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Add
            // 
            this.Add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Add.Location = new System.Drawing.Point(0, 265);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(328, 29);
            this.Add.TabIndex = 3;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(0, 0);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 0;
            this.Delete.Text = "Delete";
            this.del.Click += new System.EventHandler(this.Del_Click);

            // 
            // del
            // 
            this.del.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.del.Location = new System.Drawing.Point(0, 236);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(328, 29);
            this.del.TabIndex = 5;
            this.del.Text = "Delete note";
            this.del.UseVisualStyleBackColor = true;
            this.del.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.Add;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(328, 325);
            this.Controls.Add(this.del);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Pin);
            this.Controls.Add(this.Color);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sticky Note";
            this.TopMost = true;
            this.Move += new System.EventHandler(this.Form1_Move);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.CheckBox Pin;
        private System.Windows.Forms.Button del;
    }
}
