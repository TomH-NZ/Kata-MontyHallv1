namespace MontyHallv1.MoqTestFolder
{
    public class MoqTestPagev1 : IMoqTestPagev1
    {
        public int PlusOneAddition(int first)
        {
            return first + 1;
        }

        public bool Greater(int value)
        {
            return value > 5;
        }
    }
}