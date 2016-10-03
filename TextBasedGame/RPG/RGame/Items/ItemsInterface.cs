using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.RGame.Items
{
    public interface ItemsInterface
    {
        ItemType itemType { get; }
    }
    public enum ItemType { Food, Tool, Weapon}
}