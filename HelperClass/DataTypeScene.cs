using System;
namespace LivingAndDeadSoul.HelperClass
{
    public class DataTypeScene
    {
     

        public string GetTypeMode(int id)
        {

            switch(id)
            {
                case 1: {

                        return "Shelter";
                    }
                    break;
                case 2:
                    {

                        return "City";
                    }
                    break;
            }

            return "null";
        }

    }
}
