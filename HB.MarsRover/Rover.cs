using System;
using HB.MarsRover.Enums;

namespace HB.MarsRover
{
    public class Rover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Directions Direction { get; private set; }
        public ISurface Surface { get; }

        public Rover(int x, int y, Directions direction, ISurface surface)
        {
            X = x;
            Y = y;
            Direction = direction;
            Surface = surface;
        }

        public void Move(Movements movement)
        {
            switch (movement)
            {
                case Movements.L:
                    TurnLeft();
                    break;
                case Movements.R:
                    TurnRight();
                    break;
                case Movements.M:
                    MoveForward();
                    break;
                default:
                    throw new Exception("unknown movement command");
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {

                case Directions.N:
                    if (Y + 1 <= Surface.Size.SurfaceModel.Height)                 //yeryüzü kontrolu yapılıyor ki rover yeryüzünün dışına çıkmasın
                        Y += 1;
                    break;

                case Directions.E:
                    if (X + 1 <= Surface.Size.SurfaceModel.Width)
                        X += 1;
                    break;

                case Directions.S:
                    if (Y - 1 >= 0)
                        Y -= 1;
                    break;

                case Directions.W:
                    if (X - 1 >= 0)
                        X -= 1;
                    break;
         
            }
        }


        private void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;

                case Directions.W:
                    Direction = Directions.S;
                    break;

                case Directions.S:
                    Direction = Directions.E;
                    break;

                case Directions.E:
                    Direction = Directions.N;
                    break;
               
            }
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;

                case Directions.E:
                    Direction = Directions.S;
                    break;

                case Directions.S:
                    Direction = Directions.W;
                    break;

                case Directions.W:
                    Direction = Directions.N;
                    break;
               
            }
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction.ToString()}";
        }
    }
}