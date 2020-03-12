/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace RaaLabs.TimeSeries.Kyma
{
    /// <summary>
    /// The protocol to use for connections
    /// </summary>
    public enum Protocol
    {
        /// <summary>
        /// Straight Kyma TCP
        /// </summary>
        Tcp = 1,

        /// <summary>
        /// Straight Kyma UDP 
        /// </summary>
        Udp
    }
}