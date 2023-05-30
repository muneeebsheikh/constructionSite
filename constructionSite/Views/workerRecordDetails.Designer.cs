namespace constructionSite.Views
{
    partial class workerRecordDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(workerRecordDetails));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBack = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dgvWorkerDetails = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colSerailNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCNIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblName = new System.Windows.Forms.Label();
            this.btnExit = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnUpdateWorker = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTypeOfWork = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCNIC = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContactNumber = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPersonName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnDeleteWorker = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAddBill = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.SuspendLayout();
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
            this.btnBack.Location = new System.Drawing.Point(7, 10);
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
            this.btnDashboard.Location = new System.Drawing.Point(104, 10);
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
            // dgvWorkerDetails
            // 
            this.dgvWorkerDetails.AllowUserToAddRows = false;
            this.dgvWorkerDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvWorkerDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkerDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWorkerDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvWorkerDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkerDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkerDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkerDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerailNumber,
            this.colPersonName,
            this.colCNIC,
            this.colContactNumber,
            this.colEmail,
            this.colType,
            this.colBalance});
            this.dgvWorkerDetails.DoubleBuffered = true;
            this.dgvWorkerDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvWorkerDetails.EnableHeadersVisualStyles = false;
            this.dgvWorkerDetails.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvWorkerDetails.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.dgvWorkerDetails.HeaderForeColor = System.Drawing.Color.White;
            this.dgvWorkerDetails.Location = new System.Drawing.Point(54, 275);
            this.dgvWorkerDetails.Name = "dgvWorkerDetails";
            this.dgvWorkerDetails.ReadOnly = true;
            this.dgvWorkerDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWorkerDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvWorkerDetails.RowTemplate.Height = 20;
            this.dgvWorkerDetails.Size = new System.Drawing.Size(1268, 405);
            this.dgvWorkerDetails.TabIndex = 15;
            this.dgvWorkerDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkerDetails_CellClick);
            // 
            // colSerailNumber
            // 
            this.colSerailNumber.FillWeight = 35.53299F;
            this.colSerailNumber.HeaderText = "S.no";
            this.colSerailNumber.Name = "colSerailNumber";
            this.colSerailNumber.ReadOnly = true;
            // 
            // colPersonName
            // 
            this.colPersonName.FillWeight = 110.7445F;
            this.colPersonName.HeaderText = "Person Name";
            this.colPersonName.Name = "colPersonName";
            this.colPersonName.ReadOnly = true;
            // 
            // colCNIC
            // 
            this.colCNIC.HeaderText = "CNIC";
            this.colCNIC.Name = "colCNIC";
            this.colCNIC.ReadOnly = true;
            // 
            // colContactNumber
            // 
            this.colContactNumber.FillWeight = 110.7445F;
            this.colContactNumber.HeaderText = "Contact Number";
            this.colContactNumber.Name = "colContactNumber";
            this.colContactNumber.ReadOnly = true;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.FillWeight = 110.7445F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colBalance
            // 
            this.colBalance.FillWeight = 110.7445F;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(568, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 24);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "Name";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageActive = null;
            this.btnExit.Location = new System.Drawing.Point(1308, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(28, 18);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 20;
            this.btnExit.TabStop = false;
            this.btnExit.Zoom = 10;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageActive = null;
            this.btnMinimize.Location = new System.Drawing.Point(1264, 19);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(28, 18);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 19;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 10;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
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
            this.btnUpdateWorker.Location = new System.Drawing.Point(894, 236);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(563, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Type Of work";
            // 
            // txtTypeOfWork
            // 
            this.txtTypeOfWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTypeOfWork.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTypeOfWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTypeOfWork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtTypeOfWork.HintForeColor = System.Drawing.Color.Empty;
            this.txtTypeOfWork.HintText = "";
            this.txtTypeOfWork.isPassword = false;
            this.txtTypeOfWork.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtTypeOfWork.LineIdleColor = System.Drawing.Color.Gray;
            this.txtTypeOfWork.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtTypeOfWork.LineThickness = 3;
            this.txtTypeOfWork.Location = new System.Drawing.Point(567, 174);
            this.txtTypeOfWork.Margin = new System.Windows.Forms.Padding(4);
            this.txtTypeOfWork.Name = "txtTypeOfWork";
            this.txtTypeOfWork.Size = new System.Drawing.Size(200, 32);
            this.txtTypeOfWork.TabIndex = 11;
            this.txtTypeOfWork.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTypeOfWork.Leave += new System.EventHandler(this.txtTypeOfWork_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(563, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Email Address";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtEmail.HintForeColor = System.Drawing.Color.Empty;
            this.txtEmail.HintText = "";
            this.txtEmail.isPassword = false;
            this.txtEmail.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtEmail.LineIdleColor = System.Drawing.Color.Gray;
            this.txtEmail.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtEmail.LineThickness = 3;
            this.txtEmail.Location = new System.Drawing.Point(567, 106);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 32);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "CNIC";
            // 
            // txtCNIC
            // 
            this.txtCNIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCNIC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCNIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCNIC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(215)))));
            this.txtCNIC.HintForeColor = System.Drawing.Color.Empty;
            this.txtCNIC.HintText = "";
            this.txtCNIC.isPassword = false;
            this.txtCNIC.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtCNIC.LineIdleColor = System.Drawing.Color.Gray;
            this.txtCNIC.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtCNIC.LineThickness = 3;
            this.txtCNIC.Location = new System.Drawing.Point(54, 236);
            this.txtCNIC.Margin = new System.Windows.Forms.Padding(4);
            this.txtCNIC.Name = "txtCNIC";
            this.txtCNIC.Size = new System.Drawing.Size(200, 32);
            this.txtCNIC.TabIndex = 7;
            this.txtCNIC.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCNIC.Leave += new System.EventHandler(this.txtCNIC_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Conatct Number";
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
            this.txtContactNumber.Location = new System.Drawing.Point(54, 169);
            this.txtContactNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 32);
            this.txtContactNumber.TabIndex = 5;
            this.txtContactNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContactNumber.Leave += new System.EventHandler(this.txtContactNumber_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Person Name";
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
            this.txtPersonName.Location = new System.Drawing.Point(54, 101);
            this.txtPersonName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(200, 32);
            this.txtPersonName.TabIndex = 3;
            this.txtPersonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPersonName.Leave += new System.EventHandler(this.txtPersonName_Leave);
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
            this.btnDeleteWorker.Location = new System.Drawing.Point(731, 236);
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
            this.btnAddBill.Location = new System.Drawing.Point(567, 236);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(568, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Worker Record";
            // 
            // workerRecordDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 692);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.btnDeleteWorker);
            this.Controls.Add(this.btnUpdateWorker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTypeOfWork);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCNIC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.dgvWorkerDetails);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "workerRecordDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "workerRecordDetails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.workerRecordDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuFlatButton btnBack;
        private Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvWorkerDetails;
        private System.Windows.Forms.Label lblName;
        private Bunifu.Framework.UI.BunifuImageButton btnExit;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerailNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCNIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuFlatButton btnUpdateWorker;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTypeOfWork;
        private System.Windows.Forms.Label label7;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtEmail;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCNIC;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtContactNumber;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPersonName;
        private Bunifu.Framework.UI.BunifuFlatButton btnDeleteWorker;
        private Bunifu.Framework.UI.BunifuFlatButton btnAddBill;
        private System.Windows.Forms.Label label5;
    }
}