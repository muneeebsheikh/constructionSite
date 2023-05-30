namespace constructionSite.Views
{
    partial class CompanyRecordDtails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyRecordDtails));
            this.dgvCompanyRecord = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colSerailNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShopAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtType = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPersonName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactNumber = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShopAddress = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompanyName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnUpdateWorker = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDeleteWorker = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddBill = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCompanyRecord
            // 
            this.dgvCompanyRecord.AllowUserToAddRows = false;
            this.dgvCompanyRecord.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCompanyRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompanyRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompanyRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompanyRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCompanyRecord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanyRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompanyRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerailNumber,
            this.colCompanyName,
            this.colShopAddress,
            this.colType,
            this.colPersonName,
            this.colContactNumber,
            this.colBalance});
            this.dgvCompanyRecord.DoubleBuffered = true;
            this.dgvCompanyRecord.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCompanyRecord.EnableHeadersVisualStyles = false;
            this.dgvCompanyRecord.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvCompanyRecord.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.dgvCompanyRecord.HeaderForeColor = System.Drawing.Color.White;
            this.dgvCompanyRecord.Location = new System.Drawing.Point(53, 306);
            this.dgvCompanyRecord.Name = "dgvCompanyRecord";
            this.dgvCompanyRecord.ReadOnly = true;
            this.dgvCompanyRecord.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCompanyRecord.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCompanyRecord.RowTemplate.Height = 20;
            this.dgvCompanyRecord.Size = new System.Drawing.Size(1275, 374);
            this.dgvCompanyRecord.TabIndex = 15;
            this.dgvCompanyRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyRecord_CellClick);
            // 
            // colSerailNumber
            // 
            this.colSerailNumber.FillWeight = 35.53299F;
            this.colSerailNumber.HeaderText = "S.no";
            this.colSerailNumber.Name = "colSerailNumber";
            this.colSerailNumber.ReadOnly = true;
            // 
            // colCompanyName
            // 
            this.colCompanyName.FillWeight = 110.7445F;
            this.colCompanyName.HeaderText = "Company Name";
            this.colCompanyName.Name = "colCompanyName";
            this.colCompanyName.ReadOnly = true;
            // 
            // colShopAddress
            // 
            this.colShopAddress.FillWeight = 110.7445F;
            this.colShopAddress.HeaderText = "Shop Address";
            this.colShopAddress.Name = "colShopAddress";
            this.colShopAddress.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.FillWeight = 110.7445F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colPersonName
            // 
            this.colPersonName.FillWeight = 110.7445F;
            this.colPersonName.HeaderText = "Person Name";
            this.colPersonName.Name = "colPersonName";
            this.colPersonName.ReadOnly = true;
            // 
            // colContactNumber
            // 
            this.colContactNumber.FillWeight = 110.7445F;
            this.colContactNumber.HeaderText = "Contact Number";
            this.colContactNumber.Name = "colContactNumber";
            this.colContactNumber.ReadOnly = true;
            // 
            // colBalance
            // 
            this.colBalance.FillWeight = 110.7445F;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(618, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Company Record";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageActive = null;
            this.btnExit.Location = new System.Drawing.Point(1300, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 18);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 10;
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageActive = null;
            this.btnMinimize.Location = new System.Drawing.Point(1256, 16);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 18);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 10;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnBack
            // 
            this.btnBack.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.BorderRadius = 5;
            this.btnBack.ButtonText = "Back";
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DisabledColor = System.Drawing.Color.Gray;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBack.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnBack.Iconimage")));
            this.btnBack.Iconimage_right = null;
            this.btnBack.Iconimage_right_Selected = null;
            this.btnBack.Iconimage_Selected = null;
            this.btnBack.IconMarginLeft = 0;
            this.btnBack.IconMarginRight = 0;
            this.btnBack.IconRightVisible = true;
            this.btnBack.IconRightZoom = 0D;
            this.btnBack.IconVisible = true;
            this.btnBack.IconZoom = 50D;
            this.btnBack.IsTab = false;
            this.btnBack.Location = new System.Drawing.Point(16, 13);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Normalcolor = System.Drawing.Color.Transparent;
            this.btnBack.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnBack.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBack.selected = false;
            this.btnBack.Size = new System.Drawing.Size(85, 38);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard.BorderRadius = 5;
            this.btnDashboard.ButtonText = "DashBoard";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Iconimage")));
            this.btnDashboard.Iconimage_right = null;
            this.btnDashboard.Iconimage_right_Selected = null;
            this.btnDashboard.Iconimage_Selected = null;
            this.btnDashboard.IconMarginLeft = 0;
            this.btnDashboard.IconMarginRight = 0;
            this.btnDashboard.IconRightVisible = true;
            this.btnDashboard.IconRightZoom = 0D;
            this.btnDashboard.IconVisible = true;
            this.btnDashboard.IconZoom = 70D;
            this.btnDashboard.IsTab = false;
            this.btnDashboard.Location = new System.Drawing.Point(113, 13);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnDashboard.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDashboard.selected = false;
            this.btnDashboard.Size = new System.Drawing.Size(148, 38);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "DashBoard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnDashboard.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(624, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Type";
            // 
            // txtType
            // 
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtType.HintForeColor = System.Drawing.Color.Empty;
            this.txtType.HintText = "";
            this.txtType.isPassword = false;
            this.txtType.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtType.LineIdleColor = System.Drawing.Color.Gray;
            this.txtType.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtType.LineThickness = 3;
            this.txtType.Location = new System.Drawing.Point(622, 180);
            this.txtType.Margin = new System.Windows.Forms.Padding(4);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(200, 32);
            this.txtType.TabIndex = 11;
            this.txtType.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(618, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Person Name";
            // 
            // txtPersonName
            // 
            this.txtPersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPersonName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtPersonName.HintForeColor = System.Drawing.Color.Empty;
            this.txtPersonName.HintText = "";
            this.txtPersonName.isPassword = false;
            this.txtPersonName.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPersonName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPersonName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPersonName.LineThickness = 3;
            this.txtPersonName.Location = new System.Drawing.Point(622, 105);
            this.txtPersonName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(200, 32);
            this.txtPersonName.TabIndex = 9;
            this.txtPersonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Conatct Number";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtContactNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtContactNumber.HintForeColor = System.Drawing.Color.Empty;
            this.txtContactNumber.HintText = "";
            this.txtContactNumber.isPassword = false;
            this.txtContactNumber.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtContactNumber.LineIdleColor = System.Drawing.Color.Gray;
            this.txtContactNumber.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtContactNumber.LineThickness = 3;
            this.txtContactNumber.Location = new System.Drawing.Point(61, 247);
            this.txtContactNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 32);
            this.txtContactNumber.TabIndex = 7;
            this.txtContactNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Shop Address";
            // 
            // txtShopAddress
            // 
            this.txtShopAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShopAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShopAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtShopAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtShopAddress.HintForeColor = System.Drawing.Color.Empty;
            this.txtShopAddress.HintText = "";
            this.txtShopAddress.isPassword = false;
            this.txtShopAddress.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtShopAddress.LineIdleColor = System.Drawing.Color.Gray;
            this.txtShopAddress.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtShopAddress.LineThickness = 3;
            this.txtShopAddress.Location = new System.Drawing.Point(61, 174);
            this.txtShopAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtShopAddress.Name = "txtShopAddress";
            this.txtShopAddress.Size = new System.Drawing.Size(200, 32);
            this.txtShopAddress.TabIndex = 5;
            this.txtShopAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtCompanyName.HintForeColor = System.Drawing.Color.Empty;
            this.txtCompanyName.HintText = "";
            this.txtCompanyName.isPassword = false;
            this.txtCompanyName.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtCompanyName.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCompanyName.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtCompanyName.LineThickness = 3;
            this.txtCompanyName.Location = new System.Drawing.Point(61, 99);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(200, 32);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnUpdateWorker
            // 
            this.btnUpdateWorker.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnUpdateWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnUpdateWorker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdateWorker.BorderRadius = 0;
            this.btnUpdateWorker.ButtonText = "  Update";
            this.btnUpdateWorker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateWorker.DisabledColor = System.Drawing.Color.Gray;
            this.btnUpdateWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateWorker.Iconcolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnUpdateWorker.Iconimage = null;
            this.btnUpdateWorker.Iconimage_right = null;
            this.btnUpdateWorker.Iconimage_right_Selected = null;
            this.btnUpdateWorker.Iconimage_Selected = null;
            this.btnUpdateWorker.IconMarginLeft = 0;
            this.btnUpdateWorker.IconMarginRight = 0;
            this.btnUpdateWorker.IconRightVisible = true;
            this.btnUpdateWorker.IconRightZoom = 0D;
            this.btnUpdateWorker.IconVisible = true;
            this.btnUpdateWorker.IconZoom = 75D;
            this.btnUpdateWorker.IsTab = false;
            this.btnUpdateWorker.Location = new System.Drawing.Point(948, 247);
            this.btnUpdateWorker.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnUpdateWorker.Name = "btnUpdateWorker";
            this.btnUpdateWorker.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnUpdateWorker.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnUpdateWorker.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUpdateWorker.selected = false;
            this.btnUpdateWorker.Size = new System.Drawing.Size(153, 32);
            this.btnUpdateWorker.TabIndex = 14;
            this.btnUpdateWorker.Text = "  Update";
            this.btnUpdateWorker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnUpdateWorker.Textcolor = System.Drawing.Color.White;
            this.btnUpdateWorker.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateWorker.Click += new System.EventHandler(this.btnUpdateWorker_Click);
            // 
            // btnDeleteWorker
            // 
            this.btnDeleteWorker.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnDeleteWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnDeleteWorker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteWorker.BorderRadius = 0;
            this.btnDeleteWorker.ButtonText = "Delete";
            this.btnDeleteWorker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteWorker.DisabledColor = System.Drawing.Color.Gray;
            this.btnDeleteWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteWorker.Iconcolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnDeleteWorker.Iconimage = null;
            this.btnDeleteWorker.Iconimage_right = null;
            this.btnDeleteWorker.Iconimage_right_Selected = null;
            this.btnDeleteWorker.Iconimage_Selected = null;
            this.btnDeleteWorker.IconMarginLeft = 0;
            this.btnDeleteWorker.IconMarginRight = 0;
            this.btnDeleteWorker.IconRightVisible = true;
            this.btnDeleteWorker.IconRightZoom = 0D;
            this.btnDeleteWorker.IconVisible = true;
            this.btnDeleteWorker.IconZoom = 75D;
            this.btnDeleteWorker.IsTab = false;
            this.btnDeleteWorker.Location = new System.Drawing.Point(785, 247);
            this.btnDeleteWorker.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnDeleteWorker.Name = "btnDeleteWorker";
            this.btnDeleteWorker.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnDeleteWorker.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnDeleteWorker.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDeleteWorker.selected = false;
            this.btnDeleteWorker.Size = new System.Drawing.Size(151, 32);
            this.btnDeleteWorker.TabIndex = 13;
            this.btnDeleteWorker.Text = "Delete";
            this.btnDeleteWorker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteWorker.Textcolor = System.Drawing.Color.White;
            this.btnDeleteWorker.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteWorker.Click += new System.EventHandler(this.btnDeleteWorker_Click);
            // 
            // btnAddBill
            // 
            this.btnAddBill.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnAddBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnAddBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddBill.BorderRadius = 0;
            this.btnAddBill.ButtonText = "Add Bill";
            this.btnAddBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBill.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBill.Iconcolor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(233)))));
            this.btnAddBill.Iconimage = null;
            this.btnAddBill.Iconimage_right = null;
            this.btnAddBill.Iconimage_right_Selected = null;
            this.btnAddBill.Iconimage_Selected = null;
            this.btnAddBill.IconMarginLeft = 0;
            this.btnAddBill.IconMarginRight = 0;
            this.btnAddBill.IconRightVisible = true;
            this.btnAddBill.IconRightZoom = 0D;
            this.btnAddBill.IconVisible = true;
            this.btnAddBill.IconZoom = 75D;
            this.btnAddBill.IsTab = false;
            this.btnAddBill.Location = new System.Drawing.Point(622, 247);
            this.btnAddBill.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnAddBill.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnAddBill.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddBill.selected = false;
            this.btnAddBill.Size = new System.Drawing.Size(151, 32);
            this.btnAddBill.TabIndex = 12;
            this.btnAddBill.Text = "Add Bill";
            this.btnAddBill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddBill.Textcolor = System.Drawing.Color.White;
            this.btnAddBill.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(618, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 24);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name";
            // 
            // CompanyRecordDtails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 692);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.btnDeleteWorker);
            this.Controls.Add(this.btnUpdateWorker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtShopAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.dgvCompanyRecord);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompanyRecordDtails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompanyRecordDtails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CompanyRecordDtails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvCompanyRecord;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerailNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShopAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtType;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPersonName;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtContactNumber;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtShopAddress;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCompanyName;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdateWorker;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddBill;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteWorker;
        private System.Windows.Forms.Label lblName;
    }
}