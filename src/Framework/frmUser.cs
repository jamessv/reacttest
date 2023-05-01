using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using LPLERP.Common;

namespace LPLERP.Engine
{
    public class frmUser : CommonForm
    {
        private string[] permissions = new string[] { "CanSelect", "CanInsert", "CanUpdate", "CanDelete", "CanExport", "CanPrint" };
        private clsDataControler objDC;
        private clsSecurity objSecurity;
        private clsUserInformation objUserInformation;
        private DataSet dsInitial;
        private DataSet dsMain;
    
        #region Windows Controls Declarations...

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdApplication;
        private System.Windows.Forms.Panel pnlChkBox;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.CheckBox chkIsAdmin;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
        private System.Windows.Forms.Label label7;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtName;
        private System.Windows.Forms.Label label6;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtConfirmPassword;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPassword;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdGroup;
        private System.Windows.Forms.Panel pnlLeft;
        private Infragistics.Win.UltraWinGrid.UltraCombo cboUserCode;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Splitter splitter4;
        private Panel pnlTest;
        private Panel pnlTest1;
        private Panel pnlBody;
        private Panel panel5;
        private UltraGrid grdLocation;
        private System.ComponentModel.Container components = null;
        DataTable tblForm;
        private Label label4;
        private SearchGrid grdForm;
        private SearchGrid grdReport;
        private Splitter splitter1;
        #endregion
        private Box box1;
        private UltraCombo cmbEmployeeCode;
        private Infragistics.Win.Misc.UltraButton btnFind;
        private CheckBox chkIsInternal;

        DataTable tblReport;

