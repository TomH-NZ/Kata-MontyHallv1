using MontyHallv1.Enums;

namespace MontyHallv1.MoqTestFolder
{
    public interface IMoqTestPagev1
    {
        public string playerName { get; set; }
        public PrizeDoors playerDoor { get; set; }
        
        int PlusOneAddition(int first);
        bool Greater(int value);
        string TestReturn();
    }
}