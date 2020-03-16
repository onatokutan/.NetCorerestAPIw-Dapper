using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public interface ISinifProcessor
    {
        void EkleSinif(Sinif sinif);
        void GuncelleSinif(Sinif sinif);
        void SilSinif(int id);
    }
}
