using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Paint
{
    public partial class Form1 : Form
    {
        //khai bao can thiet
        private Bitmap bm, bmChon;
        private Graphics gp;
        private String line, transalte;
        private Color clLine = Color.Black;
        private Point oldPoint, newPoint, firstPoint, lastPoint;
        private int widthLine;
        private DrawTool dt, dtChon, dtNam;
        private ChangeTool ct;

        private Boolean bMouseClick = false;
        private Boolean bMouseDown = false;
        private Boolean bDraw = false;
        private Boolean bMousePress = false;
        private Boolean bMouseUp = true;

        public Form1()
        {
            InitializeComponent();
            start();
            dtNam.ResetBitmap();
        }

        private void TurnOffModeDraw(Button btCheck)
        {
            if (btCheck.BackColor == SystemColors.ControlDark) btCheck.BackColor = SystemColors.Control;
            if (btCheck == btConLacCD)
            {
                cbIsStop.Visible = false;
                cbIsStop.Checked = true;
            }
        }

        private void pbDrawZone_MouseDown(object sender, MouseEventArgs e)
        {
            bDraw = true;
            bMouseDown = true;
            bMouseUp = false;
            //resetPoint(ref oldPoint);
            //resetPoint(ref newPoint);
            myDraw(e);
        }

        private void pbDrawZone_MouseClick(object sender, MouseEventArgs e)
        {
            bMouseClick = true;
            //FillColor(e);
        }

        private void pbDrawZone_MouseMove(object sender, MouseEventArgs e)
        {
            if (bMouseDown == true)
            {
                bMousePress = true;
                myDraw(e);
            }
        }

        private void pbDrawZone_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseUp = true;
            bMouseDown = false;
            bMousePress = false;
            bMouseClick = false;

            myDraw(e);
            bDraw = false;


            if(!oldPoint.IsEmpty) firstPoint = oldPoint;
            if(!newPoint.IsEmpty) lastPoint = newPoint;

            resetPoint(ref oldPoint);
            resetPoint(ref newPoint);
        }

        private void btLine_Click(object sender, EventArgs e)
        {
            if (btDrawPixel.BackColor == SystemColors.Control)
            {
                if (btDrawArrow.BackColor == SystemColors.ControlDark) btDrawArrow.BackColor = SystemColors.Control;
                if (btFillColor.BackColor == SystemColors.ControlDark) btFillColor.BackColor = SystemColors.Control;
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btConLacCD);

                btDrawPixel.BackColor = SystemColors.ControlDark;

                line = "pixel";
            }
            else if (btDrawPixel.BackColor == SystemColors.ControlDark)
            {
                btDrawPixel.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }

        private void btDrawArrow_Click(object sender, EventArgs e)
        {
            if (btDrawArrow.BackColor == SystemColors.Control)
            {
                if (btDrawPixel.BackColor == SystemColors.ControlDark) btDrawPixel.BackColor = SystemColors.Control;
                if (btFillColor.BackColor == SystemColors.ControlDark) btFillColor.BackColor = SystemColors.Control;
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btConLacCD);

                btDrawArrow.BackColor = SystemColors.ControlDark;
                line = "arrow";
            }
            else if (btDrawArrow.BackColor == SystemColors.ControlDark)
            {
                btDrawArrow.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }

        private void pbDrawZone_Resize(object sender, EventArgs e)
        {
            newBitMap(pbDrawZone.Width, pbDrawZone.Height);
        }

        //Khởi tạo dữ liệu
        private void start()
        {
            //widthLine = int.Parse(cbWidthLine.SelectedValue.ToString());
            newBitMap(pbDrawZone.Width, pbDrawZone.Height);

            cbWidthLine.SelectedIndex = 0;
            cbDrawColor.Checked = false;
        }

        //Reset điểm
        private void resetPoint(ref Point p)
        {
            p = Point.Empty;
        }

        //Tạo bit map
        private void newBitMap(int w, int h)
        {
            bm = new Bitmap(w, h);
            bmChon = bm;

            pbDrawZone.Image = bm;

            dt = new DrawTool(bm, label2);
            dtChon = new DrawTool(bmChon, label2);
            ct = new ChangeTool(label2);

            dtNam = new DrawTool(pbDrawZone, label2);

            gp = Graphics.FromImage(bm);
        }

        //Vẽ đường tròn
        private void drawCircle(MouseEventArgs e)
        {
            resetPoint(ref oldPoint);
            if (bMouseUp == true)
            {
                newPoint = e.Location;
            }

            Pen pen = new Pen(clLine, widthLine);

            try
            {
                if (newPoint != Point.Empty)
                {
                    //dtNam.ResetBitmap();
                    //dt.DrawCircle(e.Location, int.Parse(tbRadius.Text), pen, cbDrawColor.Checked);
                    dtNam.DrawCircle(e.Location, int.Parse(tbRadius.Text), pen, cbDrawColor.Checked);
                }
            }
            catch (FormatException)
            {
                tbRadius.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbRadius.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Refresh();
            }
        }

        //Vẽ pixel
        private void drawPixel(MouseEventArgs e)
        {
            newPoint = e.Location;

            Pen pen = new Pen(clLine, widthLine);

            if (oldPoint != Point.Empty)
            {
                gp.FillRectangle(pen.Brush, oldPoint.X - widthLine / 2, oldPoint.Y - widthLine / 2, widthLine, widthLine);
                gp.DrawLine(pen, oldPoint, newPoint);
            }

            oldPoint = newPoint;
            pbDrawZone.Image = bm;
        }

        //Vẽ mũi tên
        private void drawArrow(MouseEventArgs e)
        {

            if (bMouseDown == true && bMousePress == false)
            {
                oldPoint = e.Location;
            }
            if (bMouseUp == true)
            {
                newPoint = e.Location;
            }

            Pen p = new Pen(clLine, widthLine);

            /*Thuật toán vẽ mũi tên:
            1) Xoay (quanh gốc tọa độ) mũi tên về trùng với trục Ox theo phép quay (CT: x2 = x1.cos(a) - y1.sin(a) 
                                                                     y2 = x1.sin(a) + y1.cos(a)
            2) Vẽ mũi tên theo dạng ngang:
                - Vẽ đường thẳng từ firstP -> lastP
                - Vẽ tam cân có đỉnh là LastP, chiều cao là 1.5 * width
            3) Xoay tất cả điểm vẽ được về hướng cũ với công thức ở trên với góc -a 
            Ở đây mình dùng thư viện cho nhanh :v */
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            if (oldPoint != Point.Empty && newPoint != Point.Empty)
            {
                dtNam.DrawArrow(oldPoint, newPoint, p, cbDrawColor.Checked);

                pbDrawZone.Refresh();

                //try
                //{

<<<<<<< HEAD
                //    pbDrawZone.Refresh();
                //}
                //catch (Exception)
                //{
                //    cbIsStop.Checked = false;
                //}
                //finally
                //{
                //    pbDrawZone.Refresh();
                //}
            }                
            //gp.DrawLine(p, oldPoint, newPoint);
=======
            //p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
>>>>>>> 4d698da9368c8be750f67590615448fae029dc4b

            
        }

        //Tô màu
        private void FillColor(MouseEventArgs e)
        {
            Point fillPoint = new Point();

            if (bMouseUp == true)
            {
                fillPoint = e.Location;
            }

            try
            {
                dt.FillColor(fillPoint, Color.Red);

                pbDrawZone.Image = bm;
            }
            catch (ArgumentOutOfRangeException)
            {
                label2.Text = "out of range!!!";
            }
        }

        private void cbWidthLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            widthLine = int.Parse(cbWidthLine.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDrawColor_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void tbRotate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btRotate_Click(object sender, EventArgs e)
        {
            if (btRotate.BackColor == SystemColors.Control)
            {
                btRotate.BackColor = SystemColors.ControlDark;
                TurnOffModeDraw(btSymmetry);

                transalte = "rotate";
            }
            else if (btRotate.BackColor == SystemColors.ControlDark)
            {
                btRotate.BackColor = SystemColors.Control;
                transalte = String.Empty;
            }
        }

        private void btSymmetry_Click(object sender, EventArgs e)
        {
            if (btSymmetry.BackColor == SystemColors.Control)
            {
                btSymmetry.BackColor = SystemColors.ControlDark;
                TurnOffModeDraw(btRotate);

                transalte = "symmetry";
            }
            else if (btSymmetry.BackColor == SystemColors.ControlDark)
            {
                btSymmetry.BackColor = SystemColors.Control;
                transalte = String.Empty;
            }
        }

        private void pbDrawZone_Click(object sender, EventArgs e)
        {

        }

        private void pbDrawZone_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawConLac(Point A, Point B, Point centerP, int R, Pen p, Boolean isColor)
        {
            dtNam.DrawLineByMidPoint(A, B, p, isColor);


            dtNam.DrawCircle(centerP, R, p, isColor);

            //if(pbDrawZone != null) pbDrawZone.Image = bm;
        }

        private void DrawClock(Point A, int height, Color color)
        {
            Point B, C, D, E, X, Y, Z, centerP;
            float radius;
            Pen p = new Pen(color, 1);

            B = new Point(A.X + height / 2, A.Y); C = new Point(A.X - height / 2, A.Y);
            D = new Point(B.X, B.Y - height); E = new Point(C.X, D.Y);

            X = new Point(A.X, A.Y - (2 * height) + height / 4);
            Y = new Point(D.X + (height / 2), D.Y); Z = new Point(E.X - (height / 2), E.Y);

            centerP = new Point(A.X, A.Y - (height / 2));
            radius = height / 2 - 5;

            Pen deleteP = new Pen(SystemColors.Control, 1);

            //DrawLineByMidPoint(B, C, p, false); DrawLineByMidPoint(C, E, p, false);
            //DrawLineByMidPoint(E, D, p, false); DrawLineByMidPoint(D, B, p, false);
            dtNam.DrawLineByMidPoint(new Point(B.X, (B.Y + D.Y) / 2), new Point(C.X, (C.Y + E.Y) / 2), new Pen(Color.Black, height / 2), true);

            dtNam.DrawTriangleByMidPoint(Y, Z, X, p, true);

            dtNam.DrawCircle(centerP, (int)radius, deleteP, true);
            //FillColor(centerP, p.Color);
        }

        public void DrawConLacThang(Point A, int height, int R, Color color, Boolean isStop)
        {
            ChangeTool ct = new ChangeTool(label2);
            Point B = new Point(A.X, A.Y + height - R);
            Point centerP = new Point(B.X, B.Y + R);

            Point centerClockP = new Point(A.X, A.Y - (height / 2));
            int radiusClock = height / 2 - height / 5;
            Point lastClockP = new Point(centerClockP.X, centerClockP.Y - radiusClock);

            Point animB, animCenterP, animClock;
            Pen p = new Pen(color, 2);
            Pen deleteP = new Pen(SystemColors.Control, 2);
            float maxAngle = 30;
            float angle = maxAngle;
            float angleClock = 0;

            Boolean chieuDuong = true;

            animClock = lastClockP;
            animB = B; animCenterP = centerP;
            //int i = 0;

            if(!isStop)
            {
                DrawClock(A, height, color);
                DrawConLac(A, animB, animCenterP, R, p, true);
            }
            while (!isStop)
            {
                isStop = cbIsStop.Checked;
                ////Thread.Yield();
                //label2.Text = i.ToString();
                //i++;

                if (angle == maxAngle)
                {
                    chieuDuong = false;

                    dtNam.DrawArrow(centerClockP, animClock, new Pen(SystemColors.Control, height / 50), false);
                    animClock = ct.RotateAroundPoint(centerClockP, lastClockP, angleClock, color);
                    dtNam.DrawArrow(centerClockP, animClock, new Pen(color, height / 50), false);

                    angleClock = angleClock + 6;
                }
                else if (angle == -maxAngle)
                {
                    chieuDuong = true;

                    dtNam.DrawArrow(centerClockP, animClock, new Pen(SystemColors.Control, height / 50), false);
                    animClock = ct.RotateAroundPoint(centerClockP, lastClockP, angleClock, color);
                    dtNam.DrawArrow(centerClockP, animClock, new Pen(color, height / 50), false);

                    angleClock = angleClock + 6;
                }


                DrawConLac(A, animB, animCenterP, R, deleteP, true);


                animB = ct.RotateAroundPoint(A, B, angle, color);
                animCenterP = ct.RotateAroundPoint(A, centerP, angle, color);

                DrawConLac(A, animB, animCenterP, R, p, true);
                
                pbDrawZone.Refresh();
                //pbDrawZone.Image = bm;
                Thread.Sleep(3);


                if (chieuDuong)
                {
                    angle++;
                }
                else
                {
                    angle--;
                }

            }
        }

        private void AnimConLac()
        {
            //Animation animation = new Animation();
            Point point = newPoint;
            label2.Text = newPoint.ToString();
            int lengh = 50;
            point.Y = point.Y + lengh / 2;

            //DrawTool dtNew = new DrawTool(pbDrawZone, label2);
            //dtChon.ResetBitmap();
            //dtNew.DrawConLacThang(new Point(200, 200), 50 * int.Parse(cbWidthLine.Text), 10 * int.Parse(cbWidthLine.Text), clLine);
            //dtNam.DrawConLacThang(new Point(200, 200), 50 , 10 , clLine, cbDrawColor.Checked);
            //DrawConLacThang(new Point(200, 200), 50, 10, clLine, cbDrawColor.Checked);
            
            DrawConLacThang(point, lengh * int.Parse(cbWidthLine.Text), 
                10 * int.Parse(cbWidthLine.Text), clLine, cbIsStop.Checked);
        }

        private void ThreadAnimConLac(MouseEventArgs e)
        {
            Thread t = new Thread(AnimConLac);
            t.IsBackground = true;

            resetPoint(ref oldPoint);
            if (bMouseUp == true)
            {
                newPoint = e.Location;
                //if (!cbIsStop.Checked)
                //{
                //    cbIsStop.Checked = true;
                //}
            }

            if (newPoint != Point.Empty)
            {
                cbIsStop.Checked = false;
                t.Start();
                Thread.Sleep(50);
                newPoint = Point.Empty;
            }

        }

        private void btConLacCD_Click(object sender, EventArgs e)
        {
            if (btConLacCD.BackColor == SystemColors.Control)
            {
                btConLacCD.BackColor = SystemColors.ControlDark;
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btFillColor);

                cbIsStop.Visible = true;
                cbIsStop.Checked = false;
                line = "con lac";
            }
            else if (btConLacCD.BackColor == SystemColors.ControlDark)
            {
                btConLacCD.BackColor = SystemColors.Control;

                cbIsStop.Visible = false;
                line = String.Empty;
            }
        }

        private void btFillColor_Click(object sender, EventArgs e)
        {
            if (btFillColor.BackColor == SystemColors.Control)
            {
                if (btDrawPixel.BackColor == SystemColors.ControlDark) btDrawPixel.BackColor = SystemColors.Control;
                if (btDrawArrow.BackColor == SystemColors.ControlDark) btDrawArrow.BackColor = SystemColors.Control;
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btConLacCD);

                btFillColor.BackColor = SystemColors.ControlDark;

                line = "color";
            }
            else if (btFillColor.BackColor == SystemColors.ControlDark)
            {
                btFillColor.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }

        private void btDrawCircle_Click(object sender, EventArgs e)
        {
            if (btDrawCircle.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btFillColor);
                TurnOffModeDraw(btConLacCD);

                btDrawCircle.BackColor = SystemColors.ControlDark;

                line = "circle";
            }
            else if (btDrawCircle.BackColor == SystemColors.ControlDark)
            {
                btDrawCircle.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }

        private void lbDoDay_Click(object sender, EventArgs e)
        {

        }

        private void RotateArrow(Point aroundPoint)
        {
            if(bMouseUp)
            {
                if(!String.IsNullOrEmpty(tbRotate.Text))
                {
                    oldPoint = ct.RotateAroundPoint(aroundPoint, firstPoint, int.Parse(tbRotate.Text), clLine);
                    newPoint = ct.RotateAroundPoint(aroundPoint, lastPoint, int.Parse(tbRotate.Text), clLine);

                    dt.DrawArrow(oldPoint, newPoint, new Pen(clLine, widthLine), cbDrawColor.Checked);
                    pbDrawZone.Image = bm;
                }
            }
        }

        private void SymmetryArrow(MouseEventArgs e)
        {
            if (bMouseDown == true && bMousePress == false)
            {
                oldPoint = e.Location;
            }
            if (bMouseUp == true)
            {
                newPoint = e.Location;
            }

            Pen p = new Pen(clLine, widthLine);

            if (bMouseUp)
            {
                //oldPoint.X = 100;
                //oldPoint.Y = 300;
                //newPoint.X = 300;
                //newPoint.Y = 100;

                //firstPoint.X = 50;
                //firstPoint.Y = 100;
                //lastPoint.X = 200;
                //lastPoint.Y = 200;

                //dt.DrawArrow(firstPoint, lastPoint, p, cbDrawColor.Checked);
                //label2.Text = oldPoint + " vs " + newPoint;
                try
                {
                    dt.DrawLineByMidPoint(oldPoint, newPoint, p, true);
                    //dt.DrawLineByMidPoint(firstPoint, lastPoint, p, true);
                    firstPoint = ct.SymmetricalPointByLine(oldPoint, newPoint, firstPoint, clLine);
                    lastPoint = ct.SymmetricalPointByLine(oldPoint, newPoint, lastPoint, clLine);
                    //label2.Text = oldPoint + " " + newPoint;
                    dt.DrawArrow(firstPoint, lastPoint, p, cbDrawColor.Checked);
                    //bm.SetPixel(oldPoint.X, oldPoint.Y, Color.Red);
                    //bm.SetPixel(newPoint.X, newPoint.Y, Color.Green);

                } catch (Exception)
                {
                    return;
                } finally
                {
                    pbDrawZone.Image = bm;
                }
            }

            pbDrawZone.Image = bm;
        }

        //hàm vẽ
        private void myDraw(MouseEventArgs e)
        {

            if (bDraw == true)
            {
                if (line == "pixel")
                {
                    drawPixel(e);
                }
                else if (line == "arrow")
                {
                    if (transalte == "rotate")
                    {
                        RotateArrow(e.Location);
                        return;
                    }
                    else if (transalte == "symmetry")
                    {
                        SymmetryArrow(e);
                        return;
                    }
                    drawArrow(e);
                }
                else if (line == "color")
                {
                    FillColor(e);
                }
                else if (line == "circle")
                {
                    drawCircle(e);
                }
                else if( line == "con lac")
                {
                    ThreadAnimConLac(e);
                }
            }
        }
    }
}
