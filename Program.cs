using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks.Dataflow;
using RandomSoccerPlayer;

string PromptString(string prompt)
{
    Console.WriteLine(prompt);
    var userInput = Console.ReadLine();

    return userInput;
}
int PromptNum(string prompt)



{
    Console.WriteLine(prompt);
    int userInput;
    var isThisANumber = Int32.TryParse(Console.ReadLine(), out userInput);

    if (isThisANumber)
    {
        return userInput;
    }
    else
    {

        Console.WriteLine("A number must be entered. But number {0} is the default number now.");
        return 0;
    }


}

void Greetings()
{

    Console.WriteLine("-----------------------------");
    Console.WriteLine("");
    Console.WriteLine(" Welcome to Ed's Soccer Player Registry ");
    Console.WriteLine("");
    Console.WriteLine("_____________________________");

}

Greetings();
var soccerPlayers = new List<SoccerPlayer>();




bool menuKeepGoing = true;


while (menuKeepGoing)
{
    Console.WriteLine();
    Console.WriteLine($"Menu Player options: \n(A)Add Player \n(S)how All Players \n(F)ind Player by Name \n(D)elete \n(U)pdate a Player \n(Q)Quit");
    var userMenuInput = Console.ReadLine().ToUpper();


    if (userMenuInput == "Q")
    {
        menuKeepGoing = false;
    }
    else if (userMenuInput == "D")
    {
        DeleteSoccerPlayer(soccerPlayers);

    }
    else if (userMenuInput == "A")
    {
        AddSoccerPlayer(soccerPlayers);
    }
    else if (userMenuInput == "U")
    {
        UpdateSoccerPlayer(soccerPlayers);

    }
    else if (userMenuInput == "F")
    {
        FindSoccerPlayerByName(soccerPlayers);

    }
    else if (userMenuInput == "S")
    {
        ShowEverySoccerPlayer(soccerPlayers);

    }



}

void DeleteSoccerPlayer(List<SoccerPlayer> soccerPlayers)
{
    var nameToDelete = PromptString("What Player by Name are you trying to delete?");

    SoccerPlayer nameSearchDelete = soccerPlayers.FirstOrDefault(value => value.name == nameToDelete);

    if (nameSearchDelete == null)
    {
        Console.WriteLine("No such name was found.");
    }
    else
    {
        Console.WriteLine($"Deleting {nameSearchDelete.name} ");

        soccerPlayers.Remove(nameSearchDelete);
    }
}

void SoccerPlayerName(SoccerPlayer foundName)
{
    var newName = PromptString($"what new name are you trying to Give the Player?: ");
    foundName.name = newName;

    Console.WriteLine($"Your New name for the Player is {newName} ");
}

void UpdateSoccerPlayer(List<SoccerPlayer> soccerPlayers)
{
    var nameToUpdate = PromptString("What Player are you updating? Search by name: ");

    SoccerPlayer foundName = soccerPlayers.FirstOrDefault(value => value.name == nameToUpdate);

    if (foundName == null)
    {
        Console.WriteLine("No name was found");
    }
    else if (nameToUpdate == foundName.name)
    {

        Console.WriteLine($"We will be Updating {foundName.name}");


        bool updatePlayerMenu = true;
        while (updatePlayerMenu)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to change the Players: \n(N)ame, \n(P)osition \n(F)Left/Right Footed \n(A)ge \n(Q)uit");
            var userInput = Console.ReadLine().ToUpper();

            if (userInput == "Q")
            {
                updatePlayerMenu = false;
            }
            else if (userInput == "N")
            {
                SoccerPlayerName(foundName);

            }
            else if (userInput == "F")
            {
                var userFoot = PromptString("What Player name will we be changing the Main Playing Foot?: ");
                SoccerPlayer footName = soccerPlayers.FirstOrDefault(value => value.name == userFoot);

                if (footName == null)
                {
                    Console.WriteLine("No, Player found");
                }
                else if (userFoot == footName.name)
                {
                    Console.WriteLine($"We are Updating {footName.name} Main Foot which is {footName.leftOrRightFooted}");
                    bool footMenu = true;
                    var footUserinputFoot = PromptString("What foot does your Player mainly NOW Use? \n(L)eft Footed / (R)ight Footed Or (Q)uit").ToUpper();
                    var leftOrRight = Console.ReadLine().ToUpper();

                    if (leftOrRight == "Q")
                    {
                        footMenu = false;
                    }
                    else if (leftOrRight == "L")
                    {


                        footName.leftOrRightFooted = "Left Footed";
                    }
                    else if (leftOrRight == "R")
                    {

                        footName.leftOrRightFooted = "Right Footed";
                    }

                }
            }
            else if (userInput == "A")
            {
                var userName = PromptString("what player name are you looking to change the Age?: ");

                SoccerPlayer findName = soccerPlayers.FirstOrDefault(value => value.name == userName);

                if (findName == null)
                {
                    Console.WriteLine("NO such name was found. ");
                }
                else if (userName == findName.name)
                {
                    Console.WriteLine($"We will change {findName.name} which is currently Age:{findName.age}");

                    Console.WriteLine("");
                    var newAge = PromptNum("What is the new Age?: ");

                    findName.age = newAge;


                }

            }
            else if (userInput == "P")
            {
                var userName = PromptString("What is the Player's name that you are you trying to change the Position?");
                SoccerPlayer positionName = soccerPlayers.FirstOrDefault(value => value.name == userName);

                if (positionName == null)
                {
                    Console.WriteLine("No, such Player Name found");
                }
                else if (userName == positionName.name)
                {
                    Console.WriteLine($"We will be changing {positionName.name} which Plays in Position:{positionName.position}");
                    Console.WriteLine("");
                    Console.WriteLine("What is the New Position?: (1)GoalKeeper \n(2)Left Defender (3)Right Defender (4)Center Defender \n(5)Center Midfield (6)Left Midfielder (7)Right Midfielder \n(8)Forward ");
                    var positionChoice = Convert.ToDouble(Console.ReadLine().ToUpper());


                    if (positionChoice == 1)
                    {
                        positionName.position = "Goal Keeper";

                    }
                    else if (positionChoice == 2)
                    {
                        positionName.position = "Left Defender";
                    }
                    else if (positionChoice == 3)
                    {
                        positionName.position = "Right Defender";

                    }
                    else if (positionChoice == 4)
                    {
                        positionName.position = "Center Defender";

                    }
                    else if (positionChoice == 5)
                    {
                        positionName.position = "Center Midfield";

                    }
                    else if (positionChoice == 6)
                    {
                        positionName.position = "Left Midfielder";

                    }
                    else if (positionChoice == 7)
                    {
                        positionName.position = "Right Midfielder";

                    }
                    else if (positionChoice == 8)
                    {
                        positionName.position = "Forward";
                    }




                }



            }



        }
    }
}

