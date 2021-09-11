namespace alps.net_api
{
    /// <summary>
    /// Interface to the optional to end choice segment path class
    /// </summary>
    public interface IOptionalToEndChoiceSegmentPath : IChoiceSegmentPath
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
