using Raylib_cs;

namespace SortingAlgorithm
{
    public class Program
    {
        const int screenWidth = 800;
        const int screenHeight = 450;
        const int arrayLength = 100;
        static bool complete = false;
        static int fullSwapped=0;
        static bool paused = false;
        static void BubbleSort(int[] arr,int i)
        {
            // for(int i=0; i < (arr.Length - 1); i++)
            // {
                int temp1 = arr[i];
                int temp2 = arr[i+1];

                if(temp1>temp2)
                {
                    arr[i]=temp2;
                    arr[i+1]=temp1;
                    //swapped=true;
                    //fullSwapped=true;
                    
                }
                else{
                    if(!complete){
                    fullSwapped++;

                    }
                }
                
            //}
            
        }

        static void DrawColumns(int[] arr, int counter)
        {
            float multiplier = (float)screenHeight / (float)arr.Max();
            int width = (screenWidth/arr.Length) / 2;
            for(int i = 0; i<arr.Length; i++)
            {
                int height= (int)(arr[i] * multiplier);
                // if(complete)
                // {
                //     Raylib.DrawRectangle(2 * width * i, screenHeight - height, width, height, Color.GREEN);
                // }
                /* else*/ if(i==counter && !complete){
                    Raylib.DrawRectangle(2 * width * i, screenHeight - height, width, height, Color.RED);

                }
                else{
                    Raylib.DrawRectangle(2 * width * i, screenHeight - height, width, height, Color.WHITE);

                }
            }
        }
        static void FinishColumns(int[] arr, int i)
        {
            float multiplier = (float)screenHeight / (float)arr.Max();
            int width = (screenWidth/arr.Length) / 2;
            
            //int height = (int)(arr[i] * multiplier);
            for(int n = 0; n<=i; n++)
            {
                //Raylib.DrawRectangle(2 * width * i, screenHeight - height, width, height, Color.GREEN);
                int height = (int)(arr[n] * multiplier);
                Raylib.DrawRectangle(2 * width * n, screenHeight - height, width, height, Color.GREEN);
                if(n==arr.Length-1){
                    paused=true;
                }
            }
            
        }
        

        public static void Main()
        {
            Random rnd = new Random();
            int[] array = new int[arrayLength];
            for(int i=0; i<arrayLength; i++)
            {
                array[i] = rnd.Next(1,arrayLength+1);
            }
            
            
            Raylib.InitWindow(screenWidth, screenHeight, "Bubble Sort");
            //Raylib.SetTargetFPS(240);
            int counter = 0;
            complete=false;
            while(!Raylib.WindowShouldClose() )
            {
                
                Raylib.BeginDrawing();
                if(!paused)
                {
                    Raylib.ClearBackground(Color.BLACK);
                    BubbleSort(array, counter);
                    counter++;
                    if(!complete)
                    {
                        DrawColumns(array, counter);
                    }
                    if(complete)
                    {
                        FinishColumns(array, counter);
                        fullSwapped=0;
                    
                        //make stop everything after counter = 99
                    }
                    // else{
                    
                    // }
                    if(fullSwapped==array.Length-1)
                    {
                        complete=true;
                        counter=0;
                    }
                    else if(counter==array.Length-1 && fullSwapped!=array.Length-1){
                        fullSwapped=0;
                    }
                    if(counter==array.Length-1){
                        counter=0;
                        // if(swapped==false){
                        //     complete=true;
                        // }
                    }
                }
                
                Raylib.EndDrawing();
                
            }
            Raylib.CloseWindow();
        }
    }
}
