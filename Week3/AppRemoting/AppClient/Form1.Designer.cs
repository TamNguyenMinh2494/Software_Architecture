namespace AppClient
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
            this.dgrShow = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtCreator = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSharable = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrShow
            // 
            this.dgrShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgrShow.Location = new System.Drawing.Point(0, 0);
            this.dgrShow.Name = "dgrShow";
            this.dgrShow.ReadOnly = true;
            this.dgrShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrShow.Size = new System.Drawing.Size(826, 150);
            this.dgrShow.TabIndex = 0;
            this.dgrShow.SelectionChanged += new System.EventHandler(this.dgrShow_SelectionChanged);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(108, 225);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(39, 29);
            this.txtID.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(108, 261);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(276, 29);
            this.txtTitle.TabIndex = 2;
            // 
            // txtCreator
            // 
            this.txtCreator.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreator.Location = new System.Drawing.Point(108, 304);
            this.txtCreator.Name = "txtCreator";
            this.txtCreator.Size = new System.Drawing.Size(276, 29);
            this.txtCreator.TabIndex = 3;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(108, 355);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(276, 29);
            this.txtDate.TabIndex = 4;
            // 
            // txtContent
            // 
            this.txtContent.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Location = new System.Drawing.Point(21, 413);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(793, 29);
            this.txtContent.TabIndex = 5;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.Location = new System.Drawing.Point(17, 225);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(26, 21);
            this.ID.TabIndex = 6;
            this.ID.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Creator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Content";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(154, 174);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(553, 29);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cbSharable
            // 
            this.cbSharable.AutoSize = true;
            this.cbSharable.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSharable.Location = new System.Drawing.Point(191, 225);
            this.cbSharable.Name = "cbSharable";
            this.cbSharable.Size = new System.Drawing.Size(118, 25);
            this.cbSharable.TabIndex = 12;
            this.cbSharable.Text = "IsSharable?";
            this.cbSharable.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(434, 285);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 48);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(581, 285);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 48);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Google Sans", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(716, 285);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 48);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbSharable);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtCreator);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.dgrShow);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrShow;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtCreator;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox cbSharable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}

