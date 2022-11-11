using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotikGezgin.Entity
{
    public class Surface
    {
        public int XCoordinationMax;
        public int YCoordinationMax;

        public Surface(int xCoordinationMax, int yCoordinationMax)
        {
            XCoordinationMax = xCoordinationMax;
            YCoordinationMax = yCoordinationMax;
        }

        public Surface()
        {

        }
    }
}
