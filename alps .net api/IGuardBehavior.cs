namespace alps.net_api
{
    /// <summary>
    /// Interface to the GuardBehavior class
    /// </summary>

    public interface IGuardBehavior : ISubjectBehavior
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectBehavior"></param>
        void setGuardsBehavior(ISubjectBehavior subjectBehavior);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubjectBehavior getGuardsBehavior();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void setGuardsState(IState state);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IState getGuardsState();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new GuardBehavior factoryMethod();
    }

}
