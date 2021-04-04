using System;

namespace homework3
{

    interface Shape
    {
        double Area { get; }

        string Info { get; }

        bool IsValid();
    }



    class Rectangle : Shape
    {
        public double Length { get; set; }

        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }


        public string Info => $"矩形:length={Length},width={Width}.";
        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                return Length * Width;
            }
        }

        public bool IsValid()
        {
            return Length > 0 && Width > 0;
        }


    }



    class Square : Shape
    {

        public double Side
        {
            get; set;
        }

        public Square(double side)
        {
            Side = side;
        }

        public string Info => $"正方形:side={Side}.";


        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                return Side * Side;
            }
        }

        public bool IsValid()
        {
            return Side > 0;
        }

    }


    class Triangle : Shape
    {
        public double[] Edges { get; set; } = new double[3];
        public Triangle(double a, double b, double c)
        {
            double[] newEdges = new double[3] { a, b, c };
            this.Edges = newEdges;
        }

        public string Info
        {
            get => $"三角形:a={Edges[0]},b={Edges[1]},c={Edges[2]}.";
        }

        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                double p = (Edges[0] + Edges[1] + Edges[2]) / 2;
                return Math.Sqrt(p * (p - Edges[0]) * (p - Edges[1]) * (p - Edges[2]));
            }
        }

        public bool IsValid()
        {
            double a = Edges[0], b = Edges[1], c = Edges[2];
            return (a > 0 && b > 0 && c > 0 &&
                    a + b > c && b + c > a && a + c > b);
        }
    }

    class Circle : Shape
    {

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public string Info => $"圆形:radius={Radius}";

        public double Area
        {
            get
            {
                if (!IsValid()) throw new InvalidOperationException("形状无效，无法计算面积");
                return Math.PI * Radius * Radius;
            }
        }

        public bool IsValid()
        {
            return Radius > 0;
        }
    }

}
        

        
