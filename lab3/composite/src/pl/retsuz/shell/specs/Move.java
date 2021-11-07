package pl.retsuz.shell.specs;

import pl.retsuz.context.IContext;
import pl.retsuz.shell.gen.Command;
import pl.retsuz.shell.gen.ICommand;

public class Move extends Command
{
    public Move(IContext ctx, ICommand next)
    {
        super("move", ctx, next, null, "przenosi plik do innego folderu");
    }
}
