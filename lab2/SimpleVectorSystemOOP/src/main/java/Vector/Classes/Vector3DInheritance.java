package Vector.Classes;

import Vector.Interfaces.IVector;

public abstract class Vector3DInheritance
{
    private double z;

    public abstract double abs();
    public abstract double cdot(IVector other);
    public double[] getComponents() { return new double[] {z}; };
    public abstract Vector3DDecorator cross(IVector other) throws Exception;
    public abstract IVector getSrc();

}
