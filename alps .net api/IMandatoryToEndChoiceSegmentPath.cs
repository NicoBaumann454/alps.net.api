namespace alps.net_api
{
    /// <summary>
    /// Interface to the mandatory to end choice segment path class
    /// </summary>

    public interface IMandatoryToEndChoiceSegmentPath : IChoiceSegmentPath
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        void setBelongsToAction(IAction action);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IAction getBelongsToAction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegmentPath"></param>
        void setChoiceSegmentPath(IChoiceSegmentPath choiceSegmentPath);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IChoiceSegmentPath getChoiceSegmentPath();

    }

}
