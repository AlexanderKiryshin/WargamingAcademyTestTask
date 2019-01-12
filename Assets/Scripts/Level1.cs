﻿using Assets.Blocks;
using UnityEngine;
namespace Assets.Scripts
{
   public class Level1
    {
       private const int HEIGHT_FIELD = 5;
        private const int WIDTH_FIELD = 5;
       public static void LoadLevel()
        {
            GameField.ClearGamefield();
            GameField.AddBlockOnGamefield( new ColorBlock(Color.Green, new Vector3(-2, -2,-1)));
            GameField.AddBlockOnGamefield(new UnMovableBlock(new Vector3(-1, -2, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Yellow, new Vector3(0, -2, -1)));
            GameField.AddBlockOnGamefield(new UnMovableBlock(new Vector3(1, -2, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Green, new Vector3(2, -2, -1)));

            GameField.AddBlockOnGamefield(new ColorBlock(Color.Red, new Vector3(-2, -1, -1)));
            GameField.AddBlockOnGamefield(new EmptyBlock(new Vector3(-1, -1, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Yellow, new Vector3(0, -1, -1)));
            GameField.AddBlockOnGamefield(new EmptyBlock(new Vector3(1, -1, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Green, new Vector3(2, -1, -1)));

            GameField.AddBlockOnGamefield(new ColorBlock(Color.Yellow, new Vector3(-2, 0, -1)));
            GameField.AddBlockOnGamefield(new UnMovableBlock( new Vector3(-1, 0, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Red, new Vector3(0, 0, -1)));
            GameField.AddBlockOnGamefield(new UnMovableBlock(new Vector3(1, 0, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Red, new Vector3(2, 0, -1)));

            GameField.AddBlockOnGamefield(new ColorBlock(Color.Green, new Vector3(-2, 1, -1)));
            GameField.AddBlockOnGamefield(new EmptyBlock( new Vector3(-1, 1, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Green, new Vector3(0, 1, -1)));
            GameField.AddBlockOnGamefield(new EmptyBlock(new Vector3(1, 1, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Yellow, new Vector3(2, 1, -1)));

            GameField.AddBlockOnGamefield(new ColorBlock(Color.Red, new Vector3(-2,2, -1)));
            GameField.AddBlockOnGamefield(new UnMovableBlock(new Vector3(-1, 2, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Red, new Vector3(0, 2, -1)));
            GameField.AddBlockOnGamefield(new UnMovableBlock(new Vector3(1, 2, -1)));
            GameField.AddBlockOnGamefield(new ColorBlock(Color.Yellow, new Vector3(2, 2, -1)));
            GameField.Goals = new Goal[3];
            GameField.Goals[0] = new Goal(Color.Yellow, new Vector3(-2, 3));
            GameField.Goals[1] = new Goal(Color.Green, new Vector3(0, 3));
            GameField.Goals[2] = new Goal(Color.Red, new Vector3(2, 3));
        }
    }
}
