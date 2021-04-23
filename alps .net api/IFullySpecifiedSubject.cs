namespace alps.net_api
{
    /// <summary>
    /// Interface to the FullySpecifiedSubject class
    /// </summary>

    public interface IFullySpecifiedSubject : ISubject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectBaseBehavior"></param>
        void setContainsBaseBehavior(ISubjectBehavior subjectBaseBehavior);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubjectBehavior getSubjectBaseBehavior();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectBehavior"></param>
        void setContainsBehavior(ISubjectBehavior subjectBehavior);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubjectBehavior getSubjectBehavior();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectDataDefinition"></param>
        void setDataDefintion(ISubjectDataDefinition subjectDataDefinition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubjectDataDefinition getSubjectDataDefinition();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputPoolConstraint"></param>
        void setInputPoolConstraint(IInputPoolConstraint inputPoolConstraint);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IInputPoolConstraint getInputPoolConstraint();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new FullySpecifiedSubject factoryMethod();
    }

}
