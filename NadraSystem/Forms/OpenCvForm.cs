using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace NadraSystem.Forms;

/// <summary>OpenCV module: applies visual effects to an image (e.g. a citizen photo).</summary>
public partial class OpenCvForm : Form
{
    private Mat original;

    public OpenCvForm()
    {
        InitializeComponent();
        lstEffects.Items.AddRange(new object[]
            { "Original", "Grayscale", "Blur", "Sharpen", "Edge Detection", "Pencil Sketch", "Cartoon", "Sepia", "Invert" });
        lstEffects.SelectedIndex = 0;
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
        original = Cv2.ImRead(openFileDialog1.FileName, ImreadModes.Color);   // BGR image
        picOriginal.Image = original.ToBitmap();
        ApplyEffect();
    }

    private void lstEffects_SelectedIndexChanged(object sender, EventArgs e) => ApplyEffect();

    private void trackBrightness_Scroll(object sender, EventArgs e)
    {
        lblBrightness.Text = "Brightness: " + trackBrightness.Value;
        ApplyEffect();
    }

    private void ApplyEffect()
    {
        if (original == null) return;
        Mat result = new Mat();
        Mat gray = original.CvtColor(ColorConversionCodes.BGR2GRAY);

        switch (lstEffects.Text)
        {
            case "Grayscale":
                result = gray.CvtColor(ColorConversionCodes.GRAY2BGR);
                break;
            case "Blur":
                Cv2.GaussianBlur(original, result, new OpenCvSharp.Size(21, 21), 0);
                break;
            case "Sharpen":
                var kernel = Mat.FromPixelData(3, 3, MatType.CV_32F, new float[] { 0, -1, 0, -1, 5, -1, 0, -1, 0 });
                Cv2.Filter2D(original, result, -1, kernel);
                break;
            case "Edge Detection":
                Cv2.Canny(gray, gray, 80, 160);
                result = gray.CvtColor(ColorConversionCodes.GRAY2BGR);
                break;
            case "Pencil Sketch":
                Cv2.PencilSketch(original, gray, result, 60, 0.07f, 0.05f);
                result = gray.CvtColor(ColorConversionCodes.GRAY2BGR);
                break;
            case "Cartoon":
                Cv2.Stylization(original, result, 60, 0.45f);
                break;
            case "Sepia":
                var sepia = Mat.FromPixelData(3, 3, MatType.CV_32F, new float[]
                    { 0.131f, 0.534f, 0.272f, 0.168f, 0.686f, 0.349f, 0.189f, 0.769f, 0.393f });
                Cv2.Transform(original, result, sepia);
                break;
            case "Invert":
                Cv2.BitwiseNot(original, result);
                break;
            default:
                result = original.Clone();
                break;
        }

        // brightness from the TrackBar (-100 .. +100)
        result.ConvertTo(result, -1, 1.0, trackBrightness.Value);
        picResult.Image = result.ToBitmap();
        lblStatus.Text = $"Effect: {lstEffects.Text}   |   Size: {original.Width} x {original.Height}";
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (picResult.Image != null && saveFileDialog1.ShowDialog() == DialogResult.OK)
            picResult.Image.Save(saveFileDialog1.FileName);
    }
}
