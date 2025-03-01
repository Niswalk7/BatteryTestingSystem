using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BatteryTestingSystem.Data;
using BatteryTestingSystem.Models;
using BatteryTestingSystem.Utils;

namespace BatteryTestingSystem
{
    public partial class ManufacturerDashboardForm : Form
    {
        private User _currentUser;
        private List<BatteryParameter> _parameters;
        private int _baudRate = 9600;

        public ManufacturerDashboardForm(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _parameters = new List<BatteryParameter>();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRate9600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRate19200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRate38400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRate57600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRate115200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeParameters = new System.Windows.Forms.TreeView();
            this.lblParameters = new System.Windows.Forms.Label();
            this.dgvParameters = new System.Windows.Forms.DataGridView();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnToggleActive = new System.Windows.Forms.Button();
            this.lblParameterConfig = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateReportToolStripMenuItem});
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            this.generateReportToolStripMenuItem.Click += new System.EventHandler(this.generateReportToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baudRateToolStripMenuItem});
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // baudRateToolStripMenuItem
            // 
            this.baudRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baudRate9600ToolStripMenuItem,
            this.baudRate19200ToolStripMenuItem,
            this.baudRate38400ToolStripMenuItem,
            this.baudRate57600ToolStripMenuItem,
            this.baudRate115200ToolStripMenuItem});
            this.baudRateToolStripMenuItem.Name = "baudRateToolStripMenuItem";
            this.baudRateToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.baudRateToolStripMenuItem.Text = "Baud Rate";
            // 
            // baudRate9600ToolStripMenuItem
            // 
            this.baudRate9600ToolStripMenuItem.Checked = true;
            this.baudRate9600ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.baudRate9600ToolStripMenuItem.Name = "baudRate9600ToolStripMenuItem";
            this.baudRate9600ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.baudRate9600ToolStripMenuItem.Text = "9600";
            this.baudRate9600ToolStripMenuItem.Click += new System.EventHandler(this.baudRateToolStripMenuItem_Click);
            // 
            // baudRate19200ToolStripMenuItem
            // 
            this.baudRate19200ToolStripMenuItem.Name = "baudRate19200ToolStripMenuItem";
            this.baudRate19200ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.baudRate19200ToolStripMenuItem.Text = "19200";
            this.baudRate19200ToolStripMenuItem.Click += new System.EventHandler(this.baudRateToolStripMenuItem_Click);
            // 
            // baudRate38400ToolStripMenuItem
            // 
            this.baudRate38400ToolStripMenuItem.Name = "baudRate38400ToolStripMenuItem";
            this.baudRate38400ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.baudRate38400ToolStripMenuItem.Text = "38400";
            this.baudRate38400ToolStripMenuItem.Click += new System.EventHandler(this.baudRateToolStripMenuItem_Click);
            // 
            // baudRate57600ToolStripMenuItem
            // 
            this.baudRate57600ToolStripMenuItem.Name = "baudRate57600ToolStripMenuItem";
            this.baudRate57600ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.baudRate57600ToolStripMenuItem.Text = "57600";
            this.baudRate57600ToolStripMenuItem.Click += new System.EventHandler(this.baudRateToolStripMenuItem_Click);
            // 
            // baudRate115200ToolStripMenuItem
            // 
            this.baudRate115200ToolStripMenuItem.Name = "baudRate115200ToolStripMenuItem";
            this.baudRate115200ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.baudRate115200ToolStripMenuItem.Text = "115200";
            this.baudRate115200ToolStripMenuItem.Click += new System.EventHandler(this.baudRateToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(984, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 100);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeParameters);
            this.splitContainer.Panel1.Controls.Add(this.lblParameters);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvParameters);
            this.splitContainer.Panel2.Controls.Add(this.btnMoveDown);
            this.splitContainer.Panel2.Controls.Add(this.btnMoveUp);
            this.splitContainer.Panel2.Controls.Add(this.btnToggleActive);
            this.splitContainer.Panel2.Controls.Add(this.lblParameterConfig);
            this.splitContainer.Size = new System.Drawing.Size(960, 436);
            this.splitContainer.SplitterDistance = 320;
            this.splitContainer.TabIndex = 2;
            // 
            // treeParameters
            // 
            this.treeParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeParameters.Location = new System.Drawing.Point(3, 30);
            this.treeParameters.Name = "treeParameters";
            this.treeParameters.Size = new System.Drawing.Size(314, 403);
            this.treeParameters.TabIndex = 1;
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblParameters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lblParameters.Location = new System.Drawing.Point(3, 6);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(166, 21);
            this.lblParameters.TabIndex = 0;
            this.lblParameters.Text = "Battery Components";
            // 
            // dgvParameters
            // 
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToDeleteRows = false;
            this.dgvParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParameters.BackgroundColor = System.Drawing.Color.White;
            this.dgvParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Location = new System.Drawing.Point(3, 30);
            this.dgvParameters.MultiSelect = false;
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.ReadOnly = true;
            this.dgvParameters.RowTemplate.Height = 25;
            this.dgvParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameters.Size = new System.Drawing.Size(630, 362);
            this.dgvParameters.TabIndex = 4;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveDown.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoveDown.ForeColor = System.Drawing.Color.White;
            this.btnMoveDown.Location = new System.Drawing.Point(538, 398);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(95, 33);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveUp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMoveUp.ForeColor = System.Drawing.Color.White;
            this.btnMoveUp.Location = new System.Drawing.Point(437, 398);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(95, 33);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnToggleActive
            // 
            this.btnToggleActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggleActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.btnToggleActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnToggleActive.ForeColor = System.Drawing.Color.White;
            this.btnToggleActive.Location = new System.Drawing.Point(3, 398);
            this.btnToggleActive.Name = "btnToggleActive";
            this.btnToggleActive.Size = new System.Drawing.Size(150, 33);
            this.btnToggleActive.TabIndex = 1;
            this.btnToggleActive.Text = "Toggle Active Status";
            this.btnToggleActive.UseVisualStyleBackColor = false;
            this.btnToggleActive.Click += new System.EventHandler(this.btnToggleActive_Click);
            // 
            // lblParameterConfig
            // 
            this.lblParameterConfig.AutoSize = true;
            this.lblParameterConfig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblParameterConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lblParameterConfig.Location = new System.Drawing.Point(3, 6);
            this.lblParameterConfig.Name = "lblParameterConfig";
            this.lblParameterConfig.Size = new System.Drawing.Size(196, 21);
            this.lblParameterConfig.TabIndex = 0;
            this.lblParameterConfig.Text = "Parameter Configuration";
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Location = new System.Drawing.Point(872, 27);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.lblWelcome.Location = new System.Drawing.Point(12, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(101, 25);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome!";
            // 
            // ManufacturerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ManufacturerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battery Testing System - Manufacturer Dashboard";
            this.Load += new System.EventHandler(this.ManufacturerDashboardForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRate9600ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRate19200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRate38400ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRate57600ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baudRate115200ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeParameters;
        private System.Windows.Forms.Label lblParameters;
        private System.Windows.Forms.Label lblParameterConfig;
        private System.Windows.Forms.Button btnToggleActive;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.DataGridView dgvParameters;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolTip toolTip;

        private void ManufacturerDashboardForm_Load(object sender, EventArgs e)
        {
            // Set welcome message
            lblWelcome.Text = $"Welcome, {_currentUser.FirstName} {_currentUser.LastName}!";

            // Set the logo
            try
            {
                // Create a placeholder logo
                Bitmap logoBitmap = new Bitmap(100, 50);
                using (Graphics g = Graphics.FromImage(logoBitmap))
                {
                    g.Clear(Color.FromArgb(0, 102, 255)); // #0066FF
                    g.DrawString("BTS", new Font("Arial", 20, FontStyle.Bold), Brushes.White, new PointF(10, 10));
                }
                picLogo.Image = logoBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load parameters
            LoadParameters();
            
            // Set up tree view
            SetupTreeView();
        }

        private void LoadParameters()
        {
            _parameters = DatabaseManager.GetAllParameters();
            
            // Bind to DataGridView
            dgvParameters.DataSource = null;
            dgvParameters.DataSource = _parameters;
            
            // Configure columns
            if (dgvParameters.Columns.Count > 0)
            {
                // Hide ID column
                if (dgvParameters.Columns.Contains("Id"))
                    dgvParameters.Columns["Id"].Visible = false;
                
                // Format columns
                if (dgvParameters.Columns.Contains("MinThreshold"))
                    dgvParameters.Columns["MinThreshold"].HeaderText = "Min Threshold";
                
                if (dgvParameters.Columns.Contains("MaxThreshold"))
                    dgvParameters.Columns["MaxThreshold"].HeaderText = "Max Threshold";
                
                if (dgvParameters.Columns.Contains("DisplayOrder"))
                    dgvParameters.Columns["DisplayOrder"].HeaderText = "Display Order";
                
                if (dgvParameters.Columns.Contains("IsActive"))
                    dgvParameters.Columns["IsActive"].HeaderText = "Active";
            }
        }

        private void SetupTreeView()
        {
            treeParameters.Nodes.Clear();
            
            // Add root node
            TreeNode rootNode = new TreeNode("Battery Parameters");
            treeParameters.Nodes.Add(rootNode);
            
            // Add active parameters
            TreeNode activeNode = new TreeNode("Active Parameters");
            rootNode.Nodes.Add(activeNode);
            
            foreach (var param in _parameters.Where(p => p.IsActive).OrderBy(p => p.DisplayOrder))
            {
                activeNode.Nodes.Add(new TreeNode($"{param.DisplayOrder}. {param.Name} ({param.Unit})"));
            }
            
            // Add inactive parameters
            TreeNode inactiveNode = new TreeNode("Inactive Parameters");
            rootNode.Nodes.Add(inactiveNode);
            
            foreach (var param in _parameters.Where(p => !p.IsActive).OrderBy(p => p.Name))
            {
                inactiveNode.Nodes.Add(new TreeNode(param.Name));
            }
            
            // Expand all nodes
            treeParameters.ExpandAll();
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (dgvParameters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a parameter to toggle.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BatteryParameter selectedParameter = (BatteryParameter)dgvParameters.SelectedRows[0].DataBoundItem;
            bool newStatus = !selectedParameter.IsActive;
            
            if (DatabaseManager.UpdateParameterActiveStatus(selectedParameter.Id, newStatus))
            {
                // Refresh data
                LoadParameters();
                SetupTreeView();
                
                toolStripStatusLabel.Text = $"Parameter '{selectedParameter.Name}' is now {(newStatus ? "active" : "inactive")}";
            }
            else
            {
                MessageBox.Show("Failed to update parameter status.", "Update Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            MoveParameter(-1); // Move up (decrease order)
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            MoveParameter(1); // Move down (increase order)
        }

        private void MoveParameter(int direction)
        {
            if (dgvParameters.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a parameter to move.", "No Selection", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BatteryParameter selectedParameter = (BatteryParameter)dgvParameters.SelectedRows[0].DataBoundItem;
            
            // Only active parameters can be reordered
            if (!selectedParameter.IsActive)
            {
                MessageBox.Show("Only active parameters can be reordered.", "Cannot Move", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Calculate new order
            int newOrder = selectedParameter.DisplayOrder + direction;
            
            // Check bounds
            int minOrder = _parameters.Where(p => p.IsActive).Min(p => p.DisplayOrder);
            int maxOrder = _parameters.Where(p => p.IsActive).Max(p => p.DisplayOrder);
            
            if (newOrder < minOrder || newOrder > maxOrder)
            {
                MessageBox.Show("Cannot move parameter further.", "Cannot Move", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Find parameter at the target position
            BatteryParameter? targetParameter = _parameters.FirstOrDefault(p => p.IsActive && p.DisplayOrder == newOrder);
            
            if (targetParameter != null)
            {
                // Swap positions
                if (DatabaseManager.UpdateParameterOrder(targetParameter.Id, selectedParameter.DisplayOrder) &&
                    DatabaseManager.UpdateParameterOrder(selectedParameter.Id, newOrder))
                {
                    // Refresh data
                    LoadParameters();
                    SetupTreeView();
                    
                    toolStripStatusLabel.Text = $"Parameter '{selectedParameter.Name}' moved {(direction < 0 ? "up" : "down")}";
                }
                else
                {
                    MessageBox.Show("Failed to update parameter order.", "Update Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void baudRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            int baudRate = int.Parse(menuItem.Text);
            
            // Update baud rate
            _baudRate = baudRate;
            SerialPortManager.SetBaudRate(baudRate);
            
            // Update menu items
            foreach (ToolStripMenuItem item in baudRateToolStripMenuItem.DropDownItems)
            {
                item.Checked = (item == menuItem);
            }
            
            toolStripStatusLabel.Text = $"Baud rate set to {baudRate}";
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ReportForm reportForm = new ReportForm())
            {
                reportForm.ShowDialog();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", 
                "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Battery Testing System\nVersion 1.0\n\nDeveloped as a Final Year Project\n\n© 2025 All Rights Reserved", 
                "About Battery Testing System", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }
    }

    // Report Form for generating reports
    public class ReportForm : Form
    {
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblOperator;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cboOperator;
        private Button btnGenerate;
        private Button btnExport;
        private Button btnClose;
        private DataGridView dgvReports;

        public ReportForm()
        {
            InitializeComponent();
            LoadOperators();
        }

        private void InitializeComponent()
        {
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 20);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(61, 15);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(300, 20);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(57, 15);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "End Date:";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Location = new System.Drawing.Point(20, 50);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(57, 15);
            this.lblOperator.TabIndex = 2;
            this.lblOperator.Text = "Operator:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(100, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(180, 23);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(380, 16);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(180, 23);
            this.dtpEndDate.TabIndex = 4;
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(100, 46);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(180, 23);
            this.cboOperator.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(255)))));
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(380, 46);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(85, 28);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(171)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(475, 46);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(85, 28);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(697, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(20, 80);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowTemplate.Height = 25;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(752, 323);
            this.dgvReports.TabIndex = 9;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 490);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Report";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Set date range (last 30 days)
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
        }

        private void LoadOperators()
        {
            // Load operators for dropdown
            List<User> operators = DatabaseManager.GetAllUsers()
                .Where(u => u.Role == UserRole.Operator)
                .ToList();

            cboOperator.Items.Clear();
            cboOperator.Items.Add("All Operators");
            foreach (var op in operators)
            {
                cboOperator.Items.Add(op);
            }
            cboOperator.DisplayMember = "Username";
            cboOperator.ValueMember = "Id";
            cboOperator.SelectedIndex = 0;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1); // End of the selected day
            
            int? operatorId = null;
            if (cboOperator.SelectedIndex > 0) // Not "All Operators"
            {
                User selectedOperator = (User)cboOperator.SelectedItem;
                operatorId = selectedOperator.Id;
            }
            
            DataTable reportData = DatabaseManager.GetTestReports(startDate, endDate, operatorId);
            dgvReports.DataSource = reportData;
            
            this.Text = $"Report - {reportData.Rows.Count} Records Found";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReports.DataSource == null || ((DataTable)dgvReports.DataSource).Rows.Count == 0)
            {
                MessageBox.Show("No report data to export. Please generate a report first.", 
                    "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                DefaultExt = "csv",
                FileName = $"BatteryTestReport_{DateTime.Now:yyyyMMdd}"
            };
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable reportData = (DataTable)dgvReports.DataSource;
                ReportGenerator.ExportToCSV(reportData, saveDialog.FileName);
            }
        }
    }
}