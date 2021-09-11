using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Building
    {
        int numFloors;
        RoofMaterials roofMaterial;
        WallMaterials wallMaterial;
        string address;
        
        public enum RoofMaterials{
            Wood,
            Tile,
            Brick,
            Stone
        }

        public enum WallMaterials {
            Wood,
            Brick,
            Stone
        }

        public int NumFloors {
            get => numFloors;
            set
            {
                if (value < 0)
                    throw new Exception("Не верное количество этажей");
                else
                    numFloors = value;
            }
        }

        protected RoofMaterials RoofMaterial { get => roofMaterial; set => roofMaterial = value; }
        protected WallMaterials WallMaterial { get => wallMaterial; set => wallMaterial = value; }

        public string Address { get => address; set => address = value; }

        public Building(string address, int numFloors, RoofMaterials roof, WallMaterials wall)
        {
            this.address = address;
            this.numFloors = numFloors;
            this.roofMaterial = roof;
            this.wallMaterial = wall;

        }
    }
}