void AddSoccerPlayer(List<SoccerPlayer> soccerPlayers)
{
    var soccerPlayer = new SoccerPlayer();
    soccerPlayer.name = PromptString("What is your name?");
    soccerPlayer.age = PromptNum("what is Players Age?");

    Console.WriteLine("What is your position? (1)GoalKeeper \n(2)Left Defender (3)Right Defender (4)Center Defender \n(5)Center Midfield (6)Left Midfielder (7)Right Midfielder \n(8)Forward");
    var positionChoice = Convert.ToDouble(Console.ReadLine().ToUpper());
    if (positionChoice == 1)
    {
        soccerPlayer.position = "Goal Keeper";

    }
    else if (positionChoice == 2)
    {
        soccerPlayer.position = "Left Defender";
    }
    else if (positionChoice == 3)
    {
        soccerPlayer.position = "Right Defender";

    }
    else if (positionChoice == 4)
    {
        soccerPlayer.position = "Center Defender";

    }
    else if (positionChoice == 5)
    {
        soccerPlayer.position = "Center Midfield";

    }
    else if (positionChoice == 6)
    {
        soccerPlayer.position = "Left Midfielder";

    }
    else if (positionChoice == 7)
    {
        soccerPlayer.position = "Right Midfielder";

    }
    else if (positionChoice == 8)
    {
        soccerPlayer.position = "Forward";
    }






    Console.WriteLine("Is the Player (R)ight or (L)eft footed? ");
    var leftOrRightFootUserInput = Console.ReadLine().ToUpper();

    if (leftOrRightFootUserInput == "R")
    {

        soccerPlayer.leftOrRightFooted = "Right Footed";




        //leftOrRightFootUserInput = soccerPlayer.leftOrRightFooted;
        //soccerPlayer.leftOrRightFooted = leftOrRightFootUserInput;
    }
    else if (leftOrRightFootUserInput == "L")

    {
        soccerPlayer.leftOrRightFooted = "Left Footed";
    }
    soccerPlayers.Add(soccerPlayer);
}

void FindSoccerPlayerByName(List<SoccerPlayer> soccerPlayers)
{
    var nameFind = PromptString($"What is the name of the player you're trying to find?:  ");

    SoccerPlayer foundSoccerPlayer = soccerPlayers.FirstOrDefault(value => value.name == nameFind);



    if (foundSoccerPlayer == null)
    {

        Console.WriteLine("No such Player exist");

    }
    else
    {
        Console.WriteLine($"found Player {foundSoccerPlayer.name} and his Age: {foundSoccerPlayer.age}. \nAlso, their Position {foundSoccerPlayer.position} and what foot they mainly use {foundSoccerPlayer.leftOrRightFooted}");
    }
}

static void ShowEverySoccerPlayer(List<SoccerPlayer> soccerPlayers)
{
    foreach (var Player in soccerPlayers)
    {
        Console.WriteLine($"We have Player {Player.name} with an Age of {Player.age} and \nthey are {Player.leftOrRightFooted} and their Position is {Player.position}");
    }
}