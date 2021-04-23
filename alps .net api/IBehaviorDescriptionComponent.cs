namespace alps.net_api
{
    /// <summary>
    /// Interface to the BehaviorDescriptionComponent class
    /// </summary>

    public interface IBehaviorDescriptionComponent : IPASSProcessModellElement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectBehavior"></param>
        void setBelongsToSubjectBehavior(ISubjectBehavior subjectBehavior); //exactly one

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubjectBehavior getSubjectBehavior();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new BehaviorDescriptionComponent factoryMethod();
    }

}
