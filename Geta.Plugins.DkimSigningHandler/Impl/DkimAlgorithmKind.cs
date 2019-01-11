﻿namespace NeosIT.Exchange.GenericExchangeTransportAgent.Plugins.DkimSigningHandler.Impl
{
    /// <summary>
    /// Enumeration of the kinds of signature and hashing algorithms 
    /// that can be used with DKIM.
    /// </summary>
    public enum DkimAlgorithmKind
    {
        /// <summary>
        /// The RSA SHA-1 hashing algorithm should be used.
        /// </summary>
        RsaSha1,

        /// <summary>
        /// The RSA SHA-2 (256) hashing algorithm should be used.
        /// </summary>
        RsaSha256
    }
}
