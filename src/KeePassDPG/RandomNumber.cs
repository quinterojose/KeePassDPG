﻿using KeePassLib.Cryptography;

namespace KeePassDPG
{
    /// <summary>
    /// Generates cryptographically strong random numbers
    /// </summary>
    public class RandomNumber
    {
        private readonly CryptoRandomStream _stream;

        /// <summary>
        /// Initializes a new RandomNumber
        /// </summary>
        /// <param name="stream">The random stream.</param>
        public RandomNumber(CryptoRandomStream stream)
        {
            _stream = stream;
        }

        /// <summary>
        /// Returns the next random number.
        /// </summary>
        /// <param name="max">The maximum number.</param>
        /// <returns>A random number.</returns>
        public int Next(int max)
        {
            return Next(0, max);
        }

        /// <summary>
        /// Returns the next random number.
        /// </summary>
        /// <param name="min">The minimum number.</param>
        /// <param name="max">The maximum number.</param>
        /// <returns>A random number.</returns>
        public int Next(int min, int max)
        {
            var mod = max - min;
            return (int)((uint)_stream.GetRandomUInt64() % mod) + min;
        }
    }
}
