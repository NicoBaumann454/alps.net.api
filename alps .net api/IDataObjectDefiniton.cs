namespace alps.net_api
{
    /// <summary>
    /// Interace to the data object definition class
    /// </summary>
    public interface IDataObjectDefiniton : IDataDescribingComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataTypeDefintion"></param>
        void setDataTypeDefinition(IDataTypeDefintion dataTypeDefintion);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataTypeDefintion getDataTypeDefintion();
    }
}
