package pl.retsuz.shell.specs;

import pl.retsuz.context.IContext;
import pl.retsuz.shell.gen.Command;
import pl.retsuz.shell.gen.ICommand;

public class Remove extends Command
{
    public Remove(IContext ctx, ICommand next)
    {
        super("rm", ctx, next, null, "usun plik o podanej lokalizacji");
    }
}
