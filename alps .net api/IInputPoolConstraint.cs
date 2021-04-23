namespace alps.net_api
{
    /// <summary>
    /// Interface to the InputPoolConstraint class
    /// </summary>

    public interface IInputPoolConstraint : IInteractionDescriptionComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        void setHandlingStrategy(IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IInputPoolConstraintHandlingStrategy getInputPoolConstraintHandlingStrategy();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nonNegativInteger"></param>
        void setLimit(int nonNegativInteger);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int getLimit();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new InputPoolConstraint factoryMethod();
    }

}
