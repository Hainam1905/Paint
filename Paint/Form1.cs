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

            //lấy thông tin tọa độ điểm O
            x0 = dt.x0;
            y0 = dt.y0;

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

            if (oldPoint != Point.Empty && newPoint != Point.Empty) dt.DrawArrow(oldPoint, newPoint, p, cbDrawColor.Checked);
            //gp.DrawLine(p, oldPoint, newPoint);
                                                                    
            pbDrawZone.Image = bm;
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
        private void xoahinh()
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
        }
        //vẽ hình tròn trên lưới pixel
        private void btn_drawCircle_Click(object sender, EventArgs e)
        {
            xoahinh();
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
                xoahinh();
                htron.setx(htron.getx() + ip.x);
                htron.sety(htron.gety() + ip.y);
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }else if (Form1.hinh == 6)//hình vuông
            {
                xoahinh();
                Hvuong hvuong2 = new Hvuong(hvuong.xA + ip.x, hvuong.yA + ip.y, hvuong.a);
                hvuong = hvuong2;
                dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);
                Form1.hinh = 6;
            }else if (Form1.hinh == 7)// hình elip
            {
                xoahinh();

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
                xoahinh();
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
                xoahinh();
                if (input.Sx == input.Sy)//ti le x va y bang nhau
                {
                    Hvuong hvuong2 = new Hvuong(hvuong.xA, hvuong.yA, Convert.ToInt32(hvuong.a * input.Sx));
                    
                    hvuong = hvuong2;
                    dt.drawLineDDA(hvuong.xA, hvuong.yA, hvuong.xB, hvuong.yB, Color.Black);
                    dt.drawLineDDA(hvuong.xB, hvuong.yB, hvuong.xC, hvuong.yC, Color.Black);
                    dt.drawLineDDA(hvuong.xC, hvuong.yC, hvuong.xD, hvuong.yD, Color.Black);
                    dt.drawLineDDA(hvuong.xD, hvuong.yD, hvuong.xA, hvuong.yA, Color.Black);
                }

                Form1.hinh = 6;
            }else if (Form1.hinh == 7)//hình elip
            {
                xoahinh();
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
                xoahinh();
                
                int y = ((y0 - htron.gety()) / 5) * (-1);

                htron.sety(y0 - (y * 5));
                
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoahinh();
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
                xoahinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.doiXungQuaOX(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            pbDrawZone.Image = bm;
        }

        private void btn_DoiXungOy_Click(object sender, EventArgs e)
        {
            if (Form1.hinh == 5)//hinh tron
            {
                xoahinh();
                int x = ((htron.getx() - x0) / 5) * (-1);
                
                htron.setx(x0 + (x * 5));
                
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoahinh();
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
                xoahinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.doiXungQuaOY(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            pbDrawZone.Image = bm;
        }

        
        private void btn_Quay_Click(object sender, EventArgs e)
        {
            if (Form1.hinh == 5)//hinh tron
            {
                xoahinh();
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
                xoahinh();
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
                xoahinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.layDiemQuay(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b, Color.Black);
                Form1.hinh = 7;
            }
            pbDrawZone.Image = bm;
        }


        private void btn_DrawSquare_Click(object sender, EventArgs e)
        {
            xoahinh();
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
            xoahinh();
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
                xoahinh();
                int x = ((htron.getx() - x0) / 5) * (-1);
                int y = ((y0 - htron.gety()) / 5) * (-1);
                
                htron.setx(x0 + (x * 5));
                htron.sety(y0 - (y * 5));
                
                dt.circleMidPoint(htron.getx(), htron.gety(), htron.getR(), Color.Black);
                Form1.hinh = 5;
            }
            else if (Form1.hinh == 6)//hình vuông
            {
                xoahinh();
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
                xoahinh();
                Point A = new Point(helip.xc, helip.yc);

                A = dt.doiXungQuaO(dt.findFakePoint(A));

                A = dt.findRealPoint(A);

                helip.xc = A.X;
                helip.yc = A.Y;

                dt.drawEllipsMidPoint(helip.xc, helip.yc, helip.a, helip.b,Color.Black);
                Form1.hinh = 7;
            }
            pbDrawZone.Image = bm;
        }

        private void btFillColor_Click(object sender, EventArgs e)
        {
            if (btFillColor.BackColor == SystemColors.Control)
            {
                if (btDrawPixel.BackColor == SystemColors.ControlDark) btDrawPixel.BackColor = SystemColors.Control;
                if (btDrawArrow.BackColor == SystemColors.ControlDark) btDrawArrow.BackColor = SystemColors.Control;
                TurnOffModeDraw(btDrawCircle);

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
                dt.DrawLineByMidPoint(oldPoint, newPoint, p, true);
                try
                {
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
            }
        }
    }
}
