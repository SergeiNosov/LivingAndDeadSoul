using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class MapGenerator {
        public string[] maps;
        public Vector2 playerEnter;
        public MapGenerator() {
           string ground ="              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" + 
                          "             F\n" +
                          "##############\n";
         string entries = "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" + 
                          "S            F\n" +
                          "              \n";
          string stairs = "        ^     \n" +
                          "        ^     \n" +
                          "        ^     \n" +
                          "        ^     \n" +
                          "        ^     \n" +
                          "        ^     \n" +
                          "        ^     \n" +
                          "              \n";
         



            string arrow = "              \n" +
                          "              \n" +
                          "       !      \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n";
   string InfoControll = "              \n" +
                         "              \n" +
                         "              \n" +
                         "              \n" +
                         "    %         \n" +
                         "   A          \n" +
                         "              \n" +
                         "              \n";

      string ExitLvls = "        E     \n" +
                        "              \n" +
                        "              \n" +
                        "              \n" +
                        "              \n" +
                        "              \n" +
                        "              \n" +
                        "              \n";

            maps = new[] { ExitLvls,InfoControll, ground, entries, stairs, arrow };
            playerEnter = new Vector2(1, 6);
        }
    }
}