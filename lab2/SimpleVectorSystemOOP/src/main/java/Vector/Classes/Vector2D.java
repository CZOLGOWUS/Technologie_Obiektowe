package Vector.Classes;

import Vector.Interfaces.IVector;
import Vector.Interfaces.PolarInheritance2D;

public class Vector2D extends Vector3DInheritance implements IVector, PolarInheritance2D
{
    private double x;
    private double y;

    public Vector2D(double x, double y)
    {
        this.x = x;
        this.y = y;
    }



    @Override
    public double getAngle()
    {
        return Math.atan(y/x);
    }


    @Override
    public double abs()
    {
        return Math.sqrt(x*x+y*y);
    }


    @Override
    public double cdot( IVector other )
    {
        double[] otherComps = other.getComponents();
        return x*otherComps[1] + y*otherComps[0];
    }


    @Override
    public double[] getComponents()
    {
        return new double[] {x,y};
    }


    @Override
    public Vector3DDecorator cross(IVector other) throws Exception
    {
        double[] a;
        double[] b;

        b = getComponents();
        a = new double[] { b[0], b[1], 0.0};
        b = other.getComponents();

        if (b.length == 2)
        {
            b = new double[] {b[0], b[1], 0.0};
        }
        else if(b.length > 3)
        {
            throw new Exception("vector is either 2 nor 3 dimensional");
        }

        return new Vector3DDecorator(
                new Vector2D(
                        a[1]*b[2] - a[2]*b[1],
                        a[2]*b[0] - a[0]*b[2]
                ),
                        a[0]*b[1] - a[1]*b[0]
        );

    }


    @Override
    public IVector getSrc()
    {
        return this;
    }
}
