namespace Mouse_codeonly;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
        Console.OutputEncoding = System.Text.Encoding.ASCII;
        int[,] map = Field.Generate_map();
         int[,] clean_path = new int[0,2];
         int[,] basic_clean = new int[0,2];
        
        int[] start = {0,0};
        int[,] path;
        int [] last_p = new int[2];
        int[,] pers_m = new int [map.GetLength(0),map.GetLength(1)];

        
               
        Field.ResizeArray(ref clean_path, clean_path.GetLength(0)+1,clean_path.GetLength(1));
        clean_path = Field.Add_to_list(clean_path,last_p, clean_path.GetLength(0)-1);

        Field.ResizeArray(ref basic_clean, basic_clean.GetLength(0)+1,basic_clean.GetLength(1));
        basic_clean= Field.Add_to_list(basic_clean,last_p, basic_clean.GetLength(0)-1);

        Console.WriteLine(clean_path.GetLength(0));
        System.Console.WriteLine(Field.Iswall(13,1));

        pers_m = Mouse.Maze_start_val(pers_m);
        (path, pers_m )  = Mouse.Basic_FF_to( map, pers_m, start );
        Mouse.Drawn(map, pers_m);
        
        Field.Drawn(map,clean_path);
        last_p[0] = path[0,0];
        last_p[1] = path[0,1]; 

        clean_path= Mouse.Clean_run(path);
        basic_clean = Mouse.Clean_run_basic(path);
        
        Field.Drawn(map,clean_path);
        if (Console.ReadKey().Key == ConsoleKey.Q)
        {
            break;
        }
        

        }
     
    }
}
