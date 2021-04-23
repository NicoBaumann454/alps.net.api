namespace alps.net_api
{
    /// <summary>
    /// Interface to the InitialStateOfChoiceSegmentPath class
    /// </summary>

    public interface IInitialstateOfChoiceSegmentPath : IState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegmentPath"></param>
        void setBelongsToChoiceSegmentPath(IChoiceSegmentPath choiceSegmentPath);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IChoiceSegmentPath getChoiceSegmentPath();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new InitialStateOfChoiceSegmentPath factoryMethod();
    }

}
