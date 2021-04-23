namespace alps.net_api
{
    /// <summary>
    /// Interface to the multi subject class
    /// </summary>
    public interface IMultiSubject : ISubject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceRestriction"></param>
        new void setMaximumSubjectInstanceRestriction(int instanceRestriction);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int getMaximumInstanceRestriction();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MultiSubject factoryMethod();
    }

}
