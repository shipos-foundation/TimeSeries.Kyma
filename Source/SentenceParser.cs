/*---------------------------------------------------------------------------------------------
 *  Copyright (c) RaaLabs. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dolittle.Collections;
using Dolittle.Types;

namespace RaaLabs.TimeSeries.Kyma
{
    /// <summary>
    /// Represents an implementation of <see cref="ISentenceParser"/>
    /// </summary>
    public class SentenceParser : ISentenceParser
    {
        readonly IDictionary<string, ISentenceFormat> _formats;

        /// <summary>
        /// Initializes a new instance <see cref="SentenceParser"/>
        /// </summary>
        /// <param name="formats">All available <see cref="ISentenceFormat">formats</see></param>
        public SentenceParser(IInstancesOf<ISentenceFormat> formats)
        {
            _formats = formats.ToDictionary(_ => $"{_.Identitifer}", _ => _);
        }

        /// <inheritdoc/>
        public bool CanParse(string sentence)
        {
            if (!IsValidSentence(sentence)) return false;
            sentence = sentence.Substring(1);
            return _formats.ContainsKey(sentence.Substring(0, 5));
        }

        /// <inheritdoc/>
        public TagWithData Parse(string sentence)
        {            

            ThrowIfSentenceIsInvalid(sentence);
            var originalSentence = sentence;
            var identifier = sentence.Substring(1, 5);
            sentence = sentence.Trim();

            if( sentence.Contains('*')) 
            {
                var checksum = Byte.Parse(sentence.Substring(sentence.Length-2), NumberStyles.HexNumber);
                sentence = sentence.Substring(1,sentence.Length-4);

                byte calculatedChecksum = 0;
                for( var i=0; i<sentence.Length; i++) calculatedChecksum ^= (byte)sentence[i];
                ThrowIfSentenceChecksumIsInvalid(sentence, checksum, calculatedChecksum);
            } else sentence = sentence.Substring(1);

            var values = sentence.Substring(6).Split(',');
            var result = _formats[identifier].Parse(values);
            return result;
        }

        bool IsValidSentence(string sentence)
        {
            if (!sentence.StartsWith('$')) return false;
            if (sentence.Length < 6) return false;
            return true;
        }

        void ThrowIfSentenceIsInvalid(string sentence)
        {
            if (!IsValidSentence(sentence)) throw new InvalidSentence(sentence);
        }

        void ThrowIfSentenceChecksumIsInvalid(string sentence, byte actualChecksum, byte expectedChecksum)
        {
            if( expectedChecksum != actualChecksum ) throw new InvalidSentenceChecksum(actualChecksum, expectedChecksum, sentence);
        }
    }
}