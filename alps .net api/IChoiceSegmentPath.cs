namespace alps.net_api
{
    /// <summary>
    /// Interface to the choice segment path class
    /// </summary>
    public interface IChoiceSegmentPath : IState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void setEndState(IState state);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IState getEndState();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void setInitialState(IState state);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IState getInitialState();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endChoice"></param>
        void setIsOptionalToEndChoiceSegmentPath(bool endChoice);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool getIsOptionalToEndChoiceSegmentPath();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endChoice"></param>
        void setIsOptionalToStartChoiceSegmentPath(bool endChoice);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool getIsOptionalToStartChoiceSegmentPath();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new ChoiceSegmentPath factoryMethod();
    }

}
