/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Machine.Specifications;

namespace RaaLabs.TimeSeries.Kyma.for_SentenceParser.when_getting_identifier
{
    public class and_sentence_is_shorter_than_expected_for_identification : given.no_formats
    {
        static Exception result;
        Because of = () => result = Catch.Exception(() => sentence_parser.GetIdentifierFor("$GPR"));

        It should_throw_invalid_sentence = () => result.ShouldBeOfExactType<InvalidSentence>();
    }
}