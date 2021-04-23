namespace alps.net_api
{
    /// <summary>
    /// Interface to the sender type constraint class
    /// </summary>
    public interface ISenderTypeConstraint : IInputPoolConstraint
    {
        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        void setReferencesSubject(ISubject subject);

        /// <summary>
        /// Method that returns the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        ISubject getReferenceSubject();
    }

}
