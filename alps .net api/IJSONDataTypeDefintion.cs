namespace alps.net_api
{
    /// <summary>
    /// Interface to the JSONDataTypeDefinition class
    /// </summary>

    public interface IJSONDataTypeDefintion : ICustomOrExternalDataTypeDefintion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new JSONDataTypeDefinition factoryMethod();
    }

}
