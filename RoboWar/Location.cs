using System;
namespace RoboWar
{
    /// <summary>
    /// Controls the location of the Robot.
    /// </summary>
    public class Location
    {
        private int _X { get; set; }
        private int _Y { get; set; }
        private Directions _Direction { get; set; }

        /// <summary>
        /// Location Constructor
        /// </summary>
        /// <param name="positionalParams"></param>
        /// <exception cref="InvalidDataException"></exception>
        public Location(string[] positionalParams)
        {
            if (positionalParams.Length == 3)
            {
                _X = Convert.ToInt32(positionalParams[0]);
                _Y = Convert.ToInt32(positionalParams[1]);
                _Direction = Enum.Parse<Directions>(positionalParams[2]);
            }
            else
            {
                throw new InvalidDataException("Invalid positional information provided. Please enter valid details.");
            }
        }

        /// <summary>
        /// Follows the commands and prints the position.
        /// </summary>
        /// <param name="envDimensions"></param>
        /// <param name="commands"></param>
        public string FollowCommands(int[] envDimensions, string commands)
        {
            var lst = CreateCircularList();
            RotateOrTraverse(commands, lst);
            if (_X < 0 || _X > envDimensions[0] || _Y < 0 || _Y > envDimensions[1])
            {
                throw new Exception($"Position should be within limits of (0 , 0) and ({envDimensions[0]} , {envDimensions[1]})");
            }
           return $"{_X} {_Y} {_Direction.ToString()}";
        }

        /// <summary>
        /// Creates the circular list for directions N, E, S, W.
        /// </summary>
        /// <returns></returns>
        private CircularList CreateCircularList()
        {
            CircularList clst = new();
            foreach (int direction in Enum.GetValues(typeof(Directions)))
            {
                clst.InsertAtEnd((int)direction);
            }
            return clst;
        }

        /// <summary>
        /// Moves one step in the direction.
        /// </summary>
        private void Move()
        {
            switch (_Direction)
            {
                case Directions.N: _Y += 1; break;
                case Directions.S: _Y -= 1; break;
                case Directions.E: _X += 1; break;
                case Directions.W: _X -= 1; break;
                default: break;
            }
        }

        /// <summary>
        /// Traverse through out the circular list to achieve the rotation by 90 degrees.
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="lst"></param>
        private void RotateOrTraverse(string commands, CircularList lst)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        Move();
                        break;
                    case 'L':
                        _Direction = (Directions)lst.GetNextNode((int)_Direction).Data;
                        break;
                    case 'R':
                        _Direction = (Directions)lst.GetNextNode((int)_Direction).Data;
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {command}");
                        break;
                }
            }
        }
    }
}

