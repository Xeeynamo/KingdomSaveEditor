using KHSave.Attributes;

namespace KHSave.Trssv.Types
{
    public enum LocationType : byte
    {
        [Info("Main Road")] Location00,
        [Info("Castle Town (variant #1)")] Location01,
        [Info("Castle Town (variant #2)")] Location02,
        [Info("Castle Town (variant #3)")] Location03,
        [Info("The World Within (variant #1)")] Location04,
        [Info("The World Within (variant #2)")] Location05,
        [Info("The World Within (variant #3)")] Location06,
        [Info("The World Within (variant #4)")] Location07,
        [Info("The World Within (variant #5)")] Location08,
        [Info("The World Within (variant #6)")] Location09,
        [Info("The World Within (variant #7)")] Location0a,
        [Info("The World Within (variant #8)")] Location0b,
        [Info("The World Within (variant #9)")] Location0c,
        [Info("The World Within (variant #10)")] Location0d,
        [Info("The World Within (variant #11)")] Location0e,
        [Info("The World Within (variant #12)")] Location0f,
        [Info("The World Within (variant #13)")] Location10,
        [Info("The World Within (variant #14)")] Location11,
        [Info("The World Within (variant #15)")] Location12,
        [Info("Uncertain Path")] Location13,
        [Info("Rocky Path (variant #1)")] Location14,
        [Info("Rocky Path (variant #2)")] Location15,
        [Info("Path's End")] Location16,
        [Info("Depths of Darkness (variant #1)")] Location17,
        [Info("Depths of Darkness (variant #2)")] Location18,
        [Info("Destiny Islands")] Location19,
    }
}
