package pl.retsuz.shell.variations.mkdir;

import pl.retsuz.filesystem.Composite;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

public class MKDIR_ddot extends CommandVariation
{

    public MKDIR_ddot(ICommandVariation next, ICommand parent)
    {
        super(next, parent, "\\.\\.");
    }

    @Override
    public void make(String params)
    {
        Composite c = (Composite) (this.getParent().getContext().getCurrent().getParent());
        Composite folder = new Composite();
        folder.setName(params);

        try
        {
            c.addElement(folder);
            System.out.print(c.ls(""));
        }
        catch (Exception e)
        {
            e.printStackTrace();
            System.out.print(e.getMessage() + "\nFile creation error");
        }
    }
}
