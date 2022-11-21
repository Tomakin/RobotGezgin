using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotikGezgin.Entity.Enums;

namespace RobotikGezgin.Entity
{
    public class Robot
    {
        private char[] PossibleDirections;
        int XCoordination;
        int YCoordination;
        char Direction;

        public Robot(int xCoordination, int yCoordination, char direction)
        {
            XCoordination = xCoordination;
            YCoordination = yCoordination;
            Direction = direction;
            PossibleDirections = new char[] { 'N', 'E', 'S', 'W' };
        }

        public void Turn(TurnDirection turnDirection, Surface surface)
        {
            var directionIndex = PossibleDirections.ToList().IndexOf(Direction);
            if (turnDirection == TurnDirection.LEFT)
            {
                if (directionIndex == 0)
                {
                    Direction = PossibleDirections[PossibleDirections.Length - 1];
                    return;
                }
                Direction = PossibleDirections[directionIndex - 1];
            }
            else if (turnDirection == TurnDirection.RIGHT)
            {
                if (directionIndex == PossibleDirections.Length - 1)
                {
                    Direction = PossibleDirections[0];
                    return;
                }
                Direction = PossibleDirections[directionIndex + 1];
            }
            else
                Move(surface);

            return;
        }

        public void Move(Surface surface)
        {
            switch (Direction)
            {
                case 'N':
                    if (YCoordination < surface.YCoordinationMax)
                        YCoordination++;
                    break;
                case 'E':
                    if (XCoordination < surface.XCoordinationMax)
                        XCoordination++;
                    break;
                case 'S':
                    if (YCoordination > 0)
                        YCoordination--;
                    break;
                case 'W':
                    if (XCoordination > 0)
                        XCoordination--;
                    break;
                default:
                    break;
            }
        }


        public void WriteStatus()
        {
            Console.WriteLine($"{XCoordination} {YCoordination} {Direction}");
        }
    }
}
