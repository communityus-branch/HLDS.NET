using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLDS.NET
{
    static class HPAK
    {
    //    public static bool GetDataPointer(string name; const Res: TResource; Buffer: PPointer; Size: PUInt32): Boolean;
    //    public static bool FindResource(const DH: THPAKDirectoryHeader; Hash: Pointer; Res: PResource): Boolean;

    //    public static void AddLump(ToCache: Boolean; Name: PLChar; Res: PResource; DataPtr: Pointer; FilePtr: PFile);
    //    public static void CreatePak(Name: PLChar; Res: PResource; DataPtr: Pointer; FilePtr: PFile);

        public static void FlushHostQueue() { }

        public static void CheckSize(string name) { }
    //    public static bool ResourceForHash(Name: PLChar; Hash: PMD5Hash; Res: PResource): Boolean;

        public static void Init() { }
        public static void CheckIntegrity(string name) { }
    }
}
