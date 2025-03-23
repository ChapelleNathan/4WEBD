using System.ComponentModel;

namespace AuthApi.Enum;

public enum ErrorEnum
{
    //Global
    [Description("Vous n'avez pas les droits nécessaire")]
    Sup401Authorization,
    [Description("Erreur inconnu")]
    Sup500UnknownError,
    [Description("Aucune description pour cette erreur")]
    Sup500NoErrorDescription,
    [Description("Vous n'êtes pas authorisée")]
    Sup401NotConnected,
    
    [Description("Le mot de passe ou l'email est incorrecte")]
    Sup401WrongCredential,
}