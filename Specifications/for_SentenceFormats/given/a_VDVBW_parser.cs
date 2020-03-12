/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using RaaLabs.TimeSeries.Kyma.SentenceFormats;
using Machine.Specifications;

namespace RaaLabs.TimeSeries.Kyma.for_SentenceFormats.given
{
    public class a_VDVBW_parser
    {
        protected static VDVBW parser;
        Establish context = () => parser = new VDVBW();
    }
}