namespace alps.net_api
{
    interface IALPSSBDComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectBehavior"></param>
        void setBelongsToSubjectBehavior(ISubjectBehavior subjectBehavior); //exactly one

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubjectBehavior getSubjectBehavior();
    }
}
