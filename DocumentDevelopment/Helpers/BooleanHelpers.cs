namespace DocumentDevelopment.Helpers
{
    public static class BooleanHelpers
    {
        public static string ToBooleanString(this bool boolean, string positive = "True", string negative = "False")
        {
            return boolean ? positive : negative;
        }
    }
}
