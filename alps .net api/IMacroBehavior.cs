using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the macro bahvior class
    /// </summary>

    public interface IMacroBehavior : ISubjectBehavior
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateReferences"></param>
        void setContainsStateReference(List<StateReference> stateReferences);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<StateReference> getStateReferences();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MacroBehavior factoryMethod();
    }

}
