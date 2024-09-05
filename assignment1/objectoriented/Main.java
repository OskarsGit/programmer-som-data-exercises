import java.util.ArrayList;
//1.4 I - IV here
public class Main{
    public static void main(String[] args){
        Expr e1 = new Add(new CstI(17), new Var("z"));
        System.out.println(e1.toString());
        Expr e2 = new Mul(new Add(new CstI(3), new CstI(4)), new Var("name"));
        System.out.println(e2.toString());
        Expr e3 = new Sub(new Mul(new Var("var1"), new Var("var2")), new Mul(new CstI(3), new CstI(4)));
        System.out.println(e3.toString());
        Expr e4 = new Mul(new Sub(new CstI(3), new CstI(4)), new Add(new CstI(3), new CstI(4)));
        System.out.println(e4.toString());

        ArrayList<Tuple> env = new ArrayList<Tuple>();
        env.add(new Tuple("z", 17));
        env.add(new Tuple("name", 10));
        env.add(new Tuple("var1", 10));
        env.add(new Tuple("var2", 5));
        try{
            System.out.println(e1.eval(env));
        }
        catch (Exception e){
            System.out.println(e);
        }
        try{
            System.out.println(e2.eval(env));
        }
        catch (Exception e){
            System.out.println(e);
        }

        Expr e5 = new Sub(new CstI(6), new CstI(6));
        System.out.println(simplify(e5).toString());
    }
    public static Expr simplify(Expr expr){
        if (expr instanceof Add){
            if (((Add)expr).expr1 instanceof CstI){
                if (((CstI)((Add)expr).expr1).value == 0){
                    return simplify(((Add)expr).expr2);
                }
            }
            else if (((Add)expr).expr2 instanceof CstI){
                if (((CstI)((Add)expr).expr2).value == 0){
                    return simplify(((Add)expr).expr1);
                }
            }
        }
        else if (expr instanceof Sub){
            if (((Sub)expr).expr1 instanceof CstI && ((Sub)expr).expr2 instanceof CstI){
                if (((CstI)((Sub)expr).expr2).value == ((CstI)((Sub)expr).expr1).value){
                    return new CstI(0);
                }
            }
            if (((Sub)expr).expr2 instanceof CstI){
                if (((CstI)((Sub)expr).expr2).value == 0){
                    return simplify(((Sub)expr).expr1);
                }
            }
        }
        else if (expr instanceof Mul){
            if (((Mul)expr).expr1 instanceof CstI){
                if (((CstI)((Mul)expr).expr1).value == 1){
                    return simplify(((Mul)expr).expr2);
                }
                else if (((CstI)((Mul)expr).expr1).value == 0){
                    return new CstI(0);
                }
            }
            if (((Mul)expr).expr2 instanceof CstI){
                if (((CstI)((Mul)expr).expr2).value == 1){
                    return simplify(((Mul)expr).expr1);
                }
                else if (((CstI)((Mul)expr).expr2).value == 0){
                    return new CstI(0);
                }
            }
        }
        return expr;
    }
}
//not very pretty
class Tuple{
    public String x;
    public int y;
    public Tuple(String x, int y){
        this.x = x;
        this.y = y;
    }
}
abstract class Expr {
    public abstract int eval(ArrayList<Tuple> env) throws Exception;
    public abstract String toString();
}
class CstI extends Expr{
    int value;
    public CstI(int value){
        this.value = value;
    }
    public String toString(){
        return value + "";
    }
    public int eval(ArrayList<Tuple> env){
        return value;
    }
}
class Var extends Expr{
    String varname;
    public Var(String varname){
        this.varname = varname;
    }
    public String toString(){
        return varname + "";
    }
    public int eval(ArrayList<Tuple> env) throws Exception{
        try{
            return lookup(env, varname);
        }
        catch (Exception e){
                throw e;
        }
    }
    public int lookup(ArrayList<Tuple> env, String var) throws Exception{
        for (Tuple tuple : env){
            if (tuple.x.equals(var)){
                return tuple.y;
            }
        }
        throw new Exception("variable does not exist in environment");
    }
}
abstract class Binop extends Expr{
    
}
class Add extends Binop{
    Expr expr1, expr2;
    public Add(Expr expr1, Expr expr2){
        this.expr1 = expr1;
        this.expr2 = expr2;
    }
    public String toString(){
        return "("+ expr1.toString() + " + " + expr2.toString() + ")"; 
    }
    public int eval(ArrayList<Tuple> env) throws Exception{
        try {
            return expr1.eval(env) + expr2.eval(env);
        }
        catch (Exception e){
            throw e;
        }
    }
}
class Sub extends Binop{
    Expr expr1, expr2;
    public Sub(Expr expr1, Expr expr2){
        this.expr1 = expr1;
        this.expr2 = expr2;
    }
    public String toString(){
        return "(" + expr1.toString() + " - " + expr2.toString() + ")";
    }
    public int eval(ArrayList<Tuple> env) throws Exception{
        try {
            return expr1.eval(env) - expr2.eval(env);
        }
        catch (Exception e){
            throw e;
        }
    }
}
class Mul extends Binop{
    Expr expr1, expr2;
    public Mul(Expr expr1, Expr expr2){
        this.expr1 = expr1;
        this.expr2 = expr2;
    }
    public String toString(){
        return "(" + expr1.toString() + " * " + expr2.toString() + ")";
    }
    public int eval(ArrayList<Tuple> env) throws Exception{
        try {
            return expr1.eval(env) * expr2.eval(env);
        }
        catch (Exception e){
            throw e;
        }
    }
}
