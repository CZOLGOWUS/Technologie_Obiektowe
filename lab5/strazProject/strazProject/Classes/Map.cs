using BasicVector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Map

{
    private static BasicVector.Vector _topLeft, _topRight, _bottomRight, _bottomLeft;

    public static Vector topLeft { get => _topLeft; set => _topLeft = value; }
    public static Vector topRight { get => _topRight; set => _topRight = value; }
    public static Vector bottomRight { get => _bottomRight; set => _bottomRight = value; }
    public static Vector bottomLeft { get => _bottomLeft; set => _bottomLeft = value; }

    public static Random random = new Random();


    public static BasicVector.Vector RandomPoint()
    {

        return new BasicVector.Vector(
            (topLeft.X + random.NextDouble() * (topRight.X - topLeft.X)),
            (bottomLeft.Y + random.NextDouble() * (topLeft.Y - bottomLeft.Y))
            );

    }

}

namespace BasicVector
{
    public class tempClass
    {
        private static BasicVector.Vector _topLeft, _topRight, _bottomRight, _bottomLeft;

        public static Vector topLeft { get => _topLeft; set => _topLeft = value; }
        public static Vector topRight { get => _topRight; set => _topRight = value; }
        public static Vector bottomRight { get => _bottomRight; set => _bottomRight = value; }
        public static Vector bottomLeft { get => _bottomLeft; set => _bottomLeft = value; }

        public static Random random = new Random();

        public static BasicVector.Vector RandomPoint()
        {

            return new BasicVector.Vector(
                topLeft.X + random.NextDouble() * (topRight.X - topLeft.X),
                bottomLeft.Y + random.NextDouble() * (topLeft.Y - bottomLeft.Y)
                );

        }
    }
}