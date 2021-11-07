package pl.retsuz.shell;

import pl.retsuz.context.IContext;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.specs.*;
import pl.retsuz.shell.variations.cd.CD_Path;
import pl.retsuz.shell.variations.cd.CD_ddot;
import pl.retsuz.shell.variations.cd.CD_def;
import pl.retsuz.shell.variations.gen.ICommandVariation;
import pl.retsuz.shell.variations.ls.LS_Def;
import pl.retsuz.shell.variations.ls.LS_Path;
import pl.retsuz.shell.variations.ls.LS_ddot;
import pl.retsuz.shell.variations.mkdir.MKDIR_Def;
import pl.retsuz.shell.variations.mkdir.MKDIR_Path;
import pl.retsuz.shell.variations.mkdir.MKDIR_ddot;
import pl.retsuz.shell.variations.more.More_Def;
import pl.retsuz.shell.variations.move.Move_Def;
import pl.retsuz.shell.variations.remove.Remove_Def;
import pl.retsuz.shell.variations.tree.Tree_Def;
import pl.retsuz.shell.variations.tree.Tree_Path;
import pl.retsuz.shell.variations.tree.Tree_ddot;

public abstract class DefShell {
    public static ICommand construct(IContext ctx)
    {
        ICommand more = new More(ctx, null);
        ICommandVariation more_def= new More_Def(null, more);
        more.set_default(more_def);

        ICommand tree = new Tree(ctx, more);
        ICommandVariation tree_path= new Tree_Path(null, tree);
        ICommandVariation tree_ddot= new Tree_ddot(tree_path, tree);
        ICommandVariation tree_def= new Tree_Def(tree_ddot, tree);
        tree.set_default(tree_def);

        ICommand cd = new Cd(ctx, tree);
        ICommandVariation cd_path= new CD_Path(null, cd);
        ICommandVariation cd_ddot= new CD_ddot(cd_path, cd);
        ICommandVariation cd_def= new CD_def(cd_ddot, cd);
        cd.set_default(cd_def);

        ICommand ls = new Ls(ctx, cd);
        ICommandVariation ls_path= new LS_Path(null, ls);
        ICommandVariation ls_ddot= new LS_ddot(ls_path, ls);
        ICommandVariation ls_def= new LS_Def(ls_ddot, ls);
        ls.set_default(ls_def);

        ICommand mkdir = new Mkdir(ctx, ls);
        ICommandVariation mkdir_path = new MKDIR_Path(null, mkdir);
        ICommandVariation mkdir_ddot = new MKDIR_ddot(mkdir_path, mkdir);
        ICommandVariation mkdir_def = new MKDIR_Def(mkdir_ddot, mkdir);
        mkdir.set_default(mkdir_def);

        ICommand move = new Move(ctx, mkdir);
        ICommandVariation move_def = new Move_Def(null, move);
        move.set_default(move_def);

        ICommand rm = new Remove(ctx, move);
        ICommandVariation remove_def = new Remove_Def(null, rm);
        rm.set_default(remove_def);

        return rm;
    }
}
