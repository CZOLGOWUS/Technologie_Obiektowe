package Vector.Classes;

import Vector.Interfaces.IPolar2D;
import Vector.Interfaces.IVector;

public class VectorPrinter
{
    public static void printVecCartesian(IVector vec)
    {
        double[] vecComponents = vec.getComponents();

        System.out.printf("[ ");
        for (int i = 0; i < vecComponents.length ; i++)
        {
            System.out.printf("%.2f",vecComponents[i] );

            if(i + 1 != vecComponents.length )
                System.out.printf(", ");
        }
        System.out.printf(" ]\n");

    }

    public static void printVecPolar(IPolar2D vec)
    {
        System.out.printf("vector angle = %.2f , vector length = %.2f\n",vec.getAngle(), vec.abs() );
    }

}
