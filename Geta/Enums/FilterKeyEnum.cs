namespace NeosIT.Exchange.GenericExchangeTransportAgent.Enums
{
    /// <summary>
    /// Defines on what mail item attribute 
    /// the filter should be applied
    /// </summary>
    public enum FilterKeyEnum
    {
        /// <summary>
        /// Apply filter on FromAddress
        /// </summary>
        From = 0,

        /// <summary>
        /// Apply filter on ToAddress / RecipientAddress
        /// </summary>
        To = 1,

        /// <summary>
        /// Apply filter on Subject
        /// </summary>
        Subject = 2,

        /// <summary>
        /// Apply filter on status code
        /// of parent handler
        /// </summary>
        LastExitCode = 3,
    }
}
