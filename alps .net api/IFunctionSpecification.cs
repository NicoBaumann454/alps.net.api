namespace alps.net_api
{
    /// <summary>
    /// Interface to the FunctionSpecification class
    /// </summary>

    public interface IFunctionSpecification : IBehaviorDescriptionComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolSpecificDefinition"></param>
        void setToolSpecificDefinition(string toolSpecificDefinition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getToolSpecificDefinition();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new FunctionSpecification factoryMethod();
    }

}
