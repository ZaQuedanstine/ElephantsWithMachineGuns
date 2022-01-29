using System;

namespace ElaphantsWithMachineGuns
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ElephantGame())
                game.Run();
        }
    }
}
