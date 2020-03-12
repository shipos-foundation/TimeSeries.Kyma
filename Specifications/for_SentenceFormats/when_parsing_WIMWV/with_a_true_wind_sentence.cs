/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using Machine.Specifications;
using RaaLabs.TimeSeries.Kyma.SentenceFormats;
using System.Linq;

namespace RaaLabs.TimeSeries.Kyma.for_SentenceFormats.when_parsing_WIMWV
{
    public class with_a_true_wind_sentence : given.a_WIMWV_parser
    {
        static string[] values = new[] { "325", "T", "018.3", "M" };
        static ParsedResult[] results;
        Because of = () => results = parser.Parse(values).ToArray();
        It should_return_two_result = () => results.Length.ShouldEqual(2);
        It should_return_a_relative_wind_angle = () => results.ShouldEmit("WindAngleTrue", 325f);
        It should_return_a_relative_wind_speed = () => results.ShouldEmit("WindSpeedTrue", 18.3f);
    }
}