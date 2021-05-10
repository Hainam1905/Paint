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
            gp = Graphics.FromImage(bm);
            gp.Clear(Color.LightGray);
            
            drawHill();
            drawForest();
            drawStreet();
            //drawSun(590, 80);
            drawMoon(590, 80);
            pbDrawZone.Image = bm;
        }
        void drawSun(int x,int y)
        {
            Pen p = new Pen(clLine, widthLine);
            dt.MidPointDrawCircle(x, y, 65, Color.Red);
        }
        void drawMoon(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);
            dt.MidPointDrawHaftCircle(x, y, 65, Color.Yellow);
            dt.drawHaftElip(x - 15, y, 30, 65, Color.Yellow);
        }
        void drawForest()
        {
            drawTree(30, 500);
            drawTree(70, 600);
            drawTree(150, 550);
            drawTree(180, 650);
            drawTree(280, 490);
            drawTree(320, 560);
            drawTree(380, 620);
            drawTree(440, 570);
            drawTree(525, 504);
            drawTree(578, 620);
            drawTree(650, 597);
            drawTree(700, 510);
            drawTree(800, 610);
            drawTree(900, 510);
            


        }
        void drawCar()
        {
            //dt.MidPointDrawCircle(int )
        }

        void drawStreet()
        {
            Pen p = new Pen(clLine, widthLine);
            dt.DrawMidPoint(new Point(0, 210), new Point(1000, 210), p);
            dt.DrawMidPoint(new Point(0, 400), new Point(1000, 400), p);
            desparateLine(100,300);
            desparateLine(300, 300);
            desparateLine(500, 300);
            desparateLine(700, 300);
            desparateLine(900, 300);
        }
        void desparateLine(int x,int y)
        {
            int xtop = x;
            int ytop = y;
            int xbottom = xtop - 20;
            int ybottom = ytop + 20;
            int tempxtop = xtop + 100;
            int tempxbottom = xbottom + 100; 
            

            

            Pen p = new Pen(clLine, widthLine);

            dt.DrawMidPoint(new Point(xtop, ytop), new Point(xbottom, ybottom), p);
            dt.DrawMidPoint(new Point(xtop, ytop), new Point(tempxtop, ytop), p);
            dt.DrawMidPoint(new Point(xbottom, ybottom), new Point(tempxbottom, ybottom), p);
            dt.DrawMidPoint(new Point(tempxbottom, ybottom), new Point(tempxtop, ytop), p);

        }
        void drawHill()
        {
            
            Pen p = new Pen(clLine, widthLine); 
            //hill 1
            dt.DrawMidPoint(new Point(0, 200), new Point(100, 100), new Pen(clLine, widthLine));
            dt.DrawMidPoint(new Point(100, 100), new Point(250, 210),p );
            //dt.ToMauDuongBienKhuDeQuy(125, 150, Color.Red);
            //hill 2
            dt.DrawMidPoint(new Point(140, 130), new Point(220, 50), p);
            dt.DrawMidPoint(new Point(220, 50), new Point(300, 130), p);
            
            //hill 3
            dt.DrawMidPoint(new Point(250, 210), new Point(330, 80), p);
            dt.DrawMidPoint(new Point(330, 80), new Point(410, 210), p);

            //hill 4
            dt.DrawMidPoint(new Point(380, 155), new Point(440, 80), p);
            dt.DrawMidPoint(new Point(440, 80), new Point(480, 150), p);
            //hill 5
            dt.DrawMidPoint(new Point(405, 210), new Point(520, 120), p);
            dt.DrawMidPoint(new Point(520, 120), new Point(580,210), p);

            //hill 6
            dt.DrawMidPoint(new Point(605, 210), new Point(655, 130), p);
            dt.DrawMidPoint(new Point(655, 130), new Point(700,210), p);
            //hill 7
            dt.DrawMidPoint(new Point(675, 160), new Point(735, 90), p);
            dt.DrawMidPoint(new Point(735, 90), new Point(780, 210), p);

            //hill 8
            dt.DrawMidPoint(new Point(755, 140), new Point(860, 70), p);
            dt.DrawMidPoint(new Point(860, 70), new Point(970, 210), p);
        }
        void drawTree(int x, int y)
        {
            Pen p = new Pen(clLine, widthLine);
            int xleft = x;
            int yleft = y;
            int xright = xleft + 20;
            int yright = yleft;

            int tempxLeft = xleft;
            int tempyLeft = yleft - 30;

            int tempxRight = xright;
            int tempyRight = yright - 30;
            dt.DrawMidPoint(new Point(xleft, yleft), new Point(xright, yright), p);
            dt.DrawMidPoint(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPoint(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;
            tempxLeft -= 30;
            tempxRight += 30;

            dt.DrawMidPoint(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPoint(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;

            tempxLeft += 20;
            tempxRight -= 20;
            tempyLeft -= 20;
            tempyRight -= 20;
            dt.DrawMidPoint(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPoint(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;
            tempxLeft -= 20;
            tempxRight += 20;

            dt.DrawMidPoint(new Point(xleft, yleft), new Point(tempxLeft, tempyLeft), p);
            dt.DrawMidPoint(new Point(xright, yright), new Point(tempxRight, tempyRight), p);

            xleft = tempxLeft;
            yleft = tempyLeft;
            xright = tempxRight;
            yright = tempyRight;

            x += 10;
            tempyLeft -= 35;
            tempyRight -= 35;
            dt.DrawMidPoint(new Point(xleft, yleft), new Point(x, tempyLeft), p);
            dt.DrawMidPoint(new Point(xright, yright), new Point(x, tempyRight), p);

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
