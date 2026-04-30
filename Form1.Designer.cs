namespace SimplePaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAppName = new Label();
            grbTool = new GroupBox();
            btnCircle = new Button();
            btnRectangle = new Button();
            btnLine = new Button();
            grbColor = new GroupBox();
            cmbColor = new ComboBox();
            grbSize = new GroupBox();
            trbLineWidth = new TrackBar();
            btnOpenFile = new Button();
            btnSaveFile = new Button();
            picCanvas = new PictureBox();
            grbTool.SuspendLayout();
            grbColor.SuspendLayout();
            grbSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("한컴 말랑말랑 Bold", 25.8F, FontStyle.Bold, GraphicsUnit.Point, 129);
            lblAppName.Location = new Point(25, 24);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(259, 56);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "SimplePaint";
            // 
            // grbTool
            // 
            grbTool.Controls.Add(btnCircle);
            grbTool.Controls.Add(btnRectangle);
            grbTool.Controls.Add(btnLine);
            grbTool.Font = new Font("한컴 말랑말랑 Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 129);
            grbTool.Location = new Point(17, 108);
            grbTool.Name = "grbTool";
            grbTool.Size = new Size(324, 102);
            grbTool.TabIndex = 1;
            grbTool.TabStop = false;
            grbTool.Text = "도형선택";
            // 
            // btnCircle
            // 
            btnCircle.Image = Properties.Resources.circle;
            btnCircle.ImageAlign = ContentAlignment.TopCenter;
            btnCircle.Location = new Point(216, 29);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(96, 57);
            btnCircle.TabIndex = 2;
            btnCircle.Text = "원";
            btnCircle.TextAlign = ContentAlignment.BottomCenter;
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Image = Properties.Resources.square;
            btnRectangle.ImageAlign = ContentAlignment.TopCenter;
            btnRectangle.Location = new Point(114, 29);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(96, 57);
            btnRectangle.TabIndex = 1;
            btnRectangle.Text = "사각형";
            btnRectangle.TextAlign = ContentAlignment.BottomCenter;
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnLine
            // 
            btnLine.Font = new Font("한컴 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            btnLine.Image = Properties.Resources.line;
            btnLine.ImageAlign = ContentAlignment.TopCenter;
            btnLine.Location = new Point(12, 29);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(96, 57);
            btnLine.TabIndex = 0;
            btnLine.Text = "직선";
            btnLine.TextAlign = ContentAlignment.BottomCenter;
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // grbColor
            // 
            grbColor.Controls.Add(cmbColor);
            grbColor.Font = new Font("한컴 말랑말랑 Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 129);
            grbColor.Location = new Point(350, 108);
            grbColor.Name = "grbColor";
            grbColor.Size = new Size(164, 102);
            grbColor.TabIndex = 2;
            grbColor.TabStop = false;
            grbColor.Text = "색 선택";
            // 
            // cmbColor
            // 
            cmbColor.FormattingEnabled = true;
            cmbColor.Items.AddRange(new object[] { "Black 검정", "Red 빨강", "Blue 파랑", "Green 녹색" });
            cmbColor.Location = new Point(14, 43);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(135, 30);
            cmbColor.TabIndex = 0;
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            // 
            // grbSize
            // 
            grbSize.Controls.Add(trbLineWidth);
            grbSize.Font = new Font("한컴 말랑말랑 Bold", 10.1999989F, FontStyle.Bold, GraphicsUnit.Point, 129);
            grbSize.Location = new Point(520, 108);
            grbSize.Name = "grbSize";
            grbSize.Size = new Size(191, 102);
            grbSize.TabIndex = 2;
            grbSize.TabStop = false;
            grbSize.Text = "선 두깨";
            // 
            // trbLineWidth
            // 
            trbLineWidth.Location = new Point(18, 41);
            trbLineWidth.Name = "trbLineWidth";
            trbLineWidth.Size = new Size(153, 56);
            trbLineWidth.TabIndex = 0;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.CornflowerBlue;
            btnOpenFile.Location = new Point(721, 137);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(96, 57);
            btnOpenFile.TabIndex = 3;
            btnOpenFile.Text = "열기";
            btnOpenFile.UseVisualStyleBackColor = false;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // btnSaveFile
            // 
            btnSaveFile.BackColor = Color.Coral;
            btnSaveFile.Location = new Point(825, 137);
            btnSaveFile.Name = "btnSaveFile";
            btnSaveFile.Size = new Size(96, 57);
            btnSaveFile.TabIndex = 4;
            btnSaveFile.Text = "저장";
            btnSaveFile.UseVisualStyleBackColor = false;
            btnSaveFile.Click += btnSaveFile_Click;
            // 
            // picCanvas
            // 
            picCanvas.BackgroundImageLayout = ImageLayout.None;
            picCanvas.Image = Properties.Resources.background;
            picCanvas.Location = new Point(17, 226);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(904, 404);
            picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            picCanvas.TabIndex = 5;
            picCanvas.TabStop = false;
            picCanvas.Paint += picCanvas_Paint;
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseDown;
            picCanvas.MouseUp += picCanvas_MouseUp;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 642);
            Controls.Add(picCanvas);
            Controls.Add(btnSaveFile);
            Controls.Add(btnOpenFile);
            Controls.Add(grbSize);
            Controls.Add(grbColor);
            Controls.Add(grbTool);
            Controls.Add(lblAppName);
            Name = "Form1";
            Text = "SimplePaint v1.0";
            grbTool.ResumeLayout(false);
            grbColor.ResumeLayout(false);
            grbSize.ResumeLayout(false);
            grbSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAppName;
        private GroupBox grbTool;
        private GroupBox grbColor;
        private GroupBox grbSize;
        private Button btnCircle;
        private Button btnRectangle;
        private Button btnLine;
        private ComboBox cmbColor;
        private TrackBar trbLineWidth;
        private Button btnOpenFile;
        private Button btnSaveFile;
        private PictureBox picCanvas;
    }
}
