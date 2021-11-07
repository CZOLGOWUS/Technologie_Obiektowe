package pl.retsuz.shell.variations.move;

import pl.retsuz.filesystem.Composite;
import pl.retsuz.filesystem.IComposite;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

public class Move_Def extends CommandVariation
{
    public Move_Def(ICommandVariation next, ICommand parent)
    {
        super(next,parent,"[a-zA-Z0-9.l\\/_]*[\\ \\t]*[a-zA-Z0-9.l\\/_]*");
    }

    @Override
    public void make(String params)
    {

        Composite current = (Composite) (this.getParent().getContext().getCurrent());
        String[] paths = params.split("[ \t]");

        Composite source;
        Composite destination;

        if(paths.length != 2)
        {
            System.out.print("Command requires 2 paths 1-source file path, 2-destination path\n");
            return;
        }


        try
        {
            source = (Composite) current.findElementByPath(paths[0]);
            destination = (Composite) current.findElementByPath(paths[1]);

            destination.addElement(source);
        }
        catch (Exception e)
        {
            System.out.print("Paths provided might not exist");
        }




    }

}
