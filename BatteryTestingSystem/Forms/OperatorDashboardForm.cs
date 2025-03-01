#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BatteryTestingSystem
{
    /// <summary>
    /// Minimal <see cref="User"/> class with default property values.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "John";
        public string LastName { get; set; } = "Doe";
        public string Username { get; set; } = "jdoe";
        public string Password { get; set; } = "password";
        // Add other fields as needed
    }

    /// <summary>
    /// Represents a single parameter (e.g., Voltage, Current, etc.).
    /// </summary>
    public class Parameter
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Unit { get; set; } = "";
        public double MinThreshold { get; set; }
        public double MaxThreshold { get; set; }
    }

    /// <summary>
    /// Represents a battery test result for a single parameter.
    /// </summary>
    public class BatteryTestResult
    {
        public int ParameterId { get; set; }
        public double Value { get; set; }
        public bool IsWithinThreshold { get; set; }
    }

    /// <summary>
    /// Represents a battery test, including all parameter results.
    /// </summary>
    public class BatteryTest
    {
        public int OperatorId { get; set; }
        public DateTime TestDate { get; set; } = DateTime.Now;
        public string BatteryId { get; set; } = "";
        public string Notes { get; set; } = "";
        public bool PassedTest { get; set; }
        public List<BatteryTestResult> Results { get; set; } = new List<BatteryTestResult>();
    }

    /// <summary>
    /// Minimal static DatabaseManager with placeholder methods.
    /// Change to non-static if you prefer instance-based usage.
    /// </summary>
    public static class DatabaseManager
    {
        /// <summary>
        /// Returns a list of active parameters for battery tests.
        /// Replace with actual database logic.
        /// </summary>
        public static List<Parameter> GetActiveParameters()
        {
            return new List<Parameter>
            {
                new Parameter { Id = 1, Name = "Voltage", Unit = "V", MinThreshold = 3.0, MaxThreshold = 4.2 },
                new Parameter { Id = 2, Name = "Current", Unit = "A", MinThreshold = 0.5, MaxThreshold = 2.0 }
            };
        }

        /// <summary>
        /// Saves a battery test result to the database.
        /// Replace with actual database logic.
        /// </summary>
        public static bool SaveBatteryTest(BatteryTest test)
        {
            // Placeholder
            return true;
        }

        /// <summary>
        /// Returns test reports from the database.
        /// Replace with actual database logic.
        /// </summary>
        public static DataTable GetTestReports(DateTime startDate, DateTime endDate, int operatorId)
        {
            // Return an empty table as a placeholder
            return new DataTable();
        }
    }

    /// <summary>
    /// Minimal static class for generating or exporting reports.
    /// </summary>
    public static class ReportGenerator
    {
        public static void ExportToCSV(DataTable table, string filename)
        {
            // Placeholder CSV export logic
        }
    }

    /// <summary>
    /// Minimal static class to manage serial ports.
    /// Replace with System.IO.Ports.SerialPort usage as needed.
    /// </summary>
    public static class SerialPortManager
    {
        /// <summary>
        /// Return available COM ports (placeholder).
        /// </summary>
        public static List<string> GetAvailablePorts()
        {
            // Example: pretend we have COM1 and COM2
            return new List<string> { "COM1", "COM2" };
        }

        public static bool OpenPort(string portName)
        {
            // Placeholder
            return true;
        }

        public static void ClosePort()
        {
            // Placeholder
        }

        public static void SetBaudRate(int baudRate)
        {
            // Placeholder
        }

        public static string ReadData()
        {
            // Placeholder
            return null;
        }
    }

    /// <summary>
    /// Minimal login form to avoid reference errors.
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LoginForm
            // 
            this.ClientSize = new Size(300, 150);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
        }
    }

    /// <summary>
    /// Minimal AdminDashboardForm to avoid reference errors.
    /// Replace with your actual admin dashboard code.
    /// </summary>
    public partial class AdminDashboardForm : Form
    {
        private User _user;
        private bool _isEditMode;

        public AdminDashboardForm(User user = null, bool isEditMode = false)
        {
            InitializeComponent();
            _user = user ?? new User();
            _isEditMode = isEditMode;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AdminDashboardForm
            // 
            this.ClientSize = new Size(600, 400);
            this.Name = "AdminDashboardForm";
            this.Text = "Admin Dashboard";
            this.ResumeLayout(false);
        }
    }

    /// <summary>
    /// The main Operator Dashboard form with all your original code, 
    /// fixed to remove static context issues, timer ambiguities, etc.
    /// </summary>
    public partial class OperatorDashboardForm : Form
    {
        // ---------------------- Fields ----------------------
        private User _currentUser;
        private int _baudRate = 9600;

        // Use System.Windows.Forms.Timer explicitly to avoid ambiguity
        private System.Windows.Forms.Timer _serialReadTimer = new System.Windows.Forms.Timer();

        private List<Parameter> _activeParameters = new List<Parameter>();
        private BatteryTest _currentTest;

        // Designer fields
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem myReportsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem baudRateToolStripMenuItem;
        private ToolStripMenuItem baudRate9600ToolStripMenuItem;
        private ToolStripMenuItem baudRate19200ToolStripMenuItem;
        private ToolStripMenuItem baudRate38400ToolStripMenuItem;
        private ToolStripMenuItem baudRate57600ToolStripMenuItem;
        private ToolStripMenuItem baudRate115200ToolStripMenuItem;
        private ToolStripMenuItem comPortToolStripMenuItem;
        private ToolStripMenuItem refreshPortsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripStatusLabel toolStripStatusLabelPort;
        private TabControl tabControl;
        private TabPage tabTesting;
        private TabPage tabReports;
        private PictureBox picLogo;
        private Label lblWelcome;
        private DataGridView dgvTestData;
        private Button btnSaveTest;
        private Button btnNewTest;
        private CheckBox chkPassedTest;
        private TextBox txtNotes;
        private Label lblNotes;
        private TextBox txtBatteryId;
        private Label lblBatteryId;
        private Label lblEndDate;
        private Label lblStartDate;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private DataGridView dgvReports;
        private Button btnExportReport;
        private Button btnGenerateReport;
        private ToolTip toolTip;

        // ---------------------- Constructor ----------------------
        public OperatorDashboardForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
        }

        // ---------------------- InitializeComponent (Designer Code) ----------------------
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.logoutToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.reportsToolStripMenuItem = new ToolStripMenuItem();
            this.myReportsToolStripMenuItem = new ToolStripMenuItem();
            this.settingsToolStripMenuItem = new ToolStripMenuItem();
            this.baudRateToolStripMenuItem = new ToolStripMenuItem();
            this.baudRate9600ToolStripMenuItem = new ToolStripMenuItem();
            this.baudRate19200ToolStripMenuItem = new ToolStripMenuItem();
            this.baudRate38400ToolStripMenuItem = new ToolStripMenuItem();
            this.baudRate57600ToolStripMenuItem = new ToolStripMenuItem();
            this.baudRate115200ToolStripMenuItem = new ToolStripMenuItem();
            this.comPortToolStripMenuItem = new ToolStripMenuItem();
            this.refreshPortsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.aboutToolStripMenuItem = new ToolStripMenuItem();
            this.statusStrip = new StatusStrip();
            this.toolStripStatusLabel = new ToolStripStatusLabel();
            this.toolStripStatusLabelPort = new ToolStripStatusLabel();
            this.tabControl = new TabControl();
            this.tabTesting = new TabPage();
            this.btnSaveTest = new Button();
            this.btnNewTest = new Button();
            this.chkPassedTest = new CheckBox();
            this.txtNotes = new TextBox();
            this.lblNotes = new Label();
            this.txtBatteryId = new TextBox();
            this.lblBatteryId = new Label();
            this.dgvTestData = new DataGridView();
            this.tabReports = new TabPage();
            this.btnExportReport = new Button();
            this.btnGenerateReport = new Button();
            this.dgvReports = new DataGridView();
            this.dtpEndDate = new DateTimePicker();
            this.dtpStartDate = new DateTimePicker();
            this.lblEndDate = new Label();
            this.lblStartDate = new Label();
            this.picLogo = new PictureBox();
            this.lblWelcome = new Label();
            this.toolTip = new ToolTip(this.components);

            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
                this.fileToolStripMenuItem,
                this.reportsToolStripMenuItem,
                this.settingsToolStripMenuItem,
                this.helpToolStripMenuItem
            });
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(984, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";

            // fileToolStripMenuItem
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.logoutToolStripMenuItem,
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.ForeColor = Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Text = "File";

            // logoutToolStripMenuItem
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new EventHandler(this.logoutToolStripMenuItem_Click);

            // exitToolStripMenuItem
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);

            // reportsToolStripMenuItem
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.myReportsToolStripMenuItem
            });
            this.reportsToolStripMenuItem.ForeColor = Color.White;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Text = "Reports";

            // myReportsToolStripMenuItem
            this.myReportsToolStripMenuItem.Name = "myReportsToolStripMenuItem";
            this.myReportsToolStripMenuItem.Size = new Size(132, 22);
            this.myReportsToolStripMenuItem.Text = "My Reports";
            this.myReportsToolStripMenuItem.Click += new EventHandler(this.myReportsToolStripMenuItem_Click);

            // settingsToolStripMenuItem
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.baudRateToolStripMenuItem,
                this.comPortToolStripMenuItem
            });
            this.settingsToolStripMenuItem.ForeColor = Color.White;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Text = "Settings";

            // baudRateToolStripMenuItem
            this.baudRateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.baudRate9600ToolStripMenuItem,
                this.baudRate19200ToolStripMenuItem,
                this.baudRate38400ToolStripMenuItem,
                this.baudRate57600ToolStripMenuItem,
                this.baudRate115200ToolStripMenuItem
            });
            this.baudRateToolStripMenuItem.Name = "baudRateToolStripMenuItem";
            this.baudRateToolStripMenuItem.Size = new Size(132, 22);
            this.baudRateToolStripMenuItem.Text = "Baud Rate";

            // baudRate9600ToolStripMenuItem
            this.baudRate9600ToolStripMenuItem.Name = "baudRate9600ToolStripMenuItem";
            this.baudRate9600ToolStripMenuItem.Size = new Size(110, 22);
            this.baudRate9600ToolStripMenuItem.Text = "9600";
            this.baudRate9600ToolStripMenuItem.Click += new EventHandler(this.baudRateToolStripMenuItem_Click);

            this.baudRate19200ToolStripMenuItem.Name = "baudRate19200ToolStripMenuItem";
            this.baudRate19200ToolStripMenuItem.Size = new Size(110, 22);
            this.baudRate19200ToolStripMenuItem.Text = "19200";
            this.baudRate19200ToolStripMenuItem.Click += new EventHandler(this.baudRateToolStripMenuItem_Click);

            this.baudRate38400ToolStripMenuItem.Name = "baudRate38400ToolStripMenuItem";
            this.baudRate38400ToolStripMenuItem.Size = new Size(110, 22);
            this.baudRate38400ToolStripMenuItem.Text = "38400";
            this.baudRate38400ToolStripMenuItem.Click += new EventHandler(this.baudRateToolStripMenuItem_Click);

            this.baudRate57600ToolStripMenuItem.Name = "baudRate57600ToolStripMenuItem";
            this.baudRate57600ToolStripMenuItem.Size = new Size(110, 22);
            this.baudRate57600ToolStripMenuItem.Text = "57600";
            this.baudRate57600ToolStripMenuItem.Click += new EventHandler(this.baudRateToolStripMenuItem_Click);

            this.baudRate115200ToolStripMenuItem.Name = "baudRate115200ToolStripMenuItem";
            this.baudRate115200ToolStripMenuItem.Size = new Size(110, 22);
            this.baudRate115200ToolStripMenuItem.Text = "115200";
            this.baudRate115200ToolStripMenuItem.Click += new EventHandler(this.baudRateToolStripMenuItem_Click);

            // comPortToolStripMenuItem
            this.comPortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.refreshPortsToolStripMenuItem,
                this.toolStripSeparator1
            });
            this.comPortToolStripMenuItem.Name = "comPortToolStripMenuItem";
            this.comPortToolStripMenuItem.Size = new Size(132, 22);
            this.comPortToolStripMenuItem.Text = "COM Port";

            this.refreshPortsToolStripMenuItem.Name = "refreshPortsToolStripMenuItem";
            this.refreshPortsToolStripMenuItem.Size = new Size(142, 22);
            this.refreshPortsToolStripMenuItem.Text = "Refresh Ports";
            this.refreshPortsToolStripMenuItem.Click += new EventHandler(this.refreshPortsToolStripMenuItem_Click);

            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(139, 6);

            // helpToolStripMenuItem
            this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.aboutToolStripMenuItem
            });
            this.helpToolStripMenuItem.ForeColor = Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Text = "Help";

            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);

            // statusStrip
            this.statusStrip.Items.AddRange(new ToolStripItem[] {
                this.toolStripStatusLabel,
                this.toolStripStatusLabelPort
            });
            this.statusStrip.Location = new Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(984, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";

            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new Size(42, 17);
            this.toolStripStatusLabel.Text = "Ready";

            this.toolStripStatusLabelPort.Name = "toolStripStatusLabelPort";
            this.toolStripStatusLabelPort.Size = new Size(118, 17);
            this.toolStripStatusLabelPort.Text = "COM Port: Not Connected";

            // tabControl
            this.tabControl.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.tabControl.Controls.Add(this.tabTesting);
            this.tabControl.Controls.Add(this.tabReports);
            this.tabControl.Location = new Point(12, 100);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(960, 436);
            this.tabControl.TabIndex = 2;

            // tabTesting
            this.tabTesting.Controls.Add(this.btnSaveTest);
            this.tabTesting.Controls.Add(this.btnNewTest);
            this.tabTesting.Controls.Add(this.chkPassedTest);
            this.tabTesting.Controls.Add(this.txtNotes);
            this.tabTesting.Controls.Add(this.lblNotes);
            this.tabTesting.Controls.Add(this.txtBatteryId);
            this.tabTesting.Controls.Add(this.lblBatteryId);
            this.tabTesting.Controls.Add(this.dgvTestData);
            this.tabTesting.Location = new Point(4, 24);
            this.tabTesting.Name = "tabTesting";
            this.tabTesting.Padding = new Padding(3);
            this.tabTesting.Size = new Size(952, 408);
            this.tabTesting.TabIndex = 0;
            this.tabTesting.Text = "Battery Testing";
            this.tabTesting.UseVisualStyleBackColor = true;

            // btnSaveTest
            this.btnSaveTest.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.btnSaveTest.BackColor = Color.FromArgb(0, 102, 255);
            this.btnSaveTest.FlatStyle = FlatStyle.Flat;
            this.btnSaveTest.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnSaveTest.ForeColor = Color.White;
            this.btnSaveTest.Location = new Point(851, 369);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new Size(95, 33);
            this.btnSaveTest.TabIndex = 7;
            this.btnSaveTest.Text = "Save Test";
            this.btnSaveTest.UseVisualStyleBackColor = false;
            this.btnSaveTest.Click += new EventHandler(this.btnSaveTest_Click);

            // btnNewTest
            this.btnNewTest.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            this.btnNewTest.BackColor = Color.FromArgb(0, 71, 171);
            this.btnNewTest.FlatStyle = FlatStyle.Flat;
            this.btnNewTest.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnNewTest.ForeColor = Color.White;
            this.btnNewTest.Location = new Point(750, 369);
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.Size = new Size(95, 33);
            this.btnNewTest.TabIndex = 6;
            this.btnNewTest.Text = "New Test";
            this.btnNewTest.UseVisualStyleBackColor = false;
            this.btnNewTest.Click += new EventHandler(this.btnNewTest_Click);

            // chkPassedTest
            this.chkPassedTest.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.chkPassedTest.AutoSize = true;
            this.chkPassedTest.Location = new Point(6, 378);
            this.chkPassedTest.Name = "chkPassedTest";
            this.chkPassedTest.Size = new Size(86, 19);
            this.chkPassedTest.TabIndex = 5;
            this.chkPassedTest.Text = "Passed Test";
            this.chkPassedTest.UseVisualStyleBackColor = true;

            // txtNotes
            this.txtNotes.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.txtNotes.Location = new Point(300, 376);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new Size(444, 23);
            this.txtNotes.TabIndex = 4;

            // lblNotes
            this.lblNotes.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new Point(260, 379);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new Size(38, 15);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes";

            // txtBatteryId
            this.txtBatteryId.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.txtBatteryId.Location = new Point(150, 376);
            this.txtBatteryId.Name = "txtBatteryId";
            this.txtBatteryId.Size = new Size(100, 23);
            this.txtBatteryId.TabIndex = 2;

            // lblBatteryId
            this.lblBatteryId.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.lblBatteryId.AutoSize = true;
            this.lblBatteryId.Location = new Point(98, 379);
            this.lblBatteryId.Name = "lblBatteryId";
            this.lblBatteryId.Size = new Size(58, 15);
            this.lblBatteryId.TabIndex = 1;
            this.lblBatteryId.Text = "Battery ID";

            // dgvTestData
            this.dgvTestData.AllowUserToAddRows = false;
            this.dgvTestData.AllowUserToDeleteRows = false;
            this.dgvTestData.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.dgvTestData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTestData.BackgroundColor = Color.White;
            this.dgvTestData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestData.Location = new Point(6, 6);
            this.dgvTestData.Name = "dgvTestData";
            this.dgvTestData.RowTemplate.Height = 25;
            this.dgvTestData.Size = new Size(940, 357);
            this.dgvTestData.TabIndex = 0;
            this.dgvTestData.CellValueChanged += new DataGridViewCellEventHandler(this.dgvTestData_CellValueChanged);

            // tabReports
            this.tabReports.Controls.Add(this.btnExportReport);
            this.tabReports.Controls.Add(this.btnGenerateReport);
            this.tabReports.Controls.Add(this.dgvReports);
            this.tabReports.Controls.Add(this.dtpEndDate);
            this.tabReports.Controls.Add(this.dtpStartDate);
            this.tabReports.Controls.Add(this.lblEndDate);
            this.tabReports.Controls.Add(this.lblStartDate);
            this.tabReports.Location = new Point(4, 24);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new Padding(3);
            this.tabReports.Size = new Size(952, 408);
            this.tabReports.TabIndex = 1;
            this.tabReports.Text = "My Reports";
            this.tabReports.UseVisualStyleBackColor = true;

            // btnExportReport
            this.btnExportReport.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnExportReport.BackColor = Color.FromArgb(0, 71, 171);
            this.btnExportReport.FlatStyle = FlatStyle.Flat;
            this.btnExportReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnExportReport.ForeColor = Color.White;
            this.btnExportReport.Location = new Point(851, 15);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new Size(95, 33);
            this.btnExportReport.TabIndex = 6;
            this.btnExportReport.Text = "Export";
            this.btnExportReport.UseVisualStyleBackColor = false;
            this.btnExportReport.Click += new EventHandler(this.btnExportReport_Click);

            // btnGenerateReport
            this.btnGenerateReport.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.btnGenerateReport.BackColor = Color.FromArgb(0, 102, 255);
            this.btnGenerateReport.FlatStyle = FlatStyle.Flat;
            this.btnGenerateReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            this.btnGenerateReport.ForeColor = Color.White;
            this.btnGenerateReport.Location = new Point(750, 15);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new Size(95, 33);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new EventHandler(this.btnGenerateReport_Click);

            // dgvReports
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            this.dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = Color.White;
            this.dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new Point(6, 54);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowTemplate.Height = 25;
            this.dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new Size(940, 348);
            this.dgvReports.TabIndex = 4;

            // dtpEndDate
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new Point(400, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new Size(120, 23);
            this.dtpEndDate.TabIndex = 3;

            // dtpStartDate
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new Point(200, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new Size(120, 23);
            this.dtpStartDate.TabIndex = 2;

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new Point(340, 24);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new Size(54, 15);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "End Date";

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new Point(140, 24);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new Size(58, 15);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date";

            // picLogo
            this.picLogo.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            this.picLogo.Location = new Point(872, 27);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new Size(100, 50);
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblWelcome.ForeColor = Color.FromArgb(0, 71, 171);
            this.lblWelcome.Location = new Point(12, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(101, 25);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Welcome!";

            // OperatorDashboardForm
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(984, 561);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new Size(800, 600);
            this.Name = "OperatorDashboardForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Battery Testing System - Operator Dashboard";
            this.FormClosing += new FormClosingEventHandler(this.OperatorDashboardForm_FormClosing);
            this.Load += new EventHandler(this.OperatorDashboardForm_Load);

            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabTesting.ResumeLayout(false);
            this.tabTesting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestData)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ---------------------- Event Handlers ----------------------

        private void OperatorDashboardForm_Load(object sender, EventArgs e)
        {
            // Display a welcome message
            lblWelcome.Text = $"Welcome, {_currentUser.FirstName} {_currentUser.LastName}!";

            // Create a simple placeholder logo
            try
            {
                Bitmap logoBitmap = new Bitmap(100, 50);
                using (Graphics g = Graphics.FromImage(logoBitmap))
                {
                    g.Clear(Color.FromArgb(0, 102, 255));
                    g.DrawString("BTS", new Font("Arial", 20, FontStyle.Bold), Brushes.White, new PointF(10, 10));
                }
                picLogo.Image = logoBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading logo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load active parameters from DB
            _activeParameters = DatabaseManager.GetActiveParameters();

            // Setup test data grid
            SetupTestDataGrid();

            // Setup reports
            SetupReportsTab();

            // Setup COM ports
            RefreshComPorts();

            // Configure serial timer
            _serialReadTimer.Interval = 1000; // 1 second
            _serialReadTimer.Tick += SerialReadTimer_Tick;
        }

        private void OperatorDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop timer and close serial port
            _serialReadTimer.Stop();
            SerialPortManager.ClosePort();
        }

        private void myReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabReports;
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

        // ---------------------- Settings / COM Port Methods ----------------------

        private void baudRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            int baudRate = int.Parse(menuItem.Text);

            _baudRate = baudRate;
            SerialPortManager.SetBaudRate(baudRate);

            // Update menu items
            foreach (ToolStripMenuItem item in baudRateToolStripMenuItem.DropDownItems)
            {
                item.Checked = (item == menuItem);
            }

            // Update status bar if connected
            if (toolStripStatusLabelPort.Text != "COM Port: Not Connected")
            {
                string portName = toolStripStatusLabelPort.Text.Replace("COM Port: ", "").Split(' ')[0];
                toolStripStatusLabelPort.Text = $"COM Port: {portName} @ {_baudRate} baud";
            }
        }

        private void refreshPortsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void RefreshComPorts()
        {
            // Remove old port items (except refresh and separator)
            List<ToolStripItem> itemsToRemove = new List<ToolStripItem>();
            foreach (ToolStripItem item in comPortToolStripMenuItem.DropDownItems)
            {
                if (item != refreshPortsToolStripMenuItem && item != toolStripSeparator1)
                {
                    itemsToRemove.Add(item);
                }
            }
            foreach (var item in itemsToRemove)
            {
                comPortToolStripMenuItem.DropDownItems.Remove(item);
            }

            // Get available ports
            List<string> ports = SerialPortManager.GetAvailablePorts();
            if (ports.Count > 0)
            {
                foreach (string port in ports)
                {
                    ToolStripMenuItem portItem = new ToolStripMenuItem(port);
                    portItem.Click += comPortToolStripMenuItem_Click;
                    comPortToolStripMenuItem.DropDownItems.Add(portItem);
                }
            }
            else
            {
                ToolStripMenuItem noPortsItem = new ToolStripMenuItem("No Ports Available");
                noPortsItem.Enabled = false;
                comPortToolStripMenuItem.DropDownItems.Add(noPortsItem);
            }
        }

        private void comPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string portName = menuItem.Text;

            // Close existing port
            SerialPortManager.ClosePort();

            // Open selected port
            if (SerialPortManager.OpenPort(portName))
            {
                toolStripStatusLabelPort.Text = $"COM Port: {portName} @ {_baudRate} baud";
                _serialReadTimer.Start();
            }
            else
            {
                toolStripStatusLabelPort.Text = "COM Port: Not Connected";
            }
        }

        // ---------------------- Serial Data Methods ----------------------

        private void SerialReadTimer_Tick(object sender, EventArgs e)
        {
            // Read data from serial port
            string data = SerialPortManager.ReadData();
            if (!string.IsNullOrEmpty(data))
            {
                ParseSerialData(data);
            }
        }

        private void ParseSerialData(string data)
        {
            // Example format: "Parameter1:Value1,Parameter2:Value2,..."
            try
            {
                string[] pairs = data.Split(',');
                foreach (string pair in pairs)
                {
                    string[] parts = pair.Split(':');
                    if (parts.Length == 2)
                    {
                        string paramName = parts[0].Trim();
                        if (double.TryParse(parts[1].Trim(), out double value))
                        {
                            // Find parameter in grid
                            foreach (DataGridViewRow row in dgvTestData.Rows)
                            {
                                if (row.Cells["Parameter"].Value.ToString() == paramName)
                                {
                                    // Update value
                                    row.Cells["Value"].Value = value;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel.Text = $"Error parsing data: {ex.Message}";
            }
        }

        // ---------------------- Test Data Methods ----------------------

        private void SetupTestDataGrid()
        {
            DataTable testDataTable = new DataTable();
            testDataTable.Columns.Add("ParameterId", typeof(int));
            testDataTable.Columns.Add("Parameter", typeof(string));
            testDataTable.Columns.Add("Value", typeof(double));
            testDataTable.Columns.Add("Unit", typeof(string));
            testDataTable.Columns.Add("MinThreshold", typeof(double));
            testDataTable.Columns.Add("MaxThreshold", typeof(double));
            testDataTable.Columns.Add("Status", typeof(string));

            foreach (var param in _activeParameters)
            {
                DataRow row = testDataTable.NewRow();
                row["ParameterId"] = param.Id;
                row["Parameter"] = param.Name;
                row["Value"] = 0.0;
                row["Unit"] = param.Unit;
                row["MinThreshold"] = param.MinThreshold;
                row["MaxThreshold"] = param.MaxThreshold;
                row["Status"] = "Not Tested";
                testDataTable.Rows.Add(row);
            }

            dgvTestData.DataSource = testDataTable;
            if (dgvTestData.Columns.Count > 0)
            {
                dgvTestData.Columns["ParameterId"].Visible = false;
                foreach (DataGridViewColumn col in dgvTestData.Columns)
                {
                    // Only 'Value' is editable
                    col.ReadOnly = (col.Name != "Value");
                }

                dgvTestData.Columns["Parameter"].Width = 150;
                dgvTestData.Columns["Value"].Width = 100;
                dgvTestData.Columns["Unit"].Width = 80;
                dgvTestData.Columns["MinThreshold"].Width = 100;
                dgvTestData.Columns["MaxThreshold"].Width = 100;
                dgvTestData.Columns["Status"].Width = 100;

                dgvTestData.Columns["Value"].DefaultCellStyle.Format = "0.00";
                dgvTestData.Columns["MinThreshold"].DefaultCellStyle.Format = "0.00";
                dgvTestData.Columns["MaxThreshold"].DefaultCellStyle.Format = "0.00";
            }

            // Initialize new test
            _currentTest = new BatteryTest
            {
                OperatorId = _currentUser.Id,
                TestDate = DateTime.Now,
                Results = new List<BatteryTestResult>()
            };
        }

        private void dgvTestData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var columnName = dgvTestData.Columns[e.ColumnIndex].Name;
                if (columnName == "Value")
                {
                    DataGridViewRow row = dgvTestData.Rows[e.RowIndex];
                    double value = Convert.ToDouble(row.Cells["Value"].Value);
                    double minThreshold = Convert.ToDouble(row.Cells["MinThreshold"].Value);
                    double maxThreshold = Convert.ToDouble(row.Cells["MaxThreshold"].Value);

                    bool isWithinThreshold = (value >= minThreshold && value <= maxThreshold);
                    row.Cells["Status"].Value = isWithinThreshold ? "Pass" : "Fail";
                    row.DefaultCellStyle.BackColor = isWithinThreshold ? Color.White : Color.LightPink;
                }
            }
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTestData.Rows)
            {
                row.Cells["Value"].Value = 0.0;
                row.Cells["Status"].Value = "Not Tested";
                row.DefaultCellStyle.BackColor = Color.White;
            }
            txtBatteryId.Text = "";
            txtNotes.Text = "";
            chkPassedTest.Checked = false;

            _currentTest = new BatteryTest
            {
                OperatorId = _currentUser.Id,
                TestDate = DateTime.Now,
                Results = new List<BatteryTestResult>()
            };

            toolStripStatusLabel.Text = "New test started";
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBatteryId.Text))
            {
                MessageBox.Show("Please enter a Battery ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentTest.BatteryId = txtBatteryId.Text.Trim();
            _currentTest.Notes = txtNotes.Text.Trim();
            _currentTest.PassedTest = chkPassedTest.Checked;
            _currentTest.TestDate = DateTime.Now;
            _currentTest.Results.Clear();

            foreach (DataGridViewRow row in dgvTestData.Rows)
            {
                int parameterId = Convert.ToInt32(row.Cells["ParameterId"].Value);
                double value = Convert.ToDouble(row.Cells["Value"].Value);
                bool isWithinThreshold = row.Cells["Status"].Value.ToString() == "Pass";

                _currentTest.Results.Add(new BatteryTestResult
                {
                    ParameterId = parameterId,
                    Value = value,
                    IsWithinThreshold = isWithinThreshold
                });
            }

            if (DatabaseManager.SaveBatteryTest(_currentTest))
            {
                MessageBox.Show("Test saved successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Start a new test
                btnNewTest_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Failed to save test. Please try again.", "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------- Reports Methods ----------------------

        private void SetupReportsTab()
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

            DataTable reportData = DatabaseManager.GetTestReports(startDate, endDate, _currentUser.Id);
            dgvReports.DataSource = reportData;

            toolStripStatusLabel.Text = $"Generated report with {reportData.Rows.Count} records";
        }

        private void btnExportReport_Click(object sender, EventArgs e)
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
