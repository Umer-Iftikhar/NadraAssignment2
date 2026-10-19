namespace NadraSystem.Forms;

partial class OpenCvForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        btnOpen = new Button();
        lstEffects = new ListBox();
        lblBrightness = new Label();
        trackBrightness = new TrackBar();
        btnSave = new Button();
        grpOriginal = new GroupBox();
        picOriginal = new PictureBox();
        grpResult = new GroupBox();
        picResult = new PictureBox();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        openFileDialog1 = new OpenFileDialog();
        saveFileDialog1 = new SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)trackBrightness).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picResult).BeginInit();
        SuspendLayout();
        // controls panel (left)
        btnOpen.Text = "Open Image...";
        btnOpen.SetBounds(12, 12, 180, 34);
        btnOpen.Click += btnOpen_Click;
        lstEffects.SetBounds(12, 56, 180, 170);
        lstEffects.SelectedIndexChanged += lstEffects_SelectedIndexChanged;
        lblBrightness.Text = "Brightness: 0";
        lblBrightness.SetBounds(12, 236, 180, 20);
        trackBrightness.Minimum = -100;
        trackBrightness.Maximum = 100;
        trackBrightness.TickFrequency = 20;
        trackBrightness.SetBounds(8, 256, 188, 45);
        trackBrightness.Scroll += trackBrightness_Scroll;
        btnSave.Text = "Save Result As...";
        btnSave.SetBounds(12, 310, 180, 34);
        btnSave.Click += btnSave_Click;
        // image boxes
        grpOriginal.Text = "Original";
        grpOriginal.SetBounds(205, 8, 380, 440);
        picOriginal.Dock = DockStyle.Fill;
        picOriginal.BackColor = Color.FromArgb(45, 45, 45);
        picOriginal.SizeMode = PictureBoxSizeMode.Zoom;
        grpOriginal.Controls.Add(picOriginal);
        grpResult.Text = "Processed (OpenCV)";
        grpResult.SetBounds(595, 8, 380, 440);
        picResult.Dock = DockStyle.Fill;
        picResult.BackColor = Color.FromArgb(45, 45, 45);
        picResult.SizeMode = PictureBoxSizeMode.Zoom;
        grpResult.Controls.Add(picResult);
        // status
        lblStatus.Text = "Open an image to begin.";
        statusStrip1.Items.Add(lblStatus);
        // dialogs
        openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp";
        saveFileDialog1.Filter = "PNG image|*.png";
        // OpenCvForm
        ClientSize = new Size(990, 480);
        Controls.AddRange(new Control[] { btnOpen, lstEffects, lblBrightness, trackBrightness, btnSave, grpOriginal, grpResult, statusStrip1 });
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "OpenCV Image Lab";
        ((System.ComponentModel.ISupportInitialize)trackBrightness).EndInit();
        ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();
        ((System.ComponentModel.ISupportInitialize)picResult).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Button btnOpen, btnSave;
    private ListBox lstEffects;
    private Label lblBrightness;
    private TrackBar trackBrightness;
    private GroupBox grpOriginal, grpResult;
    private PictureBox picOriginal, picResult;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
}
