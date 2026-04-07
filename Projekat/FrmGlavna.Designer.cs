namespace Projekat
{
    partial class FrmGlavna
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
            this.components = new System.ComponentModel.Container();
            this.dgvDobavljaci = new System.Windows.Forms.DataGridView();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.cmsProizvodi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.miUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDobavljaci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.cmsProizvodi.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDobavljaci
            // 
            this.dgvDobavljaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDobavljaci.Location = new System.Drawing.Point(13, 13);
            this.dgvDobavljaci.Name = "dgvDobavljaci";
            this.dgvDobavljaci.RowHeadersWidth = 51;
            this.dgvDobavljaci.RowTemplate.Height = 24;
            this.dgvDobavljaci.Size = new System.Drawing.Size(479, 355);
            this.dgvDobavljaci.TabIndex = 0;
            this.dgvDobavljaci.SelectionChanged += new System.EventHandler(this.dgvDobavljaci_SelectionChanged);
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.ContextMenuStrip = this.cmsProizvodi;
            this.dgvProizvodi.Location = new System.Drawing.Point(539, 13);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.RowHeadersWidth = 51;
            this.dgvProizvodi.RowTemplate.Height = 24;
            this.dgvProizvodi.Size = new System.Drawing.Size(504, 355);
            this.dgvProizvodi.TabIndex = 1;
            // 
            // cmsProizvodi
            // 
            this.cmsProizvodi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsProizvodi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInsert,
            this.miUpdate,
            this.miDelete});
            this.cmsProizvodi.Name = "cmsProizvodi";
            this.cmsProizvodi.Size = new System.Drawing.Size(128, 76);
            // 
            // miInsert
            // 
            this.miInsert.Name = "miInsert";
            this.miInsert.Size = new System.Drawing.Size(210, 24);
            this.miInsert.Text = "Insert";
            this.miInsert.Click += new System.EventHandler(this.miInsert_Click);
            // 
            // miUpdate
            // 
            this.miUpdate.Name = "miUpdate";
            this.miUpdate.Size = new System.Drawing.Size(210, 24);
            this.miUpdate.Text = "Update";
            this.miUpdate.Click += new System.EventHandler(this.miUpdate_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(210, 24);
            this.miDelete.Text = "Delete";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // FrmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 455);
            this.Controls.Add(this.dgvProizvodi);
            this.Controls.Add(this.dgvDobavljaci);
            this.Name = "FrmGlavna";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.FrmGlavna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDobavljaci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.cmsProizvodi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDobavljaci;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.ContextMenuStrip cmsProizvodi;
        private System.Windows.Forms.ToolStripMenuItem miInsert;
        private System.Windows.Forms.ToolStripMenuItem miUpdate;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
    }
}

