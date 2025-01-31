namespace AliceLyC969
{
    partial class AddCustomer
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.customerNameField = new System.Windows.Forms.TextBox();
            this.customerAddressField = new System.Windows.Forms.TextBox();
            this.customerAddress2Field = new System.Windows.Forms.TextBox();
            this.customerCityField = new System.Windows.Forms.TextBox();
            this.customerPostalCodeField = new System.Windows.Forms.TextBox();
            this.customerPhoneField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.customerCountryField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(116, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(131, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "City";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(113, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Phone";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(74, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "Postal Code";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(396, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 30);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButtonClicked);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(498, 480);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 30);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButtonClicked);
            // 
            // customerNameField
            // 
            this.customerNameField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameField.Location = new System.Drawing.Point(205, 110);
            this.customerNameField.Name = "customerNameField";
            this.customerNameField.Size = new System.Drawing.Size(290, 24);
            this.customerNameField.TabIndex = 2;
            this.customerNameField.TextChanged += new System.EventHandler(this.customerNameFieldChanged);
            // 
            // customerAddressField
            // 
            this.customerAddressField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerAddressField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAddressField.Location = new System.Drawing.Point(205, 159);
            this.customerAddressField.Name = "customerAddressField";
            this.customerAddressField.Size = new System.Drawing.Size(290, 24);
            this.customerAddressField.TabIndex = 4;
            this.customerAddressField.TextChanged += new System.EventHandler(this.customerAddressFieldChanged);
            // 
            // customerAddress2Field
            // 
            this.customerAddress2Field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerAddress2Field.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerAddress2Field.Location = new System.Drawing.Point(205, 209);
            this.customerAddress2Field.Name = "customerAddress2Field";
            this.customerAddress2Field.Size = new System.Drawing.Size(290, 24);
            this.customerAddress2Field.TabIndex = 6;
            // 
            // customerCityField
            // 
            this.customerCityField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerCityField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCityField.Location = new System.Drawing.Point(205, 260);
            this.customerCityField.Name = "customerCityField";
            this.customerCityField.Size = new System.Drawing.Size(290, 24);
            this.customerCityField.TabIndex = 8;
            this.customerCityField.TextChanged += new System.EventHandler(this.customerCityFieldChanged);
            // 
            // customerPostalCodeField
            // 
            this.customerPostalCodeField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerPostalCodeField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPostalCodeField.Location = new System.Drawing.Point(205, 366);
            this.customerPostalCodeField.Name = "customerPostalCodeField";
            this.customerPostalCodeField.Size = new System.Drawing.Size(290, 24);
            this.customerPostalCodeField.TabIndex = 12;
            this.customerPostalCodeField.TextChanged += new System.EventHandler(this.customerPostalCodeFieldChanged);
            // 
            // customerPhoneField
            // 
            this.customerPhoneField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerPhoneField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerPhoneField.Location = new System.Drawing.Point(205, 419);
            this.customerPhoneField.Name = "customerPhoneField";
            this.customerPhoneField.Size = new System.Drawing.Size(290, 24);
            this.customerPhoneField.TabIndex = 14;
            this.customerPhoneField.TextChanged += new System.EventHandler(this.customerPhoneFieldChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(104, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Country";
            // 
            // customerCountryField
            // 
            this.customerCountryField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerCountryField.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCountryField.Location = new System.Drawing.Point(205, 313);
            this.customerCountryField.Name = "customerCountryField";
            this.customerCountryField.Size = new System.Drawing.Size(290, 24);
            this.customerCountryField.TabIndex = 10;
            this.customerCountryField.TextChanged += new System.EventHandler(this.customerCountryFieldChanged);
            // 
            // AddCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 546);
            this.Controls.Add(this.customerCountryField);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.customerPhoneField);
            this.Controls.Add(this.customerPostalCodeField);
            this.Controls.Add(this.customerCityField);
            this.Controls.Add(this.customerAddress2Field);
            this.Controls.Add(this.customerAddressField);
            this.Controls.Add(this.customerNameField);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddCustomer";
            this.Text = "Add New Customer";
            this.Load += new System.EventHandler(this.AddCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox customerNameField;
        private System.Windows.Forms.TextBox customerAddressField;
        private System.Windows.Forms.TextBox customerAddress2Field;
        private System.Windows.Forms.TextBox customerCityField;
        private System.Windows.Forms.TextBox customerPostalCodeField;
        private System.Windows.Forms.TextBox customerPhoneField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox customerCountryField;
    }
}