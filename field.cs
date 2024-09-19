using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Mouse_codeonly
{
    public class Field
    {
        public static int[,] Generate_map(){
            int[,] map = new int[16,16]; // {{{U;R;D;L}..}..} map[i,t,d]
            int[,] active_list = new int[0,2];
            int[,] donttouch = new int[0,2];
            Random rnd = new();
            int[] start_point = {7,7};
            int[] midpoint = {0,0};
            int[] relativedir = new int[2];
            int dir;
            int[,] treversal = new int[16,16];
            int randomnum;


            //start generator
            switch (rnd.Next(1,5))
            {
                case 1:

                break;

                case 2:
                
                    start_point[1] = 8;
                
                break;

                case 3:
                
                    start_point[0] = 8;
                break;

                case 4:
                    start_point[0] = 8;
                    start_point[1] = 8;
                break;
                    
                
            }
               for (int i = 0; i < 16; i++)
               {
                   for (int t = 0; t < 16; t++)
                   {
                        map[i,t]=15;
                   }
               }
            
                
                if (map[start_point[0],start_point[1]] == 1 && (rnd.Next(0,2) == 1 ))
                {
                    map[start_point[0],start_point[1]] = 0;
                    
                }

            ResizeArray(ref active_list, active_list.GetLength(0)+1,active_list.GetLength(1));
            active_list = Add_to_list(active_list,start_point, 0);
            int counts_sometimes = 0;
            int[] states = {5,9,6,10};
                int[] a = new int[2];
     
                
                for (int x = 7; x < 9; x++)
                {
                    
                    for (int t = 7; t < 9; t++)
                {
                    
                        map[x,t] = states[counts_sometimes];
                        a[0] = x;
                        a[1] = t;
                        
                    
                    ResizeArray(ref donttouch, donttouch.GetLength(0)+1,donttouch.GetLength(1));
                        donttouch = Add_to_list(donttouch, a, counts_sometimes);
                    
                    counts_sometimes += 1;
                }
                
                }



            
            randomnum = rnd.Next(0,active_list.GetLength(0));
                start_point[0] = active_list[randomnum,0];
                start_point[1] = active_list[randomnum,1];

            for (int i = 0; i < (map.GetLength(0)*map.GetLength(1)-1)-3; i++)
            {
                Array.Copy( start_point, midpoint, 2 );

                


                dir = rnd.Next(1,5);
                switch (dir){
                    case 1: // left
                     start_point[0] -= 1;
                    break;
                    case 2: // right
                     start_point[0] += 1;
                    break;
                    case 3: // up
                     start_point[1] -= 1;
                    break;
                    case 4: // down
                     start_point[1] += 1;
                    break;
                }
                
            
                
                    if (start_point[0] > 15 ) //|| start_point[0] < 0 || start_point[1] > 15 || start_point[1] < 0
                        {
                            start_point[0] = 15;
                        }
                    else if (start_point[0] < 0 ) //|| start_point[0] < 0 || start_point[1] > 15 || start_point[1] < 0
                        {
                            start_point[0] = 0;
                        }
                    else if (start_point[1] < 0 ) //|| start_point[0] < 0 || start_point[1] > 15 || start_point[1] < 0
                        {
                            start_point[1] = 0;
                        }
                    else if (start_point[1] > 15 ) //|| start_point[0] < 0 || start_point[1] > 15 || start_point[1] < 0
                        {
                            start_point[1] = 15;
                        }
                    
                    


                counts_sometimes = 0;
                for (int x = 0; x < donttouch.GetLength(0); x++)
                {
                    
                        
                        
                         if (start_point[0] == donttouch[x,0] && start_point[1] == donttouch[x,1]){
                            counts_sometimes = 1;
                            start_point[0]= midpoint[0];
                            start_point[1]= midpoint[1];
                        }
                    
                }
                if (counts_sometimes == 0  ){
                    for (int x = 0; x < active_list.GetLength(0); x++)
                    {
                        
                            if (start_point[0] == active_list[x,0] && start_point[1] == active_list[x,1])
                            {
                                
                                counts_sometimes = 1;
                                randomnum = rnd.Next(1,active_list.GetLength(0));
                                start_point[0] = active_list[randomnum,0];
                                start_point[1] = active_list[randomnum,1];

                            }
                            
                        
                    }
                
                }
                

                if (counts_sometimes == 1  )
                {
               
                   
                   
                   i--;
                
                }
                else{
                    ResizeArray(ref active_list, active_list.GetLength(0)+1,active_list.GetLength(1));
                    active_list = Add_to_list(active_list,start_point, i+1);
                    
                    // set walls 
                    
                        treversal[start_point[0],start_point[1]] = i;
                        relativedir[0] = midpoint[0]- start_point[0];
                        relativedir[1] =midpoint[1]- start_point[1];
                        
                        switch (relativedir[0])
                        {
                            case 1: //R
                                map[midpoint[0],midpoint[1]] -= 1;
                                
                                map[start_point[0],start_point[1]] -= 2;
                                
                                break;
                            case -1: //L
                                map[midpoint[0],midpoint[1]] -= 2;
                                
                                map[start_point[0],start_point[1]] -= 1;
                                
                                break;

                            default:
                            break;
                        }
                        switch (relativedir[1])
                        {
                            case -1: //U
                                map[midpoint[0],midpoint[1]] -= 8;
                                
                                map[start_point[0],start_point[1]] -= 4;
                                
                                
                                break;
                            case 1: //D
                                map[midpoint[0],midpoint[1]] -= 4;
                                
                                map[start_point[0],start_point[1]] -= 8;
                                
                                break;

                            default:
                            break;
                        }
                        

                        

                    
                    
                }

                
            }

            return map;
        }
        public static int[,] Add_to_list(int[,] active_list, int[] point, int index){
            
            for (int i = 0; i < point.Length; i++)
            {
                active_list[index,i] = point[i];
            }
            return active_list;
        }
        public static void ResizeArray<T>(ref T[,] original, int newCoNum, int newRoNum)
    {
        var newArray = new T[newCoNum,newRoNum];
        int columnCount = original.GetLength(1);
        int columnCount2 = newRoNum;
        int columns = original.GetUpperBound(0);
        for (int co = 0; co <= columns; co++)
            Array.Copy(original, co * columnCount, newArray, co * columnCount2, columnCount);
        original = newArray;
    }
    public static void Drawn(int[,]map, int[,] points){
        int c=0;
        bool flag = false;
       
        
        
        
        for (int i = 0; i < map.GetLength(0); i++)
        {
            
            for (int t = 0; t < map.GetLength(1); t++)
            {
                if (c == 0  && Iswall(map[t,i],4))
                {
                    System.Console.Write($"+----");
                }
                
                else if (c == 0 ){
                    System.Console.Write($"+    ");
                }
                // Console.WriteLine(points[count,0]);
                for (int count = 0; count < points.GetLength(0); count++)
                {
                    
                if (points[count,0] == t && points[count,1] == i){
                if (c == 1  && Iswall(map[t,i],1)){
                    System.Console.Write($"| xx ");
                    
                    flag= true;
                }
                    
                else if (c == 1){
                    System.Console.Write($"  xx ");
                    
                    flag = true;
                }
                
                }
                }
                if (!flag)
                {
                    if (c == 1  && Iswall(map[t,i],1)){
                    System.Console.Write($"|    ");
                    }
                    else if (c == 1){
                        System.Console.Write($"     ");
                    }
                    if (c == 2  && Iswall(map[t,i],8))
                    {
                        System.Console.Write($"+----");
                    }
                    
                    else if (c == 2 ){
                        System.Console.Write($"+    ");
                    }
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
                
                flag = false;
                
            }
            if (c == 2)
            {
                System.Console.WriteLine("+");
            }
            
            c = 0;
            
            
        }
    }
    public static int Dirs(char direction){
        direction = char.ToUpper(direction);
        int dir=0;
        switch (direction)
        {
            
            case 'U':
            dir = 4;
            break;
            case 'D':
            dir = 8;
            break;
            case 'L':
            dir = 1;
            break;
            case 'R':
            dir = 2;
            break;
        }
         return dir;
    }

   
    public static bool Iswall(int value, int w_num){
        int[] walls = {8,4,2,1};
        bool[] wallsb = new bool[4];
        for (int i = 0; i < walls.Length; i++)
        {
            if (value - walls[i] > -1) {
                value -= walls[i];
                wallsb[i] = true;
            }
            else{
                wallsb[i] = false;
            }
            
        }

        for (int t = 0; t < walls.Length; t++)
        {
            if (w_num == walls[t] && wallsb[t]){
                return true;
            }
            
        }
        return false;
        
    }
    }
    
}