using KHSave.LibRecom.Types;
using KHSave.SaveEditor.KhRecom.Models;

namespace KHSave.SaveEditor.KhRecom.Interfaces
{
    public interface ICardCountService
    {
        byte GetCardCount(Card card, CardIndex index, bool isSpecial);

        void SetCardCount(Card card, CardIndex index, bool isSpecial, byte count);
    }
}
