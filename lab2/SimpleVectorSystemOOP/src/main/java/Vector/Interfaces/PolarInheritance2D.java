package Vector.Interfaces;

import Vector.Classes.Vector2D;
import jdk.jshell.spi.ExecutionControl;

public class PolarInheritance2D extends Vector2D implements IPolar2D
{
    public PolarInheritance2D(double x, double y)
    {
        super(x, y);
    }

    public double getAngle()
    {
        return Math.atan2(y,x)*(180/ Math.PI);
    }
}
