using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.Communication.Comm.Communication.Protocols.BinarySerialization
{
    /// <summary>
    /// This class is used to create Binary Serialization Protocol objects.
    /// </summary>
    public class BinarySerializationProtocolFactory : IScsWireProtocolFactory
    {
        /// <summary>
        /// Creates a new Wire Protocol object.
        /// </summary>
        /// <returns>Newly created wire protocol object</returns>
        public IScsWireProtocol CreateWireProtocol()
        {
            return new BinarySerializationProtocol();
        }
    }
}
