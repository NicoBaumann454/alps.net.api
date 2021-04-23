namespace alps.net_api
{
    /// <summary>
    /// Interface to the data mapping function class
    /// </summary>
    public interface IDataMappingFunction : IDataDescribingComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataMappingString"></param>
        void setDataMappingString(string dataMappingString);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getDataMappingString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FeelExpression"></param>
        void setFeelExpressionAsDataMapping(string FeelExpression);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getFeelExpressionAsDataMapping();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toolSpecificDefinition"></param>
        void setToolSpecificDefintion(string toolSpecificDefinition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getToolSpecificDefinition();
    }

}
