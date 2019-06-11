using System;
using System.Collections.Generic;
using System.Text;

namespace RpgStatSystem
{
    public interface IBattleLog
    {
        void Write(string s);
        void WriteLine(string s);
    }
}
