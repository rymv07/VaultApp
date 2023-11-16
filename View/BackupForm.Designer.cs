namespace VaultApp.View
{
    partial class BackupForm
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
            this.lblheader = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbocodetype = new System.Windows.Forms.ComboBox();
            this.lblcode = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbocodestats = new System.Windows.Forms.ComboBox();
            this.btnsavebu = new System.Windows.Forms.Button();
            this.btnclearbu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtaccount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblheader
            // 
            this.lblheader.AutoSize = true;
            this.lblheader.BackColor = System.Drawing.Color.White;
            this.lblheader.Font = new System.Drawing.Font("Consolas", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblheader.ForeColor = System.Drawing.Color.Indigo;
            this.lblheader.Location = new System.Drawing.Point(12, 9);
            this.lblheader.Name = "lblheader";
            this.lblheader.Size = new System.Drawing.Size(56, 15);
            this.lblheader.TabIndex = 0;
            this.lblheader.Text = "@header";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.ForeColor = System.Drawing.Color.DimGray;
            this.lblid.Location = new System.Drawing.Point(152, 11);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(26, 16);
            this.lblid.TabIndex = 0;
            this.lblid.Text = "ID :";
            this.lblid.Visible = false;
            // 
            // txtid
            // 
            this.txtid.BackColor = System.Drawing.Color.Azure;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtid.Enabled = false;
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(184, 12);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(155, 15);
            this.txtid.TabIndex = 0;
            this.txtid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Code Type";
            // 
            // cbocodetype
            // 
            this.cbocodetype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocodetype.FormattingEnabled = true;
            this.cbocodetype.Items.AddRange(new object[] {
            "Single",
            "Multiple"});
            this.cbocodetype.Location = new System.Drawing.Point(15, 110);
            this.cbocodetype.Name = "cbocodetype";
            this.cbocodetype.Size = new System.Drawing.Size(155, 24);
            this.cbocodetype.TabIndex = 2;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.ForeColor = System.Drawing.Color.DimGray;
            this.lblcode.Location = new System.Drawing.Point(12, 145);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(190, 16);
            this.lblcode.TabIndex = 0;
            this.lblcode.Text = "Input Code / Multi Phrase Code";
            // 
            // txtcode
            // 
            this.txtcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(15, 164);
            this.txtcode.Multiline = true;
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(324, 150);
            this.txtcode.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(181, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 16);
            this.label18.TabIndex = 0;
            this.label18.Text = "Status";
            // 
            // cbocodestats
            // 
            this.cbocodestats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocodestats.FormattingEnabled = true;
            this.cbocodestats.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cbocodestats.Location = new System.Drawing.Point(184, 110);
            this.cbocodestats.Name = "cbocodestats";
            this.cbocodestats.Size = new System.Drawing.Size(155, 24);
            this.cbocodestats.TabIndex = 3;
            // 
            // btnsavebu
            // 
            this.btnsavebu.BackgroundImage = global::VaultApp.Properties.Resources.save;
            this.btnsavebu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsavebu.FlatAppearance.BorderSize = 0;
            this.btnsavebu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnsavebu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnsavebu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsavebu.Location = new System.Drawing.Point(172, 337);
            this.btnsavebu.Name = "btnsavebu";
            this.btnsavebu.Size = new System.Drawing.Size(30, 30);
            this.btnsavebu.TabIndex = 5;
            this.btnsavebu.UseVisualStyleBackColor = true;
            this.btnsavebu.Click += new System.EventHandler(this.btnsavebu_Click);
            // 
            // btnclearbu
            // 
            this.btnclearbu.BackgroundImage = global::VaultApp.Properties.Resources.clear_icon_colored;
            this.btnclearbu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclearbu.FlatAppearance.BorderSize = 0;
            this.btnclearbu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnclearbu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnclearbu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclearbu.Location = new System.Drawing.Point(242, 337);
            this.btnclearbu.Name = "btnclearbu";
            this.btnclearbu.Size = new System.Drawing.Size(30, 30);
            this.btnclearbu.TabIndex = 6;
            this.btnclearbu.UseVisualStyleBackColor = true;
            this.btnclearbu.Click += new System.EventHandler(this.btnclearbu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account :";
            // 
            // txtaccount
            // 
            this.txtaccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccount.Location = new System.Drawing.Point(76, 55);
            this.txtaccount.Name = "txtaccount";
            this.txtaccount.Size = new System.Drawing.Size(263, 22);
            this.txtaccount.TabIndex = 1;
            this.txtaccount.WordWrap = false;
            // 
            // BackupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(355, 391);
            this.Controls.Add(this.btnclearbu);
            this.Controls.Add(this.btnsavebu);
            this.Controls.Add(this.cbocodestats);
            this.Controls.Add(this.cbocodetype);
            this.Controls.Add(this.txtaccount);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblcode);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lblheader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BackupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Header";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblheader;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbocodetype;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbocodestats;
        private System.Windows.Forms.Button btnsavebu;
        private System.Windows.Forms.Button btnclearbu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtaccount;
    }
}