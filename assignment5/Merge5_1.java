import java.util.Arrays;

public class Merge5_1{
    public static void main(String[] args){
        int[] xs = { 3, 5, 12 };
        int[] ys = { 2, 3, 4, 7 };
        System.out.println(Arrays.toString(merge(xs,ys)));
    }

    static int[] merge(int[] xs, int[] ys)
    {
        int n = xs.length + ys.length;
        int[] zs = new int[n];
        int xpoint = 0;
        int ypoint = 0;
        for (int i = 0; i < n; i++)
        {
            if (xpoint == xs.length){
                zs[i] = ys[ypoint];
                ypoint++;;
            }
            if (ypoint == ys.length || xs[xpoint] < ys[ypoint]){
                zs[i] = xs[xpoint];
                xpoint++;;
            }else {
                zs[i] = ys[ypoint];
                ypoint++;;
            }
        }
    
        return zs;
    }
}