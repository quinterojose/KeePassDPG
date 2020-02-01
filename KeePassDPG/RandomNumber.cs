using KeePassLib.Cryptography;

namespace KeePassDPG
{
    /// <summary>
    /// Generates cryptographically strong random numbers
    /// </summary>
    public class RandomNumber
    {
        /// <summary>
        /// The random stream generator.
        /// </summary>
        private CryptoRandomStream _stream = null;

        /// <summary>
        /// Initializes a new RandomNumber
        /// </summary>
        /// <param name="stream">The random stream.</param>
        public RandomNumber(CryptoRandomStream stream) => _stream = stream;

        /// <summary>
        /// Returns the next random number.
        /// </summary>
        /// <param name="max">The maximum number.</param>
        /// <returns>A random number.</returns>
        public int Next(int max) => Next(0, max);

        /// <summary>
        /// Returns the next random number.
        /// </summary>
        /// <param name="min">The minimum number.</param>
        /// <param name="max">The maximum number.</param>
        /// <returns>A random number.</returns>
        public int Next(int min, int max)
        {
            int mod = max - min;
            return (int)((uint)_stream.GetRandomUInt64() % mod) + min;
        }
    }
}