        public frmUser()
        {
            InitializeComponent();
            //
            this.objDC = new clsDataControler();
            this.objSecurity = new clsSecurity();
            objUserInformation = new clsUserInformation();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            Infragistics.Win.UltraWinGrid.UltraGridLayout ultraGridLayout1 = new Infragistics.Win.UltraWinGrid.UltraGridLayout();
            Infragistics.Win.UltraWinGrid.UltraGridLayout ultraGridLayout2 = new Infragistics.Win.UltraWinGrid.UltraGridLayout();
            Infragistics.Win.UltraWinGrid.UltraGridLayout ultraGridLayout3 = new Infragistics.Win.UltraWinGrid.UltraGridLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlTest = new System.Windows.Forms.Panel();
            this.grdGroup = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.grdApplication = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.grdLocation = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.pnlChkBox = new System.Windows.Forms.Panel();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnFind = new Infragistics.Win.Misc.UltraButton();
            this.cmbEmployeeCode = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtUserName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUserCode = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label3 = new System.Windows.Forms.Label();
            this.box1 = new LPLERP.Common.Box();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlTest1 = new System.Windows.Forms.Panel();
            this.grdReport = new LPLERP.Common.SearchGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grdForm = new LPLERP.Common.SearchGrid();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.chkIsInternal = new System.Windows.Forms.CheckBox();
            this.PanelContainer.SuspendLayout();
            this.PanelMandatory.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocation)).BeginInit();
            this.pnlChkBox.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserCode)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlTest1.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 14;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.pnlBody);
            this.PanelContainer.Size = new System.Drawing.Size(1028, 524);
            // 
            // pnlButton
            // 
            this.pnlButton.Size = new System.Drawing.Size(529, 29);
            // 
            // pnlPreview
            // 
            this.pnlPreview.Location = new System.Drawing.Point(449, 0);
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.Controls.Add(this.pnlTest);
            this.pnlLeft.Controls.Add(this.panel5);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(0, 16, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(400, 518);
            this.pnlLeft.TabIndex = 27;
            // 
            // pnlTest
            // 
            this.pnlTest.Controls.Add(this.grdGroup);
            this.pnlTest.Controls.Add(this.grdApplication);
            this.pnlTest.Controls.Add(this.grdLocation);
            this.pnlTest.Controls.Add(this.pnlChkBox);
            this.pnlTest.Controls.Add(this.splitter2);
            this.pnlTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTest.Location = new System.Drawing.Point(0, 224);
            this.pnlTest.Name = "pnlTest";
            this.pnlTest.Size = new System.Drawing.Size(400, 294);
            this.pnlTest.TabIndex = 78;
            // 
            // grdGroup
            // 
            this.grdGroup.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Standard;
            this.grdGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGroup.Layouts.Add(ultraGridLayout1);
            this.grdGroup.Location = new System.Drawing.Point(0, 143);
            this.grdGroup.Name = "grdGroup";
            this.grdGroup.Size = new System.Drawing.Size(400, 60);
            this.grdGroup.TabIndex = 10;
            this.grdGroup.Text = "Group(s)";
            this.grdGroup.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdGroup.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdGroup_InitializeLayout);
            // 
            // grdApplication
            // 
            this.grdApplication.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Standard;
            this.grdApplication.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdApplication.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdApplication.Layouts.Add(ultraGridLayout2);
            this.grdApplication.Location = new System.Drawing.Point(0, 203);
            this.grdApplication.Name = "grdApplication";
            this.grdApplication.Size = new System.Drawing.Size(400, 91);
            this.grdApplication.TabIndex = 11;
            this.grdApplication.Text = "Application";
            this.grdApplication.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdApplication.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdApplication_InitializeLayout);
            // 
            // grdLocation
            // 
            this.grdLocation.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Standard;
            this.grdLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdLocation.Layouts.Add(ultraGridLayout3);
            this.grdLocation.Location = new System.Drawing.Point(0, 33);
            this.grdLocation.Name = "grdLocation";
            this.grdLocation.Size = new System.Drawing.Size(400, 110);
            this.grdLocation.TabIndex = 9;
            this.grdLocation.Text = "Locations(s)";
            this.grdLocation.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdLocation.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdLocation_InitializeLayout);
            // 
            // pnlChkBox
            // 
            this.pnlChkBox.Controls.Add(this.chkIsInternal);
            this.pnlChkBox.Controls.Add(this.chkIsActive);
            this.pnlChkBox.Controls.Add(this.chkIsAdmin);
            this.pnlChkBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChkBox.Location = new System.Drawing.Point(0, 3);
            this.pnlChkBox.Name = "pnlChkBox";
            this.pnlChkBox.Size = new System.Drawing.Size(400, 30);
            this.pnlChkBox.TabIndex = 260;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsActive.Location = new System.Drawing.Point(105, 6);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(80, 16);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Active User";
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsAdmin.Location = new System.Drawing.Point(14, 6);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(80, 16);
            this.chkIsAdmin.TabIndex = 7;
            this.chkIsAdmin.Text = "Admin User";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(400, 3);
            this.splitter2.TabIndex = 261;
            this.splitter2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnFind);
            this.panel5.Controls.Add(this.cmbEmployeeCode);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtConfirmPassword);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtPassword);
            this.panel5.Controls.Add(this.txtName);
            this.panel5.Controls.Add(this.txtUserName);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtEmail);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.cboUserCode);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.box1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(400, 208);
            this.panel5.TabIndex = 262;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(331, 177);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(27, 23);
            this.btnFind.TabIndex = 265;
            this.btnFind.TabStop = false;
            this.btnFind.Text = "F";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cmbEmployeeCode
            // 
            this.cmbEmployeeCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEmployeeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cmbEmployeeCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbEmployeeCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.cmbEmployeeCode.Location = new System.Drawing.Point(130, 178);
            this.cmbEmployeeCode.Name = "cmbEmployeeCode";
            this.cmbEmployeeCode.Size = new System.Drawing.Size(195, 22);
            this.cmbEmployeeCode.TabIndex = 264;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 263;
            this.label4.Text = "Employee ID";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.txtConfirmPassword.Location = new System.Drawing.Point(130, 128);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '@';
            this.txtConfirmPassword.Size = new System.Drawing.Size(196, 19);
            this.txtConfirmPassword.TabIndex = 4;
            this.txtConfirmPassword.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "User Code";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.txtPassword.Location = new System.Drawing.Point(130, 103);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '@';
            this.txtPassword.Size = new System.Drawing.Size(196, 19);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.txtName.Location = new System.Drawing.Point(130, 53);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(195, 19);
            this.txtName.TabIndex = 1;
            this.txtName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.txtUserName.Location = new System.Drawing.Point(130, 78);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(195, 19);
            this.txtUserName.TabIndex = 2;
            this.txtUserName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "User Name";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BorderStyle = Infragistics.Win.UIElementBorderStyle.InsetSoft;
            this.txtEmail.Location = new System.Drawing.Point(130, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(196, 19);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Confirm Password";
            // 
            // cboUserCode
            // 
            this.cboUserCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUserCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboUserCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboUserCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.cboUserCode.Location = new System.Drawing.Point(130, 26);
            this.cboUserCode.Name = "cboUserCode";
            this.cboUserCode.Size = new System.Drawing.Size(195, 22);
            this.cboUserCode.TabIndex = 0;
            this.cboUserCode.Leave += new System.EventHandler(this.cboUserCode_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password";
            // 
            // box1
            // 
            this.box1.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(250)))), ((int)(((byte)(246)))));
            this.box1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.box1.Caption = " User Information";
            this.box1.CaptionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.box1.CaptionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.box1.CaptionHeight = 17;
            this.box1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.box1.Location = new System.Drawing.Point(0, 0);
            this.box1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(400, 208);
            this.box1.TabIndex = 262;
            this.box1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(347, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 16, 8, 0);
            this.panel1.Size = new System.Drawing.Size(389, 478);
            this.panel1.TabIndex = 29;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(2, 16);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(379, 3);
            this.splitter4.TabIndex = 68;
            this.splitter4.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(8, 224);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.panel2.Size = new System.Drawing.Size(312, 248);
            this.panel2.TabIndex = 260;
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(0, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 3);
            this.splitter3.TabIndex = 0;
            this.splitter3.TabStop = false;
            // 
            // pnlTest1
            // 
            this.pnlTest1.Controls.Add(this.grdReport);
            this.pnlTest1.Controls.Add(this.splitter1);
            this.pnlTest1.Controls.Add(this.grdForm);
            this.pnlTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTest1.Location = new System.Drawing.Point(400, 0);
            this.pnlTest1.Name = "pnlTest1";
            this.pnlTest1.Size = new System.Drawing.Size(614, 518);
            this.pnlTest1.TabIndex = 79;
            // 
            // grdReport
            // 
            this.grdReport.ArrHidden = null;
            this.grdReport.ArrWidth = null;
            this.grdReport.dataSource = null;
            this.grdReport.defaultRowFilter = null;
            this.grdReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReport.Location = new System.Drawing.Point(0, 306);
            this.grdReport.Name = "grdReport";
            this.grdReport.Size = new System.Drawing.Size(614, 212);
            this.grdReport.TabIndex = 13;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 296);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(614, 10);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // grdForm
            // 
            this.grdForm.ArrHidden = null;
            this.grdForm.ArrWidth = null;
            this.grdForm.dataSource = null;
            this.grdForm.defaultRowFilter = null;
            this.grdForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdForm.Location = new System.Drawing.Point(0, 0);
            this.grdForm.Name = "grdForm";
            this.grdForm.Size = new System.Drawing.Size(614, 296);
            this.grdForm.TabIndex = 12;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.pnlTest1);
            this.pnlBody.Controls.Add(this.pnlLeft);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(6, 6);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1014, 518);
            this.pnlBody.TabIndex = 80;
            // 
            // chkIsInternal
            // 
            this.chkIsInternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIsInternal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsInternal.Location = new System.Drawing.Point(191, 6);
            this.chkIsInternal.Name = "chkIsInternal";
            this.chkIsInternal.Size = new System.Drawing.Size(80, 16);
            this.chkIsInternal.TabIndex = 9;
            this.chkIsInternal.Text = "Is Internal";
            // 
            // frmUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1028, 564);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUser";
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.frmUser_Load);
            this.PanelContainer.ResumeLayout(false);
            this.PanelMandatory.ResumeLayout(false);
            this.PanelMandatory.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.pnlPreview.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocation)).EndInit();
            this.pnlChkBox.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUserCode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlTest1.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       
        #endregion

        private void frmUser_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.grdForm.grdSource.InitializeLayout += new InitializeLayoutEventHandler(grdSource_InitializeLayout);
                this.grdReport.grdSource.InitializeLayout += new InitializeLayoutEventHandler(grdSource1_InitializeLayout);
                this.loadInitialData(true);
                SetControllLength();
            }
            catch (Exception ex)
            {
                Utility.saveError("Error: \n" + ex.Message + "\n\nCall Stack: \n" + ex.StackTrace, this.Name, "frmUser_Load", true);
            }
        }

        private void SetControllLength()
        {
            txtConfirmPassword.MaxLength = 19;
            txtEmail.MaxLength = 50;
            txtName.MaxLength = 100;
            txtPassword.MaxLength = 19;
            txtUserName.MaxLength = 19;
        }

        private void loadInitialData(bool connect)
        {
            Utility.showInformation("Establishing connection to server...");
            if (connect)
            {
                this.objSecurity.getUser(ref this.dsInitial);
                this.clearAll(false);
            }
            this.dsInitial.Tables[0].TableName = "AP";
            this.dsInitial.Tables[1].TableName = "Menu";
            this.dsInitial.Tables[2].TableName = "RMenu";
            this.dsInitial.Tables[3].TableName = "LOC";
            this.dsInitial.Tables[4].TableName = "GT";
            this.dsInitial.Tables[5].TableName = "User";
            this.dsInitial.Tables[6].TableName = "GM";
            this.dsInitial.Tables[7].TableName = "EMP";
            this.grdApplication.DataSource = this.dsInitial.Tables["AP"];
            this.grdForm.grdSource.DataSource = this.dsInitial.Tables["Menu"];
            this.grdReport.grdSource.DataSource = this.dsInitial.Tables["RMenu"];
            this.grdLocation.DataSource = this.dsInitial.Tables["LOC"];
            this.grdGroup.DataSource = this.dsInitial.Tables["GT"];
            this.cboUserCode.DataSource = this.dsInitial.Tables["User"];
            this.cboUserCode.DisplayMember = "UserCode";
            this.cboUserCode.ValueMember = "UserCode";
            //
            this.cmbEmployeeCode.DataSource = this.dsInitial.Tables["EMP"];
            this.cmbEmployeeCode.DisplayMember = "EmployeeID";
            this.cmbEmployeeCode.ValueMember = "EmployeeID";
            //			
            Utility.hideInformation();
        }

        private void cboUserCode_Leave(object sender, System.EventArgs e)
        {
            try
            {
                ClearLocation();
                objSecurity.getUserByCode(ref dsMain, cboUserCode.Text.ToString());
                if (dsMain.Tables["User"].Rows.Count > 0)
                {
                    this.objDC.setDataToControl(this.pnlLeft, this.dsMain.Tables["User"].Rows[0]);
                    txtUserName.Text = Utility.decriptData(txtUserName.Text);
                    txtPassword.Text = Utility.decriptData(txtPassword.Text);
                }
                else
                {
                    this.clearAll(true);
                }
                LoadLocation();
            }
            catch (Exception ex)
            {
                this.messageBox(ex.Message);
            }
        }

        private void ClearLocation()
        {
            foreach (DataRow r in dsInitial.Tables["LOC"].Rows)
            {
                r["Check"] = false;
            }
            foreach (DataRow r in dsInitial.Tables["GT"].Rows)
            {
                r["Check"] = false;
            }
            foreach (DataRow r in dsInitial.Tables["AP"].Rows)
            {
                r["Check"] = false;
            }
        }

        private void LoadLocation()
        {
            foreach (DataRow r in dsMain.Tables["UL"].Rows)
            {
                DataRow[] dr = null;
                dr = dsInitial.Tables["LOC"].Select("LocationID = '" + r["LocationID"] + "'");

                if (dr.Length > 0)
                {
                    dr[0]["Check"] = true;
                }

            }
            //
            foreach (DataRow r in dsMain.Tables["UG"].Rows)
            {
                DataRow[] dr = null;
                dr = dsInitial.Tables["GT"].Select("GroupCode = '" + r["GroupCode"] + "'");

                if (dr.Length > 0)
                {
                    dr[0]["Check"] = true;
                }

            }
            //
            foreach (DataRow r in dsMain.Tables["AU"].Rows)
            {
                DataRow[] dr = null;
                dr = dsInitial.Tables["AP"].Select("ApplicationID = '" + r["ApplicationID"] + "'");

                if (dr.Length > 0)
                {
                    dr[0]["Check"] = true;
                }

            }
            //
            foreach (DataRow r in dsMain.Tables["UP"].Rows)
            {
                DataRow[] dr = null;
                dr = dsInitial.Tables["Menu"].Select("MenuID = '" + r["MenuID"] + "'");

                if (dr.Length > 0)
                {
                    dr[0]["CanSelect"] = r["CanSelect"];
                    dr[0]["CanInsert"] = r["CanInsert"];
                    dr[0]["CanUpdate"] = r["CanUpdate"];
                    dr[0]["CanDelete"] = r["CanDelete"];
                    dr[0]["CanExport"] = r["CanExport"];
                    dr[0]["CanPrint"] = r["CanPrint"];
                }
                //
                DataRow[] dr1 = null;
                dr1 = dsInitial.Tables["RMenu"].Select("MenuID = '" + r["MenuID"] + "'");

                if (dr1.Length > 0)
                {
                    dr1[0]["CanSelect"] = r["CanSelect"];
                    dr1[0]["CanInsert"] = r["CanInsert"];
                    dr1[0]["CanUpdate"] = r["CanUpdate"];
                    dr1[0]["CanDelete"] = r["CanDelete"];
                    dr1[0]["CanExport"] = r["CanExport"];
                    dr1[0]["CanPrint"] = r["CanPrint"];
                }
            }
            //
        }


        #region initialization
        private void clearAll(bool withCode)
        {
            string strUsercode = this.cboUserCode.Text.ToString();
            if (withCode)
            {
                this.objDC.clearAll(this.panel5, null);
            }
            else
            {
                this.objDC.clearAll(this.panel5, new string[] { this.cboUserCode.Name });
            }
            chkIsActive.Checked = false;
            chkIsAdmin.Checked = false;
            cboUserCode.Text = strUsercode;
            txtName.Focus();
        }
        private bool checkPre()
        {
            if (this.cboUserCode.Text.Trim().Length == 0)
            {
                this.messageBox("User code can't be blank.", MessageBoxIcon.Information);
                this.cboUserCode.Focus();
                return false;
            }
            return true;
        }
        private bool checkPreSave()
        {
            if (!this.checkPre()) return false;
            DataRow[] drc = this.dsInitial.Tables["User"].Select("UserName = '" + Utility.encriptData(this.txtUserName.Text) + "'");
            if (drc.Length > 0 && drc[0]["UserCode"].ToString() != this.cboUserCode.Text.Trim())
            {
                this.messageBox("This user name already assign for another user. Please change the user name.", MessageBoxIcon.Information);
                this.txtUserName.Focus();
                return false;
            }
            return true;
        }
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            //ClearGrids();
            //this.cboUserCode_Leave();
            //LoadLocation();
            //grdLocation.DataSource = dsUserInformation.Tables["Location"];
        }

        private void ClearGrids()
        {
            //foreach (DataRow r in dsUserInformation.Tables["location"].Rows)
            //{
            //    r["Checked"] = false;
            //}
            //foreach (DataRow r in dsInitial.Tables["Application"].Rows)
            //{
            //    r[0] = false;
            //}
            //foreach (DataRow r in dsBU.Tables["Business_Unit"].Rows)
            //{
            //    r[0] = false;
            //}
        }

        private void grdGroup_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //this.Initializer.makeGridAsListBox(e,"BusinessUnitName",200);
            this.Initializer.readOnlyColumn(e.Layout.Bands[0], new string[] { "GroupCode", "GroupName" }, true);
            e.Layout.Bands[0].Columns["GroupCode"].Header.Caption = "Group Code";
            e.Layout.Bands[0].Columns["GroupCode"].Width = 90;
            e.Layout.Bands[0].Columns["GroupName"].Header.Caption = "Group Name";
            e.Layout.Bands[0].Columns["GroupName"].Width = 150;
            e.Layout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[0].Width = 30;
        }

        private void grdApplication_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["ApplicationID"].Hidden = true;
            this.Initializer.readOnlyColumn(e.Layout.Bands[0], new string[] { "ApplicatonID", "ApplicationName" }, true);
            e.Layout.Bands[0].Columns["Check"].Header.Caption = string.Empty;
            e.Layout.Bands[0].Columns["Check"].Width = 30;
            e.Layout.Bands[0].Columns["ApplicationName"].Header.Caption = "Name";
            //e.Layout.Bands[0].Columns["IsDefault"].Header.Caption = "Default";			
            e.Layout.Bands[0].Columns["ApplicationName"].Width = 250;
            e.Layout.Override.RowSelectors = DefaultableBoolean.False;
            //e.Layout.Bands[0].Columns["IsDefault"].Width = 60;
            e.Layout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

        }

        private void grdSource_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.commonSetting(e);
            //e.Layout.Bands[0].Columns[2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[3].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[4].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[5].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[6].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[7].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns[8].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.Initializer.hideColumn(e.Layout.Bands[0], new string[] { "CanExport" }, true);
        }

        private void commonSetting(Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.Initializer.hideColumn(e.Layout.Bands[0], new string[] { "MenuID", "ValueMember" }, true);
            e.Layout.Bands[0].Columns["DisplayMember"].Header.Caption = "Display Name";
            e.Layout.Bands[0].Columns["DisplayMember"].Width = 300;
            e.Layout.Bands[0].Columns["MenuType"].Header.Caption = "Menu Type";
            e.Layout.Bands[0].Columns["MenuType"].Width = 120;
            this.Initializer.readOnlyColumn(e.Layout.Bands[0], "DisplayMember", true);
            foreach (string str in permissions)
            {
                e.Layout.Bands[0].Columns[str].Header.Caption = str.Substring(3);
                e.Layout.Bands[0].Columns[str].Width = 45;
            }
        }

        private void grdSource1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns["CanSelect"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns["CanExport"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            e.Layout.Bands[0].Columns["CanPrint"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            this.commonSetting(e);
            this.Initializer.hideColumn(e.Layout.Bands[0], new string[] { "CanInsert", "CanUpdate", "CanDelete" }, true);
        }
        #endregion


        void btnFind_Click(object sender, EventArgs e)
        {
            using (frmFind objFind = new frmFind(this.dsInitial.Tables["EMP"], "Employee find", null))
            {
                if (objFind.ShowDialog() != DialogResult.Cancel)
                {
                    cmbEmployeeCode.Text = objFind.drReturn["EmployeeID"].ToString();
                    
                }
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {


            if (!this.checkPreSave())
            {
                return;
            }
            if (chkIsInternal.Checked == true && cmbEmployeeCode.Text.Length == 0)
            {
                this.messageBox("User has been selected as Internal...\nPlease select this user's Employee ID... ", MessageBoxIcon.Information);
                this.cmbEmployeeCode.Focus();
                return;
            }
            //
            this.txtUserName.Text = Utility.encriptData(this.txtUserName.Text);
            this.txtPassword.Text = Utility.encriptData(this.txtPassword.Text);
            this.objDC.getDataFromControl(this.dsMain.Tables["User"], "UserCode = '" + this.cboUserCode.Text.Trim() + "'", this.pnlLeft, User.UserCode);
            //
            this.saveData();
            this.cboUserCode_Leave(sender, e);
        }


        private void saveData()
        {
            DataSet dsSave = new DataSet();
            try
            {
                this.showInformation("Saving data. Please wait...");
                LoadForSave();
                this.objDC.SetUserCodeForDataset(ref dsMain);
                objSecurity.saveUserInformation(ref dsMain);
                this.loadInitialData(true);
            }
            catch (Exception ex)
            {
                this.saveError("Error: \n" + ex.Message + "\n\nCall Stack: \n" + ex.StackTrace, this.Name, "saveData", true);
            }
            finally
            {
                dsSave = null;
            }
        }

        private void LoadForSave()
        {
            LoadUserLocationForSave();
            LoadUserGroupForSave();
            LoadApplicationUserForSave();
            LoadFormMainForSave();
        }


        private void LoadUserLocationForSave()
        {
            foreach (DataRow r in dsInitial.Tables["LOC"].Rows)
            {
                DataRow[] dr = null;
                DataRow[] drr = null;

                if (r["Check"].ToString() == "1" || Convert.ToBoolean(r["Check"].ToString()) == true)
                {
                    dr = dsMain.Tables["UL"].Select("LocationID = '" + r["LocationID"] + "'");
                    if (dr.Length == 0)
                    {
                        DataRow row = dsMain.Tables["UL"].NewRow();

                        row["UserCode"] = cboUserCode.Text;
                        row["LocationID"] = r["LocationID"];
                        row["IsDefault"] = r["Default"];
                        dsMain.Tables["UL"].Rows.Add(row);
                    }
                    else
                    {
                        dr[0]["UserCode"] = cboUserCode.Text;
                        dr[0]["LocationID"] = r["LocationID"];
                        dr[0]["IsDefault"] = r["Default"];
                    }
                }
                else if (r["Check"].ToString() == "0" || Convert.ToBoolean(r["Check"].ToString()) == false)
                {
                    drr = dsMain.Tables["UL"].Select("LocationID = '" + r["LocationID"] + "'");
                    if (drr.Length > 0)
                    {
                        foreach (DataRow drDelete in drr)
                        {
                            drDelete.Delete();
                        }
                    }
                }
            }
        }


        private void LoadUserGroupForSave()
        {
            foreach (DataRow r in dsInitial.Tables["GT"].Rows)
            {
                DataRow[] dr = null;
                DataRow[] drr = null;

                if (r["Check"].ToString() == "1" || Convert.ToBoolean(r["Check"].ToString()) == true)
                {
                    dr = dsMain.Tables["UG"].Select("GroupCode = '" + r["GroupCode"] + "'");
                    if (dr.Length == 0)
                    {
                        DataRow row = dsMain.Tables["UG"].NewRow();

                        row["UserCode"] = cboUserCode.Text;
                        row["GroupCode"] = r["GroupCode"];
                        dsMain.Tables["UG"].Rows.Add(row);
                    }
                    else
                    {
                        dr[0]["UserCode"] = cboUserCode.Text;
                        dr[0]["GroupCode"] = r["GroupCode"];
                    }
                }
                else if (r["Check"].ToString() == "0" || Convert.ToBoolean(r["Check"].ToString()) == false)
                {
                    drr = dsMain.Tables["UG"].Select("GroupCode = '" + r["GroupCode"] + "'");
                    if (drr.Length > 0)
                    {
                        foreach (DataRow drDelete in drr)
                        {
                            drDelete.Delete();
                        }
                    }
                }
            }
        }

        private void LoadApplicationUserForSave()
        {
            foreach (DataRow r in dsInitial.Tables["AP"].Rows)
            {
                DataRow[] dr = null;
                DataRow[] drr = null;

                if (r["Check"].ToString() == "1" || Convert.ToBoolean(r["Check"].ToString()) == true)
                {
                    dr = dsMain.Tables["AU"].Select("ApplicationID = '" + r["ApplicationID"] + "'");
                    if (dr.Length == 0)
                    {
                        DataRow row = dsMain.Tables["AU"].NewRow();

                        row["UserCode"] = cboUserCode.Text;
                        row["ApplicationID"] = r["ApplicationID"];
                        row["IsDefault"] = false;
                        dsMain.Tables["AU"].Rows.Add(row);
                    }
                    else
                    {
                        dr[0]["UserCode"] = cboUserCode.Text;
                        dr[0]["ApplicationID"] = r["ApplicationID"];
                    }
                }
                else if (r["Check"].ToString() == "0" || Convert.ToBoolean(r["Check"].ToString()) == false)
                {
                    drr = dsMain.Tables["AU"].Select("ApplicationID = '" + r["ApplicationID"] + "'");
                    if (drr.Length > 0)
                    {
                        foreach (DataRow drDelete in drr)
                        {
                            drDelete.Delete();
                        }
                    }
                }
            }
        }


        private void LoadFormMainForSave()
        {
            foreach (DataRow r in dsInitial.Tables["Menu"].Rows)
            {
                DataRow[] dr = null;
                dr = dsMain.Tables["UP"].Select("MenuID = '" + r["MenuID"] + "'");
                if (dr.Length == 0)
                {
                    DataRow row = dsMain.Tables["UP"].NewRow();

                    row["CanSelect"] = r["CanSelect"];
                    row["CanInsert"] = r["CanInsert"];
                    row["CanUpdate"] = r["CanUpdate"];
                    row["CanDelete"] = r["CanDelete"];
                    row["CanExport"] = r["CanExport"];
                    row["CanPrint"] = r["CanPrint"];
                    row["MenuID"] = r["MenuID"];
                    row["UserCode"] = cboUserCode.Text;
                    dsMain.Tables["UP"].Rows.Add(row);
                }
                else
                {
                    dr[0]["CanSelect"] = r["CanSelect"];
                    dr[0]["CanInsert"] = r["CanInsert"];
                    dr[0]["CanUpdate"] = r["CanUpdate"];
                    dr[0]["CanDelete"] = r["CanDelete"];
                    dr[0]["CanExport"] = r["CanExport"];
                    dr[0]["CanPrint"] = r["CanPrint"];
                    dr[0]["MenuID"] = r["MenuID"];
                    dr[0]["UserCode"] = cboUserCode.Text;
                }
            }
            //
            foreach (DataRow r in dsInitial.Tables["RMenu"].Rows)
            {
                DataRow[] dr = null;
                dr = dsMain.Tables["UP"].Select("MenuID = '" + r["MenuID"] + "'");
                if (dr.Length == 0)
                {
                    DataRow row = dsMain.Tables["UP"].NewRow();

                    row["CanSelect"] = r["CanSelect"];
                    row["CanInsert"] = r["CanInsert"];
                    row["CanUpdate"] = r["CanUpdate"];
                    row["CanDelete"] = r["CanDelete"];
                    row["CanExport"] = r["CanExport"];
                    row["CanPrint"] = r["CanPrint"];
                    row["MenuID"] = r["MenuID"];
                    row["UserCode"] = cboUserCode.Text;
                    dsMain.Tables["UP"].Rows.Add(row);
                }
                else
                {
                    dr[0]["CanSelect"] = r["CanSelect"];
                    dr[0]["CanInsert"] = r["CanInsert"];
                    dr[0]["CanUpdate"] = r["CanUpdate"];
                    dr[0]["CanDelete"] = r["CanDelete"];
                    dr[0]["CanExport"] = r["CanExport"];
                    dr[0]["CanPrint"] = r["CanPrint"];
                    dr[0]["MenuID"] = r["MenuID"];
                    dr[0]["UserCode"] = cboUserCode.Text;
                }
            }
        }


        private void btnDelete_Click(object sender, System.EventArgs e)
        {
        }

        private void grdLocation_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            UltraGridBand Band = e.Layout.Bands[0];
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            Band.Columns["LocationName"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            Band.Columns["LocationName"].Header.Caption = "Location Name";
            Band.Columns["LocationName"].Width = 150;
            Band.Columns["LocationType"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            Band.Columns["LocationType"].Header.Caption = "Location Type";
            Band.Columns["LocationType"].Width = 90;
            Band.Columns["Check"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Band.Columns["LocationID"].Hidden = true;
        }
        //01911254574
    }
}
