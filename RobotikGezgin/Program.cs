﻿// See https://aka.ms/new-console-template for more information
using RobotikGezgin.Entity;
using RobotikGezgin.Service;

var service = new RobotMoverService();

// Get surface datas
Console.WriteLine("Yüzey bilgilerini girin");
string? surfaceInfos = Console.ReadLine();
Surface surface = service.CreateSurface(surfaceInfos);

// Validate surface
while (surface == null || !surface.ValidateInfos())
{
    Console.WriteLine("Alan bilgileri doğru değil.");
    surfaceInfos = Console.ReadLine();
    surface = service.CreateSurface(surfaceInfos);
}

// Get first robots infos
Console.WriteLine("İlk robotun bilgilerini giriniz.");
string? firstRobotInfos = Console.ReadLine();
Robot firstRobot = service.CreateRobot(firstRobotInfos, surface);

// Validate Robot
while (!firstRobot.ValidateInfos())
{
    Console.WriteLine("Robot bilgileri hatalı. LÜtfen tekrar giriniz.");
    firstRobotInfos = Console.ReadLine();
    firstRobot = service.CreateRobot(firstRobotInfos, surface);
}

// Move/Turn first robot
Console.WriteLine("İlk robotun hareketini giriniz.");
string? firstRobotMovements = Console.ReadLine();

// First robot turnable control
bool firstRobotIsTurnable = false;
while (!firstRobotIsTurnable)
{

    firstRobotIsTurnable = service.CheckTurnCommands(firstRobotMovements);
    if (!firstRobotIsTurnable)
    {
        Console.WriteLine("Girdiğiniz komutlarda hata var. Lütfen kontrol ederek tekrar giriniz");
        firstRobotMovements = Console.ReadLine();
    }
}
service.MoveRobot(firstRobotMovements, firstRobot, surface);

// Get second robot infos
Console.WriteLine("İkinci robotun bilgilerini giriniz.");
string? secondRobotInfos = Console.ReadLine();
Robot secondRobot = service.CreateRobot(secondRobotInfos, surface);

// Move/Turn second robot
Console.WriteLine("İkinci robotun hareketini giriniz.");
string? secondRobotMovements = Console.ReadLine();

// Second robot turnable control
bool secondRobotIsTurnable = false;
while (!secondRobotIsTurnable)
{
    secondRobotIsTurnable = service.CheckTurnCommands(secondRobotMovements);
    if (!secondRobotIsTurnable)
    {
        Console.WriteLine("Girdiğiniz komutlarda hata var. Lütfen kontrol ederek tekrar giriniz");
        secondRobotMovements = Console.ReadLine();
    }
}
service.MoveRobot(secondRobotMovements, secondRobot, surface);

// Output first robot status
firstRobot.WriteStatus();

// Output second robot status
secondRobot.WriteStatus();