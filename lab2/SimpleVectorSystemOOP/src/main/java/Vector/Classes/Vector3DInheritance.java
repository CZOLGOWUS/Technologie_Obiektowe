package Vector.Classes;

import Vector.Interfaces.IVector;

public class Vector3DInheritance extends Vector2D
{
    private final double z;

    public Vector3DInheritance(double x, double y, double z)
    {
        super(x, y);
        this.z = z;
    }


    @Override
    public double abs()
    {
        return Math.sqrt(x*x + y*y + z*z);
    }

    @Override
    public double cdot(IVector other)
    {
        double[] otherV = other.getComponents();

        if (otherV.length == 2)
        {
            otherV = new double[] { otherV[0],otherV[1],0.0 };
        }
        else if(otherV.length != 3)
        {
            System.out.print("vector is either 2 nor 3 dimensional");
            return -1;
        }


        return x*otherV[0] + y*otherV[1] + z*otherV[2];
    }

    @Override
    public double[] getComponents()
    {
        return new double[] {x,y,z};
    }


    public Vector3DDecorator cross(IVector other)
    {
        double[] b;
        double[] tempB = other.getComponents();


        if (tempB.length == 2)
        {
            b = new double[] {tempB[0],tempB[1],0.0};
        }
        else if(tempB.length == 3)
        {
            b = tempB;
        }
        else
        {
            System.out.print("vector is either 2 nor 3 dimensional");
            return new Vector3DDecorator(new Vector2D(0,0),0);
        }


        return new Vector3DDecorator(
                new Vector2D(
                        y*b[2] - z*b[1],
                        z*b[0] - x*b[2]
                ),
                x*b[1] - y*b[0]
        );
    }


}
