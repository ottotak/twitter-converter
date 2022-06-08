using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args )
    {

        if (args.Length != 0)
        {
            try
            {
                string d = args[args.Length-1];
                int n = 0;
                for(int i = 0; i < d.Length; i++)if (d[i] == '\\')n = i;
                string dir = "";
                for (int i = 0; i < n; i++) dir += d[i];
                Environment.CurrentDirectory = dir;
                Console.WriteLine(dir);
                string s = $"ffmpeg -i \"{args[args.Length-1]}\" -c:v libx264 -c:a aac -vf fps=30 -aspect 16:9 \"{args[args.Length-1].Replace(dir+"\\","")}-converted.mp4\"&exit";
                ExecCmd(s);
            }
            catch(Exception e)
            {
                Console.WriteLine("エラーが発生しました。\n"+e.ToString());
            }
        }
    }
    public static void ExecCmd(string s) => Process.Start(new ProcessStartInfo("cmd.exe","/k"+s));
}