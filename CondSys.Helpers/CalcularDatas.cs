using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondSys.Helpers
{
    public static class CalcularDatas
    {
        public static DateTime CalculaDataVencimento(DateTime DataEmissao, int QtdDiasVencimento)
        {
            DateTime DataVencimento = DataEmissao.AddDays(QtdDiasVencimento);
            return DataVencimento;
        }

        public static DateTime CalculaDataVencimentoDiasUteis(DateTime DataEmissao, int QtdDiasVencimento)
        {
            DateTime DataVencimento = DataEmissao.AddDays(QtdDiasVencimento);
            switch(DataVencimento.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    DataVencimento.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    DataVencimento.AddDays(1);
                    break;
            }
            return DataVencimento;
        }

        public static int CalculaDataNascimento(DateTime DataNasciemento)
        {
            int idade = 0;
            if (DataNasciemento != DateTime.MinValue || DataNasciemento != DateTime.MaxValue)
            {
                DateTime dataAtual = DateTime.Now;
                int anos = dataAtual.Year - DataNasciemento.Year;
                if (dataAtual.Month < DataNasciemento.Month || (dataAtual.Month == DataNasciemento.Month && dataAtual.Day < DataNasciemento.Day))
                    anos--;
                return anos;
            }
            return idade;
        }
    }
}
