namespace alps.net_api
{
    /// <summary>
    /// Interface to the DayTimerTransitionCondition class
    /// </summary>
    public interface IDayTimerTransitionCondition : ITimerTransitionCondition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimeValue"></param>
        void setDateTimeValue(string dateTimeValue);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getDateTimeValue();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new DayTimerTransitionCondition factoryMethod();
    }

}
