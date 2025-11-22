
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TechnitiumLibrary.IO;

namespace TechnitiumLibrary.Net
{
  public class ExtendedNetworkAddress : NetworkAddress
  {
    readonly string _domainName;

    #region constructor
    public ExtendedNetworkAddress(IPAddress address, byte prefixLength, string domainName)
        : base(address, prefixLength)
    {
      _domainName = domainName;
    }
    public ExtendedNetworkAddress(NetworkAddress networkAddress, string domainName)
        : base(networkAddress.Address, networkAddress.PrefixLength)
    {
      _domainName = domainName;
    }
    #endregion

    public override bool Equals(object obj)
    {
      if (obj is ExtendedNetworkAddress other)
      {
        return base.Equals(other) && string.Equals(DomainName, other.DomainName, StringComparison.OrdinalIgnoreCase);
      }
      return false;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(base.GetHashCode(), DomainName?.ToLowerInvariant());
    }

    #region properties

    public string DomainName
    { 
      get { return _domainName; } 
    }

    #endregion
  }
}
