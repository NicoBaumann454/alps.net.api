namespace alps.net_api
{
    /// <summary>
    /// Interface to the data type definition class
    /// </summary>
    public interface IDataTypeDefintion : IDataDescribingComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObjectDefiniton"></param>
        void setContainsDataObjectDefintion(IDataObjectDefiniton dataObjectDefiniton);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataObjectDefiniton getDataObjectDefiniton();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new DataTypeDefinition factoryMethod();
    }
}
