namespace ShopThuCungDNK.GUI
{
    partial class frmQLChuyenDoi
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
            this.XmlSql = new System.Windows.Forms.Button();
            this.SqlXml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // XmlSql
            // 
            this.XmlSql.BackColor = System.Drawing.Color.SeaGreen;
            this.XmlSql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XmlSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XmlSql.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XmlSql.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.XmlSql.Location = new System.Drawing.Point(174, 215);
            this.XmlSql.Name = "XmlSql";
            this.XmlSql.Size = new System.Drawing.Size(227, 66);
            this.XmlSql.TabIndex = 16;
            this.XmlSql.Text = "Chuyển đổi XML - SQL";
            this.XmlSql.UseVisualStyleBackColor = false;
            this.XmlSql.Click += new System.EventHandler(this.XmlSql_Click);
            // 
            // SqlXml
            // 
            this.SqlXml.BackColor = System.Drawing.Color.Olive;
            this.SqlXml.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SqlXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SqlXml.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SqlXml.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SqlXml.Location = new System.Drawing.Point(602, 215);
            this.SqlXml.Name = "SqlXml";
            this.SqlXml.Size = new System.Drawing.Size(213, 66);
            this.SqlXml.TabIndex = 17;
            this.SqlXml.Text = "Chuyển đổi SQL - XML";
            this.SqlXml.UseVisualStyleBackColor = false;
            this.SqlXml.Click += new System.EventHandler(this.SqlXml_Click);
            // 
            // frmQLChuyenDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1005, 529);
            this.Controls.Add(this.SqlXml);
            this.Controls.Add(this.XmlSql);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQLChuyenDoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQLChuyenDoi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button XmlSql;
        private System.Windows.Forms.Button SqlXml;
    }
}