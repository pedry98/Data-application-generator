namespace dataApplicationGenerator
{
	partial class frmMain
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
			this.lvwElements = new System.Windows.Forms.ListView();
			this.Field = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.dataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnFindPath = new System.Windows.Forms.Button();
			this.txtFindPath = new System.Windows.Forms.TextBox();
			this.lblFindPath = new System.Windows.Forms.Label();
			this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.lblDataObject = new System.Windows.Forms.Label();
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.lblProjectName = new System.Windows.Forms.Label();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.gbAddFields = new System.Windows.Forms.GroupBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lblInsertFields = new System.Windows.Forms.Label();
			this.txtInsertFields = new System.Windows.Forms.TextBox();
			this.droplistDataTypes = new System.Windows.Forms.ComboBox();
			this.lblElement = new System.Windows.Forms.Label();
			this.cbMain = new System.Windows.Forms.CheckBox();
			this.cbAddEdit = new System.Windows.Forms.CheckBox();
			this.cbCreateClasses = new System.Windows.Forms.CheckBox();
			this.gbAddFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwElements
			// 
			this.lvwElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Field,
            this.dataType});
			this.lvwElements.Location = new System.Drawing.Point(508, 91);
			this.lvwElements.Name = "lvwElements";
			this.lvwElements.Size = new System.Drawing.Size(259, 281);
			this.lvwElements.TabIndex = 0;
			this.lvwElements.UseCompatibleStateImageBehavior = false;
			this.lvwElements.View = System.Windows.Forms.View.Details;
			// 
			// Field
			// 
			this.Field.Text = "Fields";
			this.Field.Width = 100;
			// 
			// dataType
			// 
			this.dataType.Text = "dataType";
			this.dataType.Width = 108;
			// 
			// btnFindPath
			// 
			this.btnFindPath.Location = new System.Drawing.Point(698, 10);
			this.btnFindPath.Name = "btnFindPath";
			this.btnFindPath.Size = new System.Drawing.Size(88, 23);
			this.btnFindPath.TabIndex = 5;
			this.btnFindPath.Text = "...";
			this.btnFindPath.UseVisualStyleBackColor = true;
			this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
			// 
			// txtFindPath
			// 
			this.txtFindPath.Location = new System.Drawing.Point(114, 12);
			this.txtFindPath.Name = "txtFindPath";
			this.txtFindPath.Size = new System.Drawing.Size(578, 20);
			this.txtFindPath.TabIndex = 4;
			// 
			// lblFindPath
			// 
			this.lblFindPath.AutoSize = true;
			this.lblFindPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFindPath.Location = new System.Drawing.Point(20, 15);
			this.lblFindPath.Name = "lblFindPath";
			this.lblFindPath.Size = new System.Drawing.Size(70, 16);
			this.lblFindPath.TabIndex = 3;
			this.lblFindPath.Text = "Find Path: ";
			// 
			// lblDataObject
			// 
			this.lblDataObject.AutoSize = true;
			this.lblDataObject.Location = new System.Drawing.Point(63, 146);
			this.lblDataObject.Name = "lblDataObject";
			this.lblDataObject.Size = new System.Drawing.Size(10, 13);
			this.lblDataObject.TabIndex = 7;
			this.lblDataObject.Text = " ";
			// 
			// txtProjectName
			// 
			this.txtProjectName.Location = new System.Drawing.Point(114, 57);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(100, 20);
			this.txtProjectName.TabIndex = 8;
			this.txtProjectName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProjectName_KeyDown);
			
			// 
			// lblProjectName
			// 
			this.lblProjectName.AutoSize = true;
			this.lblProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblProjectName.Location = new System.Drawing.Point(20, 58);
			this.lblProjectName.Name = "lblProjectName";
			this.lblProjectName.Size = new System.Drawing.Size(93, 16);
			this.lblProjectName.TabIndex = 11;
			this.lblProjectName.Text = "Project Name:";
			// 
			// btnGenerate
			// 
			this.btnGenerate.BackColor = System.Drawing.Color.DarkGreen;
			this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGenerate.ForeColor = System.Drawing.Color.White;
			this.btnGenerate.Location = new System.Drawing.Point(427, 402);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(361, 36);
			this.btnGenerate.TabIndex = 17;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = false;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Maroon;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.Color.White;
			this.btnExit.Location = new System.Drawing.Point(12, 402);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(361, 36);
			this.btnExit.TabIndex = 16;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			// 
			// gbAddFields
			// 
			this.gbAddFields.Controls.Add(this.btnAdd);
			this.gbAddFields.Controls.Add(this.lblInsertFields);
			this.gbAddFields.Controls.Add(this.txtInsertFields);
			this.gbAddFields.Controls.Add(this.droplistDataTypes);
			this.gbAddFields.Controls.Add(this.lblElement);
			this.gbAddFields.Location = new System.Drawing.Point(32, 162);
			this.gbAddFields.Name = "gbAddFields";
			this.gbAddFields.Size = new System.Drawing.Size(446, 210);
			this.gbAddFields.TabIndex = 19;
			this.gbAddFields.TabStop = false;
			this.gbAddFields.Text = "Add Fields";
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(284, 136);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(86, 36);
			this.btnAdd.TabIndex = 24;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lblInsertFields
			// 
			this.lblInsertFields.AutoSize = true;
			this.lblInsertFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInsertFields.Location = new System.Drawing.Point(15, 68);
			this.lblInsertFields.Name = "lblInsertFields";
			this.lblInsertFields.Size = new System.Drawing.Size(80, 16);
			this.lblInsertFields.TabIndex = 23;
			this.lblInsertFields.Text = "Insert Fields";
			// 
			// txtInsertFields
			// 
			this.txtInsertFields.Location = new System.Drawing.Point(153, 64);
			this.txtInsertFields.Name = "txtInsertFields";
			this.txtInsertFields.Size = new System.Drawing.Size(100, 20);
			this.txtInsertFields.TabIndex = 22;
			// 
			// droplistDataTypes
			// 
			this.droplistDataTypes.FormattingEnabled = true;
			this.droplistDataTypes.Items.AddRange(new object[] {
            "String",
            "Int"});
			this.droplistDataTypes.Location = new System.Drawing.Point(153, 27);
			this.droplistDataTypes.Name = "droplistDataTypes";
			this.droplistDataTypes.Size = new System.Drawing.Size(241, 21);
			this.droplistDataTypes.TabIndex = 21;
			// 
			// lblElement
			// 
			this.lblElement.AutoSize = true;
			this.lblElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblElement.Location = new System.Drawing.Point(15, 32);
			this.lblElement.Name = "lblElement";
			this.lblElement.Size = new System.Drawing.Size(113, 16);
			this.lblElement.TabIndex = 20;
			this.lblElement.Text = "Select Data Type";
			// 
			// cbMain
			// 
			this.cbMain.AutoSize = true;
			this.cbMain.Location = new System.Drawing.Point(50, 130);
			this.cbMain.Name = "cbMain";
			this.cbMain.Size = new System.Drawing.Size(83, 17);
			this.cbMain.TabIndex = 20;
			this.cbMain.Text = "Create Main";
			this.cbMain.UseVisualStyleBackColor = true;
			// 
			// cbAddEdit
			// 
			this.cbAddEdit.AutoSize = true;
			this.cbAddEdit.Location = new System.Drawing.Point(169, 130);
			this.cbAddEdit.Name = "cbAddEdit";
			this.cbAddEdit.Size = new System.Drawing.Size(102, 17);
			this.cbAddEdit.TabIndex = 21;
			this.cbAddEdit.Text = "Create Add/Edit";
			this.cbAddEdit.UseVisualStyleBackColor = true;
			// 
			// cbCreateClasses
			// 
			this.cbCreateClasses.AutoSize = true;
			this.cbCreateClasses.Location = new System.Drawing.Point(316, 130);
			this.cbCreateClasses.Name = "cbCreateClasses";
			this.cbCreateClasses.Size = new System.Drawing.Size(96, 17);
			this.cbCreateClasses.TabIndex = 22;
			this.cbCreateClasses.Text = "Create Classes";
			this.cbCreateClasses.UseVisualStyleBackColor = true;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cbCreateClasses);
			this.Controls.Add(this.cbAddEdit);
			this.Controls.Add(this.cbMain);
			this.Controls.Add(this.gbAddFields);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.lblProjectName);
			this.Controls.Add(this.txtProjectName);
			this.Controls.Add(this.lblDataObject);
			this.Controls.Add(this.btnFindPath);
			this.Controls.Add(this.txtFindPath);
			this.Controls.Add(this.lblFindPath);
			this.Controls.Add(this.lvwElements);
			this.Name = "frmMain";
			this.Text = "Main Form";
			this.gbAddFields.ResumeLayout(false);
			this.gbAddFields.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwElements;
		private System.Windows.Forms.ColumnHeader Field;
		private System.Windows.Forms.ColumnHeader dataType;
		private System.Windows.Forms.Button btnFindPath;
		private System.Windows.Forms.TextBox txtFindPath;
		private System.Windows.Forms.Label lblFindPath;
		private System.Windows.Forms.FolderBrowserDialog folderDialog;
		private System.Windows.Forms.Label lblDataObject;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.Label lblProjectName;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.GroupBox gbAddFields;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label lblInsertFields;
		private System.Windows.Forms.TextBox txtInsertFields;
		private System.Windows.Forms.ComboBox droplistDataTypes;
		private System.Windows.Forms.Label lblElement;
		private System.Windows.Forms.CheckBox cbMain;
		private System.Windows.Forms.CheckBox cbAddEdit;
		private System.Windows.Forms.CheckBox cbCreateClasses;
	}
}

