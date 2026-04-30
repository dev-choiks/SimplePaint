# SimplePaint

## 개요
- C# 프로그래밍 학습
- 1줄 소개: 선, 사각형, 원을 그리고 이미지 파일로 저장할 수 있는 그림판 프로그램 (Simple Paint)
- 사용한 플랫폼:
  - C#, .NET Windows Forms, Visual Studio, GitHub
- 사용한 컨트롤:
  - PictureBox, Button, ComboBox, TrackBar, GroupBox, Label
- 사용한 기술과 구현한 기능:
  - Visual Studio를 이용한 그림판 UI 디자인 및 명명 규칙을 준수한 컨트롤 배치
  - Bitmap 객체와 Graphics 클래스를 활용한 메모리 캔버스 초기화 및 제어
  - 열거형(enum)과 switch~case 문을 활용한 다양한 그리기 상태(도형, 색상 등) 관리
  - 마우스 이벤트(MouseDown, MouseMove, MouseUp)와 Paint 이벤트를 결합한 드래그 기반 그리기 구현
  - OpenFileDialog 및 SaveFileDialog를 통한 이미지 로드 및 다양한 포맷(.png, .jpg, .bmp) 저장 기능 구현

## 실행 화면 (과제1)



![과제1 실행화면](img/1.png)





- 과제 내용
  - 그림판의 기본 UI를 배치하고, 도형 선택, 색상 선택, 선 굵기 선택 기능을 구현합니다.
- 구현 내용과 기능 설명
  - UI 레이아웃 설계: 도화지 역할을 할 PictureBox(picCanvas)를 넓게 배치하고, 상단에는 기능별로 GroupBox를 나누어 묶었습니다.
  - 컨트롤 명명 규칙 준수: 모든 버튼과 콤보박스, 트랙바 등의 이름을 기본값(button1 등)에서 btnLine, btnRectangle, cmbColor, trbLineWidth 등 의미 있는 이름으로 변경하여 가독성을 높였습니다.
  - 도형 선택 기능: 3개의 Button을 이용해 직선, 사각형, 원을 선택할 수 있게 하였으며, 클릭 시 ToolType 열거형 변수의 상태가 변경되도록 구현했습니다.
  - 색상 선택 기능: ComboBox 컨트롤을 이용해 검정, 빨강, 파랑, 녹색 등 4가지 색상을 목록으로 제공하고, SelectedIndexChanged 이벤트를 통해 선택된 색상으로 상태가 업데이트되도록 구현했습니다.
  - 선 두께 조절 기능: TrackBar 컨트롤을 이용하여 마우스로 스크롤을 움직여 선의 두께를 최소 1에서 최대 10까지 조절할 수 있도록 설정했습니다.