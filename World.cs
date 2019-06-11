using System;
using System.Collections.Generic;
using System.Text;

namespace RpgStatSystem
{
    public class World<T> where T : Character, new()
    {
        public static World<T> Instance { get; private set; }
        public Random Random { get; private set; }
        public IBattleLog BattleLog { get; private set; }

        public World(int worldWidth=0, int worldHeight=0, IBattleLog battleLog=null)
        {
            if (Instance != null) throw new InvalidOperationException("World class is a singleton and must not be constructed more than once!");
            Instance = this;
            BattleLog = battleLog;
            Random = new Random();
            Enemies = new List<T>();
            Width = worldWidth;
            Height = worldHeight;
        }

        public void Update (float frameTime, long frame, TimeSpan runTime)
        {
            FrameTime = frameTime;
            Frame = frame;
            RunTime = runTime;

            // Remove dead enemies
            // Since we are removing elements from the list we must iterate backwards
            for (int i = Enemies.Count - 1; i > -1; i--)
            {
                var e = Enemies[i];
                if (e.Dead) Enemies.RemoveAt(i);                
            }

            // Update loop
            // Doing this seperatley requires a second enumeration of the
            // collection but we gain the performance back by not needing
            // to filter out dead enemies later
            foreach (var enemy in Enemies) enemy.Update(frameTime, frame, runTime);
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<T> Enemies { get; set; }        

        public float FrameTime { get; private set; }
        public long Frame { get; private set; }
        public TimeSpan RunTime { get; private set; }
    }
}
