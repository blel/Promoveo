﻿namespace PromoveoAddin
{
    partial class PromoveoRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public PromoveoRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnTest = this.Factory.CreateRibbonButton();
            this.btnWebService = this.Factory.CreateRibbonButton();
            this.btnPublish = this.Factory.CreateRibbonButton();
            this.btnMerge = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.btnRoles = this.Factory.CreateRibbonButton();
            this.btnSerialize = this.Factory.CreateRibbonButton();
            this.btnUserManagement = this.Factory.CreateRibbonButton();
            this.btnShapeDataSource = this.Factory.CreateRibbonButton();
            this.btnConfigurations = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.btnModelUserRole = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btnProcessModels = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Label = "Promoveo";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnTest);
            this.group1.Items.Add(this.btnWebService);
            this.group1.Items.Add(this.btnPublish);
            this.group1.Items.Add(this.btnMerge);
            this.group1.Label = "Prototype";
            this.group1.Name = "group1";
            // 
            // btnTest
            // 
            this.btnTest.Label = "Compare Models";
            this.btnTest.Name = "btnTest";
            this.btnTest.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTest_Click);
            // 
            // btnWebService
            // 
            this.btnWebService.Label = "Start Workflow";
            this.btnWebService.Name = "btnWebService";
            this.btnWebService.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnWebService_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Label = "Publish";
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPublish_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.Label = "Merge";
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMerge_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button1);
            this.group2.Items.Add(this.btnSerialize);
            this.group2.Items.Add(this.btnShapeDataSource);
            this.group2.Items.Add(this.btnConfigurations);
            this.group2.Label = "Configuration";
            this.group2.Name = "group2";
            // 
            // button1
            // 
            this.button1.Label = "Workflow Service";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Label = "Roles";
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRoles_Click);
            // 
            // btnSerialize
            // 
            this.btnSerialize.Label = "Serializer";
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSerialize_Click);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Label = "User Management";
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUserManagement_Click);
            // 
            // btnShapeDataSource
            // 
            this.btnShapeDataSource.Label = "Shape Data Source";
            this.btnShapeDataSource.Name = "btnShapeDataSource";
            this.btnShapeDataSource.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnShapeDataSource_Click);
            // 
            // btnConfigurations
            // 
            this.btnConfigurations.Label = "Configurations";
            this.btnConfigurations.Name = "btnConfigurations";
            this.btnConfigurations.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfigurations_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.btnModelUserRole);
            this.group3.Label = "Model User Configuration";
            this.group3.Name = "group3";
            // 
            // btnModelUserRole
            // 
            this.btnModelUserRole.Label = "Model User Roles";
            this.btnModelUserRole.Name = "btnModelUserRole";
            this.btnModelUserRole.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnModelUserRole_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.btnProcessModels);
            this.group4.Items.Add(this.btnRoles);
            this.group4.Items.Add(this.btnUserManagement);
            this.group4.Label = "Process Models";
            this.group4.Name = "group4";
            // 
            // btnProcessModels
            // 
            this.btnProcessModels.Label = "Process Models";
            this.btnProcessModels.Name = "btnProcessModels";
            this.btnProcessModels.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnProcessModels_Click);
            // 
            // PromoveoRibbon
            // 
            this.Name = "PromoveoRibbon";
            this.RibbonType = "Microsoft.Visio.Drawing";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.PromoveoRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTest;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnWebService;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPublish;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMerge;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRoles;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSerialize;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUserManagement;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnModelUserRole;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnShapeDataSource;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfigurations;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnProcessModels;
    }

    partial class ThisRibbonCollection
    {
        internal PromoveoRibbon PromoveoRibbon
        {
            get { return this.GetRibbon<PromoveoRibbon>(); }
        }
    }
}
