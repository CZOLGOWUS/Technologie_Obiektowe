package pl.retsuz.shell.variations.remove;

import pl.retsuz.filesystem.Composite;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.specs.Remove;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

public class Remove_Def extends CommandVariation
{
    public Remove_Def(ICommandVariation next, ICommand parent)
    {
        super(next,parent,"[a-zA-Z0-9.l\\/_]*");
    }

    @Override
    public void make(String params)
    {
        Composite current = (Composite) (this.getParent().getContext().getCurrent());

        try
        {
            current.removeElement(current.findElementByPath(params));
            System.out.print(current.ls(""));
        }
        catch (Exception e)
        {
            System.out.print("Could not remove File (file doesnt exist or path is incorrect)");
        }

    }
}
