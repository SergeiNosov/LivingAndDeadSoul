using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class MapGenerator {
        public string map;
        public Vector2 playerEnter;
        public MapGenerator() {
            map =  "              \n" +
                   "              \n" +
                   "              \n" +
                   "              \n" +
                   "              \n"+
                   "              \n" + 
                   "             F\n"+
                   "##############\n";
            playerEnter = new Vector2(1, 6);
        }
        public static string Gen() {
            return "              \n" +
                   "              \n" +
                   "              \n" +
                   "              \n" +
                   "              \n"+
                   "              \n" + 
                   "S            F\n"+
                   "##############\n";
        }
        public static string Gen2() {
            return "\n" +
                   "\n" +
                   "\n" +
                   "\n" +
                   "\n" +
                   "\n" +
                   "   G\n" +
                   "\n";
        }  
    }
}