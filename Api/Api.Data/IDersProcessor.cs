using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public interface IDersProcessor
    {
        int EkleDers(Ders ders);
        void GuncelleDers(Ders ders);
        void SilDers(int id);
        void DersSinifEkle(int dersId, Ders temp);
    }
}
