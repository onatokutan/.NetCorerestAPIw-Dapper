using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data
{
    public interface IOgrenciProvider
    {
        IEnumerable<Ogrenci> Get();
    }
}
