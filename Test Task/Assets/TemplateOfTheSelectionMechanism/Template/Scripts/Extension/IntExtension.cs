namespace SelectionTemplate
{
    public static class IntExtension
    {
        public static int AddCyclic(this int value, int added, int max, int min = 0)
        {
            int range = max - min;
            int newValue = ((value + added - min) % range + range) % range + min;
            return newValue;
        }
    }
}
