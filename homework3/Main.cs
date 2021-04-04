using System;
using System.Collections.Generic;
using System.Text;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Shape> shapes = new List<Shape>();
                for (int i = 0; i < 10; i++)
                {
                    shapes.Add(ShapeFactory.CreateRandomShape());
                }

                shapes.ForEach(s =>
                  Console.WriteLine($"{s.Info}, area={s.Area}"));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
