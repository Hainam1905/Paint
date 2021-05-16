using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private DrawTool dt, dtChon;
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

        }

        private void TurnOffModeDraw(Button btCheck)
        {
            if (btCheck.BackColor == SystemColors.ControlDark) btCheck.BackColor = SystemColors.Control;
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

            cbWidthLine.SelectedIndex = 3;
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
            ct = new ChangeTool(bm, label2);

            gp = Graphics.FromImage(bm);
        }

        //Vẽ đường tròn
        private void drawCircle(MouseEventArgs e)
        {
            resetPoint(ref oldPoint);
            if(bMouseUp == true)
            if (bMouseUp == true)
            {
                newPoint = e.Location;
            }

            Pen pen = new Pen(clLine, widthLine);

            try
            {
                if (newPoint != Point.Empty)
                {
                    dt.DrawCircle(e.Location, int.Parse(tbRadius.Text), pen);
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
                pbDrawZone.Image = bm;
            }
        }

        //Vẽ pixel
        private void drawPixel(MouseEventArgs e)
        {
            newPoint = e.Location;

            Pen pen = new Pen(clLine, widthLine);

            if (oldPoint != Point.Empty)
            {
                //gp.FillRectangle(pen.Brush, oldPoint.X - widthLine / 2, oldPoint.Y - widthLine / 2, widthLine, widthLine);
                //gp.DrawLine(pen, oldPoint, newPoint);
                dt.MidPoint(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, pen, true);
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

            if (oldPoint != Point.Empty && newPoint != Point.Empty) dt.DrawArrow(oldPoint, newPoint, p, cbDrawColor.Checked);
            //gp.DrawLine(p, oldPoint, newPoint);
                                                                    
            pbDrawZone.Image = bm;
        }
        //Vẽ đường thẳng
        private void drawLine(MouseEventArgs e)
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

            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            if (oldPoint != Point.Empty && newPoint != Point.Empty) dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

            pbDrawZone.Image = bm;
        }

        //vẽ hình thoi
        private void veHinhThoi(MouseEventArgs e)
        {
            resetPoint(ref oldPoint);
            if (bMouseUp == true)
                if (bMouseUp == true)
                {
                    newPoint = e.Location;
                }

            Pen pen = new Pen(clLine, widthLine);
       
            try
            {
                if (newPoint != Point.Empty)
                {
                    Point A, B, C, D;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    D = new Point();
                    dt.tim4DiemHinhThoi(e.Location, ref A, ref B, ref C, ref D, int.Parse(txtCheoA.Text), int.Parse(txtCheoB.Text));
                    dt.VeHinhTuGiac(pen,A,B,C,D);
                }
            }
            catch (FormatException)
            {
                txtCheoA.Text = String.Empty;
                txtCheoB.Text= String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                txtCheoA.Text = String.Empty;
                txtCheoB.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }

        //vẽ hình chữ nhật
        private void veHinhChuNhat(MouseEventArgs e)
        {
            resetPoint(ref oldPoint);
            if (bMouseUp == true)
                if (bMouseUp == true)
                {
                    newPoint = e.Location;
                }

            Pen pen = new Pen(clLine, widthLine);

            try
            {
                if (newPoint != Point.Empty)
                {
                    Point A, B, C, D;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    D = new Point();
                    dt.tim4DiemHinhChuNhat(e.Location, ref A, ref B, ref C, ref D, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
                    dt.VeHinhTuGiac(pen, A, B, C, D);
                }
            }
            catch (FormatException)
            {
                tbWidth.Text = String.Empty;
                tbHeight.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbWidth.Text = String.Empty;
                tbHeight.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }

        //vẽ tam giác
        private void veTamGiac(MouseEventArgs e)
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

            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            
            try
            {
                if (oldPoint != Point.Empty && newPoint != Point.Empty)
                {
                    Point A, B, C;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    dt.tim3DiemTamGiac(newPoint, ref A, ref B, ref C, int.Parse(tbChieuCao.Text), int.Parse(tbRongDay.Text));
                    dt.veHinhTamGiac(A, B, C, p);
                }
            }
            catch (FormatException)
            {
                tbChieuCao.Text = String.Empty;
                tbRongDay.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbChieuCao.Text = String.Empty;
                tbRongDay.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
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
            cbDrawColor.Checked = true;
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

        private void btDrawLine_Click(object sender, EventArgs e)
        {
            if (btDrawLine.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btHinhThoi);
                btDrawLine.BackColor = SystemColors.ControlDark;

                line = "line";
            }
            else if (btDrawLine.BackColor == SystemColors.ControlDark)
            {
                btDrawLine.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }

        private void btHinhThoi_Click(object sender, EventArgs e)
        {
            if (btHinhThoi.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btTamGiac);

                btHinhThoi.BackColor = SystemColors.ControlDark;
                lbCheoA.Visible = true;
                lbCheoB.Visible = true;
                txtCheoA.Visible = true;
                txtCheoB.Visible = true;
                line = "hinhThoi";
            }
            else if (btHinhThoi.BackColor == SystemColors.ControlDark)
            {
                btHinhThoi.BackColor = SystemColors.Control;
                line = String.Empty;
                lbCheoA.Visible = false;
                lbCheoB.Visible = false;
                txtCheoA.Visible = false;
                txtCheoB.Visible = false;
            }
        }
        private void btHCN_Click(object sender, EventArgs e)
        {
            if (btHCN.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btTamGiac);

                btHCN.BackColor = SystemColors.ControlDark;
                lbWidth.Visible = true;
                lbHeight.Visible = true;
                tbWidth.Visible = true;
                tbHeight.Visible = true;
                line = "HCN";
            }
            else if (btHCN.BackColor == SystemColors.ControlDark)
            {
                btHCN.BackColor = SystemColors.Control;
                line = String.Empty;
                lbWidth.Visible = false;
                lbHeight.Visible = false;
                tbWidth.Visible = false;
                tbHeight.Visible = false;
            }
        }
        private void btTamGiac_Click(object sender, EventArgs e)
        {
            if (btTamGiac.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);

                btTamGiac.BackColor = SystemColors.ControlDark;
                lbChieuCao.Visible = true;
                lbRongDay.Visible = true;
                tbChieuCao.Visible = true;
                tbRongDay.Visible = true;
                line = "tamGiac";
            }
            else if (btTamGiac.BackColor == SystemColors.ControlDark)
            {
                btTamGiac.BackColor = SystemColors.Control;
                line = String.Empty;
                lbChieuCao.Visible = false;
                lbRongDay.Visible = false;
                tbChieuCao.Visible = false;
                tbRongDay.Visible = false;
            }
        }
        private void btFillColor_Click(object sender, EventArgs e)
        {
            if (btFillColor.BackColor == SystemColors.Control)
            {
                if (btDrawPixel.BackColor == SystemColors.ControlDark) btDrawPixel.BackColor = SystemColors.Control;
                if (btDrawArrow.BackColor == SystemColors.ControlDark) btDrawArrow.BackColor = SystemColors.Control;
                TurnOffModeDraw(btDrawCircle);

                btFillColor.BackColor = SystemColors.ControlDark;
                //dt.FillColor(new Point(52, 52), Color.Black);
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
            float[,] a =
            {
                {1, 2, 3}
            };
            float[,] b =
            {
                {1, 2, 4 },
                {2, 3, 5 },
                {2, 4, 1 }
            };
            float[,] c =
            {
                {1, 2, 4 },
                {2, 3, 5 },
                {2, 4, 1 }
            };

            Matrix ma = new Matrix(a);
            Matrix mb = new Matrix(b);
            Matrix mc = new Matrix(c);
            Matrix md = ma * mb * mc;

            for (int i = 0; i < md.Row; i++)
                for (int j = 0; j < md.Col; j++)
                    label2.Text = label2.Text + " " + md.Matrixa[i, j];
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
        
        //BỔ SUNG
        //Các phép biến đổi của đường thẳng
        private void RotateLine(Point aroundPoint)
        {
            if (bMouseUp)
            {
                if (!String.IsNullOrEmpty(tbRotate.Text))
                {
                    oldPoint = ct.RotateAroundPoint(aroundPoint, firstPoint, int.Parse(tbRotate.Text), clLine);
                    newPoint = ct.RotateAroundPoint(aroundPoint, lastPoint, int.Parse(tbRotate.Text), clLine);
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, new Pen(clLine, widthLine));
                    //dt.DrawLineByMidPoint(oldPoint, newPoint, new Pen(clLine, widthLine), cbDrawColor.Checked);
                    pbDrawZone.Image = bm;
                }
            }
        }
        private void SymmetryLine(MouseEventArgs e)
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
                try
                {
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

                    firstPoint = ct.SymmetricalPointByLine(oldPoint, newPoint, firstPoint, clLine);
                    lastPoint = ct.SymmetricalPointByLine(oldPoint, newPoint, lastPoint, clLine);
                    dt.DDALineGrid(firstPoint.X, lastPoint.X, firstPoint.Y, lastPoint.Y, p);

                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    pbDrawZone.Image = bm;
                }
            }

            pbDrawZone.Image = bm;
        }

        private void tinhTienDT()
        {
            Pen p = new Pen(clLine, widthLine);

            
            try
            {
                xoaHinh();
               
                //đổi điểm về tọa độ người dùng để tìm tỉ lệ
                firstPoint = dt.changeToFakePoint(firstPoint);
                lastPoint = dt.changeToFakePoint(lastPoint);
                firstPoint = ct.TinhTien(firstPoint, int.Parse(tbTinhTienX.Text) , int.Parse(tbTinhTienY.Text) , p.Color);
                lastPoint = ct.TinhTien(lastPoint, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color); ;

                //đổi điểm về tọa độ máy để vẽ
                firstPoint = dt.changeToRealPoint(firstPoint);
                lastPoint = dt.changeToRealPoint(lastPoint);
                dt.DDALineGrid(firstPoint.X, lastPoint.X, firstPoint.Y, lastPoint.Y, p);
            }
            catch (FormatException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }
        private void tiLeDT()
        {
            Pen p = new Pen(clLine, widthLine);

            try
            {
                xoaHinh();
                
                //đổi điểm lastPoint về tọa độ người dùng để tìm tỉ lệ
                lastPoint = dt.changeToFakePoint(lastPoint);
                lastPoint = ct.TiLe(lastPoint, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                
                //đổi điểm lastPoint về tọa độ máy để vẽ
                lastPoint = dt.changeToRealPoint(lastPoint);
                dt.DDALineGrid(firstPoint.X, lastPoint.X, firstPoint.Y, lastPoint.Y, p);

            }
            catch (FormatException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }

        }

        //xoay và lấy đối xứng hình thoi
        private void RotateHinhThoi(Point aroundPoint)
        {
            if (bMouseUp)
            {
                if (!String.IsNullOrEmpty(tbRotate.Text))
                {
                    oldPoint = ct.RotateAroundPoint(aroundPoint, firstPoint, int.Parse(tbRotate.Text), clLine);
                    newPoint = ct.RotateAroundPoint(aroundPoint, lastPoint, int.Parse(tbRotate.Text), clLine);
                    Point A, B, C, D;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    D = new Point();
                    // tìm 4 điểm của hình thoi theo tâm mới
                    dt.tim4DiemHinhThoi(aroundPoint, ref A, ref B, ref C, ref D, int.Parse(txtCheoA.Text), int.Parse(txtCheoB.Text));
                    // xoay 4 điểm 1 góc angle 
                    A = ct.RotateAroundPoint(aroundPoint, A, int.Parse(tbRotate.Text), clLine);
                    B = ct.RotateAroundPoint(aroundPoint, B, int.Parse(tbRotate.Text), clLine);
                    C = ct.RotateAroundPoint(aroundPoint, C, int.Parse(tbRotate.Text), clLine);
                    D = ct.RotateAroundPoint(aroundPoint, D, int.Parse(tbRotate.Text), clLine);
                    //vẽ hình
                    dt.VeHinhTuGiac(new Pen(clLine, widthLine), A, B, C, D);
                    pbDrawZone.Image = bm;
                }
            }
        }
        private void SymmetryHinhThoi(MouseEventArgs e)
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
                try
                {
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

                    Point A, B, C, D;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    D = new Point();
                    // tìm 4 điểm của hình thoi theo tâm cũ
                    dt.tim4DiemHinhThoi(lastPoint, ref A, ref B, ref C, ref D, int.Parse(txtCheoA.Text), int.Parse(txtCheoB.Text));
                    
                    // lấy đối xứng 4 điểm của hình thoi qua đt
                    A = ct.SymmetricalPointByLine(oldPoint, newPoint, A, clLine);
                    B = ct.SymmetricalPointByLine(oldPoint, newPoint, B, clLine);
                    C = ct.SymmetricalPointByLine(oldPoint, newPoint, C, clLine);
                    D = ct.SymmetricalPointByLine(oldPoint, newPoint, D, clLine);
 
                    //vẽ hình thoi
                    dt.VeHinhTuGiac(p, A, B, C, D);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    pbDrawZone.Image = bm;
                }
            }

        }
        private void tinhTienHinhThoi()
        {
            Pen p = new Pen(clLine, widthLine);


            try
            {
                xoaHinh();

                Point A, B, C, D;
                A = new Point();
                B = new Point();
                C = new Point();
                D = new Point();
                dt.tim4DiemHinhThoi(lastPoint, ref A, ref B, ref C, ref D, int.Parse(txtCheoA.Text), int.Parse(txtCheoB.Text));
                
                //đổi các điểm về tọa độ ng dùng
                lastPoint = dt.changeToFakePoint(lastPoint);
                A = dt.changeToFakePoint(A);
                B = dt.changeToFakePoint(B);
                C = dt.changeToFakePoint(C);
                D = dt.changeToFakePoint(D);
                //tịnh tiến các điểm
                lastPoint = ct.TinhTien(lastPoint, int.Parse(tbTinhTienX.Text) , int.Parse(tbTinhTienY.Text) , p.Color); 
                A = ct.TinhTien(A, int.Parse(tbTinhTienX.Text) , int.Parse(tbTinhTienY.Text), p.Color);
                B = ct.TinhTien(B, int.Parse(tbTinhTienX.Text) , int.Parse(tbTinhTienY.Text) , p.Color);
                C = ct.TinhTien(C, int.Parse(tbTinhTienX.Text) , int.Parse(tbTinhTienY.Text), p.Color);
                D = ct.TinhTien(D, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi các điểm về tọa độ MÁY
                lastPoint = dt.changeToRealPoint(lastPoint);
                A = dt.changeToRealPoint(A);
                B = dt.changeToRealPoint(B);
                C = dt.changeToRealPoint(C);
                D = dt.changeToRealPoint(D);
                dt.VeHinhTuGiac(p, A, B, C, D);
                
            }
            catch (FormatException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }
        private void tiLeHinhThoi()
        {
            Pen p = new Pen(clLine, widthLine);

            try
            {
                xoaHinh();
                Point A, B, C, D;
                double tileX, tileY,cheoA, cheoB;
                tileX = double.Parse(tbTiLeX.Text);
                tileY= double.Parse(tbTiLeY.Text);
                cheoA = int.Parse(txtCheoA.Text);
                cheoB = int.Parse(txtCheoB.Text);
                //tăng tỉ lệ 2 đường chéo theo tỉ lệ
                cheoA = cheoA * tileX;
                cheoB = cheoB * tileY;

                //tìm 4 điểm
                A = new Point();
                B = new Point();
                C = new Point();
                D = new Point();
                dt.tim4DiemHinhThoi(lastPoint, ref A, ref B, ref C, ref D, (int)cheoA, (int)cheoB);
                //vẽ hình
                dt.VeHinhTuGiac(p, A, B, C, D);

                txtCheoA.Text = ((int)cheoA).ToString();
                txtCheoB.Text = ((int)cheoB).ToString();

            }
            catch (FormatException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }
        

        //Các phép biến đổi của HCN
        private void RotateHCN(Point aroundPoint)
        {
            if (bMouseUp)
            {
                if (!String.IsNullOrEmpty(tbRotate.Text))
                {
                    Point A, B, C, D;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    D = new Point();
                    // tìm 4 điểm của hình thoi theo tâm mới
                    dt.tim4DiemHinhChuNhat(aroundPoint, ref A, ref B, ref C, ref D, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
                    // xoay 4 điểm 1 góc angle 
                    A = ct.RotateAroundPoint(aroundPoint, A, int.Parse(tbRotate.Text), clLine);
                    B = ct.RotateAroundPoint(aroundPoint, B, int.Parse(tbRotate.Text), clLine);
                    C = ct.RotateAroundPoint(aroundPoint, C, int.Parse(tbRotate.Text), clLine);
                    D = ct.RotateAroundPoint(aroundPoint, D, int.Parse(tbRotate.Text), clLine);
                    //vẽ hình
                    dt.VeHinhTuGiac(new Pen(clLine, widthLine), A, B, C, D);
                    pbDrawZone.Image = bm;
                }
            }
        }
        private void SymmetryHCN(MouseEventArgs e)
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
                try
                {
                    dt.DrawLineByMidPoint(oldPoint, newPoint, p, true);

                    Point A, B, C, D;
                    A = new Point();
                    B = new Point();
                    C = new Point();
                    D = new Point();
                    // tìm 4 điểm của hình  theo tâm cũ
                    dt.tim4DiemHinhChuNhat(lastPoint, ref A, ref B, ref C, ref D, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
                    
                    // lấy đối xứng 4 điểm của hình 
                    A = ct.SymmetricalPointByLine(oldPoint, newPoint, A, clLine);
                    B = ct.SymmetricalPointByLine(oldPoint, newPoint, B, clLine);
                    C = ct.SymmetricalPointByLine(oldPoint, newPoint, C, clLine);
                    D = ct.SymmetricalPointByLine(oldPoint, newPoint, D, clLine);

                    //vẽ hình thoi
                    dt.VeHinhTuGiac(p, A, B, C, D);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    pbDrawZone.Image = bm;
                }
            }

            pbDrawZone.Image = bm;
        }
        private void tinhTienHCN()
        {
            Pen p = new Pen(clLine, widthLine);


            try
            {
                xoaHinh();

                //tìm 4 điểm để tịnh tiến
                Point A, B, C, D;
                A = new Point();
                B = new Point();
                C = new Point();
                D = new Point();
                dt.tim4DiemHinhChuNhat(lastPoint, ref A, ref B, ref C, ref D, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));

                //đổi các điểm về tọa độ ng dùng
                lastPoint = dt.changeToFakePoint(lastPoint);
                A = dt.changeToFakePoint(A);
                B = dt.changeToFakePoint(B);
                C = dt.changeToFakePoint(C);
                D = dt.changeToFakePoint(D);
                //tịnh tiến các điểm
                lastPoint = ct.TinhTien(lastPoint, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                A = ct.TinhTien(A, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                B = ct.TinhTien(B, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                C = ct.TinhTien(C, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                D = ct.TinhTien(D, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi các điểm về tọa độ MÁY
                lastPoint = dt.changeToRealPoint(lastPoint);
                A = dt.changeToRealPoint(A);
                B = dt.changeToRealPoint(B);
                C = dt.changeToRealPoint(C);
                D = dt.changeToRealPoint(D);
                dt.VeHinhTuGiac(p, A, B, C, D);

            }
            catch (FormatException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }
        private void tiLeHCN()
        {
            Pen p = new Pen(clLine, widthLine);

            try
            {
                xoaHinh();
                Point A, B, C, D;
                double tileX, tileY, cheoA, cheoB;
                tileX = double.Parse(tbTiLeX.Text);
                tileY = double.Parse(tbTiLeY.Text);
                cheoA = int.Parse(tbWidth.Text);
                cheoB = int.Parse(tbHeight.Text);
                //tăng tỉ lệ 2 đường chéo theo tỉ lệ
                cheoA = cheoA * tileX;
                cheoB = cheoB * tileY;
                //tìm 4 điểm
                A = new Point();
                B = new Point();
                C = new Point();
                D = new Point();

                dt.tim4DiemHinhChuNhat(lastPoint, ref A, ref B, ref C, ref D, (int)cheoA, (int)cheoB);
                dt.VeHinhTuGiac(p, A, B, C, D);

                tbWidth.Text = ((int)cheoA).ToString();
                tbHeight.Text = ((int)cheoB).ToString();

            }
            catch (FormatException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }


        //Các phép biến đổi của Tam Giác
        private void RotateTamGiac(Point aroundPoint)
        {
            if (bMouseUp)
            {
                if (!String.IsNullOrEmpty(tbRotate.Text))
                {
                    Point A, B, C;
                    A = new Point();
                    B = new Point();
                    C = new Point();

                    // tìm 4 điểm của hình thoi theo tâm mới
                    dt.tim3DiemTamGiac(aroundPoint, ref A, ref B, ref C, int.Parse(tbChieuCao.Text), int.Parse(tbRongDay.Text));
                    // xoay 4 điểm 1 góc angle 
                    A = ct.RotateAroundPoint(aroundPoint, A, int.Parse(tbRotate.Text), clLine);
                    B = ct.RotateAroundPoint(aroundPoint, B, int.Parse(tbRotate.Text), clLine);
                    C = ct.RotateAroundPoint(aroundPoint, C, int.Parse(tbRotate.Text), clLine);
                    //vẽ hình
                   dt.veHinhTamGiac(A,B,C, new Pen(clLine, widthLine));
                    pbDrawZone.Image = bm;
                }
            }
        }
        private void SymmetryTamGiac(MouseEventArgs e)
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
                try
                {
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

                    Point A, B, C;
                    A = new Point();
                    B = new Point();
                    C = new Point();
       
                    // tìm 3 điểm của hình
                    dt.tim3DiemTamGiac(lastPoint, ref A, ref B, ref C, int.Parse(tbChieuCao.Text), int.Parse(tbRongDay.Text));

                    // lấy đối xứng 3 điểm của hình
                    A = ct.SymmetricalPointByLine(oldPoint, newPoint, A, clLine);
                    B = ct.SymmetricalPointByLine(oldPoint, newPoint, B, clLine);
                    C = ct.SymmetricalPointByLine(oldPoint, newPoint, C, clLine);

                    //vẽ hình
                    dt.veHinhTamGiac(A,B,C, p);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    pbDrawZone.Image = bm;
                }
            }

            pbDrawZone.Image = bm;
        }

        private void tinhTienTamGiac()
        {
            Pen p = new Pen(clLine, widthLine);


            try
            {
                xoaHinh();
                Point A, B, C;
                A = new Point();
                B = new Point();
                C = new Point();
                dt.tim3DiemTamGiac(lastPoint, ref A, ref B, ref C, int.Parse(tbChieuCao.Text), int.Parse(tbRongDay.Text));

                //đổi các điểm về tọa độ ng dùng để tính toán
                lastPoint = dt.changeToFakePoint(lastPoint);
                A = dt.changeToFakePoint(A);
                B = dt.changeToFakePoint(B);
                C = dt.changeToFakePoint(C);
                //tịnh tiến các điểm
                lastPoint = ct.TinhTien(lastPoint, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                A = ct.TinhTien(A, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                B = ct.TinhTien(B, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                C = ct.TinhTien(C, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi các điểm về tọa độ MÁY
                lastPoint = dt.changeToRealPoint(lastPoint);
                A = dt.changeToRealPoint(A);
                B = dt.changeToRealPoint(B);
                C = dt.changeToRealPoint(C);
                dt.veHinhTamGiac(A, B, C, p);

            }
            catch (FormatException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTinhTienX.Text = String.Empty;
                tbTinhTienY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        }
        private void tiLeTamGiac()
        {
            Pen p = new Pen(clLine, widthLine);

            try
            {
                xoaHinh();
                Point A, B, C ;
                float tileX, tileY, day, chieuCao;
                tileX = float.Parse(tbTiLeX.Text);
                tileY = float.Parse(tbTiLeY.Text);
                day = int.Parse(tbRongDay.Text);
                chieuCao = int.Parse(tbChieuCao.Text);

               
                A = new Point();
                B = new Point();
                C = new Point();
                //tăng tỉ lệ 2 đường chéo theo tỉ lệ
                day = day * tileX;
                chieuCao = chieuCao * tileY;
                dt.tim3DiemTamGiac(lastPoint, ref A, ref B, ref C, (int)chieuCao,(int)day );
                dt.veHinhTamGiac(A, B, C, p);

                tbRongDay.Text = ((int)day).ToString();
                tbChieuCao.Text = ((int)chieuCao).ToString();

            }
            catch (FormatException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                tbTiLeX.Text = String.Empty;
                tbTiLeY.Text = String.Empty;
            }
            finally
            {
                pbDrawZone.Image = bm;
            }
        } 


        //lấy đối xứng hình tròn
        private void SymmetryCircle(MouseEventArgs e)
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
                try
                {
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

                    lastPoint = ct.SymmetricalPointByLine(oldPoint, newPoint, lastPoint, clLine);

                    dt.DrawCircle(lastPoint, int.Parse(tbRadius.Text), p);

                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    pbDrawZone.Image = bm;
                }
            }

            pbDrawZone.Image = bm;
        }

        //sự kiện tịnh tiến và tỉ lệ
        private void btTinhTien_Click(object sender, EventArgs e)
        {
            if (lbTinhTienX.Visible == false)
            {
                lbTinhTienX.Visible = true;
                lbTinhTienY.Visible = true;
                tbTinhTienX.Visible = true;
                tbTinhTienY.Visible = true;
            }
            else
            {
                if (line == "line")
                {
                    tinhTienDT();
                }
                else if (line == "hinhThoi")
                {
                    tinhTienHinhThoi();
                }
                else if (line == "HCN")
                {
                    tinhTienHCN();
                }
                else if (line == "tamGiac")
                {
                    tinhTienTamGiac();
                }
            }
        }

        private void btTiLe_Click(object sender, EventArgs e)
        {
            if (lbTiLeX.Visible == false)
            {
                lbTiLeX.Visible = true;
                lbTiLeY.Visible = true;
                tbTiLeX.Visible = true;
                tbTiLeY.Visible = true;
            }
            else
            {
                if (line == "line")
                {
                    tiLeDT();
                }
                else if (line == "hinhThoi")
                {
                    tiLeHinhThoi();
                }
                else if (line == "HCN")
                {
                    tiLeHCN();
                }
                else if (line == "tamGiac")
                {
                    tiLeTamGiac();
                }
            }
        }

        // kiện xóa hình
        private void BtXoa_Click(object sender, EventArgs e)
        {
            xoaHinh();
            
        }
        //hàm xóa hình trước đó
        private void xoaHinh()
        {
            if (line == "line")
            {
                dt.DDALineGrid(firstPoint.X, lastPoint.X, firstPoint.Y, lastPoint.Y, new Pen(Color.FromArgb(240, 240, 240), widthLine));
            }
            else if (line == "hinhThoi")
            {
                //tìm điểm và xoa hình thoi cũ
                Point A, B, C, D;
                A = new Point();
                B = new Point();
                C = new Point();
                D = new Point();
                dt.tim4DiemHinhThoi(lastPoint, ref A, ref B, ref C, ref D, int.Parse(txtCheoA.Text), int.Parse(txtCheoB.Text));
                dt.VeHinhTuGiac(new Pen(Color.FromArgb(240, 240, 240), widthLine), A, B, C, D);
            }
            else if (line == "HCN")
            {
                //tìm điểm và xoa hình chữ nhật
                Point A, B, C, D;
                A = new Point();
                B = new Point();
                C = new Point();
                D = new Point();
                dt.tim4DiemHinhChuNhat(lastPoint, ref A, ref B, ref C, ref D, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
                dt.VeHinhTuGiac(new Pen(Color.FromArgb(240, 240, 240), widthLine), A, B, C, D);
            }
            else if (line == "tamGiac")
            {
                //tìm điểm và xoa hình cũ
                Point A, B, C;
                A = new Point();
                B = new Point();
                C = new Point();
                dt.tim3DiemTamGiac(lastPoint, ref A, ref B, ref C, int.Parse(tbChieuCao.Text), int.Parse(tbRongDay.Text));
                dt.veHinhTamGiac(A, B, C, new Pen(Color.FromArgb(240, 240, 240), widthLine));
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
                    if (transalte == "symmetry")
                    {
                        SymmetryCircle(e);
                        return;
                    }
                    drawCircle(e);
                }
                //Trường-bổ sung my Draw
                else if (line == "line")
                {
                    if (transalte == "rotate")
                    {
                        RotateLine(e.Location);
                        return;
                    }
                    else if (transalte == "symmetry")
                    {
                        SymmetryLine(e);
                        return;
                    }
                    drawLine(e);
                }
                else if (line == "hinhThoi")
                {
                    if (transalte == "rotate")
                    {
                        RotateHinhThoi(e.Location);
                        return;
                    }
                    else if (transalte == "symmetry")
                    {
                        SymmetryHinhThoi(e);
                        return;
                    }
                    veHinhThoi(e);
                }
                else if (line == "HCN")
                {
                    if (transalte == "rotate")
                    {
                        RotateHCN(e.Location);
                        return;
                    }
                    else if (transalte == "symmetry")
                    {
                        SymmetryHCN(e);
                        return;
                    }
                    veHinhChuNhat(e);
                }
                else if (line == "tamGiac")
                {
                    if (transalte == "rotate")
                    {
                        RotateTamGiac(e.Location);
                        return;
                    }
                    else if (transalte == "symmetry")
                    {
                        SymmetryTamGiac(e);
                        return;
                    }
                    veTamGiac(e);
                }
            }
        }
        
        
    }
}
