using System;

namespace BookClub
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the application 
            BookClubApplication app = new BookClubApplication("./BookClub/Resources/");
            //Then call run for user input
            app.Run();
        }
    }
}
