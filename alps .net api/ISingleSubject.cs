namespace alps.net_api
{
    /// <summary>
    /// Interface to the single subject class
    /// </summary>
    public interface ISingleSubject : ISubject
    {
        /// <summary>
        /// Method that returns the instance restriction attribute of the instance
        /// </summary>
        /// <returns>The instance restriction attribute of the instance</returns>
        int getMaximumInstanceRestriction();
    }

}
