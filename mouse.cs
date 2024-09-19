using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mouse_codeonly
{
    public class Mouse
    {
        public static int[,] Maze_start_val(int[,] map){
            int inb;
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int t = 0; t < map.GetLength(1); t++)
                {
                    map[i,t]= (map.GetLength(1)-1) / 2 - t;
                    if (map[i,t] < 0){
                        map[i,t] = map[i,t] * (-1);
                        
                    }
                    
                    inb = (map.GetLength(0)-1) / 2 - i;
                    if (inb < 0){
                        map[i,t] += inb * (-1);
                    }
                    else{
                        map[i,t] += inb;
                    }
                    Console.Write($"{map[i,t],3}");
                }

                Console.WriteLine("");
                
            }   
            return map;
            
        }
        public static (int[,], int[,]) Basic_FF_to(int[,] map,int[,] persaption_map, int[] start){
            int[,] path = new int[1,2];
                int[,] next_f = new int[4,2];
                
                int cur_field = 16;
                int i= 0;
                int d = 0;
                persaption_map[start[0],start[1]] = persaption_map.GetLength(0);
                int cur_walls;
                Field.ResizeArray(ref path, path.GetLength(0)+1,path.GetLength(1));
                    path = Field.Add_to_list(path,start, i);
                while (true)//start
                {
                    int[] next_f_v = {160,160,160,160};
                    i++;
                    //if (cur_field != 0){break;}
                    
                // get cur field val
                    cur_field = persaption_map[start[0],start[1]];
                    
                // get cur field walls
                    cur_walls = map[start[0],start[1]];
                // get the field val of fields with out wall inbetween
                // coose lowest number field (incase two have the same val pic random) it now pics the first field in that case 
                // replace with Iswall code and extract from bool array
                    if (!Field.Iswall(cur_walls,8) ){ 
                        next_f[0,0] = start[0];
                        next_f[0,1] = start[1]+1;
                        next_f_v[0] = persaption_map[next_f[0,0],next_f[0,1]];
                    }
                    if (!Field.Iswall(cur_walls,4)){ 
                        next_f[1,0] = start[0];
                        next_f[1,1] = start[1]-1;
                        next_f_v[1] = persaption_map[next_f[1,0],next_f[1,1]];
                    }
                    if (!Field.Iswall(cur_walls,1)){ 
                        next_f[2,0] = start[0]-1;
                        next_f[2,1] = start[1];
                        next_f_v[2] = persaption_map[next_f[2,0],next_f[2,1]];
                    }
                    if (!Field.Iswall(cur_walls,2)){ 
                        next_f[3,0] = start[0]+1;
                        next_f[3,1] = start[1];
                        next_f_v[3] = persaption_map[next_f[3,0],next_f[3,1]];
                    }
                    
                    for (int g = 0; g < next_f_v.Length; g++)
                    {
                        if (next_f_v[g] <= next_f_v[d]){
                            d=g;
                        }
                        
                    }
                    System.Console.WriteLine(next_f_v[d]);
                     if (cur_field == 0){break;}
                   
                // update cur field val := lowest number + 1
                for (int z = 0; z < next_f_v.Length; z++)
                {
                    if (next_f_v[z] < next_f_v[d]){d=z; z=0;}
                }
              
                if (i != 0){persaption_map[start[0],start[1]] = next_f_v[d] + 1;}
                // cur field := lowest number field
                start[0] = next_f[d,0];
                start[1] = next_f[d,1];
                  
                Field.ResizeArray(ref path, path.GetLength(0)+1,path.GetLength(1));
                    path = Field.Add_to_list(path,start, i+1);
                    
                }// go to start
            return (path, persaption_map);
                
        }
        // doesn't work
        public static int[] basic_FF_back(int[,] map,int[,] persaption_map, int[] start){
                int[,] next_f = new int[4,2];
                int[] next_f_v = {16,16,16,16};
                int cur_field = persaption_map[start[0],start[1]];
                int cur_walls = map[start[0],start[1]];
                int d = 0;
                for (int i = 0; cur_field == persaption_map[0,0] ; i++)//start
                {
                    for (int z = 0; z < next_f_v.Length; z++)
                    {
                        next_f_v[z] = 16;
                    }
                // get cur field val
                    cur_field = persaption_map[start[1],start[0]];
                // get cur field walls
                    cur_walls = map[start[1],start[0]];
                // get the field val of fields with out wall inbetween
                // coose lowest number field (incase two have the same val pic random) it now pics the first field in that case 
                // replace with Iswall code and extract from bool array
                    if (!Field.Iswall(cur_walls,8) ){ 
                        next_f[0,0] = start[0];
                        next_f[0,1] = start[1]+1;
                        next_f_v[0] = persaption_map[next_f[0,0],next_f[0,1]];
                    }
                    if (!Field.Iswall(cur_walls,4)){ 
                        next_f[1,0] = start[0];
                        next_f[1,1] = start[1]-1;
                        next_f_v[1] = persaption_map[next_f[1,0],next_f[1,1]];
                    }
                    if (!Field.Iswall(cur_walls,1)){ 
                        next_f[2,0] = start[0]-1;
                        next_f[2,1] = start[1];
                        next_f_v[2] = persaption_map[next_f[2,0],next_f[2,1]];
                    }
                    if (!Field.Iswall(cur_walls,2)){ 
                        next_f[3,0] = start[0]+1;
                        next_f[3,1] = start[1];
                        next_f_v[3] = persaption_map[next_f[3,0],next_f[3,1]];
                    }
                
                // update cur field val := lowest number + 1
                for (int z = 0; z < next_f_v.Length; z++)
                {
                    if (next_f_v[z] < next_f_v[d]){d=z;}
                }
                if (i != 0){persaption_map[start[0],start[1]] = next_f_v[d] + 10;}
                
                // cur field := lowest number field
                start[0] = next_f[d,0];
                start[1] = next_f[d,1];
                }// go to start
            return start;
                
        }
        public static void Drawn(int[,]map, int[,] pers_m){
        int c=0;
        
        
        
        for (int i = 0; i < map.GetLength(0); i++)
        {
            
            for (int t = 0; t < map.GetLength(1); t++)
            {
                if (c == 0  && Field.Iswall(map[t,i],4))
                {
                    System.Console.Write($"+----");
                }
                
                else if (c == 0 ){
                    System.Console.Write($"+    ");
                }
                
                if (c == 1  && Field.Iswall(map[t,i],1)){
                    System.Console.Write($"| {pers_m[t,i],2} ");
                }
                else if (c == 1){
                    System.Console.Write($" {pers_m[t,i],2}  ");
                }
                if (c == 2  && Field.Iswall(map[t,i],8))
                {
                    System.Console.Write($"+----");
                }
                
                else if (c == 2 ){
                    System.Console.Write($"+    ");
                }
                
                
               
                if (t == map.GetLength(1)-1 && c == 0)
                {
                    c++;
                    t=-1;
                    System.Console.WriteLine("+");
                }
                else if (t == map.GetLength(1)-1 && i == map.GetLength(1)-1 && c == 1)
                {
                    c++;
                    t=-1;
                    System.Console.WriteLine("|");
                }
                else if (t == map.GetLength(1)-1 && ! (i == map.GetLength(1)-1)){
                    System.Console.WriteLine("|");
                }
                
                
                
            }
            if (c == 2)
            {
                System.Console.WriteLine("+");
            }
            
            c = 0;
            
            
        }
    }
    public static int[,] Clean_run(int[,] path ){
        int[,] clean_path = new int[0,2];
        int[] last_p = new int[2];
        for (int i = 0; i < path.GetLength(0); i++)
        {
            for (int z = i+1; z < path.GetLength(0); z++)
            {
                if (path[i,0] == path[z,0] && path[i,1] == path[z,1])
                {
                    i = z;
                }
            }
            last_p[0] = path[i,0];
            last_p[1] = path[i,1]; 
            Field.ResizeArray(ref clean_path, clean_path.GetLength(0)+1,clean_path.GetLength(1));
            clean_path = Field.Add_to_list(clean_path,last_p, clean_path.GetLength(0)-1);
        }
        return clean_path;
    }
     public static int[,] Clean_run_basic(int[,] path ){
        int[,] clean_path = new int[0,2];
        int[] last_p = new int[2];
        for (int i = 0; i < path.GetLength(0); i++)
        {
            for (int z = 0; z < clean_path.GetLength(0); z++)
            {
                if (!(path[i,0] == clean_path[z,0] && path[i,1] == clean_path[z,1]))
                {
                    last_p[0] = path[i,0];
                    last_p[1] = path[i,1]; 
                     Field.ResizeArray(ref clean_path, clean_path.GetLength(0)+1,clean_path.GetLength(1));
                     clean_path = Field.Add_to_list(clean_path,last_p, clean_path.GetLength(0)-1);
                }
            }
            
           
        }
        return clean_path;
    }
    }
}