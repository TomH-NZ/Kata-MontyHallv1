using MontyHallv1.Enums;

namespace MontyHallv1.MoqTestFolder
{
    public class MoqTestPagev1 : IMoqTestPagev1
    {
        public string playerName { get; set; }
        public PrizeDoors playerDoor { get; set; }

        public int PlusOneAddition(int first)
        {
            return first + 1;
        }

        public bool Greater(int value)
        {
            return value > 5;
        }

        public string TestReturn()
        {
            throw new System.NotImplementedException();
        }

        public string HelloWorld()
        {
            return "Hello world?";
        }
    }
}