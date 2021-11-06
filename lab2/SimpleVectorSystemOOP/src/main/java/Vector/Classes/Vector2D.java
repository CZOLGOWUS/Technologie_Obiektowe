package Vector.Classes;

import Vector.Interfaces.IVector;
import Vector.Interfaces.PolarInheritance2D;

public class Vector2D implements IVector
{
    protected double x;
    protected double y;

    public Vector2D(double x, double y)
    {
        this.x = x;
        this.y = y;
    }


    @Override
    public double abs()
    {
        return Math.sqrt(x*x+y*y);
    }


    @Override
    public double cdot(IVector other)
    {
        double[] otherV3 = other.getComponents();

        if(otherV3.length != 3 && otherV3.length != 2 )
        {
            System.out.printf("vector is either 2 nor 3 dimensional");
            return -1;
        }


        return x*otherV3[0] + y*otherV3[1];
    }


    @Override
    public double[] getComponents()
    {
        return new double[] {x,y};
    }

}
