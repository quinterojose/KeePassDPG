using KeePass.Plugins;
using System.Drawing;

namespace KeePassDPG
{
    /// <summary>
    /// KeePass plugin implementation object.
    /// </summary>
    public class KeePassDPGExt : Plugin
    {
        private IPluginHost _host = null;

        private PasswordGenerator _passwordGenerator = null;

        /// <summary>
        /// Initialize the plugin.
        /// </summary>
        /// <param name="host">The KeePass plugin host.</param>
        /// <returns>True if initialization is successful, false otherwise.</returns>
        public override bool Initialize(IPluginHost host)
        {
            if (host == null)
                return false;

            _host = host;

            // Create the password generator object and add it to the generator pool in KeePass.
            _passwordGenerator = new PasswordGenerator();
            _host.PwGeneratorPool.Add(_passwordGenerator);

            return true;
        }

        /// <summary>
        /// Clean up when plugin is terminated.
        /// </summary>
        public override void Terminate()
        {
            if (_host != null)
                _host.PwGeneratorPool.Remove(_passwordGenerator.Uuid);

            _passwordGenerator = null;
        }

        /// <summary>
        /// Icon to be displayed on the KeePass plugin list.
        /// </summary>
        public override Image SmallIcon
        {
            get
            {
                return Properties.Resources.kgpg_gen;
            }
        }

        /// <summary>
        /// Gets the plugin update URL.
        /// </summary>
        public override string UpdateUrl
        {
            get
            {
                return Properties.Resources.UpdateUrl;
            }
        }
    }
}
