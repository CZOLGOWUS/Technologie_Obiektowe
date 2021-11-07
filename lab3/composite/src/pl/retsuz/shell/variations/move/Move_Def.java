package pl.retsuz.shell.variations.move;

import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

public class Move_Def extends CommandVariation
{
    public Move_Def(ICommandVariation next, ICommand parent)
    {
        super(next,parent,"");
    }

    @Override
    public void make(String params)
    {

    }

}
