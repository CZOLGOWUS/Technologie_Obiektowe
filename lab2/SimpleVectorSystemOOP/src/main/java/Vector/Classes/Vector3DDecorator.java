package Vector.Classes;

import Vector.Interfaces.IVector;

public class Vector3DDecorator implements IVector
{
    private double z;
    private IVector srcVector;

    public  Vector3DDecorator( IVector srcVector, double z)
    {
        this.z = z;
        this.srcVector = srcVector;

        if(srcVector.getComponents().length + 1 != 3)
            throw new IllegalArgumentException("source vector is not 2 dimensional");
    }




    public double abs()
    {
        double[] xy = srcVector.getComponents();
        return Math.sqrt(xy[0]*xy[0] + xy[1]*xy[1] + z*z);
    }


    public double cdot(IVector other)
    {
        double[] otherV3 = other.getComponents();
        double[] srcVec = getComponents();

        if (otherV3.length == 2)
        {
            otherV3 = new double[] { otherV3[0],otherV3[1],0.0 };
        }
        else if(otherV3.length != 3)
        {
            System.out.print("vector is either 2 nor 3 dimensional");
            return -1;
        }


        return srcVec[0]*otherV3[0] + srcVec[1]*otherV3[1] + srcVec[2]*otherV3[2];
    }


    public double[] getComponents()
    {
        double[] temp = srcVector.getComponents();

        return new double[] {temp[0],temp[1],z};
    }


    public Vector3DDecorator cross(IVector other)
    {
        double[] a;
        double[] b;

        a = getComponents();
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
                        a[1]*b[2] - a[2]*b[1],
                        a[2]*b[0] - a[0]*b[2]
                ),
                a[0]*b[1] - a[1]*b[0]
        );
    }


    public IVector getSrc()
    {
        return srcVector;
    }


}
