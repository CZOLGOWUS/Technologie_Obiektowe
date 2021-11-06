package Vector.Classes;

import Vector.Interfaces.IPolar2D;
import Vector.Interfaces.IVector;

public class Polar2DAdapter implements IPolar2D, IVector
{

    private IVector srcVector;

    public Polar2DAdapter(IVector srcVector)
    {
        if(srcVector.getComponents().length < 2)
            throw new IllegalArgumentException("vector is not 2 or more dimensional");

        this.srcVector = srcVector;
    }


    @Override
    public double getAngle()
    {
        double[] components = srcVector.getComponents();

        if(components.length < 2 )
        {
            System.out.printf("vector is not 2 or more dimensional");
            return  -1;
        }

        return Math.atan2(components[1],components[0])*(180/ Math.PI);
    }


    @Override
    public double abs() {
        return this.srcVector.abs();
    }


    @Override
    public double cdot(IVector other) {
        return this.srcVector.cdot(other);
    }


    @Override
    public double[] getComponents() {
        return this.srcVector.getComponents();
    }
}
