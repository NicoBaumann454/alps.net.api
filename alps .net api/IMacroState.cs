namespace alps.net_api
{
    /// <summary>
    /// Interface to the macro state class
    /// </summary>

    public interface IMacroState : IState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="macroBehavior"></param>
        void setReferencesMacroBehavior(IMacroBehavior macroBehavior);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMacroBehavior getReferenceMacroBehavior();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MacroState factoryMethod();
    }
}
