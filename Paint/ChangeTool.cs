using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    class ChangeTool
    {
        private Bitmap bm, bmTemp, bmDefault;
        private Label Label;

        //Constructor
        public ChangeTool(Bitmap bitmap, Label label)
        {
            this.Label = label;

            //Bitmap chính
            bm = bitmap;

            //Bitmap Để tô màu
            bmTemp = new Bitmap(bm);

            //Bitmap mặc định, không phải để vẽ
            bmDefault = new Bitmap(bm);
        }


        
        private Matrix matrixRotateAroundPoint(Point aroundP, float angle)
        {
            //Ma trận tịnh tiến về O
            float[,] x =
            {
                {1, 0, 0 },
                {0, 1, 0 },
                {-aroundP.X, -aroundP.Y, 1 }
            };
            Matrix translateToO = new Matrix(x);

            //Ma trận quay quanh O góc angle
            float[,] y =
            {
                {MathF.Cos(angle * MathF.PI / 180), MathF.Sin(angle * MathF.PI / 180), 0 },
                {-MathF.Sin(angle * MathF.PI / 180), MathF.Cos(angle * MathF.PI / 180), 0 },
                {0, 0, 1 }
            };
            Matrix rotateAroundO = new Matrix(y);

            //Ma trận tịnh tiến về chỗ cũ
            float[,] z =
            {
                {1, 0, 0 },
                {0, 1, 0 },
                {aroundP.X, aroundP.Y, 1 }
            };
            Matrix translateToAroudP = new Matrix(z);

            Matrix temp = translateToO * rotateAroundO;
            return temp * translateToAroudP;
        }

        //Đưa điểm 2D về ma trận điểm
        private Matrix TransaleToMatrixPoint(Point point)
        {
            float[,] x =
            {
                {point.X, point.Y, 1 }
            };
            return new Matrix(x);
        }

        //Đưa ma trận điểm về điểm 2D
        private Point TransaleToPoint(Matrix matrix)
        {
            return new Point((int)matrix.Matrixa[0, 0], (int)matrix.Matrixa[0, 1]);
        }

        //Quay quanh một điểm
        public void RotateAroundPoint(Point aroundP, List<Point> listP, float angle, Color color)
        {
            //Tim Ma tran bien doi
            Matrix rotateAroundPoint = matrixRotateAroundPoint(aroundP, angle);

            //Dùng ma trận biến đổi để quay các điểm trong listP quanh aroundP với góc angle
            foreach(Point point in listP)
            {
                //Đưa điểm về matrix
                Matrix matrixPoint = this.TransaleToMatrixPoint(point);

                //Nhân ma trận điểm với ma trận biến đổi
                matrixPoint = matrixPoint * rotateAroundPoint;

                //Đưa ma trận điểm về điểm
                Point kq = TransaleToPoint(matrixPoint);
                bm.SetPixel(kq.X, kq.Y, color);
            }
        }
        public void RotateAroundPoint(Point aroundP, Point rotateP, float angle, Color color)
        {
            //Tim Ma tran bien doi
            Matrix rotateAroundPoint = matrixRotateAroundPoint(aroundP, angle);

            //Dùng ma trận biến đổi để quay các điểm trong listP quanh aroundP với góc angle
                //Đưa điểm về matrix
                Matrix matrixPoint = this.TransaleToMatrixPoint(rotateP);

                //Nhân ma trận điểm với ma trận biến đổi
                matrixPoint = matrixPoint * rotateAroundPoint;

                //Đưa ma trận điểm về điểm
                Point kq = TransaleToPoint(matrixPoint);
                bm.SetPixel(kq.X, kq.Y, color);
        }

    }
}
