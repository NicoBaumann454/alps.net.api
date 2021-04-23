using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the choice segment class
    /// </summary>
    public interface IChoiceSegment : IState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceSegmentPaths"></param>
        void setContainsChoiceSegmentPath(Dictionary<string, IChoiceSegmentPath> choiceSegmentPaths);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<string, IChoiceSegmentPath> getChoiceSegmentPath();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new ChoiceSegment factoryMethod();
    }
}
