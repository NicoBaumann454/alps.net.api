namespace alps.net_api
{
    /// <summary>
    /// Interface to the CalenderBasedReminderTransition Class
    /// </summary>

    public interface ICalenderBasedReminderTransition : IReminderTransition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new CalenderBasedReminderTransition factoryMethod();
    }
}
