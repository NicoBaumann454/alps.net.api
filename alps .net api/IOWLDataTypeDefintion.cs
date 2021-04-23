namespace alps.net_api
{
    /// <summary>
    /// Interface to the OWL data type definition class
    /// </summary>
    public interface IOWLDataTypeDefintion : ICustomOrExternalDataTypeDefintion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new OWLDataTypeDefintion factoryMethod();
    }
}
