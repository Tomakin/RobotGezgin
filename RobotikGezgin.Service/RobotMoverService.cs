using RobotikGezgin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RobotikGezgin.Entity.Enums;

namespace RobotikGezgin.Service
{
    public class RobotMoverService
    {
        public Surface CreateSurface(string infos)
        {
            var infoParts = infos.Split(' ');
            if (infoParts.Count() == 2 && int.TryParse(infoParts[0], out int xCoordination) &&
                int.TryParse(infoParts[1], out int yCoordination))
            {
                return new Surface(xCoordination, yCoordination);
            }
            return null;
        }

        public Robot CreateRobot(string infos, Surface surface)
        {
            var infoParts = infos.Split(' ');
            if (infoParts.Count() == 3 && int.TryParse(infoParts[0], out int xCoordination) &&
                int.TryParse(infoParts[1], out int yCoordination) &&
                char.TryParse(infoParts[2], out char direction))
            {
                return new Robot(getMax(xCoordination, surface.XCoordinationMax), getMax(yCoordination, surface.YCoordinationMax), direction);
            }
            return null;
        }

        public bool CheckTurnCommands(string? commands)
        {
            foreach (char command in commands)
            {
                TurnDirection turnDirection = (TurnDirection)command;
                var turnable = Enum.IsDefined(typeof(TurnDirection), turnDirection);
                if (!turnable)
                {
                    return false;
                }
            }
            return true;
        }

        public void MoveRobot(string commands, Robot robot, Surface surface)
        {
            foreach (char command in commands)
            {
                TurnDirection turnDirection = (TurnDirection)command;
                robot.Turn(turnDirection, surface);
            }
        }

        int getMax(int val, int maxVal)
        {
            return val > maxVal ? maxVal : val;
        }

    }
}
