namespace IDInfoRead
{
    partial class Form_IPSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_IPSet));
            this.label1 = new System.Windows.Forms.Label();
            this.tB_IPSet_Server = new System.Windows.Forms.TextBox();
            this.tB_IPSet_Port = new System.Windows.Forms.TextBox();
            this.btn_IPSet_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "远程配置";
            // 
            // tB_IPSet_Server
            // 
            this.tB_IPSet_Server.BackColor = System.Drawing.Color.White;
            this.tB_IPSet_Server.Location = new System.Drawing.Point(101, 43);
            this.tB_IPSet_Server.Name = "tB_IPSet_Server";
            this.tB_IPSet_Server.Size = new System.Drawing.Size(141, 23);
            this.tB_IPSet_Server.TabIndex = 1;
            this.tB_IPSet_Server.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Handler);
            // 
            // tB_IPSet_Port
            // 
            this.tB_IPSet_Port.BackColor = System.Drawing.Color.White;
            this.tB_IPSet_Port.Location = new System.Drawing.Point(274, 43);
            this.tB_IPSet_Port.Name = "tB_IPSet_Port";
            this.tB_IPSet_Port.Size = new System.Drawing.Size(66, 23);
            this.tB_IPSet_Port.TabIndex = 2;
            this.tB_IPSet_Port.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Handler);
            // 
            // btn_IPSet_Save
            // 
            this.btn_IPSet_Save.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_IPSet_Save.Location = new System.Drawing.Point(274, 88);
            this.btn_IPSet_Save.Name = "btn_IPSet_Save";
            this.btn_IPSet_Save.Size = new System.Drawing.Size(66, 23);
            this.btn_IPSet_Save.TabIndex = 3;
            this.btn_IPSet_Save.TabStop = false;
            this.btn_IPSet_Save.Text = "保 存";
            this.btn_IPSet_Save.UseVisualStyleBackColor = true;
            this.btn_IPSet_Save.Click += new System.EventHandler(this.btn_IPSet_Save_Click);
            // 
            // Form_IPSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 131);
            this.Controls.Add(this.btn_IPSet_Save);
            this.Controls.Add(this.tB_IPSet_Port);
            this.Controls.Add(this.tB_IPSet_Server);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_IPSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "端口配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosing_Handler);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Handler);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tB_IPSet_Server;
        private System.Windows.Forms.TextBox tB_IPSet_Port;
        private System.Windows.Forms.Button btn_IPSet_Save;
    }
}