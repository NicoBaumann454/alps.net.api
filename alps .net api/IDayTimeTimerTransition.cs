namespace alps.net_api
{
    /// <summary>
    /// Interface to the DayTimeTimerTransition class
    /// </summary>

    public interface IDayTimeTimerTransition : ITimerTransition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new DayTimeTimerTransition factoryMethod();
    }
}
