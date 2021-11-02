import Vector.Classes.*;
import Vector.Interfaces.IPolar2D;
import Vector.Interfaces.IVector;

public class Main
{

    public static void main(String[] args)
    {
        IPolar2D polarVector = new Polar2DAdapter(new Vector2D(2,5));
        Vector2D v2 = new Vector2D(5,4);
        Vector3DDecorator vec3DDec = new Vector3DDecorator(new Vector2D(7,2),3);

        System.out.printf("Vector 2D :");
        VectorPrinter.printVecCartesian(v2);

        System.out.printf("Vector 3D :");
        VectorPrinter.printVecCartesian(vec3DDec);

        System.out.printf("Vector 2D Polar :");
        VectorPrinter.printVecPolar(polarVector);



    }


}


/*
WNIOSKI
z powodu implementacyjnych uważam sposób implementacji adaptera poprzez własnie klase dekoratorową jest dużo bardziej przystępny
choćby z powodu małej dostępności funkcjonalnośći wielo dzieciczenia klas jak naprzkłydad w pythonie.

Też w tym przypadku jak i wielu innych można zauważyć tutaj problematyczność wykorzystania dziedziczzenia jeśli chodziło by choć o dodanie
większej ilości wektorów, co z koleji w dekoratorze nie było by aż tak problematyczne.
*/
