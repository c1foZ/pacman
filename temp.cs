// var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
// var stepMs = 2000;
// long now;
// var i = 0;
// ConsoleKey? lastKeyPress = null;
// while (true)
// {
//     ++i;
//     if (Console.KeyAvailable)
//     {
//         var cmd = Console.ReadKey(false).Key;
//         lastKeyPress = cmd;
//     }
//     Thread.Sleep(5);
//     now = DateTimeOffset.Now.ToUnixTimeMilliseconds();
//     if (now - startTime <= stepMs)
//     {
//         continue;
//     }
//     startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
//     System.Console.WriteLine(DateTimeOffset.Now);
//     System.Console.WriteLine(i);
//     if (lastKeyPress != null)
//     {
//         System.Console.WriteLine("last press: " + lastKeyPress);
//         lastKeyPress = null;
//     }

// }