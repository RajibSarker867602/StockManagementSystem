namespace StockManagementSystemApp
{
    partial class StockInForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comNameComboBox = new System.Windows.Forms.ComboBox();
            this.catNameComboBox = new System.Windows.Forms.ComboBox();
            this.itemNameComboBox = new System.Windows.Forms.ComboBox();
            this.reorderLavelTextBox = new System.Windows.Forms.TextBox();
            this.availableQtyTextBox = new System.Windows.Forms.TextBox();
            this.stockInqtyTextBox = new System.Windows.Forms.TextBox();
            this.StockInSaveButton = new System.Windows.Forms.Button();
            this.stockInIdTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stockInDataGridView = new System.Windows.Forms.DataGridView();
            this.stockInModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reorderLavelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availableQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stockInDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockInModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(32, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(32, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Item Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(351, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reorder Lavel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(333, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Available Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(336, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Stock In Quantity";
            // 
            // comNameComboBox
            // 
            this.comNameComboBox.DisplayMember = "ID";
            this.comNameComboBox.FormattingEnabled = true;
            this.comNameComboBox.Location = new System.Drawing.Point(143, 36);
            this.comNameComboBox.Name = "comNameComboBox";
            this.comNameComboBox.Size = new System.Drawing.Size(163, 21);
            this.comNameComboBox.TabIndex = 1;
            this.comNameComboBox.ValueMember = "ID";
            this.comNameComboBox.SelectedIndexChanged += new System.EventHandler(this.comNameComboBox_SelectedIndexChanged);
            // 
            // catNameComboBox
            // 
            this.catNameComboBox.DisplayMember = "ID";
            this.catNameComboBox.FormattingEnabled = true;
            this.catNameComboBox.Location = new System.Drawing.Point(143, 67);
            this.catNameComboBox.Name = "catNameComboBox";
            this.catNameComboBox.Size = new System.Drawing.Size(163, 21);
            this.catNameComboBox.TabIndex = 1;
            this.catNameComboBox.ValueMember = "ID";
            this.catNameComboBox.SelectedIndexChanged += new System.EventHandler(this.catNameComboBox_SelectedIndexChanged);
            // 
            // itemNameComboBox
            // 
            this.itemNameComboBox.DisplayMember = "Id";
            this.itemNameComboBox.FormattingEnabled = true;
            this.itemNameComboBox.Location = new System.Drawing.Point(143, 101);
            this.itemNameComboBox.Name = "itemNameComboBox";
            this.itemNameComboBox.Size = new System.Drawing.Size(163, 21);
            this.itemNameComboBox.TabIndex = 1;
            this.itemNameComboBox.ValueMember = "Id";
            this.itemNameComboBox.SelectedIndexChanged += new System.EventHandler(this.itemNameComboBox_SelectedIndexChanged);
            // 
            // reorderLavelTextBox
            // 
            this.reorderLavelTextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.reorderLavelTextBox.Location = new System.Drawing.Point(431, 41);
            this.reorderLavelTextBox.Name = "reorderLavelTextBox";
            this.reorderLavelTextBox.ReadOnly = true;
            this.reorderLavelTextBox.Size = new System.Drawing.Size(163, 20);
            this.reorderLavelTextBox.TabIndex = 2;
            // 
            // availableQtyTextBox
            // 
            this.availableQtyTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.availableQtyTextBox.Location = new System.Drawing.Point(431, 75);
            this.availableQtyTextBox.Name = "availableQtyTextBox";
            this.availableQtyTextBox.Size = new System.Drawing.Size(163, 20);
            this.availableQtyTextBox.TabIndex = 2;
            // 
            // stockInqtyTextBox
            // 
            this.stockInqtyTextBox.Location = new System.Drawing.Point(431, 109);
            this.stockInqtyTextBox.Name = "stockInqtyTextBox";
            this.stockInqtyTextBox.Size = new System.Drawing.Size(163, 20);
            this.stockInqtyTextBox.TabIndex = 2;
            // 
            // StockInSaveButton
            // 
            this.StockInSaveButton.Location = new System.Drawing.Point(500, 135);
            this.StockInSaveButton.Name = "StockInSaveButton";
            this.StockInSaveButton.Size = new System.Drawing.Size(94, 39);
            this.StockInSaveButton.TabIndex = 3;
            this.StockInSaveButton.Text = "Save";
            this.StockInSaveButton.UseVisualStyleBackColor = true;
            this.StockInSaveButton.Click += new System.EventHandler(this.StockInSaveButton_Click);
            // 
            // stockInIdTextBox
            // 
            this.stockInIdTextBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stockInIdTextBox.Location = new System.Drawing.Point(145, 143);
            this.stockInIdTextBox.Name = "stockInIdTextBox";
            this.stockInIdTextBox.ReadOnly = true;
            this.stockInIdTextBox.Size = new System.Drawing.Size(110, 20);
            this.stockInIdTextBox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(35, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 6;
            // 
            // stockInDataGridView
            // 
            this.stockInDataGridView.AutoGenerateColumns = false;
            this.stockInDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.stockInDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockInDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.idDataGridViewTextBoxColumn,
            this.SL,
            this.nameDataGridViewTextBoxColumn,
            this.createdDateDataGridViewTextBoxColumn,
            this.Name,
            this.Quantity,
            this.Action,
            this.Date,
            this.comIdDataGridViewTextBoxColumn,
            this.catIdDataGridViewTextBoxColumn,
            this.itemIdDataGridViewTextBoxColumn,
            this.reorderLavelDataGridViewTextBoxColumn,
            this.availableQtyDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1});
            this.stockInDataGridView.DataSource = this.stockInModelBindingSource;
            this.stockInDataGridView.Location = new System.Drawing.Point(143, 189);
            this.stockInDataGridView.Name = "stockInDataGridView";
            this.stockInDataGridView.Size = new System.Drawing.Size(509, 150);
            this.stockInDataGridView.TabIndex = 4;
            this.stockInDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockInDataGridView_CellContentClick);
            this.stockInDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockInDataGridView_CellContentDoubleClick);
            // 
            // stockInModelBindingSource
            // 
            this.stockInModelBindingSource.DataSource = typeof(StockManagementSystemApp.Models.StockInModel);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Id.Visible = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // SL
            // 
            this.SL.DataPropertyName = "SL";
            this.SL.HeaderText = "SL";
            this.SL.Name = "SL";
            this.SL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.HeaderText = "CreatedDate";
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Item Name";
            this.Name.Name = "Name";
            this.Name.Visible = false;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Action
            // 
            this.Action.DataPropertyName = "Action";
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "CreatedDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.Visible = false;
            // 
            // comIdDataGridViewTextBoxColumn
            // 
            this.comIdDataGridViewTextBoxColumn.DataPropertyName = "ComId";
            this.comIdDataGridViewTextBoxColumn.HeaderText = "ComId";
            this.comIdDataGridViewTextBoxColumn.Name = "comIdDataGridViewTextBoxColumn";
            this.comIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // catIdDataGridViewTextBoxColumn
            // 
            this.catIdDataGridViewTextBoxColumn.DataPropertyName = "CatId";
            this.catIdDataGridViewTextBoxColumn.HeaderText = "CatId";
            this.catIdDataGridViewTextBoxColumn.Name = "catIdDataGridViewTextBoxColumn";
            this.catIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemIdDataGridViewTextBoxColumn
            // 
            this.itemIdDataGridViewTextBoxColumn.DataPropertyName = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.HeaderText = "ItemId";
            this.itemIdDataGridViewTextBoxColumn.Name = "itemIdDataGridViewTextBoxColumn";
            this.itemIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // reorderLavelDataGridViewTextBoxColumn
            // 
            this.reorderLavelDataGridViewTextBoxColumn.DataPropertyName = "ReorderLavel";
            this.reorderLavelDataGridViewTextBoxColumn.HeaderText = "ReorderLavel";
            this.reorderLavelDataGridViewTextBoxColumn.Name = "reorderLavelDataGridViewTextBoxColumn";
            this.reorderLavelDataGridViewTextBoxColumn.Visible = false;
            // 
            // availableQtyDataGridViewTextBoxColumn
            // 
            this.availableQtyDataGridViewTextBoxColumn.DataPropertyName = "AvailableQty";
            this.availableQtyDataGridViewTextBoxColumn.HeaderText = "AvailableQty";
            this.availableQtyDataGridViewTextBoxColumn.Name = "availableQtyDataGridViewTextBoxColumn";
            this.availableQtyDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "StockInQty";
            this.dataGridViewTextBoxColumn1.HeaderText = "StockInQty";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // StockInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(765, 517);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stockInIdTextBox);
            this.Controls.Add(this.stockInDataGridView);
            this.Controls.Add(this.StockInSaveButton);
            this.Controls.Add(this.stockInqtyTextBox);
            this.Controls.Add(this.availableQtyTextBox);
            this.Controls.Add(this.reorderLavelTextBox);
            this.Controls.Add(this.itemNameComboBox);
            this.Controls.Add(this.catNameComboBox);
            this.Controls.Add(this.comNameComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
           // this.Name = "StockInForm";
            this.Load += new System.EventHandler(this.StockIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockInDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockInModelBindingSource)).EndInit();
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
        private System.Windows.Forms.ComboBox comNameComboBox;
        private System.Windows.Forms.ComboBox catNameComboBox;
        private System.Windows.Forms.ComboBox itemNameComboBox;
        private System.Windows.Forms.TextBox reorderLavelTextBox;
        private System.Windows.Forms.TextBox availableQtyTextBox;
        private System.Windows.Forms.TextBox stockInqtyTextBox;
        private System.Windows.Forms.Button StockInSaveButton;
        private System.Windows.Forms.TextBox stockInIdTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockInQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView stockInDataGridView;
        private System.Windows.Forms.BindingSource stockInModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn comIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn catIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reorderLavelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn availableQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}