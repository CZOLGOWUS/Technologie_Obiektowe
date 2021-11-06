package pl.retsuz.shell.variations.mkdir;

import pl.retsuz.filesystem.Composite;
import pl.retsuz.filesystem.IComposite;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

import java.util.ArrayList;

public class MKDIR_Path extends CommandVariation
{

    public MKDIR_Path(ICommandVariation next, ICommand parent)
    {
        super(next, parent, "[a-zA-Z0-9.l_]*");
    }

    @Override
    public void make(String params)
    {
        Composite c = (Composite) (this.getParent().getContext().getCurrent());
        Composite folder = new Composite();
        folder.setName(params);

        String[] arrayOfFolders = params.split("\\/");
        //TO THJIS FUIKIJNG S?HIET
        //c.findElementByPath();
        //while ()
        {

        }

        try
        {
            IComposite elem = c.findElementByPath(params);

            ((Composite)elem).addElement(folder);
            System.out.print(c.ls(""));
        }
        catch (Exception e)
        {
            e.printStackTrace();
            System.out.print(e.getMessage() + "\nFile creation error");
        }
    }
}
