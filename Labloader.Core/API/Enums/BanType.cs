using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labloader.Core.API.Enums
{
    public enum BanType
    {
        /// <summary>
        /// Ban by player's IP, Player object is null
        /// </summary>
        IP,
        /// <summary>
        /// Ban by player's UserID, Player object passed
        /// </summary>
        UserId
    }
}
