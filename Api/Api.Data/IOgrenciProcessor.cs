using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public interface IOgrenciProcessor
    {
        int EkleOgrenci(Ogrenci ogrenci);
        void GuncelleOgrenci(Ogrenci ogrenci);
        void SilOgrenci(int id);
        void OgrenciDersEkle(int ogrenciId, Ogrenci temp);
    }
}
