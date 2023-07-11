namespace RentalFilm_C19
{
    partial class Barang
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNama = new System.Windows.Forms.TextBox();
            this.dtTerima = new System.Windows.Forms.DateTimePicker();
            this.dtKirim = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.cbxKodeRental = new System.Windows.Forms.ComboBox();
            this.cbxKodeDistributor = new System.Windows.Forms.ComboBox();
            this.idRental = new System.Windows.Forms.Label();
            this.idDistributor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSave.Location = new System.Drawing.Point(422, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tanggal pengirim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tanggal penerima";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kode rental";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kode distributor";
            // 
            // tbNama
            // 
            this.tbNama.Location = new System.Drawing.Point(244, 74);
            this.tbNama.Name = "tbNama";
            this.tbNama.Size = new System.Drawing.Size(255, 22);
            this.tbNama.TabIndex = 6;
            // 
            // dtTerima
            // 
            this.dtTerima.Location = new System.Drawing.Point(245, 177);
            this.dtTerima.Name = "dtTerima";
            this.dtTerima.Size = new System.Drawing.Size(169, 22);
            this.dtTerima.TabIndex = 9;
            this.dtTerima.Value = new System.DateTime(2023, 7, 16, 17, 16, 0, 0);
            // 
            // dtKirim
            // 
            this.dtKirim.Location = new System.Drawing.Point(245, 125);
            this.dtKirim.Name = "dtKirim";
            this.dtKirim.Size = new System.Drawing.Size(169, 22);
            this.dtKirim.TabIndex = 10;
            this.dtKirim.Value = new System.DateTime(2023, 7, 11, 17, 23, 49, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(245, 372);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 31);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(732, 372);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 31);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(829, 372);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 31);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(518, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(690, 280);
            this.dataGridView1.TabIndex = 17;
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDisplay.Location = new System.Drawing.Point(925, 372);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 31);
            this.btnDisplay.TabIndex = 18;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // cbxKodeRental
            // 
            this.cbxKodeRental.FormattingEnabled = true;
            this.cbxKodeRental.Location = new System.Drawing.Point(244, 228);
            this.cbxKodeRental.Name = "cbxKodeRental";
            this.cbxKodeRental.Size = new System.Drawing.Size(255, 24);
            this.cbxKodeRental.TabIndex = 19;
            this.cbxKodeRental.SelectedIndexChanged += new System.EventHandler(this.cbxKodeRental_SelectedIndexChanged);
            // 
            // cbxKodeDistributor
            // 
            this.cbxKodeDistributor.FormattingEnabled = true;
            this.cbxKodeDistributor.Location = new System.Drawing.Point(244, 299);
            this.cbxKodeDistributor.Name = "cbxKodeDistributor";
            this.cbxKodeDistributor.Size = new System.Drawing.Size(255, 24);
            this.cbxKodeDistributor.TabIndex = 20;
            this.cbxKodeDistributor.SelectedIndexChanged += new System.EventHandler(this.cbxKodeDistributor_SelectedIndexChanged);
            // 
            // idRental
            // 
            this.idRental.AutoSize = true;
            this.idRental.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idRental.Location = new System.Drawing.Point(239, 255);
            this.idRental.Name = "idRental";
            this.idRental.Size = new System.Drawing.Size(75, 26);
            this.idRental.TabIndex = 21;
            this.idRental.Text = "ID Rental";
            // 
            // idDistributor
            // 
            this.idDistributor.AutoSize = true;
            this.idDistributor.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idDistributor.Location = new System.Drawing.Point(239, 326);
            this.idDistributor.Name = "idDistributor";
            this.idDistributor.Size = new System.Drawing.Size(108, 26);
            this.idDistributor.TabIndex = 22;
            this.idDistributor.Text = "ID Distributor";
            // 
            // Barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1220, 450);
            this.Controls.Add(this.idDistributor);
            this.Controls.Add(this.idRental);
            this.Controls.Add(this.cbxKodeDistributor);
            this.Controls.Add(this.cbxKodeRental);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtKirim);
            this.Controls.Add(this.dtTerima);
            this.Controls.Add(this.tbNama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "Barang";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNama;
        private System.Windows.Forms.DateTimePicker dtTerima;
        private System.Windows.Forms.DateTimePicker dtKirim;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.ComboBox cbxKodeRental;
        private System.Windows.Forms.ComboBox cbxKodeDistributor;
        private System.Windows.Forms.Label idRental;
        private System.Windows.Forms.Label idDistributor;
    }
}