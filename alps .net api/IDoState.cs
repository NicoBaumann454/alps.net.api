namespace alps.net_api
{
    /// <summary>
    /// Interface to the DoState class
    /// </summary>

    public interface IDoState : IStandartPASSState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataMappingIncomingToLocal"></param>
        void setDataMappingFunctionIncomingToLocal(IDataMappingIncomingToLocal dataMappingIncomingToLocal);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataMappingIncomingToLocal getDataMappingIncomingToLocal();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataMappingLocalToOutgoing"></param>
        void setDataMappingFunctionLocalToOutgoing(IDataMappingLocalToOutgoing dataMappingLocalToOutgoing);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDataMappingLocalToOutgoing getDataMappingLocalToOutgoing();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doFunction"></param>
        void setFunctionSpecification(IDoFunction doFunction);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IDoFunction getDoFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new DoState factoryMethod();
    }

}
