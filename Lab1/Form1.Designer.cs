
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
            cbSelectShape = new ComboBox();
            btnUndo = new Button();
            btnDraw = new Button();
            pctbMain = new PictureBox();
            lblTask = new Label();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbMain).BeginInit();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(cbSelectShape);
            panelLeft.Controls.Add(btnUndo);
            panelLeft.Controls.Add(btnDraw);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(355, 937);
            panelLeft.TabIndex = 0;
            // 
            // cbSelectShape
            // 
            cbSelectShape.FormattingEnabled = true;
            cbSelectShape.Items.AddRange(new object[] { "Segment", "Rectangle", "Ellipse", "Polygon", "BrokenLine" });
            cbSelectShape.Location = new Point(26, 139);
            cbSelectShape.Name = "cbSelectShape";
            cbSelectShape.Size = new Size(283, 40);
            cbSelectShape.TabIndex = 2;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(26, 309);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(285, 82);
            btnUndo.TabIndex = 1;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnDraw
            // 
            btnDraw.Location = new Point(26, 215);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(285, 76);
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
            // lblTask
            // 
            lblTask.AutoEllipsis = true;
            lblTask.Location = new Point(37, 26);
            lblTask.Name = "lblTask";
            lblTask.Size = new Size(285, 101);
            lblTask.TabIndex = 3;
            lblTask.Text = "Choose the shape you would like to draw";
            lblTask.Click += lblTask_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1484, 937);
            Controls.Add(lblTask);
            Controls.Add(pctbMain);
            Controls.Add(panelLeft);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            panelLeft.ResumeLayout(false);
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
    }
}
