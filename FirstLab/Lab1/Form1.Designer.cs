
namespace Lab1
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
            panelLeft = new Panel();
            label1 = new Label();
            lblStrokeThickness = new Label();
            lblColorFill = new Label();
            lblTask = new Label();
            pbStrokeColor = new PictureBox();
            pbFillColor = new PictureBox();
            trbrThickness = new TrackBar();
            btnRedo = new Button();
            cbSelectShape = new ComboBox();
            btnUndo = new Button();
            btnDraw = new Button();
            pctbMain = new PictureBox();
            colorDialog1 = new ColorDialog();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStrokeColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFillColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbrThickness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctbMain).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(label1);
            panelLeft.Controls.Add(lblStrokeThickness);
            panelLeft.Controls.Add(lblColorFill);
            panelLeft.Controls.Add(lblTask);
            panelLeft.Controls.Add(pbStrokeColor);
            panelLeft.Controls.Add(pbFillColor);
            panelLeft.Controls.Add(trbrThickness);
            panelLeft.Controls.Add(btnRedo);
            panelLeft.Controls.Add(cbSelectShape);
            panelLeft.Controls.Add(btnUndo);
            panelLeft.Controls.Add(btnDraw);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(355, 937);
            panelLeft.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.Location = new Point(194, 182);
            label1.Name = "label1";
            label1.Size = new Size(145, 47);
            label1.TabIndex = 11;
            label1.Text = "Stroke color";
            // 
            // lblStrokeThickness
            // 
            lblStrokeThickness.AutoEllipsis = true;
            lblStrokeThickness.Location = new Point(26, 433);
            lblStrokeThickness.Name = "lblStrokeThickness";
            lblStrokeThickness.Size = new Size(313, 40);
            lblStrokeThickness.TabIndex = 10;
            lblStrokeThickness.Text = "Stroke thickness";
            // 
            // lblColorFill
            // 
            lblColorFill.AutoEllipsis = true;
            lblColorFill.Location = new Point(26, 182);
            lblColorFill.Name = "lblColorFill";
            lblColorFill.Size = new Size(145, 47);
            lblColorFill.TabIndex = 9;
            lblColorFill.Text = "Fill color";
            lblColorFill.Click += lblColorFill_Click;
            // 
            // lblTask
            // 
            lblTask.AutoEllipsis = true;
            lblTask.Location = new Point(26, 19);
            lblTask.Name = "lblTask";
            lblTask.Size = new Size(313, 80);
            lblTask.TabIndex = 3;
            lblTask.Text = "Choose the shape you would like to draw";
            lblTask.Click += lblTask_Click;
            // 
            // pbStrokeColor
            // 
            pbStrokeColor.BorderStyle = BorderStyle.FixedSingle;
            pbStrokeColor.Location = new Point(194, 232);
            pbStrokeColor.Name = "pbStrokeColor";
            pbStrokeColor.Size = new Size(145, 145);
            pbStrokeColor.TabIndex = 8;
            pbStrokeColor.TabStop = false;
            pbStrokeColor.Click += pbStroke_Click;
            // 
            // pbFillColor
            // 
            pbFillColor.BorderStyle = BorderStyle.FixedSingle;
            pbFillColor.Location = new Point(26, 232);
            pbFillColor.Name = "pbFillColor";
            pbFillColor.Size = new Size(145, 145);
            pbFillColor.TabIndex = 7;
            pbFillColor.TabStop = false;
            pbFillColor.Click += pbFillColor_Click;
            // 
            // trbrThickness
            // 
            trbrThickness.BackColor = Color.LavenderBlush;
            trbrThickness.LargeChange = 8;
            trbrThickness.Location = new Point(26, 507);
            trbrThickness.Maximum = 128;
            trbrThickness.Name = "trbrThickness";
            trbrThickness.Size = new Size(313, 90);
            trbrThickness.TabIndex = 6;
            trbrThickness.TickFrequency = 16;
            trbrThickness.Scroll += trbrThickness_Scroll;
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(26, 843);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(145, 82);
            btnRedo.TabIndex = 3;
            btnRedo.Text = "Redo";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // cbSelectShape
            // 
            cbSelectShape.FormattingEnabled = true;
            cbSelectShape.Items.AddRange(new object[] { "Segment", "Rectangle", "Ellipse", "Polygon", "BrokenLine" });
            cbSelectShape.Location = new Point(26, 118);
            cbSelectShape.Name = "cbSelectShape";
            cbSelectShape.Size = new Size(313, 40);
            cbSelectShape.TabIndex = 2;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(194, 843);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(145, 82);
            btnUndo.TabIndex = 1;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(26, 716);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(313, 76);
            btnDraw.TabIndex = 0;
            btnDraw.Text = "Draw";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += btnDraw_Click;
            // 
            // pctbMain
            // 
            pctbMain.BackColor = Color.White;
            pctbMain.Dock = DockStyle.Right;
            pctbMain.Location = new Point(383, 0);
            pctbMain.Name = "pctbMain";
            pctbMain.Size = new Size(1101, 937);
            pctbMain.TabIndex = 1;
            pctbMain.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1484, 937);
            Controls.Add(pctbMain);
            Controls.Add(panelLeft);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStrokeColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFillColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbrThickness).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctbMain).EndInit();
            ResumeLayout(false);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblTask_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panelLeft;
        private ComboBox cbSelectShape;
        private Button btnUndo;
        private Button btnDraw;
        private PictureBox pctbMain;
        private Label lblTask;
        private Button btnRedo;
        private TrackBar trbrThickness;
        private ColorDialog colorDialog1;
        private PictureBox pbFillColor;
        private Label lblColorFill;
        private PictureBox pbStrokeColor;
        private Label lblStrokeThickness;
        private Label label1;
    }
}
