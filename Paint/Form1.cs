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
        public static int hinh = -1; // stt của hình đang vẽ để xóa nhanh hơn
        private Htron htron;
        private Hvuong hvuong;
        private Helip helip;
        private int x0, y0; // khai báo tọa độ điểm O trên lưới pixel

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
        private Point Ap, Bp, Cp, Dp;
        private int countDrawConLac = 0;

        public Form1()
        {
            InitializeComponent();
            start();
            dtNam.ResetBitmap();
        }

        private void TurnOffModeDraw(Button btCheck)
        {
            if (btCheck.BackColor == SystemColors.ControlDark) btCheck.BackColor = SystemColors.Control;
            if (transalte != String.Empty)
            {
                btRotate.BackColor= SystemColors.Control;
                btSymmetry.BackColor = SystemColors.Control;
            }
            transalte = String.Empty;
            /*if (btCheck == btRotate)
            {
                transalte = null;
            }*/
            if (btCheck == btConLacCD)
            {
                cbIsStop.Visible = false;
                cbIsStop.Checked = true;
                countDrawConLac = 0;
            }
            else if (btCheck == btTamGiac)
            {
                lbChieuCao.Visible = false;
                lbRongDay.Visible = false;
                tbChieuCao.Visible = false;
                tbRongDay.Visible = false;
            }
            else if (btCheck == btHinhThoi)
            {
                lbCheoA.Visible = false;
                lbCheoB.Visible = false;
                txtCheoA.Visible = false;
                txtCheoB.Visible = false;
            }
            else if (btCheck == btHCN)
            {
                lbWidth.Visible = false;
                lbHeight.Visible = false;
                tbWidth.Visible = false;
                tbHeight.Visible = false;
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
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btFillColor);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btRotate);

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
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btFillColor);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btRotate);

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

            //lấy thông tin tọa độ điểm O
            x0 = dt.x0;
            y0 = dt.y0;

            dtChon = new DrawTool(bmChon, label2);
            ct = new ChangeTool(label2);

            dtNam = new DrawTool(pbDrawZone, label2);

            gp = Graphics.FromImage(bm);
        }

        //Vẽ đường tròn
        /*private void drawCircle(MouseEventArgs e)
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
                //tbRadius.Text = String.Empty;
            }
            catch (ArgumentOutOfRangeException)
            {
                //tbRadius.Text = String.Empty;
            }
            finally
            {
                //pbDrawZone.Refresh();
                pbDrawZone.Image = dtNam.bm;
            }
        }*/

        //Vẽ pixel
        private void drawPixel(MouseEventArgs e)
        {
            newPoint = e.Location;

            Pen pen = new Pen(clLine, widthLine);

            if (oldPoint != Point.Empty)
            {
                //gp.FillRectangle(pen.Brush, oldPoint.X - widthLine / 2, oldPoint.Y - widthLine / 2, widthLine, widthLine);
                //gp.DrawLine(pen, oldPoint, newPoint);
                dtNam.DrawLineByMidPoint(oldPoint, newPoint, pen, true);
            }

            oldPoint = newPoint;
            pbDrawZone.Image = dtNam.bm;
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

                pbDrawZone.Image = dtNam.bm;
                //pbDrawZone.Refresh();
                //try
                //{

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
                dtNam.FillColor(fillPoint, Color.Red);

                pbDrawZone.Image = dtNam.bm;
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
                
                TurnOffModeDraw(btSymmetry);
                btRotate.BackColor = SystemColors.ControlDark;
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
                
                TurnOffModeDraw(btRotate);
                btSymmetry.BackColor = SystemColors.ControlDark;
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


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bt3D_Click(object sender, EventArgs e)
        {
            Draw3D draw3D = new Draw3D();
            draw3D.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Xechayquadoi xechayquaydoi = new Xechayquadoi();
            xechayquaydoi.ShowDialog();
        }
        
        private void btFillColor_Click(object sender, EventArgs e)
        {
            if (btFillColor.BackColor == SystemColors.Control)
            {
                if (btDrawPixel.BackColor == SystemColors.ControlDark) btDrawPixel.BackColor = SystemColors.Control;
                if (btDrawArrow.BackColor == SystemColors.ControlDark) btDrawArrow.BackColor = SystemColors.Control;
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btRotate);

                btFillColor.BackColor = SystemColors.ControlDark;

                line = "color";
            }
            else if (btFillColor.BackColor == SystemColors.ControlDark)
            {
                btFillColor.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }
    
        /*private void xoaHinh()
        {
            Color bgColor = Color.FromArgb(240, 240, 240);
            if (Form1.hinh == 5)// hình tròn
            {
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), bgColor);
            }else if (Form1.hinh == 6)// hinh vuong
            {
                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, bgColor);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, bgColor);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, bgColor);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, bgColor);
            }else if (Form1.hinh == 7) // hinh elip
            {
                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, bgColor);
            }
        }*/
        //vẽ hình tròn trên lưới pixel
        private void btn_drawCircle_Click(object sender, EventArgs e)
        {
            xoaHinh();
            inputHtron input = new inputHtron(x0, y0);
            input.ShowDialog();
            if (input.checkchange == false) return;
            htron = new Htron(input.xc, input.yc, input.R);
            dt.circleMidPoint(input.xc, input.yc, input.R,Color.Black);
            Form1.hinh = 5;
            pbDrawZone.Image = bm;
        }

        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            inputTinhTien ip = new inputTinhTien();
            ip.ShowDialog();
            
            if (ip.checkchange == false) return;

            if (Form1.hinh == 5)// hình tròn
            {
                xoaHinh();
                htron.setx(htron.getx() + ip.x);
                htron.sety(htron.gety() + ip.y);
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }else if (Form1.hinh == 6)//hình vuông
            {
                xoaHinh();
              
                hvuong.xA = hvuong.xA + ip.x;
                hvuong.yA = hvuong.yA + ip.y;
                hvuong.xB = hvuong.xB + ip.x;
                hvuong.yB = hvuong.yB + ip.y;
                hvuong.xC = hvuong.xC + ip.x;
                hvuong.yC = hvuong.yC + ip.y;
                hvuong.xD = hvuong.xD + ip.x;
                hvuong.yD = hvuong.yD + ip.y;

                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);
                Form1.hinh = 6;
            }else if (Form1.hinh == 7)// hình elip
            {
                xoaHinh();

                helip.xc = helip.xc + ip.x;
                helip.yc = helip.yc + ip.y;
                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }

            pbDrawZone.Image = bm;
        }

        private void btn_TiLe_Click(object sender, EventArgs e)
        {
            inputTiLe input = new inputTiLe();
            input.ShowDialog();
            /*label2.Text = input.Sx + " vs " + input.Sy;*/
            if (input.checkchange == false) return;
            
            if (Form1.hinh == 5)//hình tròn
            {
                xoaHinh();
                if (input.Sx == input.Sy)//ti le x va y bang nhau 
                {
                    htron.setR((int)(htron.getR() * input.Sx));
                    dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                    Form1.hinh = 5;
                }
                else
                {
                    Helip helip2 = new Helip(htron.getx(), htron.gety(), Convert.ToInt32(htron.getR() * input.Sx), Convert.ToInt32(htron.getR() * input.Sy));
                    helip = helip2;
                    dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                    Form1.hinh = 7; // hinh tron thanh hinh elip
                }
                
                
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoaHinh();
                int XO, YO, Dx, Dy;

                Point A = new Point(hvuong.xA, hvuong.yA);
                A = dt.findFakePoint(A);
                Point B = new Point(hvuong.xB, hvuong.yB);
                B = dt.findFakePoint(B);
                Point C = new Point(hvuong.xC, hvuong.yC);
                C = dt.findFakePoint(C);
                Point D = new Point(hvuong.xD, hvuong.yD);
                D = dt.findFakePoint(D);

                //lấy điểm gốc là A
                XO = A.X;
                YO = A.Y;
                //tỉ lể các điểm trên hình vuông
                A.X = Convert.ToInt32(A.X * input.Sx);
                A.Y = Convert.ToInt32(A.Y * input.Sy);
                B.X = Convert.ToInt32(B.X * input.Sx);
                B.Y = Convert.ToInt32(B.Y * input.Sy);
                C.X = Convert.ToInt32(C.X * input.Sx);
                C.Y = Convert.ToInt32(C.Y * input.Sy);
                D.X = Convert.ToInt32(D.X * input.Sx);
                D.Y = Convert.ToInt32(D.Y * input.Sy);

                Dx = A.X - XO;
                Dy = A.Y - YO;

                A.X = A.X - Dx;
                A.Y = A.Y - Dy;
                B.X = B.X - Dx;
                B.Y = B.Y - Dy;
                C.X = C.X - Dx;
                C.Y = C.Y - Dy;
                D.X = D.X - Dx;
                D.Y = D.Y - Dy;

                A = dt.findRealPoint(A);
                B = dt.findRealPoint(B);
                C = dt.findRealPoint(C);
                D = dt.findRealPoint(D);

                hvuong.xA = A.X;
                hvuong.yA = A.Y;
                hvuong.xB = B.X;
                hvuong.yB = B.Y;
                hvuong.xC = C.X;
                hvuong.yC = C.Y;
                hvuong.xD = D.X;
                hvuong.yD = D.Y;

                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);

                Form1.hinh = 6;
            }else if (Form1.hinh == 7)//hình elip
            {
                xoaHinh();
                helip.a = Convert.ToInt32(helip.a * input.Sx);
                helip.b = Convert.ToInt32(helip.b * input.Sy);

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            pbDrawZone.Image = bm;
        }

        private void btn_DoiXungOx_Click(object sender, EventArgs e)
        {
            if (Form1.hinh == 5)//hinh tron
            {
                xoaHinh();
                
                int y = ((y0 - htron.gety()) / 5) * (-1);

                htron.sety(y0 - (y * 5));
                
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoaHinh();
                Point A = new Point(hvuong.xA, hvuong.yA);
                Point B = new Point(hvuong.xB, hvuong.yB);
                Point C = new Point(hvuong.xC, hvuong.yC);
                Point D = new Point(hvuong.xD, hvuong.yD);

                A = dt.doiXungQuaOX(dt.findFakePoint(A));
                B = dt.doiXungQuaOX(dt.findFakePoint(B));
                C = dt.doiXungQuaOX(dt.findFakePoint(C));
                D = dt.doiXungQuaOX(dt.findFakePoint(D));

                A = dt.findRealPoint(A);
                B = dt.findRealPoint(B);
                C = dt.findRealPoint(C);
                D = dt.findRealPoint(D);

                hvuong.xA = A.X;
                hvuong.yA = A.Y;
                hvuong.xB = B.X;
                hvuong.yB = B.Y;
                hvuong.xC = C.X;
                hvuong.yC = C.Y;
                hvuong.xD = D.X;
                hvuong.yD = D.Y;

                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);

                Form1.hinh = 6;
            }
            else if (Form1.hinh == 7)//hinh elip
            {
                xoaHinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.doiXungQuaOX(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            //trường bổ sung
            if (line == "line")
            {
                xoaHinh();
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);

                Ap = ct.DoiXungOx(Ap);
                Bp = ct.DoiXungOx(Bp);

                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);

                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, new Pen(clLine, widthLine), true);

            }
            else if (line == "hinhThoi" || line == "HCN")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);


                //lấy tỉ lệ các điểm của hình
                Ap = ct.DoiXungOx(Ap);
                Bp = ct.DoiXungOx(Bp);
                Cp = ct.DoiXungOx(Cp);
                Dp = ct.DoiXungOx(Dp);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);

                dt.VeHinhTuGiac(new Pen(clLine, widthLine), Ap, Bp, Cp, Dp);
            }
            else if (line == "tamGiac")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);

                // lấy đối xứng 3 điểm của hình
                Ap = ct.DoiXungOx(Ap);
                Bp = ct.DoiXungOx(Bp);
                Cp = ct.DoiXungOx(Cp);
                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);

                //vẽ hình
                dt.veHinhTamGiac(Ap, Bp, Cp, new Pen(clLine, widthLine));
            }
            pbDrawZone.Image = bm;
        }

        private void btn_DoiXungOy_Click(object sender, EventArgs e)
        {
            if (Form1.hinh == 5)//hinh tron
            {
                xoaHinh();
                int x = ((htron.getx() - x0) / 5) * (-1);
                
                htron.setx(x0 + (x * 5));
                
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoaHinh();
                Point A = new Point(hvuong.xA, hvuong.yA);
                Point B = new Point(hvuong.xB, hvuong.yB);
                Point C = new Point(hvuong.xC, hvuong.yC);
                Point D = new Point(hvuong.xD, hvuong.yD);

                A = dt.doiXungQuaOY(dt.findFakePoint(A));
                B = dt.doiXungQuaOY(dt.findFakePoint(B));
                C = dt.doiXungQuaOY(dt.findFakePoint(C));
                D = dt.doiXungQuaOY(dt.findFakePoint(D));

                A = dt.findRealPoint(A);
                B = dt.findRealPoint(B);
                C = dt.findRealPoint(C);
                D = dt.findRealPoint(D);

                hvuong.xA = A.X;
                hvuong.yA = A.Y;
                hvuong.xB = B.X;
                hvuong.yB = B.Y;
                hvuong.xC = C.X;
                hvuong.yC = C.Y;
                hvuong.xD = D.X;
                hvuong.yD = D.Y;

                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);

                Form1.hinh = 6;
            }
            else if (Form1.hinh == 7)//hinh elip
            {
                xoaHinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.doiXungQuaOY(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            //trường bổ sung
            if(line=="line")
            {
                xoaHinh();
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);

                Ap = ct.DoiXungOy(Ap);
                Bp = ct.DoiXungOy(Bp);

                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);

                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, new Pen(clLine, widthLine), true);

            }
            else if(line == "hinhThoi" || line == "HCN")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);


                //lấy tỉ lệ các điểm của hình
                Ap = ct.DoiXungOy(Ap);
                Bp = ct.DoiXungOy(Bp);
                Cp = ct.DoiXungOy(Cp);
                Dp = ct.DoiXungOy(Dp);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);

                dt.VeHinhTuGiac(new Pen(clLine, widthLine), Ap, Bp, Cp, Dp);
            }
            else if(line == "tamGiac")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);

                // lấy đối xứng 3 điểm của hình
                Ap = ct.DoiXungOy(Ap);
                Bp = ct.DoiXungOy(Bp);
                Cp = ct.DoiXungOy(Cp);
                 //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);

                //vẽ hình
                dt.veHinhTamGiac(Ap, Bp, Cp, new Pen(clLine, widthLine));
            }
           
            pbDrawZone.Image = bm;
        }

        
        private void btn_Quay_Click(object sender, EventArgs e)
        {
            if (Form1.hinh == 5)//hinh tron
            {
                xoaHinh();
                int x = ((htron.getx() - x0) / 5) ;
                int y = ((y0 - htron.gety()) / 5) ;

                Point a = new Point(x, y);
                a = dt.layDiemQuay(a);

                htron.setx(x0 + (a.X * 5));
                htron.sety(y0 - (a.Y * 5));

                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoaHinh();
                Point A = new Point(hvuong.xA, hvuong.yA);
                Point B = new Point(hvuong.xB, hvuong.yB);
                Point C = new Point(hvuong.xC, hvuong.yC);
                Point D = new Point(hvuong.xD, hvuong.yD);

                A = dt.layDiemQuay(dt.findFakePoint(A));
                B = dt.layDiemQuay(dt.findFakePoint(B));
                C = dt.layDiemQuay(dt.findFakePoint(C));
                D = dt.layDiemQuay(dt.findFakePoint(D));
                
                A = dt.findRealPoint(A);
                B = dt.findRealPoint(B);
                C = dt.findRealPoint(C);
                D = dt.findRealPoint(D);

                hvuong.xA = A.X;
                hvuong.yA = A.Y;
                hvuong.xB = B.X;
                hvuong.yB = B.Y;
                hvuong.xC = C.X;
                hvuong.yC = C.Y;
                hvuong.xD = D.X;
                hvuong.yD = D.Y;

                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);

                Form1.hinh = 6;
            }
            else if (Form1.hinh == 7)//hinh elip
            {
                xoaHinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.layDiemQuay(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            //trường bổ xung

            if (line == "line")
            {
                xoaHinh();
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);

                Ap = ct.XoayQuanhTamO(Ap,60);
                Bp = ct.XoayQuanhTamO(Bp, 60);

                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);

                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, new Pen(clLine, widthLine), true);

            }
            else if (line == "hinhThoi" || line == "HCN")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);


                //lấy tỉ lệ các điểm của hình
                Ap = ct.XoayQuanhTamO(Ap, 60);
                Bp = ct.XoayQuanhTamO(Bp, 60);
                Cp = ct.XoayQuanhTamO(Cp, 60);
                Dp = ct.XoayQuanhTamO(Dp, 60);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);

                dt.VeHinhTuGiac(new Pen(clLine, widthLine), Ap, Bp, Cp, Dp);
            }
            else if (line == "tamGiac")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);

                // lấy đối xứng 3 điểm của hình
                Ap = ct.XoayQuanhTamO(Ap, 60);
                Bp = ct.XoayQuanhTamO(Bp, 60);
                Cp = ct.XoayQuanhTamO(Cp, 60);
                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);

                //vẽ hình
                dt.veHinhTamGiac(Ap, Bp, Cp, new Pen(clLine, widthLine));
            }
            pbDrawZone.Image = bm;
        }


        private void btn_DrawSquare_Click(object sender, EventArgs e)
        {
            xoaHinh();
            inputHvuong input = new inputHvuong(x0, y0);
            input.ShowDialog();
            if (input.checkchange == false) return;
            /*label2.Text = "A(" + input.xA + ", " + input.yA + ") ";*/
            hvuong = new Hvuong(input.xA, input.yA, input.a);
            dt.drawLineDDA(input.xA, input.yA, input.xB, input.yB, Color.Black);
            dt.drawLineDDA(input.xB, input.yB, input.xC, input.yC, Color.Black);
            dt.drawLineDDA(input.xC, input.yC, input.xD, input.yD, Color.Black);
            dt.drawLineDDA(input.xD, input.yD, input.xA, input.yA, Color.Black);
            Form1.hinh = 6;
            pbDrawZone.Image = bm;
        }

        private void btn_drawElip_Click(object sender, EventArgs e)
        {
            xoaHinh();
            inputHelip input = new inputHelip(x0, y0);
            input.ShowDialog();
            if (input.checkchange == false) return;
            helip = new Helip(input.xc, input.yc, input.a, input.b);
            dt.drawEllipsMidPoint(input.xc, input.yc, input.a, input.b, Color.Black);

            Form1.hinh = 7;
            pbDrawZone.Image = bm;
        }

        private void btn_DoiXungQuaO_Click(object sender, EventArgs e)
        {
            if (Form1.hinh == 5)//hinh tron
            {
                xoaHinh();
                int x = ((htron.getx() - x0) / 5) * (-1);
                int y = ((y0 - htron.gety()) / 5) * (-1);
                
                htron.setx(x0 + (x * 5));
                htron.sety(y0 - (y * 5));
                
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoaHinh();
                Point A = new Point(hvuong.xA, hvuong.yA);
                Point B = new Point(hvuong.xB, hvuong.yB);
                Point C = new Point(hvuong.xC, hvuong.yC);
                Point D = new Point(hvuong.xD, hvuong.yD);

                A = dt.doiXungQuaO(dt.findFakePoint(A));
                B = dt.doiXungQuaO(dt.findFakePoint(B));
                C = dt.doiXungQuaO(dt.findFakePoint(C));
                D = dt.doiXungQuaO(dt.findFakePoint(D));

                A = dt.findRealPoint(A);
                B = dt.findRealPoint(B);
                C = dt.findRealPoint(C);
                D = dt.findRealPoint(D);

                hvuong.xA = A.X;
                hvuong.yA = A.Y;
                hvuong.xB = B.X;
                hvuong.yB = B.Y;
                hvuong.xC = C.X;
                hvuong.yC = C.Y;
                hvuong.xD = D.X;
                hvuong.yD = D.Y;

                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);

                Form1.hinh = 6;
            }else if (Form1.hinh == 7)//hinh elip
            {
                xoaHinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.doiXungQuaO(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b,Color.Black);
                Form1.hinh = 7;
            }

            //trường bổ sung
            if (line == "line")
            {
                xoaHinh();
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);

                Ap = ct.DoiXungO(Ap);
                Bp = ct.DoiXungO(Bp);

                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);

                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, new Pen(clLine, widthLine), true);

            }
            else if (line == "hinhThoi" || line == "HCN")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);


                //lấy tỉ lệ các điểm của hình
                Ap = ct.DoiXungO(Ap);
                Bp = ct.DoiXungO(Bp);
                Cp = ct.DoiXungO(Cp);
                Dp = ct.DoiXungO(Dp);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);

                dt.VeHinhTuGiac(new Pen(clLine, widthLine), Ap, Bp, Cp, Dp);
            }
            else if (line == "tamGiac")
            {
                xoaHinh();

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);

                // lấy đối xứng 3 điểm của hình
                Ap = ct.DoiXungO(Ap);
                Bp = ct.DoiXungO(Bp);
                Cp = ct.DoiXungO(Cp);
                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);

                //vẽ hình
                dt.veHinhTamGiac(Ap, Bp, Cp, new Pen(clLine, widthLine));
            }

            pbDrawZone.Image = bm;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtXoa_Click(object sender, EventArgs e)
        {
            xoaHinh();

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
                btTatTinhTien.Visible = true;
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
                Point ip = new Point(int.Parse(tbTinhTienX.Text), -int.Parse(tbTinhTienY.Text));
                if (Form1.hinh == 5)// hình tròn
                {
                    xoaHinh();
                    htron.setx(htron.getx() + ip.X);
                    htron.sety(htron.gety() + ip.Y);
                    dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                    Form1.hinh = 5;
                }
                else if (Form1.hinh == 6)//hình vuông
                {
                    xoaHinh();

                    hvuong.xA = hvuong.xA + ip.X;
                    hvuong.yA = hvuong.yA + ip.Y;
                    hvuong.xB = hvuong.xB + ip.X;
                    hvuong.yB = hvuong.yB + ip.Y;
                    hvuong.xC = hvuong.xC + ip.X;
                    hvuong.yC = hvuong.yC + ip.Y;
                    hvuong.xD = hvuong.xD + ip.X;
                    hvuong.yD = hvuong.yD + ip.Y;

                    dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                    dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                    dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                    dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);
                    Form1.hinh = 6;
                }
                else if (Form1.hinh == 7)// hình elip
                {
                    xoaHinh();
                    helip.xc = helip.xc + ip.X;
                    helip.yc = helip.yc + ip.Y;
                    dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                    Form1.hinh = 7;
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
                btTatTiLe.Visible = true;
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
                if (Form1.hinh == 5)//hình tròn
                {
                    xoaHinh();
                    if (float.Parse(tbTiLeX.Text) == float.Parse(tbTiLeY.Text))//ti le x va y bang nhau 
                    {
                        htron.setR((int)(htron.getR() * float.Parse(tbTiLeX.Text)));
                        dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                        Form1.hinh = 5;
                    }
                    else
                    {
                        Helip helip2 = new Helip(htron.getx(), htron.gety(), Convert.ToInt32(htron.getR() * float.Parse(tbTiLeX.Text)), Convert.ToInt32(htron.getR() * float.Parse(tbTiLeY.Text)));
                        helip = helip2;
                        dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                        Form1.hinh = 7; // hinh tron thanh hinh elip
                    }


                }
                else if (Form1.hinh == 6)//hình vuông
                {
                    
                    xoaHinh();
                    int XO, YO, Dx, Dy;

                    Point A = new Point(hvuong.xA, hvuong.yA);
                    A = dt.findFakePoint(A);
                    Point B = new Point(hvuong.xB, hvuong.yB);
                    B = dt.findFakePoint(B);
                    Point C = new Point(hvuong.xC, hvuong.yC);
                    C = dt.findFakePoint(C);
                    Point D = new Point(hvuong.xD, hvuong.yD);
                    D = dt.findFakePoint(D);

                    //lấy điểm gốc là A
                    XO = A.X;
                    YO = A.Y;
                    //tỉ lể các điểm trên hình vuông
                    A.X = Convert.ToInt32(A.X * float.Parse(tbTiLeX.Text));
                    A.Y = Convert.ToInt32(A.Y * float.Parse(tbTiLeY.Text));
                    B.X = Convert.ToInt32(B.X * float.Parse(tbTiLeX.Text));
                    B.Y = Convert.ToInt32(B.Y * float.Parse(tbTiLeY.Text));
                    C.X = Convert.ToInt32(C.X * float.Parse(tbTiLeX.Text));
                    C.Y = Convert.ToInt32(C.Y * float.Parse(tbTiLeY.Text));
                    D.X = Convert.ToInt32(D.X * float.Parse(tbTiLeX.Text));
                    D.Y = Convert.ToInt32(D.Y * float.Parse(tbTiLeY.Text));

                    Dx = A.X - XO;
                    Dy = A.Y - YO;

                    A.X = A.X - Dx;
                    A.Y = A.Y - Dy;
                    B.X = B.X - Dx;
                    B.Y = B.Y - Dy;
                    C.X = C.X - Dx;
                    C.Y = C.Y - Dy;
                    D.X = D.X - Dx;
                    D.Y = D.Y - Dy;

                    A = dt.findRealPoint(A);
                    B = dt.findRealPoint(B);
                    C = dt.findRealPoint(C);
                    D = dt.findRealPoint(D);

                    hvuong.xA = A.X;
                    hvuong.yA = A.Y;
                    hvuong.xB = B.X;
                    hvuong.yB = B.Y;
                    hvuong.xC = C.X;
                    hvuong.yC = C.Y;
                    hvuong.xD = D.X;
                    hvuong.yD = D.Y;

                    dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                    dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                    dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                    dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);

                    Form1.hinh = 6;
                }
                else if (Form1.hinh == 7)//hình elip
                {
                    xoaHinh();
                    helip.a = Convert.ToInt32(helip.a * float.Parse(tbTiLeX.Text));
                    helip.b = Convert.ToInt32(helip.b * float.Parse(tbTiLeY.Text));

                    dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                    Form1.hinh = 7;
                }
                pbDrawZone.Image = bm;
            }
        }

        private void btDrawLine_Click(object sender, EventArgs e)
        {
            if (btDrawLine.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btFillColor);
                TurnOffModeDraw(btTamGiac);
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
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btTamGiac);;
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btFillColor);

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
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btFillColor);

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
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btFillColor);

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
            }

            if (newPoint != Point.Empty)
            {
                if (countDrawConLac == 0)
                {
                    t.Start();
                    Thread.Sleep(50);
                    newPoint = Point.Empty;
                }
                else
                {
                    if (cbIsStop.Checked)
                    {
                        cbIsStop.Checked = false;
                        t.Start();
                        Thread.Sleep(50);
                        newPoint = Point.Empty;
                    }
                }
                countDrawConLac++;
            }
        }

        private void btConLacCD_Click(object sender, EventArgs e)
        {
            if (btConLacCD.BackColor == SystemColors.Control)
            {
                btConLacCD.BackColor = SystemColors.ControlDark;
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btFillColor);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btRotate);

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

        /*private void btFillColor_Click(object sender, EventArgs e)
        {
            if (btFillColor.BackColor == SystemColors.Control)
            {
                if (btDrawPixel.BackColor == SystemColors.ControlDark) btDrawPixel.BackColor = SystemColors.Control;
                if (btDrawArrow.BackColor == SystemColors.ControlDark) btDrawArrow.BackColor = SystemColors.Control;
                TurnOffModeDraw(btDrawCircle);
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btRotate);

                btFillColor.BackColor = SystemColors.ControlDark;

                line = "color";
            }
            else if (btFillColor.BackColor == SystemColors.ControlDark)
            {
                btFillColor.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }*/

        /*private void btDrawCircle_Click(object sender, EventArgs e)
        {
            if (btDrawCircle.BackColor == SystemColors.Control)
            {
                TurnOffModeDraw(btDrawArrow);
                TurnOffModeDraw(btDrawPixel);
                TurnOffModeDraw(btFillColor);
                TurnOffModeDraw(btConLacCD);
                TurnOffModeDraw(btDrawLine);
                TurnOffModeDraw(btHinhThoi);
                TurnOffModeDraw(btHCN);
                TurnOffModeDraw(btTamGiac);
                TurnOffModeDraw(btRotate);

                btDrawCircle.BackColor = SystemColors.ControlDark;

                line = "circle";
            }
            else if (btDrawCircle.BackColor == SystemColors.ControlDark)
            {
                btDrawCircle.BackColor = SystemColors.Control;
                line = String.Empty;
            }
        }*/

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

                    //dt.DrawCircle(lastPoint, int.Parse(tbRadius.Text), p, cbDrawColor.Checked);

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
        //BỔ SUNG
        //Các phép biến đổi của đường thẳng
        private void RotateLine(Point aroundPoint)
        {
            if (bMouseUp)
            {
                if (!String.IsNullOrEmpty(tbRotate.Text))
                {
                    xoaHinh();
                    Ap = ct.RotateAroundPoint(aroundPoint, Ap, int.Parse(tbRotate.Text), clLine);
                    Bp = ct.RotateAroundPoint(aroundPoint, Bp, int.Parse(tbRotate.Text), clLine);
                    dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, new Pen(clLine, widthLine), true);

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
                    xoaHinh();
                    dt.MidPoint(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p,true);

                    Ap = ct.SymmetricalPointByLine(oldPoint, newPoint, Ap, clLine);
                    Bp = ct.SymmetricalPointByLine(oldPoint, newPoint, Bp, clLine);
                    dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, p,true);

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
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);

                //tịnh tiến các điểm
                Ap = ct.TinhTien(Ap, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Bp = ct.TinhTien(Bp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi điểm về tọa độ máy để vẽ
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, p, true);
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
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                //biến dùng để lưu lại vị trí ban đầu của đt
                Point position = new Point(Ap.X, Ap.Y);

                Ap = ct.TiLe(Ap, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Bp = ct.TiLe(Bp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);

                //tính khoảng cách giữa vị trí ban đầu và vị trí sau tỉ lệ, để tịnh tiến
                position = new Point(position.X - Ap.X, position.Y - Ap.Y);
                //tịnh tiến đt về vị trí ban đầu
                Ap = ct.TinhTien(Ap, position.X, position.Y, p.Color);
                Bp = ct.TinhTien(Bp, position.X, position.Y, p.Color);

                //đổi điểm lastPoint về tọa độ máy để vẽ
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, p,true);
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
                    xoaHinh();
                    // xoay 4 điểm 1 góc angle 
                    Ap = ct.RotateAroundPoint(aroundPoint, Ap, int.Parse(tbRotate.Text), clLine);
                    Bp = ct.RotateAroundPoint(aroundPoint, Bp, int.Parse(tbRotate.Text), clLine);
                    Cp = ct.RotateAroundPoint(aroundPoint, Cp, int.Parse(tbRotate.Text), clLine);
                    Dp = ct.RotateAroundPoint(aroundPoint, Dp, int.Parse(tbRotate.Text), clLine);
                    //vẽ hình
                    dt.VeHinhTuGiac(new Pen(clLine, widthLine), Ap, Bp, Cp, Dp);
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
                    xoaHinh();
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);
                    // tìm 4 điểm của hình thoi theo tâm cũ
                  
                    // lấy đối xứng 4 điểm của hình thoi qua đt
                    Ap = ct.SymmetricalPointByLine(oldPoint, newPoint, Ap, clLine);
                    Bp = ct.SymmetricalPointByLine(oldPoint, newPoint, Bp, clLine);
                    Cp = ct.SymmetricalPointByLine(oldPoint, newPoint, Cp, clLine);
                    Dp = ct.SymmetricalPointByLine(oldPoint, newPoint, Dp, clLine);

                    //vẽ hình thoi
                    dt.VeHinhTuGiac(p, Ap, Bp, Cp, Dp);
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
                
                //đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);
                //tịnh tiến các điểm
                Ap = ct.TinhTien(Ap, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Bp = ct.TinhTien(Bp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Cp = ct.TinhTien(Cp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Dp = ct.TinhTien(Dp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi các điểm về tọa độ MÁY
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);
                dt.VeHinhTuGiac(p, Ap, Bp, Cp, Dp);

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

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);

                //Lưu lại vị trí ban đầu của điểm
                Point position = new Point(Ap.X, Ap.Y);

                //lấy tỉ lệ các điểm của hình
                Ap = ct.TiLe(Ap, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text),p.Color);
                Bp = ct.TiLe(Bp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Cp = ct.TiLe(Cp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Dp = ct.TiLe(Dp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);

                //tính khoảng cách giữa điểm ban đầu và điểm sau tỉ lệ để tịnh tiến
                position = new Point(position.X - Ap.X, position.Y - Ap.Y);

                //tịnh tiến
                Ap = ct.TinhTien(Ap, position.X, position.Y, p.Color);
                Bp = ct.TinhTien(Bp, position.X, position.Y, p.Color);
                Cp = ct.TinhTien(Cp, position.X, position.Y, p.Color);
                Dp = ct.TinhTien(Dp, position.X, position.Y, p.Color);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);

                dt.VeHinhTuGiac(p, Ap, Bp, Cp, Dp);

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
                    xoaHinh();
                    // xoay 4 điểm 1 góc angle 
                    Ap = ct.RotateAroundPoint(aroundPoint, Ap, int.Parse(tbRotate.Text), clLine);
                    Bp = ct.RotateAroundPoint(aroundPoint, Bp, int.Parse(tbRotate.Text), clLine);
                    Cp = ct.RotateAroundPoint(aroundPoint, Cp, int.Parse(tbRotate.Text), clLine);
                    Dp = ct.RotateAroundPoint(aroundPoint, Dp, int.Parse(tbRotate.Text), clLine);
                    //vẽ hình
                    dt.VeHinhTuGiac(new Pen(clLine, widthLine), Ap, Bp, Cp, Dp);
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
                    xoaHinh();
                    //dt.DrawLineByMidPoint(oldPoint, newPoint, p, true);
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

                    // lấy đối xứng 4 điểm của hình 
                    Ap = ct.SymmetricalPointByLine(oldPoint, newPoint, Ap, clLine);
                    Bp = ct.SymmetricalPointByLine(oldPoint, newPoint, Bp, clLine);
                    Cp = ct.SymmetricalPointByLine(oldPoint, newPoint, Cp, clLine);
                    Dp = ct.SymmetricalPointByLine(oldPoint, newPoint, Dp, clLine);

                    //vẽ hình thoi
                    dt.VeHinhTuGiac(p, Ap, Bp, Cp, Dp);
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

                
                //đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);
                //tịnh tiến các điểm
                Ap = ct.TinhTien(Ap, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Bp = ct.TinhTien(Bp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Cp = ct.TinhTien(Cp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Dp = ct.TinhTien(Dp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi các điểm về tọa độ MÁY
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);
                dt.VeHinhTuGiac(p, Ap, Bp, Cp, Dp);

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

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                Dp = dt.changeToFakePoint(Dp);

                //Lưu lại vị trí ban đầu của điểm
                Point position = new Point(Ap.X, Ap.Y);

                //lấy tỉ lệ các điểm của hình
                Ap = ct.TiLe(Ap, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Bp = ct.TiLe(Bp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Cp = ct.TiLe(Cp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Dp = ct.TiLe(Dp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);

                //tính khoảng cách giữa điểm ban đầu và điểm sau tỉ lệ để tịnh tiến
                position = new Point(position.X - Ap.X, position.Y - Ap.Y);

                //tịnh tiến
                Ap = ct.TinhTien(Ap, position.X, position.Y, p.Color);
                Bp = ct.TinhTien(Bp, position.X, position.Y, p.Color);
                Cp = ct.TinhTien(Cp, position.X, position.Y, p.Color);
                Dp = ct.TinhTien(Dp, position.X, position.Y, p.Color);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                Dp = dt.changeToRealPoint(Dp);

                dt.VeHinhTuGiac(p, Ap, Bp, Cp, Dp);



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

        private void btTatTinhTien_Click(object sender, EventArgs e)
        {
            lbTinhTienX.Visible = false;
            lbTinhTienY.Visible = false;
            tbTinhTienX.Visible = false;
            tbTinhTienY.Visible = false;
            btTatTinhTien.Visible = false;
        }

        private void lbChieuCao_Click(object sender, EventArgs e)
        {

        }

        private void tbChieuCao_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbRongDay_Click(object sender, EventArgs e)
        {

        }

        private void tbRongDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbCheoA_Click(object sender, EventArgs e)
        {

        }

        private void txtCheoA_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbCheoB_Click(object sender, EventArgs e)
        {

        }

        private void txtCheoB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btTatTiLe_Click(object sender, EventArgs e)
        {
            lbTiLeX.Visible = false;
            lbTiLeY.Visible = false;
            tbTiLeX.Visible = false;
            tbTiLeY.Visible = false;
            btTatTiLe.Visible = false;
        }


        //Các phép biến đổi của Tam Giác
        private void RotateTamGiac(Point aroundPoint)
        {
            if (bMouseUp)
            {
                if (!String.IsNullOrEmpty(tbRotate.Text))
                {
                    xoaHinh();
                    // xoay 4 điểm 1 góc angle 
                    Ap = ct.RotateAroundPoint(aroundPoint, Ap, int.Parse(tbRotate.Text), clLine);
                    Bp = ct.RotateAroundPoint(aroundPoint, Bp, int.Parse(tbRotate.Text), clLine);
                    Cp = ct.RotateAroundPoint(aroundPoint, Cp, int.Parse(tbRotate.Text), clLine);
                    //vẽ hình
                    dt.veHinhTamGiac(Ap, Bp, Cp, new Pen(clLine, widthLine));
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
                    xoaHinh();
                    dt.DDALineGrid(oldPoint.X, newPoint.X, oldPoint.Y, newPoint.Y, p);

                    // lấy đối xứng 3 điểm của hình
                    Ap = ct.SymmetricalPointByLine(oldPoint, newPoint, Ap, clLine);
                    Bp = ct.SymmetricalPointByLine(oldPoint, newPoint, Bp, clLine);
                    Cp = ct.SymmetricalPointByLine(oldPoint, newPoint, Cp, clLine);

                    //vẽ hình
                    dt.veHinhTamGiac(Ap, Bp, Cp, p);
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
               //đổi các điểm về tọa độ ng dùng để tính toán
                lastPoint = dt.changeToFakePoint(lastPoint);
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                //tịnh tiến các điểm
                lastPoint = ct.TinhTien(lastPoint, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Ap = ct.TinhTien(Ap, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Bp = ct.TinhTien(Bp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);
                Cp = ct.TinhTien(Cp, int.Parse(tbTinhTienX.Text), int.Parse(tbTinhTienY.Text), p.Color);

                //đổi các điểm về tọa độ MÁY
                lastPoint = dt.changeToRealPoint(lastPoint);
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                dt.veHinhTamGiac(Ap, Bp, Cp, p);

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

                //Đổi các điểm về tọa độ ng dùng
                Ap = dt.changeToFakePoint(Ap);
                Bp = dt.changeToFakePoint(Bp);
                Cp = dt.changeToFakePoint(Cp);
                lastPoint = dt.changeToFakePoint(lastPoint);

                //Lưu lại vị trí ban đầu của điểm
                Point position = new Point(lastPoint.X, lastPoint.Y);

                //lấy tỉ lệ các điểm của hình
                Ap = ct.TiLe(Ap, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Bp = ct.TiLe(Bp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                Cp = ct.TiLe(Cp, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);
                lastPoint = ct.TiLe(lastPoint, float.Parse(tbTiLeX.Text), float.Parse(tbTiLeY.Text), p.Color);

                //tính khoảng cách giữa điểm ban đầu và điểm sau tỉ lệ để tịnh tiến
                position = new Point(position.X - lastPoint.X, position.Y - lastPoint.Y);

                //tịnh tiến
                Ap = ct.TinhTien(Ap, position.X, position.Y, p.Color);
                Bp = ct.TinhTien(Bp, position.X, position.Y, p.Color);
                Cp = ct.TinhTien(Cp, position.X, position.Y, p.Color);
                lastPoint = ct.TinhTien(lastPoint, position.X, position.Y, p.Color);

                //đổi về tọa độ máy để vẽ hình
                Ap = dt.changeToRealPoint(Ap);
                Bp = dt.changeToRealPoint(Bp);
                Cp = dt.changeToRealPoint(Cp);
                lastPoint = dt.changeToRealPoint(lastPoint);

                dt.veHinhTamGiac(Ap, Bp, Cp, p);

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

            if (oldPoint != Point.Empty && newPoint != Point.Empty)
            {
                xoaHinh();
                Ap = new Point(oldPoint.X, oldPoint.Y);
                Bp = new Point(newPoint.X, newPoint.Y);
                dt.MidPoint(Ap.X, Bp.X, Ap.Y, Bp.Y, p, true);
            }
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
                    xoaHinh();
                    //Point A, B, C, D;
                    Ap = new Point(e.Location.X,e.Location.Y);
                    Bp = new Point();
                    Cp = new Point();
                    Dp = new Point();

                    dt.tim4DiemHinhThoi_Canh(Ap, ref Bp, ref Cp, ref Dp, int.Parse(txtCheoA.Text), int.Parse(txtCheoB.Text));
                    dt.VeHinhTuGiac(pen, Ap, Bp, Cp, Dp);
                }
            }
            catch (FormatException)
            {
                txtCheoA.Text = String.Empty;
                txtCheoB.Text = String.Empty;
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
                    xoaHinh();
                    Ap = new Point(e.Location.X, e.Location.Y);
                    Bp = new Point();
                    Cp = new Point();
                    Dp = new Point();
                    //dt.tim4DiemHinhChuNhat(e.Location, ref Ap, ref Bp, ref Cp, ref Dp, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
                    dt.tim4DiemHCN_Canh(Ap, ref Bp, ref Cp, ref Dp, int.Parse(tbWidth.Text), int.Parse(tbHeight.Text));
                    dt.VeHinhTuGiac(pen, Ap, Bp, Cp, Dp);
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

            //p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;


            try
            {
                if (oldPoint != Point.Empty && newPoint != Point.Empty)
                {
                    xoaHinh();
                    Ap = new Point();
                    Bp = new Point();
                    Cp = new Point();
                    dt.tim3DiemTamGiac(newPoint, ref Ap, ref Bp, ref Cp, int.Parse(tbChieuCao.Text), int.Parse(tbRongDay.Text));
                    dt.veHinhTamGiac(Ap, Bp, Cp, p);
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

        //hàm xóa hình trước đó
        private void xoaHinh()
        {
           
           dt.MidPoint(firstPoint.X, lastPoint.X, firstPoint.Y, lastPoint.Y, new Pen(Color.FromArgb(240, 240, 240), widthLine),true);
           //tìm điểm và xoa hình thoi cũ
           dt.VeHinhTuGiac(new Pen(Color.FromArgb(240, 240, 240), widthLine), Ap, Bp, Cp, Dp);
           //tìm điểm và xoa hình cũ
           dt.veHinhTamGiac(Ap, Bp, Cp, new Pen(Color.FromArgb(240, 240, 240), widthLine));
            Color bgColor = Color.FromArgb(240, 240, 240);

            if (Form1.hinh == 5)// hình tròn
            {
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), bgColor);
            }
            else if (Form1.hinh == 6)// hinh vuong
            {
                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, bgColor);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, bgColor);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, bgColor);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, bgColor);
            }
            else if (Form1.hinh == 7) // hinh elip
            {
                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, bgColor);
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
                else if( line == "con lac")
                {
                    ThreadAnimConLac(e);
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
