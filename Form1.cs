using System;
using System.Drawing;
using System.Drawing.Drawing2D; // 미리보기 점선(DashStyle)을 위해 필수 추가
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        // 사용할 도형 타입
        enum ToolType { Line, Rectangle, Circle }

        private Bitmap canvasBitmap;          // 실제 그림이 저장되는 비트맵
        private Graphics canvasGraphics;      // 비트맵 위에 그리기 위한 객체 
        private bool isDrawing = false;       // 현재 드래그 중인지 여부
        private Point startPoint;             // 드래그 시작점 
        private Point endPoint;               // 드래그 끝점 

        private ToolType currentTool = ToolType.Line;  // 현재 선택된 도형 
        private Color currentColor = Color.Black;      // 현재 색상
        private int currentLineWidth = 2;              // 현재 선 두께
        private double zoomFactor = 1.0;               // 확대/축소 비율

        public Form1()
        {
            InitializeComponent();

            // 1. 캔버스 초기화 
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);   // 캔버스를 흰색으로 초기화 
            picCanvas.Image = canvasBitmap;      // 그린 그림을 화면(PictureBox)에 표시

            // 마우스/페인트 이벤트는 디자이너에서 연결됨(InitializeComponent)

            // 3. 도형 선택 버튼 및 색상/두께 설정 (이벤트는 디자이너에서 연결됨)
            cmbColor.SelectedIndex = 0;  // 기본값: Black

            trbLineWidth.Minimum = 1;    // 최소값 
            trbLineWidth.Maximum = 10;   // 최대값 
            trbLineWidth.Value = 2;
        }



        // 마우스 누를 때 (드래그 시작) 
        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = GetRealCoordinate(e.Location); // 보정된 좌표 저장
        }

        // 마우스 이동할 때 (미리보기 화면 갱신) 
        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;       // 그림 그리기와 상관 없는 움직임은 무시
            endPoint = GetRealCoordinate(e.Location); // 보정된 좌표 갱신
            picCanvas.Invalidate();       // 화면 다시 그리기 (Paint 이벤트 발생)
        }

        // 마우스 뗄 때 (그리기 확정) 
        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;       // 무시 
            isDrawing = false;            // 드래그 종료 
            endPoint = GetRealCoordinate(e.Location); // 보정된 좌표 갱신

            // 실제 비트맵에 도형 확정 그리기
            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate();
        }

        // Paint 이벤트 (미리보기 도형을 점선으로 표시) 
        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing) return;

            // 점선 펜 (미리보기용) - 미리보기는 화면 좌표(확대 적용)
            using (Pen previewPen = new Pen(currentColor, Math.Max(1, (int)(currentLineWidth * zoomFactor))))
            {
                previewPen.DashStyle = DashStyle.Dash;
                // 캔버스 좌표(startPoint/endPoint)는 비트맵 기준이므로 확대 비율을 적용
                Point sp = new Point((int)(startPoint.X * zoomFactor), (int)(startPoint.Y * zoomFactor));
                Point ep = new Point((int)(endPoint.X * zoomFactor), (int)(endPoint.Y * zoomFactor));
                DrawShape(e.Graphics, previewPen, sp, ep);
            }
        }

        // 마우스 좌표(픽셀)를 비트맵상의 실제 좌표로 변환
        private Point GetRealCoordinate(Point mouseLocation)
        {
            return new Point((int)(mouseLocation.X / zoomFactor), (int)(mouseLocation.Y / zoomFactor));
        }

        // 확대/축소 적용
        private void ApplyZoom()
        {
            if (canvasBitmap == null) return;
            // PictureBox 크기를 비트맵 크기에 확대 비율을 적용하여 설정
            picCanvas.Width = (int)(canvasBitmap.Width * zoomFactor);
            picCanvas.Height = (int)(canvasBitmap.Height * zoomFactor);
            // PictureBox에 표시되는 이미지는 StretchImage 모드에서 PictureBox 크기에 맞춰 그려진다
            picCanvas.Invalidate();
        }

        // 선택된 도형을 그리는 통합 함수
        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);

            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "이미지 불러오기";
                openFileDialog.Filter = "이미지 파일 (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp|모든 파일 (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image loadedImage = Image.FromFile(openFileDialog.FileName);

                    // 기존 리소스 정리
                    if (canvasGraphics != null) canvasGraphics.Dispose();
                    if (canvasBitmap != null) canvasBitmap.Dispose();

                    // 불러온 이미지를 캔버스로 사용
                    canvasBitmap = new Bitmap(loadedImage);
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    // PictureBox 크기를 이미지 크기에 맞추고 표시
                    zoomFactor = 1.0;
                    picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
                    picCanvas.Image = canvasBitmap;
                    ApplyZoom();
                }
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoomFactor += 0.2;
            ApplyZoom();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (zoomFactor > 0.4)
            {
                zoomFactor -= 0.2;
                ApplyZoom();
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }
        private Rectangle GetRectangle(Point p1, Point p2)
        // 두 점으로부터 사각형의 위치와 크기(Rectangle 객체)를 계산하는 함수
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }



        private void btnLine_Click(object sender, EventArgs e) { currentTool = ToolType.Line; }
        private void btnRectangle_Click(object sender, EventArgs e) { currentTool = ToolType.Rectangle; }
        private void btnCircle_Click(object sender, EventArgs e) { currentTool = ToolType.Circle; }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: currentColor = Color.Black; break;
                case 1: currentColor = Color.Red; break;
                case 2: currentColor = Color.Blue; break;
                case 3: currentColor = Color.Green; break;
                default: currentColor = Color.Black; break;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // SaveFileDialog를 생성하여 저장 대화상자 호출
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "그림 저장하기";
                // .png, .jpg, .bmp 3가지 포맷 지정
                saveFileDialog.Filter = "PNG 파일 (*.png)|*.png|JPG 파일 (*.jpg)|*.jpg|BMP 파일 (*.bmp)|*.bmp";

                // 사용자가 '저장' 버튼을 눌렀을 때
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 사용자가 선택한 파일 확장자 추출
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    // 확장자에 맞추어 canvasBitmap을 파일로 저장
                    switch (extension)
                    {
                        case ".png":
                            canvasBitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case ".jpg":
                        case ".jpeg":
                            canvasBitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case ".bmp":
                            canvasBitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                    }
                }
            }
        }


        

        // Designer-level handlers were removed in favor of PicCanvas_* methods above.

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}