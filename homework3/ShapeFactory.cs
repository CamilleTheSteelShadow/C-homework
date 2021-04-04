using System;
using System.Collections.Generic;
using System.Text;

namespace homework3
{
    class ShapeFactory
    {
        static Random random = new Random();

        public static Shape CreateShape(string type, params double[] edges)
        {
            Shape result = null;
            switch (type)
            {
                case "squre":
                    result = new Square(edges[0]);
                    break;
                case "circle":
                    result = new Circle(edges[0]);
                    break;
                case "rectangle":
                    result = new Rectangle(edges[0], edges[1]);
                    break;
                case "triangle":
                    result = new Triangle(edges[0], edges[1], edges[2]);
                    break;
                default: throw new InvalidOperationException("Invalid shape type:" + type);
            }
            if (!result.IsValid())
            {
                throw new InvalidOperationException("Invalid shape arguments");
            }
            return result;
        }

        
        public static Shape CreateRandomShape()
        {
            int type = random.Next(0, 4);
            Shape result = null;
            while (result == null)
            {
                try
                {
                    switch (type)
                    {
                        case 0:
                            result = CreateShape("squre", random.Next(200));
                            break;
                        case 1:
                            result = CreateShape("circle", random.Next(200));
                            break;
                        case 2:
                            result = CreateShape("rectangle", random.Next(200), random.Next(200));
                            break;
                        case 3:
                            result = CreateShape("triangle", random.Next(200), random.Next(200), random.Next(200));
                            break;
                    }
                }
                catch
                {
                    
                }
            }
            return result;
        }
    }
}
