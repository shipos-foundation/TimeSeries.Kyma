/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using RaaLabs.TimeSeries.DataTypes;

namespace RaaLabs.TimeSeries.Kyma.SentenceFormats
{
    /// <summary>
    /// Represents the format of Kyma
    /// </summary>
    public class IIXDR : ISentenceFormat
    {

        /// <inheritdoc/>
        public string Identitifer => "IIXDR";

        /// <inheritdoc/>
        public TagWithData Parse(string[] values)
        {

            var value = float.Parse(values[1]);
            var kymaId = values[3];
            var tag = "";

            switch (kymaId)
            {
                case "001":
                    tag = "ShaftRevolutions";
                    break;
                case "002":
                    tag = "ShaftTorque";
                    break;

                case "003":
                    tag = "ShaftPower";
                    break;

                case "004":
                    tag = "PropellerThrust";
                    break;
            }

            return new TagWithData(tag, value);

        }

    }
}