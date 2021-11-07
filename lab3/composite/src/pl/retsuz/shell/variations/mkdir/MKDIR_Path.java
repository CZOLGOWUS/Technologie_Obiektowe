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
        super(next, parent, "[a-zA-Z0-9.l\\/_]*");
    }

    @Override
    public void make(String params)
    {
        Composite c = (Composite) (this.getParent().getContext().getCurrent());

        Composite parentFolder = c;

        String[] arrayOfFolders = params.split("[\\/]");

        for (int i = 0; i < arrayOfFolders.length ; i++)
        {
            String path = arrayOfFolders[i];

            IComposite nextFolder = new Composite();
            nextFolder.setName(arrayOfFolders[i]);

            if(arrayOfFolders[i].contentEquals(".."))
            {
                if(parentFolder.getParent() != null)
                {
                    parentFolder = (Composite) parentFolder.getParent();
                }
                else
                {
                    System.out.print("there is no folders above");
                    return;
                }
            }
            else if(parentFolder.alreadyExists(nextFolder))
            {
                try
                {
                    parentFolder = (Composite) parentFolder.findElementByPath(nextFolder.getName());
                }
                catch (Exception e)
                {
                    System.out.print("Find function exception");
                    return;
                }

            }
            else
            {
                try
                {
                    parentFolder.addElement( nextFolder);
                    parentFolder = (Composite) nextFolder;
                }
                catch (Exception e)
                {
                    e.printStackTrace();
                    System.out.print(e.getMessage() + "\nFile creation error");
                }
            }

        }

    }
}
