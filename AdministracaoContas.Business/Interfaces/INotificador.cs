using AdministracaoContas.Business.Notificacoes;
using System.Collections.Generic;

namespace AdministracaoContas.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
