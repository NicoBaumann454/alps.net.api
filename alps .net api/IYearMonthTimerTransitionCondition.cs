namespace alps.net_api
{
    /// <summary>
    /// Interface to the year month timer transition class
    /// </summary>
    public interface IYearMonthTimerTransitionCondition : ITimerTransitionCondition
    {
        /// <summary>
        /// Method that sets the year month Duration attribute
        /// </summary>
        /// <param name="yearMonthDuration"></param>
        void setYearMonthDuration(string yearMonthDuration);

        /// <summary>
        /// Method that returns the year month Duration attribute
        /// </summary>
        /// <returns>The year month Duration attribute</returns>
        string getYearMonthDuration();
    }

}
