using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class MapGenerator3
    {
        public string[] maps;
        public Vector2 playerEnter;
        public Texture2D backgroundLose;
        public Texture2D backgroundHappy;
        public MapGenerator3()
        {
            string ground = "<             >\n" +
                          "<              >\n" +
                          "<              >\n" +
                          "<              >\n" +
                          "<              >\n" +
                          "<              >\n" +
                           "####CC####CC#\n";
            string entries = "              \n" +
                             "              \n" +
                             "              \n" +
                             "              \n" +
                             "              \n" +
                             "              \n" +
                             "S            F\n" +
                             "              \n";
            string stairs = "           ^     ^\n" +
                            "           ^  \n" +
                            "           ^  \n" +
                            "           ^  \n" +
                            "           ^  \n" +
                            "           ^  \n" +
                            "              \n" +
                            "              \n";




            string arrow = "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n" +
                          "              \n";
            string InfoControll = "              \n" +
                                  "              \n" +
                                  "              \n" +
                                  "              \n" +
                                  "              \n" +
                                  "             \n" +
                                  "              \n" +
                                  "              \n";

            string ExitLvls = "              \n" +
                              "              \n" +
                              "              \n" +
                              "              \n" +
                              "              \n" +
                              "              \n" +
                              "             E\n" +
                              "              \n";

            maps = new[] { ExitLvls, InfoControll, ground, entries, stairs, arrow };
            playerEnter = new Vector2(1, 3);
        }

    }
}
