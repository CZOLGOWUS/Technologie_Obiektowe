import Vector.Classes.*;
import Vector.Interfaces.IPolar2D;
import Vector.Interfaces.IVector;
import Vector.Interfaces.PolarInheritance2D;

public class Main
{

    public static void main(String[] args)
    {

        PolarInheritance2D polarVector = new PolarInheritance2D(8,10);
        Vector3DInheritance vec3DInheritance = new Vector3DInheritance(10,12,9);
        Vector3DDecorator vec3DDec = new Vector3DDecorator(new Vector2D(52,45),32);

        System.out.print("CARTESIAN\n"); //---------------

        System.out.print("Vector 2D Polar :");
        VectorPrinter.printVecCartesian(polarVector );

        System.out.printf("Vector 3D :");
        VectorPrinter.printVecCartesian(vec3DInheritance);

        System.out.printf("Vector 3D :");
        VectorPrinter.printVecCartesian(vec3DDec);




        System.out.printf("\n\nPOLAR\n"); //-----------------

        System.out.printf("Vector 2D Polar :");
        VectorPrinter.printVecPolar(polarVector );

        System.out.printf("Vector 3D :");
        VectorPrinter.printVecPolar(new Polar2DAdapter( vec3DInheritance) );

        System.out.printf("Vector 3D :");
        VectorPrinter.printVecPolar(new Polar2DAdapter(vec3DDec));




        System.out.printf("\n\nDOT PRODUCTS\n"); // ---------------------

        System.out.printf("3DInheritance x polarVec :");
        System.out.printf("%.2f\n", vec3DInheritance.cdot(polarVector) );

        System.out.printf("3DInheritance x 3DDec :");
        System.out.printf("%.2f\n", vec3DInheritance.cdot(vec3DDec) );

        System.out.printf("3DInheritance x 3DInheritance :");
        System.out.printf("%.2f\n", vec3DInheritance.cdot(vec3DInheritance) );



        System.out.printf("polarVec x polarVec :");
        System.out.printf("%.2f\n", polarVector.cdot(polarVector) );

        System.out.printf("polarVec x 3DDec :");
        System.out.printf("%.2f\n", polarVector.cdot(vec3DDec) );

        System.out.printf("polarVec x 3DInheritance :");
        System.out.printf("%.2f\n", polarVector.cdot(vec3DInheritance) );



        System.out.printf("3DDec x polarVec :");
        System.out.printf("%.2f\n", vec3DDec.cdot(polarVector) );

        System.out.printf("3DDec x 3DDec :");
        System.out.printf("%.2f\n", vec3DDec.cdot(vec3DDec) );

        System.out.printf("3DDec x 3DInheritance :");
        System.out.printf("%.2f\n", vec3DDec.cdot(vec3DInheritance) );







        System.out.printf("\n\nCROSS PRODUCTS\n"); // ---------------------

        System.out.printf("3DInheritance x polarVec :");
        VectorPrinter.printVecCartesian( vec3DInheritance.cross( polarVector) );

        System.out.printf("3DInheritance x 3DDec :");
        VectorPrinter.printVecCartesian( vec3DInheritance.cross( vec3DDec) );

        System.out.printf("3DInheritance x 3DInheritance :");
        VectorPrinter.printVecCartesian( vec3DInheritance.cross(vec3DInheritance) );



        System.out.printf("polarVec x polarVec :");
        System.out.printf("no method\n");

        System.out.printf("polarVec x 3DDec :");
        System.out.printf("no method\n");

        System.out.printf("polarVec x 3DInheritance :");
        System.out.printf("no method\n");



        System.out.printf("3DDec x polarVec :");
        VectorPrinter.printVecCartesian( vec3DDec.cross(polarVector) );

        System.out.printf("3DDec x 3DDec :");
        VectorPrinter.printVecCartesian(vec3DDec.cross(vec3DDec) );

        System.out.printf("3DDec x 3DInheritance :");
        VectorPrinter.printVecCartesian(vec3DDec.cross(vec3DInheritance) );

    }


}


/*
WNIOSKI

dziedziczenie:
- umożliwia "overide"-owanie zachowan adaptowaneej kalsy gdyż włąsnie adapter jest
- niebedzie jednak działać gdy chcialibysmy zaadoptować tą klase jak i jej podklasy

Dekorator:
- sprawia że nadpisywanie metod jest duzo bardziej skomplikowane i jest rozwiazane poprzez referowanie do innych podklas w adapterze a nie celowego objektu adaptowanego
- pozwala na adaptowanie wielu obiektów adaptowanych jak tez edytować ich zachowanie


*/
