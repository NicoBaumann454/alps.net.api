namespace alps.net_api
{
    /// <summary>
    /// Interface to the BuisnessDayTimerTransition class
    /// </summary>

    public interface IBuisnessDayTimerTransition : ITimerTransition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new BuisnessDayTimerTransition factoryMethod();
    }

}
