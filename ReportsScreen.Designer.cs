namespace AliceLyC969
{
    partial class ReportsScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.ComboBox();
            this.dgvUserReport = new System.Windows.Forms.DataGridView();
            this.dgvApptReport = new System.Windows.Forms.DataGridView();
            this.dgvCityReport = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApptReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCityReport)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reports";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select A Consultant";
            // 
            // userBox
            // 
            this.userBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(192, 120);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(183, 26);
            this.userBox.TabIndex = 3;
            this.userBox.SelectedIndexChanged += new System.EventHandler(this.userBoxSelected);
            // 
            // dgvUserReport
            // 
            this.dgvUserReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserReport.Location = new System.Drawing.Point(38, 171);
            this.dgvUserReport.Name = "dgvUserReport";
            this.dgvUserReport.Size = new System.Drawing.Size(913, 166);
            this.dgvUserReport.TabIndex = 4;
            // 
            // dgvApptReport
            // 
            this.dgvApptReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApptReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApptReport.Location = new System.Drawing.Point(38, 379);
            this.dgvApptReport.Name = "dgvApptReport";
            this.dgvApptReport.Size = new System.Drawing.Size(442, 204);
            this.dgvApptReport.TabIndex = 5;
            // 
            // dgvCityReport
            // 
            this.dgvCityReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCityReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCityReport.Location = new System.Drawing.Point(537, 379);
            this.dgvCityReport.Name = "dgvCityReport";
            this.dgvCityReport.Size = new System.Drawing.Size(414, 204);
            this.dgvCityReport.TabIndex = 6;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(876, 615);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 30);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButtonClicked);
            // 
            // ReportsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 679);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.dgvCityReport);
            this.Controls.Add(this.dgvApptReport);
            this.Controls.Add(this.dgvUserReport);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ReportsScreen";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApptReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCityReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox userBox;
        private System.Windows.Forms.DataGridView dgvUserReport;
        private System.Windows.Forms.DataGridView dgvApptReport;
        private System.Windows.Forms.DataGridView dgvCityReport;
        private System.Windows.Forms.Button backButton;
    }
}