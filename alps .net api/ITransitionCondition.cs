namespace alps.net_api
{
    /// <summary>
    /// Interface of the transition condition class
    /// </summary>
    public interface ITransitionCondition : IBehaviorDescriptionComponent
    {
        /// <summary>
        /// Method that sets the tool specific definition attribute of the instance
        /// </summary>
        /// <param name="toolSpecificDefintion"></param>
        void setToolSpecificDefiniton(string toolSpecificDefintion);

        /// <summary>
        /// Method that returns the tool specific definition attribute of the instance
        /// </summary>
        /// <returns>The tool specific definition attribute of the instance</returns>
        string getToolSpecificDefintion();
    }

}
