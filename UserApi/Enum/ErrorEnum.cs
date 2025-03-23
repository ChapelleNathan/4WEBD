using System.ComponentModel;

namespace UserApi.Enum;

public enum ErrorEnum
{
    [Description("Vous n'avez pas les droits nécessaire")]
    Sup401Authorization,
    [Description("Erreur inconnu")]
    Sup500UnknownError,
    [Description("Aucune description pour cette erreur")]
    Sup500NoErrorDescription,
    [Description("Vous n'êtes pas authorisée")]
    Sup401NotConnected,
}